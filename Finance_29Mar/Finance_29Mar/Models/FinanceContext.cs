using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Finance_29Mar.Models
{
    public partial class FinanceContext : DbContext
    {
        public FinanceContext()
        {
        }

        public FinanceContext(DbContextOptions<FinanceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<CardStatus> CardStatuses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<EmiCard> EmiCards { get; set; }
        public virtual DbSet<LoginDetail> LoginDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI;Database=finance;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK__Admin__C6970A1015A858CE");

                entity.ToTable("Admin");

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

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<CardStatus>(entity =>
            {
                entity.HasKey(e => e.CardNo)
                    .HasName("PK__CardStat__55FF25F15E6DA5A6");

                entity.ToTable("CardStatus");

                entity.Property(e => e.Adminid).HasColumnName("adminid");

                entity.Property(e => e.CardBalance).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Cardtype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cardtype");

                entity.Property(e => e.Validity)
                    .HasColumnType("date")
                    .HasColumnName("validity");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.CardStatuses)
                    .HasForeignKey(d => d.Adminid)
                    .HasConstraintName("FK__CardStatu__admin__01142BA1");

                entity.HasOne(d => d.CusNoNavigation)
                    .WithMany(p => p.CardStatuses)
                    .HasForeignKey(d => d.CusNo)
                    .HasConstraintName("FK__CardStatu__CusNo__02084FDA");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CusNo)
                    .HasName("PK__Customer__2F18696342988BB8");

                entity.ToTable("Customer");

                entity.HasIndex(e => e.PhnNo, "UQ__Customer__5AB97F81EE1D800A")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Customer__AB6E6164A58A3231")
                    .IsUnique();

                entity.Property(e => e.CusNo).HasColumnName("CusNO");

                entity.Property(e => e.AccNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Bank)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bank");

                entity.Property(e => e.Cardtype)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cpassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("CPassword");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("email");

                entity.Property(e => e.IfscCode)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("ifscCode");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhnNo)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("PhnNO");

                entity.Property(e => e.ResetPasswordCode).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<EmiCard>(entity =>
            {
                entity.HasKey(e => e.Cardtype)
                    .HasName("PK__EmiCard__E26074B17FD9555F");

                entity.ToTable("EmiCard");

                entity.Property(e => e.Cardtype)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CardLimit).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<LoginDetail>(entity =>
            {
                entity.HasKey(e => e.Loginid)
                    .HasName("PK__LoginDet__1F5DF0A7232C233B");

                entity.Property(e => e.Loginid).HasColumnName("loginid");

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.ProductCost).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.StrikedCost).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.ProdId })
                    .HasName("PK__Purchase__33D762B105D18F5B");

                entity.ToTable("Purchase");

                entity.Property(e => e.BookingId).ValueGeneratedOnAdd();

                entity.Property(e => e.ProdId).HasColumnName("ProdID");

                entity.Property(e => e.DueAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MonthlyAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PurchasedDate).HasColumnType("date");

                entity.HasOne(d => d.CusNoNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.CusNo)
                    .HasConstraintName("FK__Purchase__CusNo__09A971A2");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Purchase__ProdID__08B54D69");
            });

            modelBuilder.Entity<TransactionHistory>(entity =>
            {
                entity.HasKey(e => e.TrnId)
                    .HasName("PK__Transact__B3442DC634F9611E");

                entity.ToTable("TransactionHistory");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.CusNo).HasColumnName("CusNO");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.CusNoNavigation)
                    .WithMany(p => p.TransactionHistories)
                    .HasForeignKey(d => d.CusNo)
                    .HasConstraintName("FK__Transacti__CusNO__0C85DE4D");

                entity.HasOne(d => d.Prd)
                    .WithMany(p => p.TransactionHistories)
                    .HasForeignKey(d => d.PrdId)
                    .HasConstraintName("FK__Transacti__PrdId__0D7A0286");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
