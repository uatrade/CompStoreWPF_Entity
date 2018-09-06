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

        private void BtnAddEquipment_Click(object sender, RoutedEventArgs e)   //Добавление на склад
        {
            switch (KindOfEquipment.SelectedItem.ToString())
            {
                case "Процессор":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            Processor processor = new Processor();
                            processor.ProcessorName = TextAddEquipment.Text;
                            processor.ProcessorPrice = Int32.Parse(TextPriceEquipment.Text);
                            processor.NumOfProcessor= Int32.Parse(TextNumEquipment.Text);
                            db.Processors.Add(processor);
                            db.SaveChanges();
                        }
                        MessageBox.Show($"{TextAddEquipment.Text} успешно добавлен на склад");
                        break;
                    }
                case "Материнская плата":
                        {
                            using (CompStorEntity db = new CompStorEntity())
                            {
                                Motherboard motherboard = new Motherboard();
                                motherboard.MotherboardName = TextAddEquipment.Text;
                                motherboard.MotherboardPrice = Int32.Parse(TextPriceEquipment.Text);
                                motherboard.NumOfMotherboard= Int32.Parse(TextNumEquipment.Text);
                                db.Motherboards.Add(motherboard);
                                db.SaveChanges();
                            }
                        MessageBox.Show($"{TextAddEquipment.Text} успешно добавлен на склад");
                        break;
                        }
                case "Оперативная память":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            RAM ram = new RAM();
                            ram.RAMName = TextAddEquipment.Text;
                            ram.RAMPrice = Int32.Parse(TextPriceEquipment.Text);
                            ram.NumOfRam= Int32.Parse(TextNumEquipment.Text);
                            db.RAMs.Add(ram);
                            db.SaveChanges();
                        }
                        MessageBox.Show($"{TextAddEquipment.Text} успешно добавлен на склад");
                        break;
                    }
                case "Жесткий диск":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            HardDisk hardDisk = new HardDisk();
                            hardDisk.HardDiskName = TextAddEquipment.Text;
                            hardDisk.HardDiskPrice = Int32.Parse(TextPriceEquipment.Text);
                            hardDisk.NumOfHardDisk= Int32.Parse(TextNumEquipment.Text);
                            db.HardDisks.Add(hardDisk);
                            db.SaveChanges();
                        }
                        MessageBox.Show($"{TextAddEquipment.Text} успешно добавлен на склад");
                        break;
                    }
                case "Видео карта":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            VideoCard videoCard = new VideoCard();
                            videoCard.VideoCardName = TextAddEquipment.Text;
                            videoCard.VideoCardPrice = Int32.Parse(TextPriceEquipment.Text);
                            videoCard.NumOfVideoCard = Int32.Parse(TextNumEquipment.Text);
                            db.VideoCards.Add(videoCard);
                            db.SaveChanges();
                        }
                        MessageBox.Show($"{TextAddEquipment.Text} успешно добавлен на склад");
                        break;
                    }
                case "Корпус":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            Case cases=new Case();
                            cases.CaseName = TextAddEquipment.Text;
                            cases.CasePrice = Int32.Parse(TextPriceEquipment.Text);
                            cases.NumOfCase = Int32.Parse(TextNumEquipment.Text);
                            db.Cases.Add(cases);
                            db.SaveChanges();
                        }
                        MessageBox.Show($"{TextAddEquipment.Text} успешно добавлен на склад");
                        break;
                    }
                case "Монитор":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            Monitor monitor = new Monitor();
                            monitor.MonitorName = TextAddEquipment.Text;
                            monitor.MonitorPrice = Int32.Parse(TextPriceEquipment.Text);
                            monitor.NumOfMonitor = Int32.Parse(TextNumEquipment.Text);
                            db.Monitors.Add(monitor);
                            db.SaveChanges();
                        }
                        MessageBox.Show($"{TextAddEquipment.Text} успешно добавлен на склад");
                        break;
                    }
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

                case "Оперативная память":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            foreach (var item in db.RAMs)
                            {
                                ListOfEquipment.Items.Add(item.RAMName + " Цена: " + item.RAMPrice + " грн." + " в наличии" + item.NumOfRam + " шт.");
                            }
                        }
                        break;
                    }
                case "Жесткий диск":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            foreach (var item in db.HardDisks)
                            {
                                ListOfEquipment.Items.Add(item.HardDiskName + " Цена: " + item.HardDiskPrice + " грн." + " в наличии" + item.NumOfHardDisk + " шт.");
                            }
                        }
                        break;
                    }
                case "Видео карта":
                        {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            foreach (var item in db.VideoCards)
                            {
                                ListOfEquipment.Items.Add(item.VideoCardName + " Цена: " + item.VideoCardPrice + " грн." + " в наличии" + item.NumOfVideoCard + " шт.");
                            }
                        }
                        break;
                        }
                case "Корпус":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            foreach (var item in db.Cases)
                            {
                                ListOfEquipment.Items.Add(item.CaseName + " Цена: " + item.CasePrice + " грн." + " в наличии" + item.NumOfCase + " шт.");
                            }
                        }
                        break;
                    }
                case "Монитор":
                    {
                        using (CompStorEntity db = new CompStorEntity())
                        {
                            foreach (var item in db.Monitors)
                            {
                                ListOfEquipment.Items.Add(item.MonitorName + " Цена: " + item.MonitorPrice + " грн." + " в наличии" + item.NumOfMonitor + " шт.");
                            }
                        }
                        break;
                    }

            }
                
        }
    }
}
