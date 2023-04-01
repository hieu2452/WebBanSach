using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebBanSach.Models;

public partial class DbBookStoreContext : DbContext
{
    public DbBookStoreContext()
    {
    }

    public DbBookStoreContext(DbContextOptions<DbBookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TChiTietHoaDon> TChiTietHoaDons { get; set; }

    public virtual DbSet<THoaDon> THoaDons { get; set; }

    public virtual DbSet<TKho> TKhos { get; set; }

    public virtual DbSet<TNgonNgu> TNgonNgus { get; set; }

    public virtual DbSet<TNhaXuatBan> TNhaXuatBans { get; set; }

    public virtual DbSet<TSach> TSaches { get; set; }

    public virtual DbSet<TSachKho> TSachKhos { get; set; }

    public virtual DbSet<TTheLoai> TTheLoais { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    public virtual DbSet<TUserRole> TUserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HIEUXUOG;Initial Catalog=DB_BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaSach });

            entity.ToTable("tChiTietHoaDon");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.TChiTietHoaDons)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHoaDon_tHoaDon");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.TChiTietHoaDons)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHoaDon_tSach");
        });

        modelBuilder.Entity<THoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd);

            entity.ToTable("tHoaDon");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.THoaDons)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK_tHoaDon _tUser");
        });

        modelBuilder.Entity<TKho>(entity =>
        {
            entity.HasKey(e => e.MaKho);

            entity.ToTable("tKho");

            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.TenKho).HasMaxLength(100);
        });

        modelBuilder.Entity<TNgonNgu>(entity =>
        {
            entity.HasKey(e => e.MaNg);

            entity.ToTable("tNgonNgu");

            entity.Property(e => e.MaNg).HasColumnName("MaNG");
            entity.Property(e => e.Mota).HasMaxLength(100);
        });

        modelBuilder.Entity<TNhaXuatBan>(entity =>
        {
            entity.HasKey(e => e.MaNxb);

            entity.ToTable("tNhaXuatBan");

            entity.Property(e => e.MaNxb).HasColumnName("MaNXB");
            entity.Property(e => e.TenNxb)
                .HasMaxLength(100)
                .HasColumnName("TenNXB");
            entity.Property(e => e.Url).HasMaxLength(100);
        });

        modelBuilder.Entity<TSach>(entity =>
        {
            entity.HasKey(e => e.MaSach);

            entity.ToTable("tSach");

            entity.Property(e => e.Anh).HasMaxLength(1000);
            entity.Property(e => e.MaNg).HasColumnName("MaNG");
            entity.Property(e => e.MaNxb).HasColumnName("MaNXB");
            entity.Property(e => e.MaTl).HasColumnName("MaTL");
            entity.Property(e => e.Mota).HasMaxLength(500);
            entity.Property(e => e.TacGia).HasMaxLength(100);
            entity.Property(e => e.TenSach).HasMaxLength(100);

            entity.HasOne(d => d.MaNgNavigation).WithMany(p => p.TSaches)
                .HasForeignKey(d => d.MaNg)
                .HasConstraintName("FK_tSach _tNgonNgu");

            entity.HasOne(d => d.MaNxbNavigation).WithMany(p => p.TSaches)
                .HasForeignKey(d => d.MaNxb)
                .HasConstraintName("FK_tSach _tNhaXuatBan");

            entity.HasOne(d => d.MaTlNavigation).WithMany(p => p.TSaches)
                .HasForeignKey(d => d.MaTl)
                .HasConstraintName("FK_tSach _tTheLoai");
        });

        modelBuilder.Entity<TSachKho>(entity =>
        {
            entity.HasKey(e => new { e.MaKho, e.MaSach });

            entity.ToTable("tSach_Kho");

            entity.HasOne(d => d.MaKhoNavigation).WithMany(p => p.TSachKhos)
                .HasForeignKey(d => d.MaKho)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tSachKho_tKho");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.TSachKhos)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tSachKho_tSach");
        });

        modelBuilder.Entity<TTheLoai>(entity =>
        {
            entity.HasKey(e => e.MaTl);

            entity.ToTable("tTheLoai");

            entity.Property(e => e.MaTl).HasColumnName("MaTL");
            entity.Property(e => e.TenTl)
                .HasMaxLength(100)
                .HasColumnName("TenTL");
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.ToTable("tUser");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AnhDaiDien).HasMaxLength(1000);
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PassW)
                .HasMaxLength(100)
                .HasColumnName("passW");
            entity.Property(e => e.RoleId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("roleID");
            entity.Property(e => e.Sdt).HasColumnName("SDT");
            entity.Property(e => e.UserN).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.TUsers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_tUser_tUserRole");
        });

        modelBuilder.Entity<TUserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("tUserRole");

            entity.Property(e => e.RoleId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("roleID");
            entity.Property(e => e.MoTa).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
