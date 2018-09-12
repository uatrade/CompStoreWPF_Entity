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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CompStoreWPF.DataModel;

namespace CompStoreWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<TempData> list = new List<TempData>();
        List<TempData> SellList = new List<TempData>();

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
                if(tempData.Num>=1)
                SellList.Add(new TempData(tempData.Title, 1, tempData.Price));
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            //MessageBox.Show(tempData.Title);
        }

        private void MainComboEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListOfEquipment.Columns.Clear();
                ListOfEquipment.Items.Refresh();
                //list.Clear();
                
                switch (MainComboEquipment.SelectedItem)
                {
                    case "Процессор":
                        {
                            list.Clear();
                            list = new List<TempData>();
                            using (CompStorEntity db = new CompStorEntity())
                            {
                                // Processor processor = new Processor();
                                foreach (var item in db.Processors)
                                {
                                    //MainListOfEquipment.Items.Add(item.ProcessorName);
                                    list.Add(new TempData(item.ProcessorName, item.NumOfProcessor, item.ProcessorPrice));
                                    //list.Add(new { Title = item.ProcessorName, Num = item.NumOfProcessor, Price = item.ProcessorPrice });
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
                                    //MainListOfEquipment.Items.Add(item.ProcessorName);
                                    list.Add(new TempData(item.MotherboardName, item.NumOfMotherboard, item.MotherboardPrice));
                                    //list.Add(new { Title = item.ProcessorName, Num = item.NumOfProcessor, Price = item.ProcessorPrice });
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
            try
            {
                SellGridView.Columns.Clear();
                ListOfEquipment.Columns.Clear(); 
                ListOfEquipment.Items.Refresh();
                SellGridView.Items.Refresh();

                SellList.Clear();
                list.Clear();

                MainComboEquipment.SelectedIndex =0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSell_Click(object sender, RoutedEventArgs e)
        {
            using (CompStorEntity db=new CompStorEntity())
            {
                Processor processor = new Processor();
                
                //foreach(var item in SellListView.Items)
                //{
                //    var res=db.Processors.Where(x => x.ProcessorName == item.ToString());
                //    db.Processors.RemoveRange(res);

                //    db.SaveChanges();
                    
                //}
            }
        }

    }
}
