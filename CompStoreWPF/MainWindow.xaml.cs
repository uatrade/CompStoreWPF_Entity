using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CompStoreWPF.DataModel;
using System.IO;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace CompStoreWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<TempData> list = new List<TempData>();    //temp для добавления в DATaGrid
        List<TempData> SellList = new List<TempData>();
        List<TempData> CustomerList = new List<TempData>();
        int sum;

        //CompStorEntity connect = new CompStorEntity($"Data Source=DESKTOP-E8FFIHV;Initial Catalog=CompStore;User id=sa;password=123456;");
        CompStorEntity conn;
        string connection;

         TempData tempData;
        public MainWindow()
        {
            InitializeComponent();
            Uri iconUri = new Uri(@"pack://application:,,,/Resources/IconComp.jpg", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            
            Loaded += MainWindow_Loaded;
            MainComboEquipment.SelectionChanged += MainComboEquipment_SelectionChanged;

            ListOfEquipment.MouseDoubleClick += ListOfEquipment_MouseDoubleClick;

            MainComboEquipment.SelectedIndex = 0;
            TotalSum.Text = "0";

            //conn.Open();

            //SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
            //{
            //    DataSource = "DESKTOP-E8FFIHV".ToString(), // Server name
            //    InitialCatalog = "CompStore",  //Database
            //    UserID = "sa",         //Username
            //    Password = "12345",  //Password
            //};     

        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainComboEquipment.Items.Add("Выберите комплектующие");
            MainComboEquipment.Items.Add("Процессор");
            MainComboEquipment.Items.Add("Материнская плата");
            MainComboEquipment.Items.Add("Оперативная память");
            MainComboEquipment.Items.Add("Жесткий диск");
            MainComboEquipment.Items.Add("Видео карта");
            MainComboEquipment.Items.Add("Корпус");
            MainComboEquipment.Items.Add("Монитор");

            //try
            //{
            //    //connection = "Data Source=DESKTOP-E8FFIHV;Initial Catalog=CompStore;User id=sa;password=123456;";
            //    //Properties.Settings.Default["CompStorEntity"] = connection;
            //    //Properties.Settings.Default.Save();

            //    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //    var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            //    connectionStringsSection.ConnectionStrings["CompStorEntity"].ConnectionString = "Data Source=DESKTOP-E8FFIHV;Initial Catalog=CompStore;User id=sa;password=123456;";
            //    config.Save();
            //    ConfigurationManager.RefreshSection("connectionStrings");
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void ListOfEquipment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                tempData = null;
                tempData = ListOfEquipment.SelectedItem as TempData;

                List<TempData> temp = new List<TempData>();
                List<TempData> updateList = new List<TempData>();

                temp = SellList;
                updateList = list;

                list = new List<TempData>();
                SellList = new List<TempData>();


                foreach (var numbers in updateList)  //обновляем первый лист
                {
                    if (numbers == tempData)
                    {
                        numbers.Num -= 1;
                        list.Add(numbers);
                    }
                    else
                        list.Add(numbers);
                }

                ListOfEquipment.ItemsSource = list;

                //tempData.Num = 1;
                if (tempData.Num >= 0)
                {
                    SellList.Add(new TempData(tempData.Title, 1, tempData.Price));
                    CustomerList.Add(new TempData(tempData.Title, 1, tempData.Price));
                    sum += tempData.Price;
                    TotalSum.Text = sum.ToString();
                }
                else
                {
                    throw new MyException($"Недостаточное кол-во {tempData.Title} на складе");
                }
                foreach (var items in temp)
                {
                    SellList.Add(items);
                }

                SellGridView.ItemsSource = SellList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void MainComboEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                ListOfEquipment.Columns.Clear();
                ListOfEquipment.Items.Refresh();

                switch (MainComboEquipment.SelectedItem)
                {
                    case "Процессор":

                        {
                            list.Clear();
                            list = new List<TempData>();
                            using (CompStorEntity db = new CompStorEntity())
                            {
                                foreach (var item in db.Processors)
                                {
                                    list.Add(new TempData(item.ProcessorName, item.NumOfProcessor, item.ProcessorPrice));
                                }
                            }
                            ListOfEquipment.ItemsSource = list;
                            break;
                        }
                    case "Материнская плата":
                        {
                            list.Clear();
                            list = new List<TempData>();
                            using (CompStorEntity db = new CompStorEntity())
                            {
                                Motherboard motherboard = new Motherboard();
                                foreach (var item in db.Motherboards)
                                {
                                    list.Add(new TempData(item.MotherboardName, item.NumOfMotherboard, item.MotherboardPrice));
                                }
                            }
                            ListOfEquipment.ItemsSource = list;
                            break;
                        }
                    case "Оперативная память":
                        {
                            list.Clear();
                            list = new List<TempData>();
                            using (CompStorEntity db = new CompStorEntity())
                            {
                                foreach (var item in db.RAMs)
                                {
                                    list.Add(new TempData(item.RAMName, item.NumOfRam, item.RAMPrice));
                                }
                            }
                            ListOfEquipment.ItemsSource = list;
                            break;
                        }
                    case "Жесткий диск":
                        {
                            list.Clear();
                            list = new List<TempData>();
                            using (CompStorEntity db = new CompStorEntity())
                            {
                                foreach (var item in db.HardDisks)
                                {
                                    list.Add(new TempData(item.HardDiskName, item.NumOfHardDisk, item.HardDiskPrice));
                                }
                            }
                            ListOfEquipment.ItemsSource = list;
                            break;
                        }
                    case "Видео карта":
                        {
                            list.Clear();
                            list = new List<TempData>();
                            using (CompStorEntity db = new CompStorEntity())
                            {
                                foreach (var item in db.VideoCards)
                                {
                                    list.Add(new TempData(item.VideoCardName, item.NumOfVideoCard, item.VideoCardPrice));
                                }
                            }
                            ListOfEquipment.ItemsSource = list;
                            break;
                        }
                    case "Корпус":
                        {
                            list.Clear();
                            list = new List<TempData>();
                            using (CompStorEntity db = new CompStorEntity())
                            {
                                foreach (var item in db.Cases)
                                {
                                    list.Add(new TempData(item.CaseName, item.NumOfCase, item.CasePrice));
                                }
                            }
                            ListOfEquipment.ItemsSource = list;
                            break;
                        }
                    case "Монитор":
                        {
                            list.Clear();
                            list = new List<TempData>();
                            using (CompStorEntity db = new CompStorEntity())
                            {
                                foreach (var item in db.Monitors)
                                {
                                    list.Add(new TempData(item.MonitorName, item.NumOfMonitor, item.MonitorPrice));
                                }
                            }
                            ListOfEquipment.ItemsSource = list;
                            break;
                        }
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Stock_Click(object sender, RoutedEventArgs e)
        {
            Stock stokWindow = new Stock();
            stokWindow.Show();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }
        private void BtnSell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (CompStorEntity db = new CompStorEntity())
                {

#region PROCESSOR
                    foreach (var item in db.Processors)    //разобраться с удалением
                    {
                        foreach (var custom in CustomerList)
                        {
                            if (item.ProcessorName == custom.Title)
                            {
                                if (item.NumOfProcessor > 1)
                                {
                                    item.NumOfProcessor -= 1;
                                    MessageBox.Show($"Товар {item.ProcessorName} успешно продан");
                                    using (FileStream fstream = new FileStream(@"D:\CompStore.txt", FileMode.OpenOrCreate))
                                    {
                                        // преобразуем строку в байты
                                        byte[] array = System.Text.Encoding.Default.GetBytes(item.ProcessorName + " " + "продан в " + DateTime.Now.ToShortTimeString() + "\r\n");
                                        // запись массива байтов в файл
                                        fstream.Seek(+2, SeekOrigin.End);
                                        fstream.Write(array, 0, array.Length);
                                    }
                                }
                                else if (item.NumOfProcessor == 1)
                                {
                                    db.Processors.Remove(item);
                                    MessageBox.Show($"Товар успешно продан. {item.ProcessorName} уже закончились на складе");
                                    using (FileStream fstream = new FileStream(@"D:\CompStore.txt", FileMode.OpenOrCreate))
                                    {
                                        // преобразуем строку в байты
                                        byte[] array = System.Text.Encoding.Default.GetBytes(item.ProcessorName + " " + "продан в " + DateTime.Now.ToShortTimeString() +"по цене"+item.ProcessorPrice +"\r\n");
                                        // запись массива байтов в файл
                                        fstream.Seek(+2, SeekOrigin.End);
                                        fstream.Write(array, 0, array.Length);
                                    }
                                }
                            }
                        }
                    }
#endregion

#region MotherBoard
                    foreach (var itemM in db.Motherboards)
                        {
                            foreach (var custom in CustomerList)
                            {
                                if (itemM.MotherboardName == custom.Title)
                                {
                                    if (itemM.NumOfMotherboard > 1)
                                    {
                                        itemM.NumOfMotherboard -= 1;
                                        MessageBox.Show($"Товар {itemM.MotherboardName} успешно продан");
                                        //TODO Запись в файл
                                    }
                                    else if (itemM.NumOfMotherboard == 1)
                                    {
                                        db.Motherboards.Remove(itemM);
                                        MessageBox.Show($"Товар успешно продан. {itemM.MotherboardName} уже закончились на складе");
                                        //TODO запись в файл
                                    }
                                }
                            }
                        }
#endregion 

#region HardDisk
                    foreach (var itemM in db.HardDisks)
                    {
                        foreach (var custom in CustomerList)
                        {
                            if (itemM.HardDiskName == custom.Title)
                            {
                                if (itemM.NumOfHardDisk > 1)
                                {
                                    itemM.NumOfHardDisk -= 1;
                                    MessageBox.Show($"Товар {itemM.HardDiskName} успешно продан");
                                    //TODO Запись в файл
                                }
                                else if (itemM.NumOfHardDisk == 1)
                                {
                                    db.HardDisks.Remove(itemM);
                                    MessageBox.Show($"Товар успешно продан. {itemM.HardDiskName} уже закончились на складе");
                                    //TODO запись в файл
                                }
                            }
                        }
                    }
                    #endregion

#region RAM
                    foreach (var itemM in db.RAMs)
                    {
                        foreach (var custom in CustomerList)
                        {
                            if (itemM.RAMName == custom.Title)
                            {
                                if (itemM.NumOfRam > 1)
                                {
                                    itemM.NumOfRam -= 1;
                                    MessageBox.Show($"Товар {itemM.RAMName} успешно продан");
                                    //TODO Запись в файл
                                }
                                else if (itemM.NumOfRam == 1)
                                {
                                    db.RAMs.Remove(itemM);
                                    MessageBox.Show($"Товар успешно продан. {itemM.RAMName} уже закончились на складе");
                                    //TODO запись в файл
                                }
                            }
                        }
                    }
                    #endregion

#region CASES
                    foreach (var itemM in db.Cases)
                    {
                        foreach (var custom in CustomerList)
                        {
                            if (itemM.CaseName == custom.Title)
                            {
                                if (itemM.NumOfCase > 1)
                                {
                                    itemM.NumOfCase -= 1;
                                    MessageBox.Show($"Товар {itemM.CaseName} успешно продан");
                                    //TODO Запись в файл
                                }
                                else if (itemM.NumOfCase == 1)
                                {
                                    db.Cases.Remove(itemM);
                                    MessageBox.Show($"Товар успешно продан. {itemM.CaseName} уже закончились на складе");
                                    //TODO запись в файл
                                }
                            }
                        }
                    }
                    #endregion

#region VIDEO
                    foreach (var itemM in db.VideoCards)
                    {
                        foreach (var custom in CustomerList)
                        {
                            if (itemM.VideoCardName == custom.Title)
                            {
                                if (itemM.NumOfVideoCard > 1)
                                {
                                    itemM.NumOfVideoCard -= 1;
                                    MessageBox.Show($"Товар {itemM.VideoCardName} успешно продан");
                                    //TODO Запись в файл
                                }
                                else if (itemM.NumOfVideoCard == 1)
                                {
                                    db.VideoCards.Remove(itemM);
                                    MessageBox.Show($"Товар успешно продан. {itemM.VideoCardName} уже закончились на складе");
                                    //TODO запись в файл
                                }
                            }
                        }
                    }
                    #endregion

#region MONITOR
                    foreach (var itemM in db.Monitors)
                    {
                        foreach (var custom in CustomerList)
                        {
                            if (itemM.MonitorName == custom.Title)
                            {
                                if (itemM.NumOfMonitor > 1)
                                {
                                    itemM.NumOfMonitor -= 1;
                                    MessageBox.Show($"Товар {itemM.MonitorName} успешно продан");
                                    //TODO Запись в файл
                                }
                                else if (itemM.NumOfMonitor == 1)
                                {
                                    db.Monitors.Remove(itemM);
                                    MessageBox.Show($"Товар успешно продан. {itemM.MonitorName} уже закончились на складе");
                                    //TODO запись в файл
                                }
                            }
                        }
                    }
                    #endregion

                    db.SaveChanges();

                    ClearAll();
                }

             }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
        private void ClearAll()
        {
            try
            {
                SellGridView.Columns.Clear();
                ListOfEquipment.Columns.Clear();
                ListOfEquipment.Items.Refresh();
                SellGridView.Items.Refresh();

                SellList.Clear();
                CustomerList.Clear();
                list.Clear();

                MainComboEquipment.SelectedIndex = 0;
                sum = 0;
                TotalSum.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            ConnectWindow connectWindow= new ConnectWindow();

            connectWindow.Show();
        }
    }
}
