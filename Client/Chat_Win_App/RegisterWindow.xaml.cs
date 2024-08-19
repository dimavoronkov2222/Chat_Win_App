using System;
using System.Data.SqlClient;
using System.Windows;

namespace Chat_Win_App
{
    public partial class RegisterWindow : Window
    {
        private readonly string _connectionString = "Data Source=DESKTOP-18724IK;Initial Catalog=ChatApp;Integrated Security=True";

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;
            var confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || password != confirmPassword)
            {
                MessageBox.Show("Please enter a username, password, and ensure both passwords match.");
                return;
            }

            if (RegisterUser(username, password))
            {
                MessageBox.Show("Registration successful.");
                var loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username already exists or an error occurred.");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool RegisterUser(string username, string password)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Проверка существования пользователя
                    using (var checkCommand = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @username", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@username", username);
                        int userCount = (int)checkCommand.ExecuteScalar();

                        if (userCount > 0)
                        {
                            MessageBox.Show("Username already exists.");
                            return false;
                        }
                    }

                    // Вставка нового пользователя с паролем
                    using (var command = new SqlCommand("INSERT INTO Users (Username, Password) VALUES (@username, @password)", connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}