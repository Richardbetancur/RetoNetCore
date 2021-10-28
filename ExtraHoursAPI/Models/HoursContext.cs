using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExtraHoursAPI.Models
{
    public partial class HoursContext : DbContext
    {
        public HoursContext()
        {
        }

        public HoursContext(DbContextOptions<HoursContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applications> Applications { get; set; }
        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<ExtraHours> ExtraHours { get; set; }
        public virtual DbSet<Options> Options { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersxAreas> UsersxAreas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=HoursDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applications>(entity =>
            {
                entity.HasKey(e => e.IdApplication)
                    .HasName("PK__Applicat__C67BBB1F1507B98C");

                entity.Property(e => e.ApplicationDate).HasColumnType("datetime");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompensationEnd).HasColumnType("date");

                entity.Property(e => e.CompensationStar).HasColumnType("date");

                entity.Property(e => e.Reason)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseDate).HasColumnType("datetime");

                entity.HasOne(d => d.ColaboratorNavigation)
                    .WithMany(p => p.ApplicationsColaboratorNavigation)
                    .HasForeignKey(d => d.Colaborator)
                    .HasConstraintName("FK__Applicati__Colab__32AB8735");

                entity.HasOne(d => d.LeaderNavigation)
                    .WithMany(p => p.ApplicationsLeaderNavigation)
                    .HasForeignKey(d => d.Leader)
                    .HasConstraintName("FK__Applicati__Leade__31B762FC");
            });

            modelBuilder.Entity<Areas>(entity =>
            {
                entity.HasKey(e => e.IdArea);

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraHours>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Quatity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany(p => p.ExtraHours)
                    .HasForeignKey(d => d.UserName)
                    .HasConstraintName("FK__ExtraHour__UserN__29221CFB");
            });

            modelBuilder.Entity<Options>(entity =>
            {
                entity.HasKey(e => e.IdOption)
                    .HasName("PK__Options__C118A0F1E40ECF9E");

                entity.Property(e => e.OptionName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.UrlOption)
                    .IsRequired()
                    .HasMaxLength(155)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__Options__Rol__2EDAF651");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.Property(e => e.RolName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            modelBuilder.Entity<UsersxAreas>(entity =>
            {
                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.UsersxAreas)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsersxAre__IdAre__3D2915A8");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UsersxAreas)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsersxAre__IdUse__3C34F16F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
