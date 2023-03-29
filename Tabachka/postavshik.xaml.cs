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
    /// Логика взаимодействия для postavshik.xaml
    /// </summary>
    /// ВСЁ СДЕЛАНО
    /// 
    public partial class postavshik : Window
    {
        ПоставщикTableAdapter postavka = new ПоставщикTableAdapter();
        public postavshik()
        {
            InitializeComponent();
            Aqw.ItemsSource = postavka .GetData();
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
                    postavka.InsertQuery(NameTbx.Text, NameTbx1.Text, NameTbx2.Text, NameTbx3.Text);
                }

                catch (System.FormatException e_)
                {
                    MessageBox.Show(e_.Message);
                }

                finally
                {
                    Aqw.ItemsSource = postavka.GetData();
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
                     postavka.DeleteQuery(Convert.ToInt32(id));
                    Aqw.ItemsSource = postavka.GetData();
                }
                catch
                {
                    MessageBox.Show("Ошибка: не удалось удалить запись");
                }
                finally
                {
                    Aqw.SelectedItem = null;
                    Aqw.ItemsSource = postavka.GetData();
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
                    postavka.UpdateQuery(NameTbx.Text, NameTbx1.Text, NameTbx2.Text, NameTbx3.Text, Convert.ToInt32(id));
                    Aqw.ItemsSource = postavka.GetData();
                }
                catch
                {
                    MessageBox.Show("Ошибка: не удалось изменить запись");
                }
                finally
                {
                    Aqw.ItemsSource = postavka.GetData();
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
            }
            catch
            {
                NameTbx.Text = null;
                NameTbx1.Text = null;
                NameTbx2.Text = null;
                NameTbx3.Text = null;
            }

        }
    }
}
