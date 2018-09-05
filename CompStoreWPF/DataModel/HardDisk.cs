﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStoreWPF.DataModel
{
    public class HardDisk
    {
        [Key]
        public int HardDiskId { get; set; }
        [MaxLength(50)]
        [Required]
        public string HardDiskName { get; set; }
        [Required]
        public int HardDiskPrice { get; set; }
        [Required]
        public int NumOfHardDisk { get; set; }
    }
}
