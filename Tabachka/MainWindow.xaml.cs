
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
using Tabachka.tovar;

namespace Tabachka
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            this.Close();
            window1.Show();
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            zakaz zakaz= new zakaz();
            this.Close();
            zakaz.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            oplata oplata = new oplata();
            this.Close();
            oplata.Show();

        }


        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            tovar.tovar tovar = new tovar.tovar();
            this.Close();
            tovar.Show();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {


            detalies detalies = new detalies();
            this.Close();
            detalies.Show();

        }


        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            //Роль
            role role = new role();
            this.Close();
            role.Show();


        }

        
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            sotrudnik sotrudnik = new sotrudnik();
            this.Close();
            sotrudnik.Show();

        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {

            postavshik postavshik = new postavshik();
            this.Close();
            postavshik.Show();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            reg reg = new reg();
            this.Close();
            reg.Show();
        }
    }
}
