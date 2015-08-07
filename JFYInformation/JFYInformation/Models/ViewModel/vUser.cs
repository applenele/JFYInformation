using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFYInformation.Models.ViewModel
{
    public class vUser
    {
        public int ID { set; get; }

        public string Username { set; get; }

        public string Password { set; get; }

        public string Role { set; get; }
 
        public int RoleAsInt { set; get; }

        public byte[] Picture { set; get; }

        public DateTime Time { set; get; }

        public string RealName { set; get; }

        public string Phone { set; get; }

        public string Address { set; get; }

        public bool IsOff { set; get; }

        public vUser() { }

        public vUser(User model)
        {
            this.Username = model.Username;
            this.Password = model.Password;
            this.Role = CommonDisply.RoleDisply[model.RoleAsInt];
            this.Time = model.Time;
            this.RealName = model.RealName;
            this.Phone = model.Phone;
            this.Address = model.Address;
            this.RoleAsInt = model.RoleAsInt;
        }
    }
}
