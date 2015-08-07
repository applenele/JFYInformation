using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFYInformation.Models.ViewModel
{
    public class vCompany
    {
        public int ID { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Contacts { set; get; }

        public string Phone { set; get; }

        public string Description { set; get; }

        public string Industry { set; get; }

        public string URL { set; get; }

        public string Scale { set; get; }

        public string Property { set; get; }


        public DateTime? Time { set; get; }

        public string Statu { set; get; }


        public string Source { set; get; }

        public string DealResult { set; get; }


        public vCompany() { }

        public vCompany(Company model)
        {
            this.ID = model.ID;
            this.CompanyName = model.CompanyName;
            this.Address = model.Address;
            this.Contacts = model.Contacts;
            this.Phone = model.Source.Contains("58同城") ? "http://image.58.com/showphone.aspx?v=" + model.Phone : model.Phone;
            this.Description = model.Description;
            this.Industry = model.Industry;
            this.URL = model.URL;
            this.Property = model.Property;
            this.Scale = model.Scale;
            this.Time = model.Time;
            this.Statu = CommonDisply.CompanyStatuDisply[model.StatuAsInt];
            this.DealResult = CommonDisply.DealResultDisply[model.DealResultAsInt];
        }
    }
}
