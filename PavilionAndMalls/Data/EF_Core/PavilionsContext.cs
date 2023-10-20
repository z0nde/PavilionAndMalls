using Microsoft.EntityFrameworkCore;

namespace PavilionAndMalls.EF_Core
{
    public partial class PavilionsContext : DbContext
    {
        private static PavilionsContext _Context { get; set; }

        public PavilionsContext()
        {
        }

        public PavilionsContext(DbContextOptions<PavilionsContext> options)
            : base(options)
        {
        }

        public static PavilionsContext GetContext()
        {
            if (_Context == null)
                _Context = new PavilionsContext();
            return _Context;
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Mall> Malls { get; set; } = null!;
        public virtual DbSet<MallStatus> MallStatuses { get; set; } = null!;
        public virtual DbSet<Pavilion> Pavilions { get; set; } = null!;
        public virtual DbSet<PavilionStatus> PavilionStatuses { get; set; } = null!;
        public virtual DbSet<PavilionsTenant> PavilionsTenants { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Tenant> Tenants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-B8VQ37D\\SQLEXPRESS;Database=Pavilions;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity);

                entity.Property(e => e.CityName).HasMaxLength(255);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);

                entity.Property(e => e.Gender).HasMaxLength(3);

                entity.Property(e => e.Login).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Patronymic).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(255);

                entity.Property(e => e.Surname).HasMaxLength(255);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Employees_Role");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Log");

                entity.Property(e => e.CenterName).HasMaxLength(255);

                entity.Property(e => e.CurrentUser).HasMaxLength(255);

                entity.Property(e => e.EmployeeLastName).HasMaxLength(255);

                entity.Property(e => e.RentalEnd).HasColumnType("date");

                entity.Property(e => e.RentalStart).HasColumnType("date");

                entity.Property(e => e.TenantName).HasMaxLength(255);
            });

            modelBuilder.Entity<Mall>(entity =>
            {
                entity.HasKey(e => e.IdMall);

                entity.Property(e => e.MallName).HasMaxLength(255);

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Malls)
                    .HasForeignKey(d => d.IdCity)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Malls_Cities");

                entity.HasOne(d => d.IdMallStatusNavigation)
                    .WithMany(p => p.Malls)
                    .HasForeignKey(d => d.IdMallStatus)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Malls_MallStatuses");
            });

            modelBuilder.Entity<MallStatus>(entity =>
            {
                entity.HasKey(e => e.IdMallStatus);

                entity.Property(e => e.MallStatus1)
                    .HasMaxLength(255)
                    .HasColumnName("MallStatus");
            });

            modelBuilder.Entity<Pavilion>(entity =>
            {
                entity.HasKey(e => e.IdPavilion);

                entity.Property(e => e.PavilionNumber).HasMaxLength(255);

                entity.HasOne(d => d.IdMallNavigation)
                    .WithMany(p => p.Pavilions)
                    .HasForeignKey(d => d.IdMall)
                    .HasConstraintName("FK_Pavilions_Malls1");

                entity.HasOne(d => d.IdPavilionStatusNavigation)
                    .WithMany(p => p.Pavilions)
                    .HasForeignKey(d => d.IdPavilionStatus)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Pavilions_PavilionStatuses");
            });

            modelBuilder.Entity<PavilionStatus>(entity =>
            {
                entity.HasKey(e => e.IdPavilionStatus);

                entity.Property(e => e.PavilionStatus1)
                    .HasMaxLength(255)
                    .HasColumnName("PavilionStatus");
            });

            modelBuilder.Entity<PavilionsTenant>(entity =>
            {
                entity.HasKey(e => e.IdPavilonTenant);

                entity.Property(e => e.RentEnd).HasColumnType("datetime");

                entity.Property(e => e.RentStart).HasColumnType("datetime");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.PavilionsTenants)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PavilionsTenants_Employees");

                entity.HasOne(d => d.IdMallNavigation)
                    .WithMany(p => p.PavilionsTenants)
                    .HasForeignKey(d => d.IdMall)
                    .HasConstraintName("FK_PavilionsTenants_Malls");

                entity.HasOne(d => d.IdPavilionNavigation)
                    .WithMany(p => p.PavilionsTenants)
                    .HasForeignKey(d => d.IdPavilion)
                    .HasConstraintName("FK_PavilionsTenants_Pavilions");

                entity.HasOne(d => d.IdTenantNavigation)
                    .WithMany(p => p.PavilionsTenants)
                    .HasForeignKey(d => d.IdTenant)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PavilionsTenants_Tenants");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.ToTable("Role");

                entity.Property(e => e.RoleName).HasMaxLength(255);
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasKey(e => e.IdTenant);

                entity.Property(e => e.TenantName).HasMaxLength(255);

                entity.Property(e => e.TenantPhone).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
