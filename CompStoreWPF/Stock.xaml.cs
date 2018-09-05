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
using System.Data.Entity;
using CompStoreWPF.DataModel;

namespace CompStoreWPF
{
    /// <summary>
    /// Interaction logic for Stock.xaml
    /// </summary>
    public partial class Stock : Window
    {
        public Stock()
        {
            InitializeComponent();
            Uri iconUri = new Uri(@"pack://application:,,,/Resources/IconComp.jpg", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            Loaded += Stock_Loaded;
        }

        private void Stock_Loaded(object sender, RoutedEventArgs e)
        {
            KindOfEquipment.Items.Add("Процессор");
            KindOfEquipment.Items.Add("Материнская плата");
            KindOfEquipment.Items.Add("Оперативная память");
            KindOfEquipment.Items.Add("Жесткий диск");
            KindOfEquipment.Items.Add("Видео карта");
            KindOfEquipment.Items.Add("Корпус");
            KindOfEquipment.Items.Add("Монитор");

        }

        private void BtnAddEquipment_Click(object sender, RoutedEventArgs e)
        {
            //if(KindOfEquipment.SelectedItem.ToString()== "Процессор")
                
            //ListOfEquipment.Items.Add(TextAddEquipment.Text);

            switch (KindOfEquipment.SelectedItem.ToString())
            {
                case "Процессор":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            Processor processor = new Processor();
                            processor.ProcessorName = TextAddEquipment.Text;
                            processor.ProcessorPrice = Int32.Parse(TextPriceEquipment.Text);
                            db.Processors.Add(processor);
                            db.SaveChanges();
                        }
                        break;
                    }
                    //Запись в таблицу БД Процессоров
                case "Материнская плата":
                        {
                            using (CompStorEntity db = new CompStorEntity())
                            {
                                Motherboard motherboard = new Motherboard();
                                motherboard.MotherboardName = TextAddEquipment.Text;
                                motherboard.MotherboardPrice = Int32.Parse(TextPriceEquipment.Text);
                                db.Motherboards.Add(motherboard);
                                db.SaveChanges();
                            }
                            break;
                        }
                case "Оперативная память":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            RAM ram = new RAM();
                            ram.RAMName = TextAddEquipment.Text;
                            ram.RAMPrice = Int32.Parse(TextPriceEquipment.Text);
                            db.RAMs.Add(ram);
                            db.SaveChanges();
                        }
                        break;
                    }
                case "Жесткий диск":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            HardDisk hardDisk = new HardDisk();
                            hardDisk.HardDiskName = TextAddEquipment.Text;
                            hardDisk.HardDiskPrice = Int32.Parse(TextPriceEquipment.Text);
                            db.HardDisks.Add(hardDisk);
                            db.SaveChanges();
                        }
                        break;
                    }
                case "Видео карта": break;
                case "Корпус": break;
                case "Монитор": break;

            }

        }

        private void KindOfEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAllEquipment_Click(object sender, RoutedEventArgs e)
        {
            ListOfEquipment.Items.Clear();
            switch (KindOfEquipment.SelectedItem.ToString())
            {
                case "Процессор":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            foreach (var item in db.Processors)
                            {
                                ListOfEquipment.Items.Add(item.ProcessorName + " Цена: " + item.ProcessorPrice + " грн.");
                            }
                        }
                        break;
                    }
                case "Материнская плата":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            foreach (var item in db.Motherboards)
                            {
                                ListOfEquipment.Items.Add(item.MotherboardName + " Цена: " + item.MotherboardPrice + " грн.");
                            }
                        }
                        break;
                    }
                    
                //case:
                //    break;
                //case:
                //    break;
                //case:
                //    break;
                //case:
                //    break;
                //case:
                //    break;
                //case:
                //    break;
            }
                
        }
    }
}
