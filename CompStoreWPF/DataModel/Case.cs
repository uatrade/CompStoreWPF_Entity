using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStoreWPF.DataModel
{
   public class Case
    {
        [Key]
        public int CaseId { get; set; }
        [MaxLength(50)]
        [Required]
        public string CaseName { get; set; }
        [Required]
        public int CasePrice { get; set; }
        [Required]
        public int NumOfCase { get; set; }
    }
}
