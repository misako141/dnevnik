using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace dnevnik
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string fio = fioBOX.Text;
            string group = groupBOX.Text;
            string birthdate = birthdateBOX.Text;
            string datezadaniya = datezadaniyaBOX.Text;
            string tema = temaBOX.Text;

            int ocenka = 0;

            if (ocenkaBOX.Text != "")
            {
                ocenka = Convert.ToInt32(ocenkaBOX.Text);
            }

            string ssql = $"INSERT INTO students_table  VALUES ( '{fio}','{group}','{birthdate}')"; 
            string ssql2 = $"INSERT INTO work_table VALUES ( '{datezadaniya}','{tema}','{ocenka}')";
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True"; 

            SqlConnection conn = new SqlConnection(connectionString); 
            conn.Open();

            SqlCommand command = new SqlCommand(ssql, conn);
            int number = command.ExecuteNonQuery();
            SqlConnection conn2 = new SqlConnection(connectionString); 
            conn2.Open();

            SqlCommand command2 = new SqlCommand(ssql2, conn2);
            int number2 = command2.ExecuteNonQuery();
            
            MessageBox.Show("Данные были добавлены.");
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string date = datezadaniyaBOX.Text;
            string tema = temaBOX.Text;
            string ocenka = ocenkaBOX.Text;
            
            string ssql = $"UPDATE work_table SET tema = '{tema}', ocenka = '{ocenka}' WHERE datezadaniya = '{date}'"; //Запрос
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            reader.Close();
            
            MessageBox.Show("Данные были обновлены.");
        }
    }
}
