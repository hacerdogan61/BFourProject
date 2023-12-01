using System;
using System.Reflection;
using System.Reflection.Metadata;
using Bfour.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bfour.Repository
{
    public class AppDbContex : DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex> options) : base(options)
        {
        }

        public DbSet<Member> Member { get; set; }

        public DbSet<MemberShip> MemberShip { get; set; }

        public DbSet<MemberAppointment> MemberAppointment { get; set; }

        public DbSet<MembershipHistory> MembershipHistory { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<PaymentType> PaymentType { get; set; }

        public DbSet<ProductDiscount> ProductDiscount { get; set; }
		public DbSet<Pos> Pos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<Member>().HasKey(x => x.Id);
            modelBuilder.Entity<MemberShip>().HasKey(x => x.Id);
            modelBuilder.Entity<MemberAppointment>().HasKey(x => x.Id);
            modelBuilder.Entity<MembershipHistory>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<PaymentType>().HasKey(x => x.Id);
			modelBuilder.Entity<Pos>().HasKey(x => x.Id);
			// Member ve Order ilişkisi
			modelBuilder.Entity<Order>()
                .HasOne(o => o.Member)
                .WithMany(m => m.Orders)
                .HasForeignKey(o => o.MemberId);

            // Order ve PaymentType ilişkisi
            modelBuilder.Entity<Order>()
                .HasOne(o => o.PaymentType)
                .WithMany()
                .HasForeignKey(o => o.PaymentTypeId);

            // Order ve OrderDetail ilişkisi
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            // OrderDetail ve Product ilişkisi
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);

            // Membership ve Member ilişkisi
            modelBuilder.Entity<MemberShip>()
                .HasOne(m => m.Member)
                .WithMany()
                .HasForeignKey(m => m.MemberId);

            // Membership ve Product ilişkisi
            modelBuilder.Entity<MemberShip>()
                .HasOne(m => m.Product)
                .WithMany(p => p.Memberships)
                .HasForeignKey(m => m.ProductId);

            // Membership ve OrderDetail ilişkisi
            modelBuilder.Entity<MemberShip>()
                .HasMany(m => m.OrderDetail)
                .WithOne(od=>od.Membership)
                .HasForeignKey(od => od.MemberShipId);

            // MembershipHistory ve Member ilişkisi
            modelBuilder.Entity<MembershipHistory>()
                .HasOne(mh => mh.Member)
                .WithMany()
                .HasForeignKey(mh => mh.MemberId);

            // MembershipHistory ve Product ilişkisi
            modelBuilder.Entity<MembershipHistory>()
                .HasOne(mh => mh.Product)
                .WithMany()
                .HasForeignKey(mh => mh.ProductId);

            // MemberAppointment ve Member ilişkisi
            modelBuilder.Entity<MemberAppointment>()
                .HasOne(ma => ma.Member)
                .WithMany()
                .HasForeignKey(ma => ma.MemberId);

            // MemberAppointment ve Product ilişkisi
            modelBuilder.Entity<MemberAppointment>()
                .HasOne(ma => ma.Product)
                .WithMany()
                .HasForeignKey(ma => ma.ProductId);

     
        }
    }
}