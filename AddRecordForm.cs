using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HotelDBClientApp
{
    public partial class AddRecordForm : Form
    {
        private DataGridView dataGridView;
        private string tableName;
        private TextBox[] inputFields;
        public event Action<string> OnSave;

        public AddRecordForm(DataGridView grid, string table)
        {
            InitializeComponent();
            dataGridView = grid;
            tableName = table;
            CreateInputFields();
        }

        private void CreateInputFields()
        {
            int labelWidth = 100;
            int fieldWidth = 300;
            int yPosition = 20;
            int verticalSpacing = 30;
            int buttonHeight = 30;

            var columnsToInclude = dataGridView.Columns.Cast<DataGridViewColumn>()
                .Where(col => !(tableName == "Complaint" && col.HeaderText == "ID_complaint"))
                .ToArray();

            inputFields = new TextBox[columnsToInclude.Length];
            for (int i = 0; i < columnsToInclude.Length; i++)
            {
                Label label = new Label
                {
                    Text = columnsToInclude[i].HeaderText,
                    Location = new System.Drawing.Point(20, yPosition),
                    Size = new System.Drawing.Size(labelWidth, 20)
                };
                this.Controls.Add(label);

                TextBox textBox = new TextBox
                {
                    Name = columnsToInclude[i].HeaderText,
                    Location = new System.Drawing.Point(20 + labelWidth + 10, yPosition),
                    Size = new System.Drawing.Size(fieldWidth - labelWidth - 20, 20)
                };
                this.Controls.Add(textBox);
                inputFields[i] = textBox;
                yPosition += verticalSpacing;
            }

            Button saveButton = new Button
            {
                Text = "Зберегти",
                Location = new System.Drawing.Point(20 + labelWidth + 10, yPosition),
                Size = new System.Drawing.Size(fieldWidth - labelWidth - 20, buttonHeight)
            };
            saveButton.Click += SaveButton_Click;
            this.Controls.Add(saveButton);

            this.ClientSize = new System.Drawing.Size(this.ClientSize.Width, yPosition + buttonHeight + 40);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var columns = dataGridView.Columns.Cast<DataGridViewColumn>()
                .Where(col => !(tableName == "Complaint" && col.HeaderText == "ID_complaint"))
                .Select(col => col.HeaderText)
                .ToArray();
            var values = new List<string>();

            for (int i = 0; i < inputFields.Length; i++)
            {
                string value = inputFields[i].Text.Trim();
                if (columns[i].ToLower() == "complaint_date" && !string.IsNullOrEmpty(value))
                {
                    if (DateTime.TryParse(value, out DateTime date))
                    {
                        value = date.ToString("yyyy-MM-dd HH:mm");
                    }
                    else
                    {
                        MessageBox.Show($"Некоректний формат дати для стовпця {columns[i]}. Очікується DD.MM.YYYY HH:MM.");
                        return;
                    }
                }
                values.Add($"'{value.Replace("'", "''")}'");
            }

            string query = $"INSERT INTO {tableName} ({string.Join(", ", columns)}) VALUES ({string.Join(", ", values)});";
            try
            {
                OnSave?.Invoke(query);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження: {ex.Message}");
            }
        }
    }
}