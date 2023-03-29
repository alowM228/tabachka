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
    /// Логика взаимодействия для detalies.xaml
    /// </summary>
    public partial class detalies : Window
    {
        Детали_заказаTableAdapter det = new Детали_заказаTableAdapter();
        ЗаказTableAdapter  zak = new ЗаказTableAdapter();
        ТоварTableAdapter tov = new ТоварTableAdapter();
        int product_id = 0, order_id = 0;

        public detalies()
        {
            InitializeComponent();
            Aqw.ItemsSource = det.GetData();

            cd_order_id.ItemsSource = zak.GetData();
            cd_order_id.DisplayMemberPath = "order_id";

            cb_product_id.ItemsSource = tov.GetData();
            cb_product_id.DisplayMemberPath = "product_id";

        }

        private void Aqw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                NameTbx.Text = (Aqw.SelectedItem as DataRowView).Row[3].ToString();
                NameTbx1.Text = (Aqw.SelectedItem as DataRowView).Row[4].ToString();
            }
            catch
            {
                NameTbx.Text = null;
                NameTbx1.Text = null;
            }
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
                    det.InsertQuery(order_id, product_id, Convert.ToInt32(NameTbx.Text), Convert.ToInt32(NameTbx1.Text));
                }

                catch (System.FormatException e_)
                {
                    MessageBox.Show(e_.Message);
                }
                finally
                {
                    Aqw.ItemsSource = det.GetData();
                    NameTbx.Text = null;
                }
                Aqw.ItemsSource = det.GetData();
            }
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Aqw.SelectedItem != null)
            {
                try
                {
                    object id = (Aqw.SelectedItem as DataRowView).Row[0];
                    det.DeleteQuery(Convert.ToInt32(id));
                    Aqw.ItemsSource = det.GetData();
                }
                catch
                {
                    MessageBox.Show("Ошибка: не удалось удалить запись");
                }
                finally
                {
                    Aqw.SelectedItem = null;
                    Aqw.ItemsSource = det.GetData();
                }


            }
            else
            {
                MessageBox.Show("Ошибка: элемент для удаления не выбран");
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
                    det.UpdateQuery(order_id, product_id, Convert.ToInt32(NameTbx.Text), Convert.ToInt32(NameTbx1.Text), Convert.ToInt32(id));
                    Aqw.ItemsSource = det.GetData();
                }
                catch
                {
                    MessageBox.Show("Ошибка: не удалось изменить запись");
                }
                finally
                {
                    Aqw.ItemsSource = det.GetData();
                }
            }
        }

        

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        private void cd_order_id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cd_order_id.SelectedItem as DataRowView).Row[0];
            order_id = Convert.ToInt32(cell);
        }

        private void cb_product_id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cb_product_id.SelectedItem as DataRowView).Row[0];
            product_id = Convert.ToInt32(cell);

        }

    }
}
