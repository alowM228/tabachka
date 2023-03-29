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
using System.Xml.Linq;
using Tabachka.ТабачкаDataSetTableAdapters;

namespace Tabachka
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Window
    {
        СотрудникTableAdapter adapter = new СотрудникTableAdapter();
        РольTableAdapter rol = new РольTableAdapter();
        public reg()
        {
            InitializeComponent();
            
        }

        private void bt_avt_Click(object sender, RoutedEventArgs e)
        {
            var user = adapter.GetData().FirstOrDefault(elemet => elemet.password_ == passwordTbx.Password && elemet.login_ == loginTbx.Text);
            if (user !=null)
            {
                if (rol.GetData().First(element => element.role_id == user.role_id_).role_name == "Admin")
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                
                if (rol.GetData().First(element => element.role_id == user.role_id_).role_name == "Kasir")
                {
                    kasir mainWindow = new kasir();
                    mainWindow.Show();
                    this.Close();
                }


            }

        }
    }
}
