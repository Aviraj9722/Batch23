using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoCore.DBEntities;

public partial class Mim23Context : DbContext
{
    public Mim23Context()
    {
    }

    public Mim23Context(DbContextOptions<Mim23Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TblActionAuditLog> TblActionAuditLogs { get; set; }

    public virtual DbSet<TblCity> TblCities { get; set; }

    public virtual DbSet<TblGst> TblGsts { get; set; }

    public virtual DbSet<TblMaterial> TblMaterials { get; set; }

    public virtual DbSet<TblMaterialLog> TblMaterialLogs { get; set; }

    public virtual DbSet<TblNavigation> TblNavigations { get; set; }

    public virtual DbSet<TblPo> TblPos { get; set; }

    public virtual DbSet<TblPurchaseDetail> TblPurchaseDetails { get; set; }

    public virtual DbSet<TblPurchaseMaster> TblPurchaseMasters { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblSaleDetail> TblSaleDetails { get; set; }

    public virtual DbSet<TblSaleMaster> TblSaleMasters { get; set; }

    public virtual DbSet<TblUom> TblUoms { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblVender> TblVenders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=MIM23;Persist Security Info=True;User ID=sa;Password=Sql123;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblActionAuditLog>(entity =>
        {
            entity.ToTable("tblActionAuditLog");

            entity.Property(e => e.ActionName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ControllerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ErrorMessage).IsUnicode(false);
            entity.Property(e => e.Operation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoutValues).IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCity>(entity =>
        {
            entity.ToTable("tblCity");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TblGst>(entity =>
        {
            entity.ToTable("tblGST");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblMaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblMater__3213E83FA7900425");

            entity.ToTable("tblMaterial", tb => tb.HasTrigger("trg_Material_Audit"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Gstid).HasColumnName("GSTID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Uomid).HasColumnName("UOMID");

            entity.HasOne(d => d.Gst).WithMany(p => p.TblMaterials)
                .HasForeignKey(d => d.Gstid)
                .HasConstraintName("FK_tblMaterial_tblGST");

            entity.HasOne(d => d.Uom).WithMany(p => p.TblMaterials)
                .HasForeignKey(d => d.Uomid)
                .HasConstraintName("FK_tblMaterial_tblUOM");
        });

        modelBuilder.Entity<TblMaterialLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblMaterial_log");

            entity.Property(e => e.CreateOn).HasColumnType("datetime");
            entity.Property(e => e.Gstid).HasColumnName("GSTID");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OpearationDate).HasColumnType("datetime");
            entity.Property(e => e.Operation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Uomid).HasColumnName("UOMID");
        });

        modelBuilder.Entity<TblNavigation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblNavig__3213E83F84048F68");

            entity.ToTable("tblNavigations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ControllerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LinkText).HasMaxLength(200);
        });

        modelBuilder.Entity<TblPo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblPO");
        });

        modelBuilder.Entity<TblPurchaseDetail>(entity =>
        {
            entity.ToTable("tblPurchaseDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Material).WithMany(p => p.TblPurchaseDetails)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_tblPurchaseDetail_tblMaterial");

            entity.HasOne(d => d.Po).WithMany(p => p.TblPurchaseDetails)
                .HasForeignKey(d => d.Poid)
                .HasConstraintName("FK_tblPurchaseDetail_tblPurchaseMaster");
        });

        modelBuilder.Entity<TblPurchaseMaster>(entity =>
        {
            entity.ToTable("tblPurchaseMaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Podate)
                .HasColumnType("datetime")
                .HasColumnName("PODate");

            entity.HasOne(d => d.Vender).WithMany(p => p.TblPurchaseMasters)
                .HasForeignKey(d => d.VenderId)
                .HasConstraintName("FK_tblPurchaseMaster_tblVender");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblRoles__3213E83F914E0FE3");

            entity.ToTable("tblRoles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblSaleDetail>(entity =>
        {
            entity.ToTable("tblSaleDetails");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Material).WithMany(p => p.TblSaleDetails)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_tblSaleDetails_tblMaterial");

            entity.HasOne(d => d.Sale).WithMany(p => p.TblSaleDetails)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK_tblSaleDetails_tblSaleMaster");
        });

        modelBuilder.Entity<TblSaleMaster>(entity =>
        {
            entity.ToTable("tblSaleMaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SaleDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblUom>(entity =>
        {
            entity.ToTable("tblUOM");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUser__3213E83FCE2C96DD");

            entity.ToTable("tblUser");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__tblUser__RoleId__3E1D39E1");
        });

        modelBuilder.Entity<TblVender>(entity =>
        {
            entity.ToTable("tblVender");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contact).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Gstn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GSTN");
            entity.Property(e => e.Hobbies)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pancard).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Photo).IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.TblVenders)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_tblVender_tblRoles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
