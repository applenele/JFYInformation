using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFYInformation.Models
{
    public class User
    {
        public int ID { set; get; }

        [Required]
        public string Username { set; get; }

        [Required]
        public string Password { set; get; }

        public int RoleAsInt { set; get; }

        [NotMapped]
        public Role Role
        {
            set { RoleAsInt = (int)value; }
            get { return (Role)RoleAsInt; }
        }

        public byte[] Picture { set; get; }

        public DateTime Time { set; get; }

        public string RealName { set; get; }
    }
}
