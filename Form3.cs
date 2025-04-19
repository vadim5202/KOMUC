using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Разработка_интерактивного_обучающего_пособия
{
    public partial class Form3 : Form
    {
        private string connectionString = @"Server=VARVARA\MSSQLSERVE;Database=KOMYC;Trusted_Connection=True;";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textBox1.Text.Trim();  // Имя
            string lastName = textBox2.Text.Trim();   // Фамилия
            string position = comboBox1.Text.Trim();   // Должность
            string email = textBox4.Text.Trim();      // Почта
            string username = textBox5.Text.Trim();   // Логин
            string password = textBox6.Text.Trim();   // Пароль

            // Проверяем, что все поля заполнены
            if (string.IsNullOrEmpty(firstName)  || string.IsNullOrEmpty(lastName)
        || string.IsNullOrEmpty(position)  || string.IsNullOrEmpty(email)
        || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
    {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL-запрос для вставки нового пользователя
                    string query = "INSERT INTO users (first_name, last_name, position, email, username, password) " +
                                   "VALUES (@FirstName, @LastName, @Position, @Email, @Username, @Password)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Position", position);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password); // В реальном проекте пароль нужно хешировать!

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form12 form12 = new Form12(); // Переход на Form4
                            form12.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка регистрации. Попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
