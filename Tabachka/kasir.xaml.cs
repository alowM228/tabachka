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
using Tabachka.ТабачкаDataSetTableAdapters;


namespace Tabachka
{
    /// <summary>
    /// Логика взаимодействия для kasir.xaml
    /// </summary>
    public partial class kasir : Window
    {
        ТоварTableAdapter tov = new ТоварTableAdapter();
        public kasir()
        {
            InitializeComponent();
            Aqw.ItemsSource = tov.GetData();
        }

        private void Aqw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            kasir_oplata kasir_ = new kasir_oplata();
            this.Close();
            kasir_.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            reg reg = new reg();
            this.Close();
            reg.Show();
        }
    }
}
