using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStoreWPF.DataModel
{
    public class Motherboard
    {
        [Key]
        public int MotherboardId { get; set; }

        [MaxLength(50)]
        [Required]
        public string MotherboardName { get; set; }
        [Required]
        public int MotherboardPrice { get; set; }
        [Required]
        public int NumOfMotherboard { get; set; }
    }
}
