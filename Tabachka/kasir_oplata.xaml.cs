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
using Microsoft.WindowsAPICodePack.Dialogs;


namespace Tabachka
{
    /// <summary>
    /// Логика взаимодействия для kasir_oplata.xaml
    /// </summary>
    public partial class kasir_oplata : Window
    {
        ОплатаTableAdapter opl = new ОплатаTableAdapter();
        Методы_оплатыTableAdapter metod_pay = new Методы_оплатыTableAdapter();
        ЗаказTableAdapter zakaz = new ЗаказTableAdapter();

        int order_id_ = 0, pay_id_ = 0;
        public kasir_oplata()
        {
            InitializeComponent();
            Aqw.ItemsSource = opl.GetData();

            order_id.ItemsSource = zakaz.GetData();
            order_id.DisplayMemberPath = "order_id";

            pay_id.ItemsSource = metod_pay.GetData();
            pay_id.DisplayMemberPath = "Название";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            kasir mainWindow = new kasir();
            mainWindow.Show();
            this.Close();
        }

        private void Aqw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        //    CommonOpenFileDialog dialog = new CommonOpenFileDialog
        //    { 
        //        IsFolderPicker = true 
        //    };

        //    if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
        //    {

        //    }
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

    }
}
