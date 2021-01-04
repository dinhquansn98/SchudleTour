namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SchudletourDbContext : DbContext
    {
        public SchudletourDbContext()
            : base("name=Model12")
        {
        }

        public virtual DbSet<Diachi> Diachis { get; set; }
        public virtual DbSet<Diadiemthamquan> Diadiemthamquans { get; set; }
        public virtual DbSet<Dichvu> Dichvus { get; set; }
        public virtual DbSet<DichvuNcc> DichvuNccs { get; set; }
        public virtual DbSet<Hoten> Hotens { get; set; }
        public virtual DbSet<Lichtrinh> Lichtrinhs { get; set; }
        public virtual DbSet<LichtrinhDVNCC> LichtrinhDVNCCs { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Thanhvien> Thanhviens { get; set; }
        public virtual DbSet<ThoigianCCDD> ThoigianCCDDs { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diachi>()
                .Property(e => e.Toanha)
                .IsUnicode(false);

            modelBuilder.Entity<Diachi>()
                .Property(e => e.Phuongxa)
                .IsUnicode(false);

            modelBuilder.Entity<Diachi>()
                .Property(e => e.Quanhuyen)
                .IsUnicode(false);

            modelBuilder.Entity<Diachi>()
                .Property(e => e.Tinhthanh)
                .IsUnicode(false);

            modelBuilder.Entity<Diachi>()
                .HasMany(e => e.Nhacungcaps)
                .WithOptional(e => e.Diachi)
                .HasForeignKey(e => e.diachiID);

            modelBuilder.Entity<Diachi>()
                .HasMany(e => e.Diadiemthamquans)
                .WithOptional(e => e.Diachi)
                .HasForeignKey(e => e.Idddiachi);

            modelBuilder.Entity<Diadiemthamquan>()
                .Property(e => e.DiadiemName)
                .IsUnicode(false);

            modelBuilder.Entity<Diadiemthamquan>()
                .Property(e => e.Mota)
                .IsUnicode(false);

            modelBuilder.Entity<Dichvu>()
                .HasMany(e => e.LichtrinhDVNCCs)
                .WithOptional(e => e.Dichvu)
                .HasForeignKey(e => e.IDDichvu);

            modelBuilder.Entity<DichvuNcc>()
                .Property(e => e.Mota)
                .IsUnicode(false);

            modelBuilder.Entity<Hoten>()
                .Property(e => e.Ho)
                .IsUnicode(false);

            modelBuilder.Entity<Hoten>()
                .Property(e => e.Tendem)
                .IsUnicode(false);

            modelBuilder.Entity<Hoten>()
                .Property(e => e.Ten)
                .IsUnicode(false);

            modelBuilder.Entity<Lichtrinh>()
                .HasMany(e => e.ThoigianCCDDs)
                .WithOptional(e => e.Lichtrinh)
                .HasForeignKey(e => e.IDLichtrinh);

            modelBuilder.Entity<Nhacungcap>()
                .Property(e => e.NccName)
                .IsUnicode(false);

            modelBuilder.Entity<Nhacungcap>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<Nhacungcap>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Nhanvien>()
                .Property(e => e.Vitri)
                .IsUnicode(false);

            modelBuilder.Entity<Thanhvien>()
                .Property(e => e.Usename)
                .IsUnicode(false);

            modelBuilder.Entity<Thanhvien>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Thanhvien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<Thanhvien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Thanhvien>()
                .Property(e => e.Ghichu)
                .IsUnicode(false);
        }
    }
}
