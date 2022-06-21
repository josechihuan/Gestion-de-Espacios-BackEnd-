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

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<WorkPlace> WorkPlaces { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasOne(x => x.RoleId);
           
            // PREGUNTAR A CESAR PARA OPTIMIZAR ESTE COGIDO
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasOne(x => x.DepartmentId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>()
                .HasOne(x => x.CompanyId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WorkPlace>()
                .HasOne(x => x.OfficeId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.WorkPlaceId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.UserId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.MeetingId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Office>()
                .HasMany(x => x.WorkPlaces);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>()
                .HasMany(x => x.Departments);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>()
                .HasMany(x => x.Users);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WorkPlace>()
                .HasMany(x => x.Reservations);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Meeting>()
                .HasMany(x => x.Reservations);

        }

    }
}
