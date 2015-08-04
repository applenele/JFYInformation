using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFYInformation.Models
{
    public class Company
    {
        public int ID { get; set; }

        public string CompanyName { get; set; }

        public string City { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contacts { set; get; }

        public string Phone { set; get; }

        public string Description { set; get; }


        public string Industry { set; get; }

        public string URL { set; get; }

        public DateTime Time { get; set; }
    }
}
