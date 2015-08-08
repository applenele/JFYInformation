using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFYInformation.Models
{
    public class DealRecord
    {
        public int ID { get; set; }

        [ForeignKey("Company")]
        public int CompanyID { get; set; }

        public virtual Company Company { get; set; }

        public DateTime Time { set; get; }

        [ForeignKey("User")]
        public int UID { get; set; }

        public virtual User User { set; get; }


        public int DealResultAsInt { get; set; }
        
        public string Hint { set; get; }

        [NotMapped]
        public DealResult DealResult
        {
            get { return (DealResult)DealResultAsInt; }
            set { DealResultAsInt = (int)value; }
        }
    }
}
