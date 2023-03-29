using System;
using System.Collections.Generic;
using System.Data;
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
using Tabachka.ТабачкаDataSetTableAdapters;

namespace Tabachka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    /// ВСЁ СДЕЛАНО НЕ ТРОГАТЬ
   


    public partial class Window1 : Window
    {


        ЗаказчикTableAdapter customer = new ЗаказчикTableAdapter();
        public Window1()
        {
            InitializeComponent();
            Aqw.ItemsSource = customer.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(NameTbx.Text))
            {
                MessageBox.Show("Ошибка: пустая строка");

            }
            else if (NameTbx.Text.FirstOrDefault(element => char.IsDigit(element)).ToString() != "\0")
            {
                MessageBox.Show("Ошибка: Строка не может содержать цифры");
            }
            else
            {
                try
                {
                    customer.InsertQuery(NameTbx.Text, NameTbx1.Text, Convert.ToInt32(NameTbx2.Text), NameTbx3.Text, NameTbx5.Text, NameTbx6.Text, DateTime.Now);
                }

                catch
                {
                    MessageBox.Show("Ошибка: не удалось добавить запись");
                }
                finally
                {
                    Aqw.ItemsSource = customer.GetData();
                    NameTbx.Text = null;
                }
                Aqw.ItemsSource = customer.GetData();
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Aqw.SelectedItem != null)
            {
                try
                {
                    object id = (Aqw.SelectedItem as DataRowView).Row[0];
                    customer.DeleteQuery(Convert.ToInt32(id));
                    Aqw.ItemsSource = customer.GetData();
                }
                catch
                {
                    MessageBox.Show("Ошибка: не удалось удалить запись");
                }
                finally
                {
                    Aqw.SelectedItem = null;
                    Aqw.ItemsSource = customer.GetData();
                }


            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTbx.Text))
            {
                MessageBox.Show("Ошибка: пустая строка");
            }

            else if (NameTbx.Text.FirstOrDefault(element => char.IsDigit(element)).ToString() != "\0")
            {
                MessageBox.Show("Ошибка: Строка не может содержать цифры");
            }
            else
            {
                try
                {
                    object id = (Aqw.SelectedItem as DataRowView).Row[0];
                    customer.UpdateQuery(NameTbx.Text, NameTbx1.Text, Convert.ToInt32(NameTbx2.Text), NameTbx3.Text, NameTbx5.Text, NameTbx6.Text, DateTime.Now, Convert.ToInt32(id));
                    Aqw.ItemsSource = customer.GetData();
                }
                catch
                {
                    MessageBox.Show("Ошибка: не удалось изменить запись");
                }
                finally
                {
                    Aqw.ItemsSource = customer.GetData();
                }

            }
        }

        private void Aqw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                NameTbx.Text = (Aqw.SelectedItem as DataRowView).Row[1].ToString();
                NameTbx1.Text = (Aqw.SelectedItem as DataRowView).Row[2].ToString();
                NameTbx2.Text = (Aqw.SelectedItem as DataRowView).Row[3].ToString();
                NameTbx3.Text = (Aqw.SelectedItem as DataRowView).Row[4].ToString();
               
                NameTbx5.Text = (Aqw.SelectedItem as DataRowView).Row[6].ToString();
                NameTbx6.Text = (Aqw.SelectedItem as DataRowView).Row[7].ToString();




            }
            catch
            {
                NameTbx.Text = null;
                NameTbx1.Text = null;
                NameTbx2.Text = null;
                NameTbx3.Text = null;
               
                NameTbx5.Text = null;
                NameTbx6.Text = null;


            }


        }

       

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
           MainWindow mainWindow= new MainWindow(); 
           mainWindow.Show();
            this.Close();
            
        }
    }
}
