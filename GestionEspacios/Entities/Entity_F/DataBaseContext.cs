
using Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity_F
{
    public class DataBaseContext : IdentityDbContext<IdentityUser>   
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) 
        { }

      
       /*protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Data Source= LAPTOP-SL4OFHD4\\SQLEXPRESS;Initial Catalog=GestionEspacios;Integrated Security=True");

        }  */

      
        public DbSet<WorkPlace> WorkPlaces { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
               
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.WorkPlace);
                   

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.Meeting);
                          

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WorkPlace>()
                .HasMany(x => x.Reservations);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Meeting>()
                .HasMany(x => x.Reservations);

       
            
        }

    }
}
