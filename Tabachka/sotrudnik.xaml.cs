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
    /// Логика взаимодействия для sotrudnik.xaml
    /// </summary>
    /// ВСЁ СДЕЛАНО
    public partial class sotrudnik : Window
    {
        СотрудникTableAdapter sotrudnik1 = new СотрудникTableAdapter();
        РольTableAdapter role = new РольTableAdapter();
        int ID= 0;

        public sotrudnik()
        {

            InitializeComponent();
            Aqw.ItemsSource = sotrudnik1.GetData();
            cb_sotrudnik.ItemsSource = role.GetData();
            cb_sotrudnik.DisplayMemberPath = "role_name";
        }

        private void cb_sotrudnik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cb_sotrudnik.SelectedItem as DataRowView).Row[0];
            ID = Convert.ToInt32(cell);
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
                    sotrudnik1.InsertQuery(ID, NameTbx.Text, NameTbx1.Text, NameTbx2.Text);
                    
                }
                catch (System.FormatException e_)
                {
                    MessageBox.Show(e_.Message);
                }
                finally
                {
                    Aqw.ItemsSource = sotrudnik1.GetData();
                    NameTbx.Text = null;
                }

               
            }
        }


        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

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
                    sotrudnik1.UpdateQuery(ID, NameTbx.Text, NameTbx1.Text, NameTbx2.Text, Convert.ToInt32(id));
                    Aqw.ItemsSource = sotrudnik1.GetData();
                }

                catch
                {
                    MessageBox.Show("Ошибка: не удалось изменить запись");
                }
                finally
                {
                    Aqw.ItemsSource = sotrudnik1.GetData();
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
                    sotrudnik1.DeleteQuery(Convert.ToInt32(id));
                    Aqw.ItemsSource = sotrudnik1.GetData();
                }
                catch
                {
                    MessageBox.Show("Ошибка: не удалось удалить запись");
                }
                finally
                {
                    Aqw.SelectedItem = null;
                    Aqw.ItemsSource = sotrudnik1.GetData();
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
                
                NameTbx.Text = (Aqw.SelectedItem as DataRowView).Row[2].ToString();
                NameTbx1.Text = (Aqw.SelectedItem as DataRowView).Row[3].ToString();
                NameTbx2.Text = (Aqw.SelectedItem as DataRowView).Row[4].ToString();

            }
            catch
            {
                NameTbx.Text = null;
                NameTbx1.Text = null;
                NameTbx2.Text = null;
            }


        }


    }
    
}
