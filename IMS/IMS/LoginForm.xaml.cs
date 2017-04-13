using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace IMS
{
    /// <summary>
    /// Логика взаимодействия для LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        #region Обработка кнопок формы логина
        #region Кнопка "Войти"
        /// <summary>
        /// Логика взаимодействия с кнопкой "Войти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            //Проверка ввода данных в форму
            if (LoginBox.Text.Length <1 || PasswordBox.Password.Length <1)
            {
                MessageBox.Show("Совет: Возможно вы не заполнили поля Логин|Пароль", "Ошибка авторизации пользователя");
            }
            else
            {
                string connectionToTestDB = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\blagi\Source\Repos\Sample-InventoryManagmentSoftware-\IMS\IMS\AppDB.mdf;Integrated Security=True";
                //Попытка подключения к базе данных
                using (SqlConnection connection = new SqlConnection(connectionToTestDB))
                    try
                {
                    SqlCommand command = new SqlCommand("Select * from People where UserName = @username and Password = @password",  connection);
                        command.Parameters.AddWithValue("@UserName", LoginBox.Text);
                        command.Parameters.AddWithValue("@Password", PasswordBox.Password);
                        connection.Open();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataSet dataset = new DataSet();
                        dataAdapter.Fill(dataset);
                        connection.Close();
                        // Переход к следующему окну при соответсвии введённых данных
                        if (dataset.Tables[0].Rows.Count == 1)
                        {
                            this.Hide();
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                        }
                        // Возвращение к повторному вводу пароля
                        else
                        {
                            MessageBox.Show("\n Пользователь с введенной парой Логин|Пароль не найден. \n Возможно вы неверно ввели пароль.","Ошибка при авторизации пользователя.");
                        }

                }
                    //Отлавливание ошибок покдлючения к базе данных
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Отсутствует подключение к базе данных, обратитесь к администратору \n {ex.Message}", "Ошибка при авторизации пользователя.");
                    }
               
            }
        }
        #endregion
        #region Кнопка "Закрыть"
        /// <summary>
        /// Логика взаимодействия с кнопкой "Закрыть"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion
    }
}
