using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Context
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            // Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Attributesss> Attribute { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerBillingAddress> CustomerBillingAddress { get; set; }
        public DbSet<CustomerShippingAddress> CustomerShippingAddress { get; set; }
        public DbSet<OrderTable> OrderTable { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<MobileBanking> MobileBanking { get; set; }
        public DbSet<CardInformation> CardInformation { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attributesss>(entity =>
            {
                entity.HasKey(e => e.AttributeId);
                entity.Property(p => p.AttributeName).IsRequired();
                entity.Property(p => p.AttributeValue).IsRequired();
                entity.Property(p => p.Status).IsRequired();

            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.BrandId);
                entity.Property(p => p.BrandName).IsRequired();
                entity.Property(p => p.Image).IsRequired();
                entity.Property(p => p.Status).IsRequired();
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoriesId);
                entity.Property(p => p.CategoriesName).IsRequired();
                entity.Property(p => p.Image).IsRequired();
                entity.Property(p => p.Status).IsRequired();
            });

            //modelBuilder.Entity<Cart>(entity =>
            //{
            //    entity.HasKey(e => e.CartId);
            //    entity.HasOne(o => o.Customer)
            //    .WithMany(m => m.Cart)
            //    .HasForeignKey(f => f.CustomerId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //    entity.HasOne(o => o.Product)
            //    .WithOne(o => o.Cart)
            //    .HasForeignKey<Cart>(f => f.ProductId);

            //});

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);
                entity.Property(p => p.CustomerName).IsRequired();
                entity.Property(p => p.Email).IsRequired();
                entity.Property(p => p.Password).IsRequired();
                entity.Property(p => p.MobileNo).IsRequired();
                entity.Property(p => p.MobileNo).IsRequired();
            });

            modelBuilder.Entity<CustomerBillingAddress>(entity =>
            {
                entity.HasKey(e => e.BillingAddressId);
                entity.Property(p => p.StreetAddress).IsRequired();
                entity.Property(p => p.PostalCode).IsRequired();
                entity.Property(p => p.District).IsRequired();

                entity.HasOne(o => o.Customer)
                .WithMany(m => m.CustomerBillingAddress)
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<CustomerShippingAddress>(entity =>
            {
                entity.HasKey(e => e.ShippingAddressId);
                entity.Property(p => p.StreetAddress).IsRequired();
                entity.Property(p => p.PostalCode).IsRequired();
                entity.Property(p => p.District).IsRequired();

                entity.HasOne(o => o.Customer)
                .WithMany(m => m.CustomerShippingAddress)
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderTable>(entity =>
            {
                entity.HasKey(e => e.BillId);
                entity.Property(p => p.Quantity).IsRequired();
                entity.Property(p => p.BillAmount);

                entity.HasOne(o => o.Customer)
                .WithOne(o => o.OrderTable)
                .HasForeignKey<OrderTable>(f => f.CustomerId);

                entity.HasOne(o => o.Product)
                .WithOne(o => o.OrderTable)
                .HasForeignKey<OrderTable>(f => f.ProductId);
            });

            modelBuilder.Entity<Payment>(entity =>
            {

                entity.HasKey(e => e.PaymentId);
                entity.Property(d => d.OrderId);
                entity.Property(d => d.PaymentMethod);

                entity.HasOne(e => e.OrderTable)
               .WithOne(e => e.Payment)
               .HasForeignKey<Payment>(e => e.OrderId);
            });


            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);
                entity.Property(p => p.Description).IsRequired();
                entity.Property(p => p.ProductCode).IsRequired();
                entity.Property(p => p.StockQuantity).IsRequired();
                entity.Property(p => p.Image).IsRequired();
                entity.Property(p => p.RegularPrice).IsRequired();
                entity.Property(p => p.DiscountPrice);

                entity.HasOne(o => o.Attribute)
                .WithMany(m => m.Product)
                .HasForeignKey(f => f.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(o => o.Brand)
                .WithMany(m => m.Product)
                .HasForeignKey(f => f.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(o => o.Categories)
                .WithMany(m => m.Product)
                .HasForeignKey(f => f.CategoriesId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);
                entity.Property(d => d.RoleName).IsRequired();
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId);
                entity.HasOne(p => p.User)
                .WithMany(d => d.UserRole)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Role)
                .WithMany(d => d.UserRole)
                .HasForeignKey(p => p.RoleId)
                .OnDelete(DeleteBehavior.Cascade);


            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(d => d.UserName).IsRequired();
                entity.Property(d => d.Email).IsRequired();
                entity.Property(d => d.Password).IsRequired();
                entity.Property(d => d.UserType).IsRequired();
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.TagId);
                entity.Property(p => p.TagName).IsRequired();

            });

            modelBuilder.Entity<CardInformation>(entity =>
            {
                entity.HasKey(e => e.CardInformationId);
                entity.Property(d => d.CardNumber);
                entity.Property(d => d.Balance);

            });

            modelBuilder.Entity<MobileBanking>(entity =>
            {
                entity.HasKey(e => e.MobileBankingId);
                entity.Property(d => d.MobileNo);
                entity.Property(d => d.Pin);
                entity.Property(d => d.Balance);
            });
        }
    }
}
