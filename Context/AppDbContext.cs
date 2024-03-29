﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .OwnsOne(o => o.Range,
                sa =>
                {
                    sa.Property(p => p.From).HasColumnName("From");
                    sa.Property(p => p.To).HasColumnName("To");
                });
            
            modelBuilder.Entity<Faculty>()
                .OwnsOne(o => o.WorkingHours,
                    sa =>
                    {
                        sa.Property(p => p.Opens).HasColumnName("Opens");
                        sa.Property(p => p.Closes).HasColumnName("Closes");
                    });

            modelBuilder.Entity<Room>()
                .HasOne<Faculty>()
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.FacultyId);

            modelBuilder.Entity<Desk>()
                .HasOne<Room>()
                .WithMany(x => x.Desks)
                .HasForeignKey(x => x.RoomId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
