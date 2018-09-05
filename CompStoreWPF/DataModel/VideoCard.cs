using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompStoreWPF.DataModel
{
    public class VideoCard
    {
        [Key]
        public int VideoCardId { get; set; }

        [MaxLength(50)]
        [Required]
        public string VideoCardName { get; set; }
        [Required]
        public int VideoCardPrice { get; set; }
        [Required]
        public int NumOfVideoCard { get; set; }
    }
}
