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
    /// Логика взаимодействия для role.xaml
    /// </summary>
    /// ВСЁ СДЕЛАНО

    public partial class role : Window
    {
        РольTableAdapter role1 = new РольTableAdapter();
        public role()
        {
            InitializeComponent();
            Aqw.ItemsSource = role1.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(NameTbx.Text))
            {
                MessageBox.Show("Ошибка: пустая строка");
            }
            else if (role1.GetData().FirstOrDefault(element => element.role_name.ToLower() == NameTbx.Text.ToLower()) != null)
            {
                MessageBox.Show("Ошибка: такое значение уже существует");
            }
            else if (NameTbx.Text.FirstOrDefault(element => char.IsDigit(element)).ToString() != "\0")
            {
                MessageBox.Show("Ошибка: Строка не может содержать цифры");
            }
            else
            { 
                try
                {
                    role1.InsertQuery(NameTbx.Text);
                }
                catch
                {
                    MessageBox.Show("Ошибка: не удалось добавить запись");
                }
                finally
                {
                    Aqw.ItemsSource = role1.GetData();
                    NameTbx.Text = null;
                }
            }

            Aqw.ItemsSource = role1.GetData();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(NameTbx.Text))
            {
                MessageBox.Show("Ошибка: пустая строка");
            }
            else if (role1.GetData().FirstOrDefault(element => element.role_name.ToLower() == NameTbx.Text.ToLower()) != null)
            {
                MessageBox.Show("Ошибка: такое значение уже существует");
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
                    object id2 = (Aqw.SelectedItem as DataRowView).Row[0];
                    role1.UpdateQuery(NameTbx.Text, (Convert.ToInt32(id2)));
                }
                catch
                {
                    Aqw.ItemsSource = role1.GetData();
                }

                finally
                {
                   Aqw.ItemsSource = role1.GetData();
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = Aqw.SelectedItem as DataRowView;

      

            if (Aqw.SelectedItem != null)
            {
                try
                {
                    int id3 = Convert.ToInt32(selectedRow.Row[0]);
                    role1.DeleteQuery(id3);
                }
                catch
                {
                    MessageBox.Show("Ошибка: не удалось удалить запись");
                }
                finally
                {
                    Aqw.SelectedItem = null;
                    Aqw.ItemsSource = role1.GetData();
                }

            }
            else
            {
                MessageBox.Show("Ошибка: элемент для удаления не выбран");
            }

        }


        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Aqw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
