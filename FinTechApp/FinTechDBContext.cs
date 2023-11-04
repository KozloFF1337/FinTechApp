using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace FinTechApp
{
    internal class FinTechDBContext : DbContext
    {
        public DbSet<FinTechDB> FinTechDB { get; set; }
        public FinTechDBContext() : base("DefaultConnection") { }
    }
}
