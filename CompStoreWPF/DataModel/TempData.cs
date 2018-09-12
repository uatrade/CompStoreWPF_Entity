using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStoreWPF.DataModel
{
    class TempData
    {
        public string Title { get; set; }
        public int Num { get; set; }
        public int Price { get; set; }


        public TempData(string Title, int Num, int Price)
        {
            this.Title = Title;
            this.Num = Num;
            this.Price = Price;
        }
    }
}
