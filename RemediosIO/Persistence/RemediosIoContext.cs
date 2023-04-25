using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RemediosIO.Models;

namespace RemediosIO.Persistence;

public partial class RemediosIoContext : DbContext
{
    public RemediosIoContext()
    {
    }

    public RemediosIoContext(DbContextOptions<RemediosIoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Pharmacy> Pharmacies { get; set; }

    public virtual DbSet<Strip> Strips { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-36FJ1G6;Database=RemediosIO;Trusted_Connection=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07CF4ABE20");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clients__3214EC0784540BBB");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.MedicalHistory)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPharmacyNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdPharmacy)
                .HasConstraintName("FK_Clients_Pharmacies");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medicine__3214EC07A37563E2");

            entity.Property(e => e.DosageInstructions)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Postedat).HasColumnType("datetime");
            entity.Property(e => e.Warnings)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Medicines)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK_Medicines_Categories");

            entity.HasOne(d => d.IdStripNavigation).WithMany(p => p.Medicines)
                .HasForeignKey(d => d.IdStrip)
                .HasConstraintName("FK_Medicines_Strips");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Medicines)
                .HasForeignKey(d => d.IdSupplier)
                .HasConstraintName("FK_Medicines_Supplier");

            entity.HasMany(d => d.IdPharmacies).WithMany(p => p.IdMedicines)
                .UsingEntity<Dictionary<string, object>>(
                    "PharmacyCatalog",
                    r => r.HasOne<Pharmacy>().WithMany()
                        .HasForeignKey("IdPharmacy")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PharmacyC__IdPha__30F848ED"),
                    l => l.HasOne<Medicine>().WithMany()
                        .HasForeignKey("IdMedicine")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PharmacyC__IdMed__300424B4"),
                    j =>
                    {
                        j.HasKey("IdMedicine", "IdPharmacy").HasName("PK__Pharmacy__C6B6B685EDD5E056");
                        j.ToTable("PharmacyCatalog");
                    });

            entity.HasMany(d => d.IdSuppliers).WithMany(p => p.IdMedicines)
                .UsingEntity<Dictionary<string, object>>(
                    "MedicineSupplier",
                    r => r.HasOne<Supplier>().WithMany()
                        .HasForeignKey("IdSupplier")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MedicineS__IdSup__34C8D9D1"),
                    l => l.HasOne<Medicine>().WithMany()
                        .HasForeignKey("IdMedicine")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MedicineS__IdMed__33D4B598"),
                    j =>
                    {
                        j.HasKey("IdMedicine", "IdSupplier").HasName("PK__Medicine__9282DB4B340464AA");
                        j.ToTable("MedicineSupplier");
                    });
        });

        modelBuilder.Entity<Pharmacy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pharmaci__3214EC078EA1305F");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Strip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Strips__3214EC070C7013DA");

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.StripName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC0731E1D4CA");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CNPJ");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
