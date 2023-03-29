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
    /// Логика взаимодействия для zakaz.xaml
    /// </summary>
    /// ВСЁ СДЕЛАНО
    public partial class zakaz : Window
    {

        ЗаказTableAdapter zakaz1 = new ЗаказTableAdapter();
        ЗаказчикTableAdapter customer = new ЗаказчикTableAdapter();
        СотрудникTableAdapter sotrudnik1 = new СотрудникTableAdapter();
        int user_id = 0, emp_id = 0;


        public zakaz()
        {
            InitializeComponent();
            Aqw.ItemsSource = zakaz1.GetData();

            cb_zakachik.ItemsSource = customer.GetData();
            cb_zakachik.DisplayMemberPath = "Имя";

            cb_prodavec.ItemsSource = sotrudnik1.GetData();
            cb_prodavec.DisplayMemberPath = "name_";


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
                    zakaz1.InsertQuery(user_id, emp_id, Convert.ToInt32(NameTbx.Text), NameTbx1.Text);
                }

                catch (System.FormatException e_)
                {

                    MessageBox.Show(e_.Message);

                }
                finally
                {
                    Aqw.ItemsSource = zakaz1.GetData();
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
                    zakaz1.DeleteQuery(Convert.ToInt32(id));
                    Aqw.ItemsSource = zakaz1.GetData();
                }
                catch 
                {
                    MessageBox.Show("Ошибка: не удалось удалить запись");
                }
                finally
                {
                    Aqw.SelectedItem = null;
                    Aqw.ItemsSource = zakaz1.GetData();
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
                    zakaz1.UpdateQuery(user_id, emp_id, Convert.ToInt32(NameTbx.Text), NameTbx1.Text, Convert.ToInt32(id));
                    Aqw.ItemsSource = zakaz1.GetData();
                }
                catch
                {
                    MessageBox.Show("Ошибка: не удалось изменить запись");
                }
                finally
                {
                    Aqw.ItemsSource = zakaz1.GetData();
                }

            }

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

        private void cb_zakachik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cb_zakachik.SelectedItem as DataRowView).Row[0];
            user_id = Convert.ToInt32(cell);

        }

        private void cb_prodavec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cb_prodavec.SelectedItem as DataRowView).Row[0];
            emp_id = Convert.ToInt32(cell);

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        
    }
}
