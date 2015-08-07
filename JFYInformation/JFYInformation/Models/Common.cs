using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFYInformation.Models
{

    public enum CompanyStatu { Untreated, Lock, Treated }

    public enum Role { Clerk, Manager, System }

    public enum DealResult { Untreated, Pass, Deny }


    public class CommonDisply
    {
        public string[] CompanyStatuDisply = new string[] { "未处理", "锁定", "处理" };

        public string[] RoleDisply = new string[] { "职员", "经理", "管理员" };

        public string[] DealResultDisply = new string[] { "未处理", "通过", "拒绝" };
    }
}
