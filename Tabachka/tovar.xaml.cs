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

namespace Tabachka.tovar
{
    /// <summary>
    /// Логика взаимодействия для tovar.xaml
    /// </summary>
    public partial class tovar : Window
    {
        ПроизводительTableAdapter proi = new ПроизводительTableAdapter();
        КатегорииTableAdapter cat = new КатегорииTableAdapter();
        ТоварTableAdapter tovar_ = new ТоварTableAdapter();

        ПоставщикTableAdapter sup = new ПоставщикTableAdapter();

        int manufacturer_id = 0, category_id = 0, supplier_id = 0;
        

        public tovar()
        {
            InitializeComponent();
            Aqw.ItemsSource = tovar_.GetData();

            cd_manufacturer_id.ItemsSource = proi.GetData();
            cd_manufacturer_id.DisplayMemberPath = "Название";

            cb_category_id.ItemsSource = cat.GetData();
            cb_category_id.DisplayMemberPath = "Название";

            cb_supplier_id.ItemsSource = sup.GetData();
            cb_supplier_id.DisplayMemberPath = "Название";

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

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

                    tovar_.InsertQuery(manufacturer_id, category_id, supplier_id, NameTbx.Text, Convert.ToInt32(NameTbx1.Text), Convert.ToInt32(NameTbx2.Text));
                }
                catch (System.FormatException e_)
                {

                    MessageBox.Show(e_.Message);

                }
                finally
                {
                    Aqw.ItemsSource = tovar_.GetData();
                    NameTbx.Text = null;
                }


         
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Aqw.SelectedItem != null)
            {
                try
                {


                    object id = (Aqw.SelectedItem as DataRowView).Row[0];
                    tovar_.DeleteQuery(Convert.ToInt32(id));
                    Aqw.ItemsSource = tovar_.GetData();
                }
                catch
                {
                    MessageBox.Show("Ошибка: не удалось удалить запись");
                }
                finally
                {
                    Aqw.SelectedItem = null;
                    Aqw.ItemsSource = tovar_.GetData();
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
                    tovar_.UpdateQuery(manufacturer_id, category_id, supplier_id, NameTbx.Text, Convert.ToInt32(NameTbx1.Text), Convert.ToInt32(NameTbx2.Text), Convert.ToInt32(id));
                    Aqw.ItemsSource = tovar_.GetData();
                }
                catch
                {
                    MessageBox.Show("Ошибка: не удалось изменить запись");
                }
                finally
                {
                    Aqw.ItemsSource = tovar_.GetData();
                }

            }
        }

        private void Aqw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                NameTbx.Text = (Aqw.SelectedItem as DataRowView).Row[4].ToString();
                NameTbx1.Text = (Aqw.SelectedItem as DataRowView).Row[5].ToString();
                NameTbx2.Text = (Aqw.SelectedItem as DataRowView).Row[6].ToString();
            }
            catch
            {
                NameTbx.Text = null;
                NameTbx1.Text = null;
                NameTbx2.Text = null;
            }


        }

        private void cb_category_id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cb_category_id.SelectedItem as DataRowView).Row[0];
            category_id = Convert.ToInt32(cell);

        }

        private void cb_supplier_id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            object cell = (cb_supplier_id.SelectedItem as DataRowView).Row[0];
            supplier_id = Convert.ToInt32(cell);

        }

        

        private void cd_manufacturer_id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cd_manufacturer_id.SelectedItem as DataRowView).Row[0];
            manufacturer_id = Convert.ToInt32(cell);

        }
       



    }
}
