using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinancePrj.Models
{
    public partial class FinanceContext : DbContext
    {
        //public FinanceContext()
        //{
        //}

        public FinanceContext(DbContextOptions<FinanceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BankDetail> BankDetails { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<EmiCard> EmiCards { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-ATI7PU9\\MSSQLSERVER01;Database=Finance;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Admin__F3DBC573B012573D");

                entity.ToTable("Admin");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .HasColumnName("username");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.MobNo)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("mobNo");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<BankDetail>(entity =>
            {
                entity.HasKey(e => e.AccNo)
                    .HasName("PK__BankDeta__91CBCB53FD9B5E2D");

                entity.Property(e => e.AccNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Bank)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bank");

                entity.Property(e => e.CusNo).HasColumnName("CusNO");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.IfscCode)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("ifscCode");

                entity.HasOne(d => d.CusNoNavigation)
                    .WithMany(p => p.BankDetails)
                    .HasForeignKey(d => d.CusNo)
                    .HasConstraintName("FK__BankDetai__CusNO__32E0915F");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CusNo)
                    .HasName("PK__Customer__2F186963D057D14A");

                entity.ToTable("Customer");

                entity.HasIndex(e => e.PhnNo, "UQ__Customer__5AB97F8194A1E365")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Customer__AB6E61641E7CFAC2")
                    .IsUnique();

                entity.Property(e => e.CusNo).HasColumnName("CusNO");

                entity.Property(e => e.CardBalance).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Cardtype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cardtype");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .HasColumnName("email");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.PhnNo)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("PhnNO");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Validity)
                    .HasColumnType("date")
                    .HasColumnName("validity");
            });

            modelBuilder.Entity<EmiCard>(entity =>
            {
                entity.HasKey(e => e.Cardtype)
                    .HasName("PK__EmiCard__E26074B19F3A10BD");

                entity.ToTable("EmiCard");

                entity.Property(e => e.Cardtype)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CardLimit).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Img).IsUnicode(false);

                entity.Property(e => e.ProductCost).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.ProdId })
                    .HasName("PK__Purchase__33D762B128BF574B");

                entity.ToTable("Purchase");

                entity.Property(e => e.BookingId).ValueGeneratedOnAdd();

                entity.Property(e => e.ProdId).HasColumnName("ProdID");

                entity.Property(e => e.DueAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MonthlyAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PurchasedDate).HasColumnType("date");

                entity.HasOne(d => d.CusNoNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.CusNo)
                    .HasConstraintName("FK__Purchase__CusNo__2F10007B");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Purchase__ProdID__2E1BDC42");
            });

            modelBuilder.Entity<TransactionHistory>(entity =>
            {
                entity.HasKey(e => e.TrnId)
                    .HasName("PK__Transact__B3442DC69BFA124C");

                entity.ToTable("TransactionHistory");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.CusNo).HasColumnName("CusNO");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.CusNoNavigation)
                    .WithMany(p => p.TransactionHistories)
                    .HasForeignKey(d => d.CusNo)
                    .HasConstraintName("FK__Transacti__CusNO__37A5467C");

                entity.HasOne(d => d.Prd)
                    .WithMany(p => p.TransactionHistories)
                    .HasForeignKey(d => d.PrdId)
                    .HasConstraintName("FK__Transacti__PrdId__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
