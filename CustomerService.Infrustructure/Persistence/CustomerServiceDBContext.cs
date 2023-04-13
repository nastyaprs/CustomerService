using CustomerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Infrustructure.Persistence
{
    public class CustomerServiceDBContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<SupportRequest> SupportRequests { get; set; } = null!;

        public DbSet<SupportRequestMessage> SupportRequestMessages { get; set; } = null!;

        public CustomerServiceDBContext(DbContextOptions options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CongigureUsersTable(modelBuilder);
            ConfigureSupportRequeststable(modelBuilder);
            ConfigureSupportRequestMessagesTable(modelBuilder);
        }

        private void ConfigureSupportRequestMessagesTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupportRequestMessage>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<SupportRequestMessage>()
                .Property(m => m.CreatedBy)
                .HasMaxLength(100);
        }

        private void ConfigureSupportRequeststable(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SupportRequest>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<SupportRequest>()
                .HasMany(r => r.SupportRequestMessages)
                .WithOne(m => m.SupportRequest)
                .HasForeignKey(m => m.SupportRequestId);

            modelBuilder.Entity<SupportRequest>()
                .Property(r => r.UrgencyLevel)
                .HasMaxLength(25);

            modelBuilder.Entity<SupportRequest>()
                .Property(r => r.Status)
                .HasMaxLength(25);

            modelBuilder.Entity<SupportRequest>()
                .Property(r => r.IssueType)
                .HasMaxLength(50);
        }

        private void CongigureUsersTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
              .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.Email);

            modelBuilder.Entity<User>()
                .HasMany(u => u.SupportRequests)
                .WithOne(r => r.Customer)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasMaxLength(50);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateStatistics();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            UpdateStatistics();
            return base.SaveChanges();
        }

        private void UpdateStatistics()
        {
            var created = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            foreach (var entityEntry in created)
            {
                if (entityEntry.Entity is User user)
                {
                    user.CreatedAt = DateTime.UtcNow;
                }

                if (entityEntry.Entity is SupportRequest supportRequest)
                {
                    supportRequest.CreatedAt = DateTime.UtcNow;
                }

                if (entityEntry.Entity is SupportRequestMessage requestMessage)
                {
                    requestMessage.CreatedAt = DateTime.UtcNow;
                }
            }

            var update = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach (var entityEntry in update)
            {
                if (entityEntry.Entity is User user)
                {
                    user.UpdatedAt = DateTime.UtcNow;
                }

                if (entityEntry.Entity is SupportRequest supportRequest)
                {
                    supportRequest.UpdatedAt = DateTime.UtcNow;
                }

                if (entityEntry.Entity is SupportRequestMessage requestMessage)
                {
                    requestMessage.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
