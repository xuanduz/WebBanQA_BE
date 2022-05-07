using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebBanQA.Models
{
    public partial class QLCuaHangBanQAContext : DbContext
    {
        public QLCuaHangBanQAContext()
        {
        }

        public QLCuaHangBanQAContext(DbContextOptions<QLCuaHangBanQAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Cartdetum> Cartdeta { get; set; } = null!;
        public virtual DbSet<Catalog> Catalogs { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<Style> Styles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-C1PHLHJ\\SQLEXPRESS;Database=QLCuaHangBanQA;Trusted_Connection=True");
                //optionsBuilder.UseSqlServer("Server=tcp:xuanduzdbserver.database.windows.net,1433;Initial Catalog=QLCuaHangBanQA;User ID=xuanduz;Password=Nxd942k1;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PK__Cart__7D17AAACE46B3E54");

                entity.ToTable("Cart");

                entity.Property(e => e.CarId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CAR_id");

                entity.Property(e => e.CarDate)
                    .HasColumnType("datetime")
                    .HasColumnName("car_date");

                entity.Property(e => e.CarSelect)
                    .HasMaxLength(20)
                    .HasColumnName("CAR_select");

                entity.Property(e => e.CarStatus)
                    .HasMaxLength(20)
                    .HasColumnName("CAR_status");

                entity.Property(e => e.CarUid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CAR_UID");

                entity.HasOne(d => d.CarU)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CarUid)
                    .HasConstraintName("FK__Cart__CAR_UID__5441852A");
            });

            modelBuilder.Entity<Cartdetum>(entity =>
            {
                entity.HasKey(e => e.CdId)
                    .HasName("PK__Cartdeta__3A09C183B671D060");

                entity.Property(e => e.CdId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CD_id");

                entity.Property(e => e.CdAmount).HasColumnName("CD_amount");

                entity.Property(e => e.CdCarId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CD_CarID");

                entity.Property(e => e.CdColslug)
                    .HasMaxLength(20)
                    .HasColumnName("CD_COLslug");

                entity.Property(e => e.CdPid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CD_PID");

                entity.Property(e => e.CdSName)
                    .HasMaxLength(20)
                    .HasColumnName("CD_S_name");

                entity.HasOne(d => d.CdCar)
                    .WithMany(p => p.Cartdeta)
                    .HasForeignKey(d => d.CdCarId)
                    .HasConstraintName("FK__Cartdeta__CD_Car__5DCAEF64");

                entity.HasOne(d => d.CdP)
                    .WithMany(p => p.Cartdeta)
                    .HasForeignKey(d => d.CdPid)
                    .HasConstraintName("FK__Cartdeta__CD_PID__5CD6CB2B");
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.HasKey(e => e.CaId)
                    .HasName("PK__catalog__705679CC3107F07F");

                entity.ToTable("catalog");

                entity.Property(e => e.CaId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CA_id");

                entity.Property(e => e.CaName)
                    .HasMaxLength(200)
                    .HasColumnName("CA_name");

                entity.Property(e => e.CaStid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CA_STID");

                entity.HasOne(d => d.CaSt)
                    .WithMany(p => p.Catalogs)
                    .HasForeignKey(d => d.CaStid)
                    .HasConstraintName("FK__catalog__CA_STID__47DBAE45");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.ColId)
                    .HasName("PK__Color__F30C209384157E07");

                entity.ToTable("Color");

                entity.Property(e => e.ColId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COL_id");

                entity.Property(e => e.ColName)
                    .HasMaxLength(200)
                    .HasColumnName("COL_name");

                entity.Property(e => e.ColPid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COL_PID");

                entity.Property(e => e.ColSlug)
                    .HasMaxLength(100)
                    .HasColumnName("COL_slug");

                entity.HasOne(d => d.ColP)
                    .WithMany(p => p.Colors)
                    .HasForeignKey(d => d.ColPid)
                    .HasConstraintName("FK__Color__COL_PID__5165187F");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.ComId)
                    .HasName("PK__Comment__FAC429380DBA16E2");

                entity.ToTable("Comment");

                entity.Property(e => e.ComId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COM_id");

                entity.Property(e => e.ComContent)
                    .HasMaxLength(300)
                    .HasColumnName("COM_content");

                entity.Property(e => e.ComPid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COM_PID");

                entity.Property(e => e.ComUid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COM_UID");

                entity.HasOne(d => d.ComP)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ComPid)
                    .HasConstraintName("FK__Comment__COM_PID__59FA5E80");

                entity.HasOne(d => d.ComU)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ComUid)
                    .HasConstraintName("FK__Comment__COM_UID__59063A47");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__Product__A3410E4F5858FD42");

                entity.ToTable("Product");

                entity.HasIndex(e => e.PName, "UQ__Product__90F077213C66A06C")
                    .IsUnique();

                entity.Property(e => e.PId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("P_id");

                entity.Property(e => e.PAmount).HasColumnName("P_amount");

                entity.Property(e => e.PCaid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("P_CAID");

                entity.Property(e => e.PContent)
                    .HasMaxLength(2000)
                    .HasColumnName("P_content");

                entity.Property(e => e.PDiscount).HasColumnName("P_discount");

                entity.Property(e => e.PImage)
                    .HasMaxLength(300)
                    .HasColumnName("P_image");

                entity.Property(e => e.PName)
                    .HasMaxLength(200)
                    .HasColumnName("P_name");

                entity.Property(e => e.PNote)
                    .HasMaxLength(2000)
                    .HasColumnName("P_note");

                entity.Property(e => e.PPrice)
                    .HasColumnType("money")
                    .HasColumnName("P_Price");

                entity.Property(e => e.PSlug)
                    .HasMaxLength(100)
                    .HasColumnName("P_slug");

                entity.HasOne(d => d.PCa)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.PCaid)
                    .HasConstraintName("FK__Product__P_CAID__4BAC3F29");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("PK__Size__A3DCCCA5BB159E01");

                entity.ToTable("Size");

                entity.Property(e => e.SId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("S_id");

                entity.Property(e => e.SName)
                    .HasMaxLength(200)
                    .HasColumnName("S_name");

                entity.Property(e => e.SPid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("S_PID");

                entity.HasOne(d => d.SP)
                    .WithMany(p => p.Sizes)
                    .HasForeignKey(d => d.SPid)
                    .HasConstraintName("FK__Size__S_PID__4E88ABD4");
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.HasKey(e => e.StId)
                    .HasName("PK__style__EBD417B704D52E6C");

                entity.ToTable("style");

                entity.HasIndex(e => e.StName, "UQ__style__BBD70BFAE6373804")
                    .IsUnique();

                entity.Property(e => e.StId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ST_id");

                entity.Property(e => e.StName)
                    .HasMaxLength(200)
                    .HasColumnName("ST_name");

                entity.Property(e => e.StSlug)
                    .HasMaxLength(200)
                    .HasColumnName("ST_slug");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__Users__5A396513903947BC");

                entity.HasIndex(e => e.UName, "UQ__Users__153E89F83E9C244B")
                    .IsUnique();

                entity.HasIndex(e => e.UContact, "UQ__Users__7F892826A002B50F")
                    .IsUnique();

                entity.HasIndex(e => e.UEmail, "UQ__Users__BD4E74B49D2B66B6")
                    .IsUnique();

                entity.Property(e => e.UId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("U_id");

                entity.Property(e => e.UAdd)
                    .HasMaxLength(200)
                    .HasColumnName("U_add");

                entity.Property(e => e.UContact)
                    .HasMaxLength(200)
                    .HasColumnName("U_contact");

                entity.Property(e => e.UCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("U_created");

                entity.Property(e => e.UEmail)
                    .HasMaxLength(200)
                    .HasColumnName("U_email");

                entity.Property(e => e.UFname)
                    .HasMaxLength(200)
                    .HasColumnName("U_Fname");

                entity.Property(e => e.ULname)
                    .HasMaxLength(200)
                    .HasColumnName("U_Lname");

                entity.Property(e => e.UName)
                    .HasMaxLength(200)
                    .HasColumnName("U_name");

                entity.Property(e => e.UPass)
                    .HasMaxLength(200)
                    .HasColumnName("U_pass");

                entity.Property(e => e.UStatus)
                    .HasMaxLength(10)
                    .HasColumnName("U_status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
