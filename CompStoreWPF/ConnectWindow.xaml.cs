using CompStoreWPF.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace CompStoreWPF
{
    /// <summary>
    /// Interaction logic for ConnectWindow.xaml
    /// </summary>
    public partial class ConnectWindow : Window
    {
        MainWindow main;
        public ConnectWindow(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void btnForConnect_Click(object sender, RoutedEventArgs e)
        {  
            try
            {

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
               // connectionStringsSection.ConnectionStrings["CompStorEntity"].ConnectionString = "Data Source=DESKTOP-E8FFIHV;Initial Catalog=CompStore;User id=sa;password=123456;";
                connectionStringsSection.ConnectionStrings["CompStorEntity"].ConnectionString = $"Data Source={tbServer.Text};Initial Catalog={tbBase.Text};User id={tbLogin.Text};password={tbPassword.Password};";
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");

                //MessageBox.Show(tbBase.Text);

                if (CheckConnection())
                {
                    LabelIsConnect.Content = "Подключено";
                    main.BtnSell.IsEnabled = true;
                    main.MainComboEquipment.IsEnabled = true;
                    main.Stock.IsEnabled = true;
                }
                else
                {
                    LabelIsConnect.Content = "Введены недостоверные данные: Отключено";
                    System.Windows.Forms.Application.Restart();
                    System.Windows.Application.Current.Shutdown();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool CheckConnection()
        {
            try
            {
                using (CompStorEntity db=new CompStorEntity())
                {
                    db.Database.Connection.Open();
                    db.Database.Connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }
    }
}
