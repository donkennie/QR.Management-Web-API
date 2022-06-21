using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Persistence.Configurations.Entities
{
    public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
    {
        public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
        {
            
        }
    }
}
