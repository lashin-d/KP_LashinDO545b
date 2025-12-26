using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HotelDBClientApp
{
    public partial class RegisterForm : Form
    {
        private readonly string connectionString;

        public RegisterForm(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        // Обробка реєстрації
        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля!");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Паролі не збігаються!");
                return;
            }

            string checkUserQuery = "SELECT COUNT(*) FROM users WHERE username = @username;";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(checkUserQuery, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        int userCount = Convert.ToInt32(command.ExecuteScalar());
                        if (userCount > 0)
                        {
                            MessageBox.Show("Користувач з таким ім'ям вже існує!");
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO users (username, password) VALUES (@username, @password);";
                    using (var insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@username", username);
                        insertCommand.Parameters.AddWithValue("@password", password);
                        insertCommand.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show("Реєстрація успішна!");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка реєстрації: {ex.Message}");
            }
        }

        // Відображення інформації про програму
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Програма для управління базою даних готелю.\n" +
                            "Функціонал: перегляд, редагування, додавання і видалення записів, подача скарг, статистика.\n" +
                            "Автор: Лашин Дмитро\n" +
                            "Версія: 1.0\n" +
                            "Дата: 16.05.2025", "Про програму");
        }

        // Закриття програми
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}