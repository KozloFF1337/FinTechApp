using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace FinTechApp
{
    internal class FinTechDBRightContext : DbContext
    {
        public DbSet<FinTechDB> FinTechDB { get; set; }
        public FinTechDBRightContext() : base("RightConnection") { }
    }
}
