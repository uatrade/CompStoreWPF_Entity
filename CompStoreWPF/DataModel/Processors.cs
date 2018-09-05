using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompStoreWPF.DataModel;

namespace CompStoreWPF.DataModel
{
    public class Processor
    {
        [Key]
        public int ProcessorsId { get; set; }

        [MaxLength(40)]
        [Required]
        public string ProcessorName { get; set; }
        [Required]
        public int ProcessorPrice { get; set; }
        [Required]
        public int NumOfProcessor { get; set; }
    }
}
