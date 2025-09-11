using Microsoft.EntityFrameworkCore;
using CRM.Domain.Entities;
using CRM.Domain.Enums;
using System.Security.Cryptography;
using System.Text;

namespace CRM.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Lead> Leads { get; set; } = null!;
        public DbSet<Opportunity> Opportunities { get; set; } = null!;
        public DbSet<Quote> Quotes { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;
        public DbSet<Report> Reports { get; set; } = null!;
        public DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==========================
            // RELATIONSHIPS
            // ==========================

            // User <-> Role (Many-to-Many)
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // User -> Customers (One-to-Many)
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.AssignedToUser)
                .WithMany(u => u.Customers)
                .HasForeignKey(c => c.AssignedToUserId)
                .OnDelete(DeleteBehavior.Restrict); // ⚠️ Prevent cascade path issue

            // Customer -> Leads (One-to-Many)
            modelBuilder.Entity<Lead>()
                .HasOne(l => l.Customer)
                .WithMany(c => c.Leads)
                .HasForeignKey(l => l.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lead>()
                .HasOne(l => l.CreatedByUser)
                .WithMany(u => u.Leads)
                .HasForeignKey(l => l.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Customer -> Opportunities (One-to-Many)
            modelBuilder.Entity<Opportunity>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Opportunities)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Opportunity>()
                .HasOne(o => o.OwnerUser)
                .WithMany(u => u.Opportunities)
                .HasForeignKey(o => o.OwnerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Opportunity -> Quotes (One-to-Many)
            modelBuilder.Entity<Quote>()
                .HasOne(q => q.Opportunity)
                .WithMany(o => o.Quotes)
                .HasForeignKey(q => q.OpportunityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quote>()
                .HasOne(q => q.Customer)
                .WithMany(c => c.Quotes)
                .HasForeignKey(q => q.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quote>()
                .HasOne(q => q.CreatedByUser)
                .WithMany(u => u.Quotes)
                .HasForeignKey(q => q.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Customer -> Invoices (One-to-Many)
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.CreatedByUser)
                .WithMany(u => u.Invoices)
                .HasForeignKey(i => i.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict); // ⚠️ Prevent multiple cascade paths

            // User -> Reports (One-to-Many)
            modelBuilder.Entity<Report>()
                .HasOne(r => r.GeneratedByUser)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.GeneratedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // User -> AuditLogs (One-to-Many)
            modelBuilder.Entity<AuditLog>()
                .HasOne(a => a.User)
                .WithMany(u => u.AuditLogs)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // User -> Notifications (One-to-Many)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ==========================
            // DECIMAL PRECISION FIX
            // ==========================

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Amount)
                .HasPrecision(18, 2); // ✅ Fix warning

            modelBuilder.Entity<Quote>()
                .Property(q => q.Amount)
                .HasPrecision(18, 2); // ✅ Fix warning

            // ==========================
            // ENUM TO STRING
            // ==========================

            modelBuilder.Entity<Lead>()
                .Property(l => l.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Opportunity>()
                .Property(o => o.Stage)
                .HasConversion<string>();

            modelBuilder.Entity<Quote>()
                .Property(q => q.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Report>()
                .Property(r => r.ReportType)
                .HasConversion<string>();

            // ✅ You can now seed data or add more config as needed

            var (hash1, salt1) = CreatePasswordHash("admin123");
            var (hash2, salt2) = CreatePasswordHash("hr123");
            var (hash3, salt3) = CreatePasswordHash("user123");

            // Users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "Admin User", Email = "admin@crm.com", PasswordHash = hash1, PasswordSalt = salt1 },
                new User { UserId = 2, UserName = "HR Manager", Email = "hr@crm.com", PasswordHash = hash2, PasswordSalt = salt2 },
                new User { UserId = 3, UserName = "Normal User", Email = "user@crm.com", PasswordHash = hash3, PasswordSalt = salt3 }
            );

            // Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "HR" },
                new Role { RoleId = 3, RoleName = "User" }
            );

            // UserRoles
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserId = 1, RoleId = 1 },
                new UserRole { UserId = 2, RoleId = 2 },
                new UserRole { UserId = 3, RoleId = 3 }
            );

            // Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "ABC Corp", Email = "contact@abc.com", AssignedToUserId = 1 },
                new Customer { CustomerId = 2, Name = "XYZ Ltd", Email = "info@xyz.com", AssignedToUserId = 2 },
                new Customer { CustomerId = 3, Name = "TechSoft", Email = "sales@techsoft.com", AssignedToUserId = 3 }
            );

            // Leads
            modelBuilder.Entity<Lead>().HasData(
                new Lead { LeadId = 1, CustomerId = 1, CreatedByUserId = 1, Status = LeadStatus.New },
                new Lead { LeadId = 2, CustomerId = 2, CreatedByUserId = 2, Status = LeadStatus.Contacted },
                new Lead { LeadId = 3, CustomerId = 3, CreatedByUserId = 3, Status = LeadStatus.Qualified }
            );

            // Opportunities
            modelBuilder.Entity<Opportunity>().HasData(
                new Opportunity { OpportunityId = 1, CustomerId = 1, OwnerUserId = 1, Stage = OpportunityStage.Prospecting },
                new Opportunity { OpportunityId = 2, CustomerId = 2, OwnerUserId = 2, Stage = OpportunityStage.Negotiation },
                new Opportunity { OpportunityId = 3, CustomerId = 3, OwnerUserId = 3, Stage = OpportunityStage.ClosedWon }
            );

            // Quotes
            modelBuilder.Entity<Quote>().HasData(
                new Quote { QuoteId = 1, CustomerId = 1, OpportunityId = 1, CreatedByUserId = 1, Status = QuoteStatus.Draft },
                new Quote { QuoteId = 2, CustomerId = 2, OpportunityId = 2, CreatedByUserId = 2, Status = QuoteStatus.Sent },
                new Quote { QuoteId = 3, CustomerId = 3, OpportunityId = 3, CreatedByUserId = 3, Status = QuoteStatus.Approved }
            );

            // Invoices
            modelBuilder.Entity<Invoice>().HasData(
                new Invoice { InvoiceId = 1, CustomerId = 1, CreatedByUserId = 1, Status = InvoiceStatus.Pending, Amount = 1000 },
                new Invoice { InvoiceId = 2, CustomerId = 2, CreatedByUserId = 2, Status = InvoiceStatus.Paid, Amount = 2000 },
                new Invoice { InvoiceId = 3, CustomerId = 3, CreatedByUserId = 3, Status = InvoiceStatus.Overdue, Amount = 3000 }
            );

            // Reports
            modelBuilder.Entity<Report>().HasData(
                new Report { ReportId = 1, GeneratedByUserId = 1, ReportType = ReportType.Sales, Title = "Sales Report Q1" },
                new Report { ReportId = 2, GeneratedByUserId = 2, ReportType = ReportType.Financial, Title = "Finance Report Q1" },
                new Report { ReportId = 3, GeneratedByUserId = 3, ReportType = ReportType.Customer, Title = "Customer Report Q1" }
            );

            // AuditLogs
            modelBuilder.Entity<AuditLog>().HasData(
                new AuditLog { AuditLogId = 1, UserId = 1, EntityName = "Customer", Action = "Created", Changes = "Added new customer ABC Corp", Timestamp = DateTime.UtcNow },
                new AuditLog { AuditLogId = 2, UserId = 2, EntityName = "Lead", Action = "Updated", Changes = "Changed lead status to Contacted", Timestamp = DateTime.UtcNow },
                new AuditLog { AuditLogId = 3, UserId = 3, EntityName = "Quote", Action = "Deleted", Changes = "Deleted quote with ID 3", Timestamp = DateTime.UtcNow }
            );

            // Notifications
            modelBuilder.Entity<Notification>().HasData(
                new Notification { NotificationId = 1, UserId = 1, Message = "New Lead Assigned", IsRead = false },
                new Notification { NotificationId = 2, UserId = 2, Message = "Invoice Paid", IsRead = false },
                new Notification { NotificationId = 3, UserId = 3, Message = "Report Generated", IsRead = true }
            );
        }

        // 🔑 Password hashing helper
        private static (byte[] hash, byte[] salt) CreatePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return (hash, salt);
        }
    }
}
