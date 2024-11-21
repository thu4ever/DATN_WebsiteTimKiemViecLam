using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DATN_WebsiteTimKiemViecLam.Models
{
    public partial class db_WebsiteTimkiemvieclamContext : DbContext
    {
        public db_WebsiteTimkiemvieclamContext()
        {
        }

        public db_WebsiteTimkiemvieclamContext(DbContextOptions<db_WebsiteTimkiemvieclamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBaituyendung> TblBaituyendungs { get; set; } = null!;
        public virtual DbSet<TblDoanhnghiep> TblDoanhnghieps { get; set; } = null!;
        public virtual DbSet<TblQuyen> TblQuyens { get; set; } = null!;
        public virtual DbSet<TblTaikhoan> TblTaikhoans { get; set; } = null!;
        public virtual DbSet<TblThongTinUngTuyen> TblThongTinUngTuyens { get; set; } = null!;
        public virtual DbSet<TblUngVien> TblUngViens { get; set; } = null!;
        public virtual DbSet<TblWebsite> TblWebsites { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-7CRV2HV\\SQLEXPRESS;Initial Catalog=db_WebsiteTimkiemvieclam;Integrated Security=True");
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CQAFHU8\\SQLEXPRESS;Initial Catalog=db_WebsiteTimkiemvieclam;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBaituyendung>(entity =>
            {
                entity.HasKey(e => e.PkSMaBai);

                entity.ToTable("tblBaituyendung");

                entity.Property(e => e.PkSMaBai).HasColumnName("PK_sMaBai");

                entity.Property(e => e.DTgDangBai)
                    .HasColumnType("date")
                    .HasColumnName("dTgDangBai");

                entity.Property(e => e.DTgTuyenDung)
                    .HasColumnType("date")
                    .HasColumnName("dTgTuyenDung");

                entity.Property(e => e.FMucLuongtoithieu).HasColumnName("fMucLuongtoithieu");

                entity.Property(e => e.FMucluongtoida).HasColumnName("fMucluongtoida");

                entity.Property(e => e.FNamKinhNghiem).HasColumnName("fNamKinhNghiem");

                entity.Property(e => e.FkSMaDn).HasColumnName("FK_sMaDN");

                entity.Property(e => e.ISoLuong).HasColumnName("iSoLuong");

                entity.Property(e => e.ITrangthai).HasColumnName("iTrangthai");

                entity.Property(e => e.SDiachicuthe).HasColumnName("sDiachicuthe");

                entity.Property(e => e.SMoTa).HasColumnName("sMoTa");

                entity.Property(e => e.SQuyenLoi).HasColumnName("sQuyenLoi");

                entity.Property(e => e.STenBai)
                    .HasMaxLength(100)
                    .HasColumnName("sTenBai");

                entity.Property(e => e.SYeuCau).HasColumnName("sYeuCau");

                entity.HasOne(d => d.FkSMaDnNavigation)
                    .WithMany(p => p.TblBaituyendungs)
                    .HasForeignKey(d => d.FkSMaDn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBaituyendung_tblDoanhnghiep");
            });

            modelBuilder.Entity<TblDoanhnghiep>(entity =>
            {
                entity.HasKey(e => e.PkSMaDn);

                entity.ToTable("tblDoanhnghiep");

                entity.Property(e => e.PkSMaDn).HasColumnName("PK_sMaDN");

                entity.Property(e => e.FkSEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FK_sEmail");

                entity.Property(e => e.SDiachi)
                    .HasMaxLength(200)
                    .HasColumnName("sDiachi");

                entity.Property(e => e.SLogo)
                    .IsUnicode(false)
                    .HasColumnName("sLogo");

                entity.Property(e => e.SMasothue).HasColumnName("sMasothue");

                entity.Property(e => e.SMota).HasColumnName("sMota");

                entity.Property(e => e.SSdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sSDT");

                entity.Property(e => e.STenDn)
                    .HasMaxLength(100)
                    .HasColumnName("sTenDN");

                entity.HasOne(d => d.FkSEmailNavigation)
                    .WithMany(p => p.TblDoanhnghieps)
                    .HasForeignKey(d => d.FkSEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDoanhnghiep_tblTaikhoan");
            });

            modelBuilder.Entity<TblQuyen>(entity =>
            {
                entity.HasKey(e => e.PkSMaQuyen);

                entity.ToTable("tblQuyen");

                entity.Property(e => e.PkSMaQuyen).HasColumnName("PK_sMaQuyen");

                entity.Property(e => e.BTrangThai).HasColumnName("bTrangThai");

                entity.Property(e => e.STenQuyen)
                    .HasMaxLength(50)
                    .HasColumnName("sTenQuyen");
            });

            modelBuilder.Entity<TblTaikhoan>(entity =>
            {
                entity.HasKey(e => e.PkSEmail);

                entity.ToTable("tblTaikhoan");

                entity.Property(e => e.PkSEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PK_sEmail");

                entity.Property(e => e.FkSMaQuyen).HasColumnName("FK_sMaQuyen");

                entity.Property(e => e.SMatkhau)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sMatkhau");

                entity.HasOne(d => d.FkSMaQuyenNavigation)
                    .WithMany(p => p.TblTaikhoans)
                    .HasForeignKey(d => d.FkSMaQuyen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTaikhoan_tblQuyen");
            });

            modelBuilder.Entity<TblThongTinUngTuyen>(entity =>
            {
                entity.HasKey(e => new { e.PkFkSMaUngVien, e.PkFkSMaBai })
                    .HasName("PK_tblThongTinUnTuyen");

                entity.ToTable("tblThongTinUngTuyen");

                entity.Property(e => e.PkFkSMaUngVien).HasColumnName("PK_FK_sMaUngVien");

                entity.Property(e => e.PkFkSMaBai).HasColumnName("PK_FK_sMaBai");

                entity.Property(e => e.BTrangthai).HasColumnName("bTrangthai");

                entity.Property(e => e.DNgayGui)
                    .HasColumnType("date")
                    .HasColumnName("dNgayGui");

                entity.Property(e => e.SCv)
                    .IsUnicode(false)
                    .HasColumnName("sCV");

                entity.Property(e => e.SGioithieu)
                    .HasMaxLength(200)
                    .HasColumnName("sGioithieu");

                entity.HasOne(d => d.PkFkSMaBaiNavigation)
                    .WithMany(p => p.TblThongTinUngTuyens)
                    .HasForeignKey(d => d.PkFkSMaBai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblThongTinUngTuyen_tblBaituyendung");

                entity.HasOne(d => d.PkFkSMaUngVienNavigation)
                    .WithMany(p => p.TblThongTinUngTuyens)
                    .HasForeignKey(d => d.PkFkSMaUngVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblThongTinUngTuyen_tblUngVien");
            });

            modelBuilder.Entity<TblUngVien>(entity =>
            {
                entity.HasKey(e => e.PkSMaUngVien);

                entity.ToTable("tblUngVien");

                entity.Property(e => e.PkSMaUngVien).HasColumnName("PK_sMaUngVien");

                entity.Property(e => e.BGioiTinh).HasColumnName("bGioiTinh");

                entity.Property(e => e.FkSEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FK_sEmail");

                entity.Property(e => e.SAnh)
                    .IsUnicode(false)
                    .HasColumnName("sAnh");

                entity.Property(e => e.SHoTen)
                    .HasMaxLength(50)
                    .HasColumnName("sHoTen");

                entity.Property(e => e.SSdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sSDT");

                entity.HasOne(d => d.FkSEmailNavigation)
                    .WithMany(p => p.TblUngViens)
                    .HasForeignKey(d => d.FkSEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CustomerID");
            });

            modelBuilder.Entity<TblWebsite>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblWebsite");

                entity.Property(e => e.FkSMaDn).HasColumnName("FK_sMaDN");

                entity.Property(e => e.PkSMaWebsite).HasColumnName("PK_sMaWebsite");

                entity.Property(e => e.SLink)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sLink");

                entity.Property(e => e.STenWebsite)
                    .HasMaxLength(200)
                    .HasColumnName("sTenWebsite");

                entity.HasOne(d => d.FkSMaDnNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkSMaDn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWebsite_tblDoanhnghiep");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
