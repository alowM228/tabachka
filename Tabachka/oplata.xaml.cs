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
using System.Windows.Shapes;
using Tabachka.ТабачкаDataSetTableAdapters;

namespace Tabachka
{
    /// <summary>
    /// Логика взаимодействия для oplata.xaml
    /// </summary>
    /// СДЕЛАНО
    public partial class oplata : Window
    {
        ОплатаTableAdapter oplata1 = new ОплатаTableAdapter();
        ЗаказTableAdapter zakaz = new ЗаказTableAdapter();
        Методы_оплатыTableAdapter metod_pay = new Методы_оплатыTableAdapter();
        int order_id_ = 0, pay_id_ = 0;

        public oplata()
        {
            InitializeComponent();
            Aqw.ItemsSource = oplata1.GetData();

            order_id.ItemsSource = zakaz.GetData();
            order_id.DisplayMemberPath = "order_id";

            pay_id.ItemsSource = metod_pay.GetData();
            pay_id.DisplayMemberPath = "Название";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object id = (Aqw.SelectedItem as DataRowView);
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
                    oplata1.InsertQuery(order_id_, pay_id_, Convert.ToInt32(NameTbx.Text), DateTime.Now);
                }
                catch (System.FormatException e_)
                {
                    MessageBox.Show("Ошибка: не удалось изменить запись");
                }
                finally
                {
                    Aqw.ItemsSource = oplata1.GetData();
                    NameTbx.Text = null;
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
                    oplata1.UpdateQuery(order_id_, pay_id_, Convert.ToInt32(NameTbx.Text), DateTime.Now, Convert.ToInt32(id));
                }
                catch
                {
                    MessageBox.Show("Ошибка: не удалось удалить запись");
                }
                finally
                {
                    
                    Aqw.ItemsSource = oplata1.GetData();
                }
            }

            

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (Aqw.SelectedItem as DataRowView).Row[0];
            if (Aqw.SelectedItem != null)
            {
                try
                {
                    oplata1.DeleteQuery(Convert.ToInt32(id));
                    Aqw.ItemsSource = oplata1.GetData();
                }
                catch
                {
                    MessageBox.Show("Ошибка: не удалось удалить запись");
                }
                finally
                {
                    Aqw.SelectedItem = null;
                    Aqw.ItemsSource = oplata1.GetData();
                }

            }
            else
            {
                MessageBox.Show("Ошибка: элемент для удаления не выбран");
            }
        }



        private void Aqw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                NameTbx.Text = (Aqw.SelectedItem as DataRowView).Row[3].ToString();


            }
            catch
            {
                NameTbx.Text = null;

            }

        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (pay_id.SelectedItem as DataRowView).Row[0];
            pay_id_ = Convert.ToInt32(cell);

        }

        private void order_id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (order_id.SelectedItem as DataRowView).Row[0];
            order_id_ = Convert.ToInt32(cell);
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();


        }
    }
}
