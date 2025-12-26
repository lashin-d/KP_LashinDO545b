using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HotelDBClientApp
{
    public partial class LoginForm : Form
    {
        private readonly string connectionString;

        public LoginForm(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        // Обробка входу
        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Будь ласка, введіть ім'я користувача та пароль!");
                return;
            }

            string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password;";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        int userCount = Convert.ToInt32(command.ExecuteScalar());
                        if (userCount > 0)
                        {
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Невірне ім'я користувача або пароль!");
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка входу: {ex.Message}");
            }
        }

        // Перехід до форми реєстрації
        private void registerButton_Click(object sender, EventArgs e)
        {
            using (var registerForm = new RegisterForm(connectionString))
            {
                if (registerForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Реєстрація успішна! Тепер ви можете увійти.");
                }
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