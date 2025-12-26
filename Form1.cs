using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;

namespace HotelDBClientApp
{
    public partial class Form1 : Form
    {
        private readonly string[] allowedTables = { "Hotel_Building", "Room", "Client", "Booking", "Organization", "Contract", "Additional_Service", "Client_Service", "Complaint", "Room_Statistics" };
        private string currentTable;
        private DatabaseManager dbManager;
        private readonly Stopwatch stopwatch;

        public Form1()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            string connectionString = "Server=localhost;Database=HotelDB;Uid=root;Pwd=qazwsx111;";
            dbManager = new DatabaseManager(connectionString);

            using (var loginForm = new LoginForm(connectionString))
            {
                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }
            }

            tableComboBox.Items.AddRange(allowedTables);
            tableComboBox.SelectedIndex = 0;

            submitComplaintButton.Click += submitComplaintButton_Click;
            showStatisticsButton.Click += showStatisticsButton_Click;
            loadButton.Click += loadButton_Click;
            sortButton.Click += sortButton_Click;
            searchButton.Click += searchButton_Click;
            countButton.Click += countButton_Click;
            addButton.Click += addButton_Click;
            editButton.Click += editButton_Click;
            deleteButton.Click += deleteButton_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(tableComboBox, "Оберіть таблицю Client, щоб подати скаргу");
        }

        // Логування помилок у файл
        private void LogError(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("error_log.txt", true))
                {
                    writer.WriteLine($"[{DateTime.Now}] {message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка запису в лог: {ex.Message}");
            }
        }

        // Завантаження таблиці з вимірюванням часу
        private void LoadTable(string tableName)
        {
            if (!allowedTables.Contains(tableName))
            {
                MessageBox.Show("Обрана таблиця не підтримується!");
                return;
            }
            string query = $"SELECT * FROM {tableName};";
            try
            {
                stopwatch.Restart();
                var result = dbManager.ExecuteQuery(query);
                stopwatch.Stop();
                if (result.Rows.Count == 0)
                {
                    MessageBox.Show($"Таблиця {tableName} порожня!");
                }
                dataGridView1.DataSource = result;
                currentTable = tableName;
                UpdateFieldComboBox();
                MessageBox.Show($"Час завантаження таблиці: {stopwatch.ElapsedMilliseconds} мс");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження таблиці: {ex.Message}");
                LogError($"Помилка завантаження таблиці {tableName}: {ex.Message}");
            }
        }

        private void UpdateFieldComboBox()
        {
            fieldComboBox.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                fieldComboBox.Items.Add(column.HeaderText);
            }
            if (fieldComboBox.Items.Count > 0)
                fieldComboBox.SelectedIndex = 0;
        }

        private void SortTable(string table, string sortColumn, bool ascending)
        {
            if (!allowedTables.Contains(table)) return;
            string order = ascending ? "ASC" : "DESC";
            string query = $"SELECT * FROM {table} ORDER BY {sortColumn} {order};";
            try
            {
                stopwatch.Restart();
                dataGridView1.DataSource = dbManager.ExecuteQuery(query);
                stopwatch.Stop();
                MessageBox.Show($"Час сортування: {stopwatch.ElapsedMilliseconds} мс");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка сортування: {ex.Message}");
                LogError($"Помилка сортування таблиці {table}: {ex.Message}");
            }
        }

        private void SearchByColumn(string table, string columnName, string searchTerm)
        {
            if (!allowedTables.Contains(table)) return;
            string query = $"SELECT * FROM {table} WHERE {columnName} LIKE @searchTerm;";
            try
            {
                using (var connection = new MySqlConnection(dbManager.ConnectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                        using (var adapter = new MySqlDataAdapter(command))
                        {
                            DataTable result = new DataTable();
                            adapter.Fill(result);
                            dataGridView1.DataSource = result;
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка пошуку: {ex.Message}");
                LogError($"Помилка пошуку в таблиці {table}: {ex.Message}");
            }
        }

        private void CountByColumn(string table, string columnName)
        {
            if (!allowedTables.Contains(table)) return;
            string query;
            if (table == "Complaint" && columnName == "ID_client")
            {
                query = $"SELECT c.ID_client, cl.fullname, COUNT(*) AS ComplaintCount FROM Complaint c LEFT JOIN Client cl ON c.ID_client = cl.ID_client GROUP BY c.ID_client, cl.fullname;";
            }
            else if (table == "Room_Statistics" && columnName == "ID_room")
            {
                query = $"SELECT rs.ID_room, r.room_type, rs.booking_count, rs.popularity_score FROM Room_Statistics rs LEFT JOIN Room r ON rs.ID_room = r.ID_room ORDER BY rs.popularity_score DESC;";
            }
            else if (table == "Booking" && columnName == "ID_room")
            {
                query = $"SELECT b.ID_room, r.room_type, COUNT(*) AS BookingCount FROM Booking b LEFT JOIN Room r ON b.ID_room = r.ID_room GROUP BY b.ID_room, r.room_type;";
            }
            else
            {
                query = $"SELECT {columnName}, COUNT(*) AS Count FROM {table} GROUP BY {columnName};";
            }
            try
            {
                var result = dbManager.ExecuteQuery(query);
                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Немає даних для відображення!");
                }
                dataGridView1.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка підрахунку: {ex.Message}");
                LogError($"Помилка підрахунку в таблиці {table}: {ex.Message}");
            }
        }

        private void DeleteSelectedRecord(string table)
        {
            if (dataGridView1.CurrentCell == null) return;
            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            string idColumn = dataGridView1.Columns[0].HeaderText;
            int idToDelete = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);
            string query = $"DELETE FROM {table} WHERE {idColumn} = @idToDelete;";
            try
            {
                stopwatch.Restart();
                using (var connection = new MySqlConnection(dbManager.ConnectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idToDelete", idToDelete);
                        int rowsAffected = command.ExecuteNonQuery(); // Перевіряємо, скільки рядків видалено
                        if (rowsAffected == 0)
                        {
                            throw new Exception($"Запис з ID {idToDelete} не існує в таблиці {table}!");
                        }
                    }
                    connection.Close();
                }
                stopwatch.Stop();
                MessageBox.Show($"Запис успішно видалено! Час: {stopwatch.ElapsedMilliseconds} мс");
                LoadTable(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка видалення: {ex.Message}");
                LogError($"Помилка видалення запису з таблиці {table}: {ex.Message}");
            }
        }

        private void EditSelectedRecord(string table)
        {
            if (dataGridView1.CurrentCell == null) return;
            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            int selectedColumnIndex = dataGridView1.CurrentCell.ColumnIndex;
            string idColumn = dataGridView1.Columns[0].HeaderText;
            int idToEdit = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);
            string columnName = dataGridView1.Columns[selectedColumnIndex].HeaderText;
            string newValue = editTextBox.Text;
            string query = $"UPDATE {table} SET {columnName} = @newValue WHERE {idColumn} = @idToEdit;";
            try
            {
                stopwatch.Restart();
                using (var connection = new MySqlConnection(dbManager.ConnectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@newValue", newValue);
                        command.Parameters.AddWithValue("@idToEdit", idToEdit);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                stopwatch.Stop();
                MessageBox.Show($"Запис успішно відредаговано! Час: {stopwatch.ElapsedMilliseconds} мс");
                LoadTable(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка редагування: {ex.Message}");
                LogError($"Помилка редагування запису в таблиці {table}: {ex.Message}");
            }
        }

        private void submitComplaintButton_Click(object sender, EventArgs e)
        {
            if (currentTable != "Client")
            {
                MessageBox.Show("Спочатку оберіть клієнта в таблиці Client!");
                return;
            }
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть клієнта для подачі скарги!");
                return;
            }

            int clientId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_client"].Value);

            string verifyClientQuery = "SELECT COUNT(*) FROM Client WHERE ID_client = @clientId;";
            try
            {
                using (var connection = new MySqlConnection(dbManager.ConnectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(verifyClientQuery, connection))
                    {
                        command.Parameters.AddWithValue("@clientId", clientId);
                        int clientCount = Convert.ToInt32(command.ExecuteScalar());
                        if (clientCount == 0)
                        {
                            MessageBox.Show($"Клієнт з ID {clientId} не існує!");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка перевірки клієнта: {ex.Message}");
                LogError($"Помилка перевірки клієнта ID {clientId}: {ex.Message}");
                return;
            }

            using (var complaintForm = new ComplaintForm())
            {
                if (complaintForm.ShowDialog() == DialogResult.OK)
                {
                    string description = complaintForm.ComplaintDescription.Trim();
                    if (string.IsNullOrEmpty(description))
                    {
                        MessageBox.Show("Опис скарги не може бути порожнім!");
                        return;
                    }

                    string checkDuplicateQuery = "SELECT COUNT(*) FROM Complaint WHERE ID_client = @clientId AND complaint_date = NOW();";
                    try
                    {
                        using (var connection = new MySqlConnection(dbManager.ConnectionString))
                        {
                            connection.Open();
                            using (var command = new MySqlCommand(checkDuplicateQuery, connection))
                            {
                                command.Parameters.AddWithValue("@clientId", clientId);
                                int duplicateCount = Convert.ToInt32(command.ExecuteScalar());
                                if (duplicateCount > 0)
                                {
                                    MessageBox.Show("Скарга для цього клієнта з поточною датою вже існує!");
                                    return;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка перевірки дублів: {ex.Message}");
                        LogError($"Помилка перевірки дублів скарги для клієнта ID {clientId}: {ex.Message}");
                        return;
                    }

                    string query = "INSERT INTO Complaint (ID_client, complaint_date, description) VALUES (@clientId, NOW(), @description);";
                    try
                    {
                        stopwatch.Restart();
                        using (var connection = new MySqlConnection(dbManager.ConnectionString))
                        {
                            connection.Open();
                            using (var command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@clientId", clientId);
                                command.Parameters.AddWithValue("@description", description);
                                command.ExecuteNonQuery();
                            }
                            connection.Close();
                        }
                        stopwatch.Stop();
                        MessageBox.Show($"Скарга успішно подана! Час: {stopwatch.ElapsedMilliseconds} мс");
                        if (currentTable == "Complaint")
                        {
                            LoadTable("Complaint");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка подачі скарги: {ex.Message}");
                        LogError($"Помилка подачі скарги для клієнта ID {clientId}: {ex.Message}");
                    }
                }
            }
        }

        private void showStatisticsButton_Click(object sender, EventArgs e)
        {
            if (currentTable == null)
            {
                MessageBox.Show("Спочатку оберіть таблицю!");
                return;
            }

            if (currentTable == "Room_Statistics")
            {
                CountByColumn(currentTable, "ID_room");
            }
            else if (currentTable == "Complaint")
            {
                CountByColumn(currentTable, "ID_client");
            }
            else if (currentTable == "Booking")
            {
                CountByColumn(currentTable, "ID_room");
            }
            else
            {
                MessageBox.Show("Статистика для цієї таблиці не реалізована!");
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (tableComboBox.SelectedItem != null)
            {
                LoadTable(tableComboBox.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Оберіть таблицю!");
            }
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            if (currentTable != null && fieldComboBox.SelectedItem != null)
            {
                SortTable(currentTable, fieldComboBox.SelectedItem.ToString(), !descendingCheckBox.Checked);
            }
            else
            {
                MessageBox.Show("Оберіть таблицю і поле для сортування!");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (currentTable != null && fieldComboBox.SelectedItem != null)
            {
                SearchByColumn(currentTable, fieldComboBox.SelectedItem.ToString(), searchTextBox.Text);
            }
            else
            {
                MessageBox.Show("Оберіть таблицю і поле для пошуку!");
            }
        }

        private void countButton_Click(object sender, EventArgs e)
        {
            if (currentTable != null && fieldComboBox.SelectedItem != null)
            {
                CountByColumn(currentTable, fieldComboBox.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Оберіть таблицю і поле для підрахунку!");
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (currentTable == null)
            {
                MessageBox.Show("Оберіть таблицю!");
                return;
            }
            AddRecordForm addForm = new AddRecordForm(dataGridView1, currentTable);
            addForm.OnSave += (query) =>
            {
                try
                {
                    stopwatch.Restart();
                    dbManager.ExecuteNonQuery(query);
                    stopwatch.Stop();
                    MessageBox.Show($"Новий запис успішно додано! Час: {stopwatch.ElapsedMilliseconds} мс");
                    LoadTable(currentTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка додавання запису: {ex.Message}");
                    LogError($"Помилка додавання запису в таблиці {currentTable}: {ex.Message}");
                }
            };
            addForm.ShowDialog();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (currentTable != null)
            {
                EditSelectedRecord(currentTable);
            }
            else
            {
                MessageBox.Show("Оберіть таблицю!");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (currentTable != null)
            {
                DeleteSelectedRecord(currentTable);
            }
            else
            {
                MessageBox.Show("Оберіть таблицю!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                editTextBox.Text = dataGridView1.CurrentCell.Value?.ToString();
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Програма для управління базою даних готелю.\n" +
                            "Функціонал: перегляд, редагування, додавання і видалення записів, подача скарг, статистика.\n" +
                            "Автор: Лашин Дмитро\n" +
                            "Версія: 1.0\n" +
                            "Дата: 16.05.2025", "Про програму");
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}