using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStoreWPF.DataModel
{
    public class Monitor
    {
        [Key]
        public int MonitorId { get; set; }
        [MaxLength(50)]
        [Required]
        public string MonitorName { get; set; }
        [Required]
        public int MonitorPrice { get; set; }
        [Required]
        public int NumOfMonitor { get; set; }
    }
}
