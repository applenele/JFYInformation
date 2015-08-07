using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFYInformation.Models
{

    public enum CompanyStatu { Untreated, Lock, Treated }
    public class CommonDisply
    {
        public string[] CompanyStatuDisply = new string[] { "未处理", "锁定", "处理" };
    }
}
