using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFYInformation.Models
{
    public class City
    {
        public int ID { get; set; }

        [Required]
        [StringLength(40)]
        public string Province { get; set; }

        [Required]
        [StringLength(40)]
        public string CityName { get; set; }

        public DateTime Time { get; set; }
    }
}
