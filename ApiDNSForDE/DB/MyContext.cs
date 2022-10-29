using Microsoft.EntityFrameworkCore;

namespace ApiDNSForDE.DB
{
    public class MyContext : DbContext
    {
        public string cs = "Server=192.168.10.160; database=LockDns; user id = stud; password=stud";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(cs);
        }


        public DbSet<LockDNS> LockDNs { get; set; } 
    }
}
