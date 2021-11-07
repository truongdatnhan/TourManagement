﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(TourContext))]
    [Migration("20211107125124_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.ChiPhi", b =>
                {
                    b.Property<int>("MaChiPhi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaDoan")
                        .HasColumnType("int");

                    b.Property<int>("MaLoaiChiPhi")
                        .HasColumnType("int");

                    b.Property<long>("SoTien")
                        .HasColumnType("bigint");

                    b.HasKey("MaChiPhi");

                    b.HasIndex("MaDoan");

                    b.HasIndex("MaLoaiChiPhi");

                    b.ToTable("ChiPhi");
                });

            modelBuilder.Entity("Domain.Entities.ChiTietDoan", b =>
                {
                    b.Property<int>("MaDoan")
                        .HasColumnType("int");

                    b.Property<int>("MaKhachHang")
                        .HasColumnType("int");

                    b.HasKey("MaDoan", "MaKhachHang");

                    b.HasIndex("MaKhachHang");

                    b.ToTable("ChiTietDoan");
                });

            modelBuilder.Entity("Domain.Entities.DiaDiem", b =>
                {
                    b.Property<int>("MaDiaDiem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenDiaDiem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDiaDiem");

                    b.ToTable("DiaDiem");
                });

            modelBuilder.Entity("Domain.Entities.DiemThamQuan", b =>
                {
                    b.Property<int>("MaDiaDiem")
                        .HasColumnType("int");

                    b.Property<int>("MaTour")
                        .HasColumnType("int");

                    b.Property<int>("ThuTu")
                        .HasColumnType("int");

                    b.HasKey("MaDiaDiem", "MaTour");

                    b.HasIndex("MaTour");

                    b.ToTable("DiemThamQuan");
                });

            modelBuilder.Entity("Domain.Entities.DoanDuLich", b =>
                {
                    b.Property<int>("MaDoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("DoanhThu")
                        .HasColumnType("bigint");

                    b.Property<int>("MaTour")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKhoiHanh")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenDoan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDoan");

                    b.HasIndex("MaTour");

                    b.ToTable("DoanDuLich");
                });

            modelBuilder.Entity("Domain.Entities.GiaTour", b =>
                {
                    b.Property<int>("MaGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaTour")
                        .HasColumnType("int");

                    b.Property<long>("ThanhTien")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ThoiGianBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianKetThuc")
                        .HasColumnType("datetime2");

                    b.HasKey("MaGia");

                    b.HasIndex("MaTour");

                    b.ToTable("GiaTour");
                });

            modelBuilder.Entity("Domain.Entities.Khach", b =>
                {
                    b.Property<int>("MaKhachHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuocTich")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoCMND")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKhachHang");

                    b.ToTable("Khach");
                });

            modelBuilder.Entity("Domain.Entities.LoaiChiPhi", b =>
                {
                    b.Property<int>("MaLoaiChiPhi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenLoaiChiPhi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLoaiChiPhi");

                    b.ToTable("LoaiChiPhi");
                });

            modelBuilder.Entity("Domain.Entities.LoaiHinhDuLich", b =>
                {
                    b.Property<int>("MaLoaiHinh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenLoaiHinh")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLoaiHinh");

                    b.ToTable("LoaiHinhDuLich");
                });

            modelBuilder.Entity("Domain.Entities.NhanVien", b =>
                {
                    b.Property<int>("MaNhanVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenNhanVien")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaNhanVien");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("Domain.Entities.NoiDungTour", b =>
                {
                    b.Property<int>("MaDoan")
                        .HasColumnType("int");

                    b.Property<string>("DiaDiemThamQuan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HanhTrinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KhachSan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDoan");

                    b.ToTable("NoiDungTour");
                });

            modelBuilder.Entity("Domain.Entities.PhanBoNhanVienDoan", b =>
                {
                    b.Property<int>("MaDoan")
                        .HasColumnType("int");

                    b.Property<int>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<string>("NhiemVu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDoan", "MaNhanVien");

                    b.HasIndex("MaNhanVien");

                    b.ToTable("PhanBoNhanVien_Doan");
                });

            modelBuilder.Entity("Domain.Entities.TourDuLich", b =>
                {
                    b.Property<int>("MaTour")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DacDiem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaLoaiHinh")
                        .HasColumnType("int");

                    b.Property<string>("TenGoi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaTour");

                    b.HasIndex("MaLoaiHinh");

                    b.ToTable("TourDuLich");
                });

            modelBuilder.Entity("Domain.Entities.ChiPhi", b =>
                {
                    b.HasOne("Domain.Entities.DoanDuLich", "DoanDuLich")
                        .WithMany("ChiPhis")
                        .HasForeignKey("MaDoan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.LoaiChiPhi", "LoaiChiPhi")
                        .WithMany("ChiPhis")
                        .HasForeignKey("MaLoaiChiPhi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoanDuLich");

                    b.Navigation("LoaiChiPhi");
                });

            modelBuilder.Entity("Domain.Entities.ChiTietDoan", b =>
                {
                    b.HasOne("Domain.Entities.DoanDuLich", "Doan")
                        .WithMany("ChiTietDoans")
                        .HasForeignKey("MaDoan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Khach", "Khach")
                        .WithMany("ChiTietDoans")
                        .HasForeignKey("MaKhachHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doan");

                    b.Navigation("Khach");
                });

            modelBuilder.Entity("Domain.Entities.DiemThamQuan", b =>
                {
                    b.HasOne("Domain.Entities.DiaDiem", "DiaDiem")
                        .WithMany("DiemThamQuans")
                        .HasForeignKey("MaDiaDiem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TourDuLich", "TourDuLich")
                        .WithMany("DiemThamQuans")
                        .HasForeignKey("MaTour")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiaDiem");

                    b.Navigation("TourDuLich");
                });

            modelBuilder.Entity("Domain.Entities.DoanDuLich", b =>
                {
                    b.HasOne("Domain.Entities.TourDuLich", "Tour")
                        .WithMany("DoanDuLichs")
                        .HasForeignKey("MaTour")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Domain.Entities.GiaTour", b =>
                {
                    b.HasOne("Domain.Entities.TourDuLich", "TourDuLich")
                        .WithMany("GiaTours")
                        .HasForeignKey("MaTour")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TourDuLich");
                });

            modelBuilder.Entity("Domain.Entities.NoiDungTour", b =>
                {
                    b.HasOne("Domain.Entities.DoanDuLich", "Doan")
                        .WithOne("NoiDungTour")
                        .HasForeignKey("Domain.Entities.NoiDungTour", "MaDoan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doan");
                });

            modelBuilder.Entity("Domain.Entities.PhanBoNhanVienDoan", b =>
                {
                    b.HasOne("Domain.Entities.DoanDuLich", "Doan")
                        .WithMany("PhanBoNhanVienDoans")
                        .HasForeignKey("MaDoan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.NhanVien", "NhanVien")
                        .WithMany("PhanBoNhanVienDoans")
                        .HasForeignKey("MaNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doan");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("Domain.Entities.TourDuLich", b =>
                {
                    b.HasOne("Domain.Entities.LoaiHinhDuLich", "LoaiHinh")
                        .WithMany("TourDuLiches")
                        .HasForeignKey("MaLoaiHinh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiHinh");
                });

            modelBuilder.Entity("Domain.Entities.DiaDiem", b =>
                {
                    b.Navigation("DiemThamQuans");
                });

            modelBuilder.Entity("Domain.Entities.DoanDuLich", b =>
                {
                    b.Navigation("ChiPhis");

                    b.Navigation("ChiTietDoans");

                    b.Navigation("NoiDungTour");

                    b.Navigation("PhanBoNhanVienDoans");
                });

            modelBuilder.Entity("Domain.Entities.Khach", b =>
                {
                    b.Navigation("ChiTietDoans");
                });

            modelBuilder.Entity("Domain.Entities.LoaiChiPhi", b =>
                {
                    b.Navigation("ChiPhis");
                });

            modelBuilder.Entity("Domain.Entities.LoaiHinhDuLich", b =>
                {
                    b.Navigation("TourDuLiches");
                });

            modelBuilder.Entity("Domain.Entities.NhanVien", b =>
                {
                    b.Navigation("PhanBoNhanVienDoans");
                });

            modelBuilder.Entity("Domain.Entities.TourDuLich", b =>
                {
                    b.Navigation("DiemThamQuans");

                    b.Navigation("DoanDuLichs");

                    b.Navigation("GiaTours");
                });
#pragma warning restore 612, 618
        }
    }
}
