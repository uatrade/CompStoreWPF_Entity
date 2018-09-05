using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStoreWPF.DataModel
{
    public class RAM
    {
        [Key]
        public int RAMId { get; set; }

        [MaxLength(50)]
        [Required]
        public string RAMName { get; set; }
        [Required]
        public int RAMPrice { get; set; }
        [Required]
        public int NumOfRam { get; set; }
    }
}
