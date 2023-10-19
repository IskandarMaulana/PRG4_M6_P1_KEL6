﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PRG4_M6_P1_KEL6.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DataPetuga> DataPetugas { get; set; }

    public virtual DbSet<Pengumuman> Pengumumen { get; set; }

    public virtual DbSet<Transaksi> Transaksis { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataPetuga>(entity =>
        {
            entity.HasKey(e => e.Nim);

            entity.ToTable("Data Petugas");

            entity.Property(e => e.Nim)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nim");
            entity.Property(e => e.Nama)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nama");
            entity.Property(e => e.NoTelp)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("no_telp");
            entity.Property(e => e.Prodi)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("prodi");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Pengumuman>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Pengumuman");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.JenisPengumuman)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("jenis_pengumuman");
            entity.Property(e => e.NamaPengumuman)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nama_pengumuman");
        });

        modelBuilder.Entity<Transaksi>(entity =>
        {
            entity.HasKey(e => e.Nim).HasName("PK_Table_1");

            entity.ToTable("transaksi");

            entity.Property(e => e.Nim)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nim");
            entity.Property(e => e.Jobdesk)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("jobdesk");
            entity.Property(e => e.Tanggal)
                .HasColumnType("date")
                .HasColumnName("tanggal");
            entity.Property(e => e.WaktuSholat)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("waktu_sholat");

            entity.HasOne(d => d.NimNavigation).WithOne(p => p.Transaksi)
                .HasForeignKey<Transaksi>(d => d.Nim)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_petugas");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alamat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("alamat");
            entity.Property(e => e.Nama)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nama");
            entity.Property(e => e.NoTelp)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("no_telp");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
