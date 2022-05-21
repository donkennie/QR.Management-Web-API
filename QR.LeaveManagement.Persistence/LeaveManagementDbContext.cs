using Microsoft.EntityFrameworkCore;
using QR.LeaveManagement.Domain;
using QR.LeaveManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QR.LeaveManagement.Persistence
{
    public class LeaveManagementDbContext : DbContext
    {

        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options)
            : base (options) 
        {
           //  Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedBy = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

            }

            return base.SaveChangesAsync(cancellationToken);    
        }

        public DbSet<LeaveRequest> leaveRequests { get; set; }

        public DbSet<LeaveType> leaveTypes { get; set; }

        public DbSet<LeaveAllocation> leaveAllocations { get; set; }
    }
}
