using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFYInformation.Models
{

    /// <summary>
    /// 公司实体
    /// </summary>
    public class Company
    {
        public int ID { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contacts { set; get; }

        public string Phone { set; get; }

        public string Description { set; get; }

        /// <summary>
        /// 行业
        /// </summary>
        public string Industry { set; get; }

        /// <summary>
        ///  URL
        /// </summary>
        public string URL { set; get; }

        /// <summary>
        /// 规模
        /// </summary>
        [StringLength(100)]
        public string Scale { set; get; }

        /// <summary>
        /// 性质
        /// </summary>
        [StringLength(100)]
        public string Property { set; get; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? Time { get; set; }


        public int StatuAsInt { set; get; }

        public string Source { set; get; }

        public int DealResultAsInt { set; get; }

        [NotMapped]
        public DealResult DealResult
        {
            set { DealResultAsInt = (int)value; }
            get { return (DealResult)DealResultAsInt; }
        }

        [NotMapped]
        public CompanyStatu CompanyStatu
        {
            set { StatuAsInt = (int)value; }
            get { return (CompanyStatu)StatuAsInt; }
        }

    }
}
