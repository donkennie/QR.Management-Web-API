using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public DateTime LastModifiedBy { get; set; }

    }
}
