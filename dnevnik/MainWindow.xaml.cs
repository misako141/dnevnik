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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Console;
using static System.Convert;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace dnevnik
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
       
            string table = "students_table"; 
            string table2 = "work_table";
            string ssql = $"SELECT * FROM {table} "; 
            string ssql2 = $"SELECT * FROM {table2} ";
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
            
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(ssql, conn);

            SqlDataReader reader = command.ExecuteReader(); 
            

            SqlConnection conn2 = new SqlConnection(connectionString); 
            conn2.Open();
            SqlCommand command2 = new SqlCommand(ssql2, conn2);

            SqlDataReader reader2 = command2.ExecuteReader();

            fioColoumn.Items.Clear();
            groupColoumn.Items.Clear();
            dateColoumn.Items.Clear();
            temaColoumn.Items.Clear();
            ocenkaColoumn.Items.Clear();

            while (reader.Read() && reader2.Read()) 
            {
                fioColoumn.Items.Add(reader[0]);
                groupColoumn.Items.Add(reader[1]);
                dateColoumn.Items.Add(reader2[1]);
                temaColoumn.Items.Add(reader2[2]);
                ocenkaColoumn.Items.Add(reader2[3]);
            }
            
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window Edit_Window = new Window1();
            Edit_Window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
                string date = dateColoumn.ToString();
                string ssql = $"DELETE FROM work_table WHERE data_zanyati = '{date}'"; 
                string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnevnik;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString); 
                conn.Open();

                SqlCommand command = new SqlCommand(ssql, conn);
                SqlDataReader reader = command.ExecuteReader();


                dateColoumn.Items.Clear();
                temaColoumn.Items.Clear();
                ocenkaColoumn.Items.Clear();

                while (reader.Read()) 
                {
                    dateColoumn.Items.Add(reader[1]);
                    temaColoumn.Items.Add(reader[2]);
                    ocenkaColoumn.Items.Add(reader[3]);
                }

                reader.Close();
                MessageBox.Show("Изменения были применены.");
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window Edit_Window = new Window1();
            Edit_Window.Show();
        }
    }

}
