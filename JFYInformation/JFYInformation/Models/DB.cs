using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFYInformation.Models
{
    public class DB : DbContext
    {
        public DB() : base("sqlserverdb") { }
        public DbSet<Company> Companies { set; get; }
    }
}
