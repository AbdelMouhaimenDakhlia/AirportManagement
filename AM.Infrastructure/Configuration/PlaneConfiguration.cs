using AM.ApplicationCore.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configuration
{
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            //tp4 Q4
            builder.HasKey(p => p.PlaneId);

            builder.ToTable("MyPlane");
            
            builder.Property(p => p.Capacity).HasColumnName("PlaneCapacity");
        }
    }
}
