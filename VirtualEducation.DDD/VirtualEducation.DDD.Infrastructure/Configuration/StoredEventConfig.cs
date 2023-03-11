using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualEducation.DDD.Domain.Generics;

namespace VirtualEducation.DDD.Infrastructure.Configuration
{
    public class StoredEventConfig : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.ToTable("storedEvent");

            builder.HasKey(p => p.StoredId);
        }
    }
}
