using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelEF.Model
{
    public partial class NguyenNgocHuyContext : DbContext
    {
        public NguyenNgocHuyContext()
            : base("name=NguyenNgocHuyContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserInRole> UserInRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.idCategory)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.idProduct)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.idCategory)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Unicost)
                .HasPrecision(18, 0);

          

            modelBuilder.Entity<Product>()
                .Property(e => e.Year);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserInRoles)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.idRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .HasMany(e => e.UserInRoles)
                .WithRequired(e => e.UserAccount)
                .HasForeignKey(e => e.idAccount)
                .WillCascadeOnDelete(false);
        }
    }
}
