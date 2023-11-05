using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace FinTechApp
{
    internal class FinTechContext : DbContext
    {
        public DbSet<FinTech> FinTech { get; set; }
        public DbSet<FinTechRight> FinTechRight { get; set; }
        public FinTechContext() : base("DefaultConnection") { }
    }
}
