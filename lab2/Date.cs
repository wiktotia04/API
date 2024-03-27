using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class info_walut
    {
        [Key]
        public int Index { get; set; }   
        public  string WalutaDb { get; set; }
        public  double WartoscDb { get; set; }

    }

    public class kantor : DbContext
    {
        public virtual DbSet<info_walut> Baza_Danych { get; set; }

        public kantor ()
        {
            
            Database.EnsureCreated();
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source = C:\Users\sarni\Desktop\lab2\lab2\Univ2.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<info_walut>(entity =>
            {
                entity.HasKey(e => e.Index);
                entity.Property(e => e.WalutaDb).IsRequired();
                entity.Property(e => e.WartoscDb).IsRequired();
            });
        }
    }

}
