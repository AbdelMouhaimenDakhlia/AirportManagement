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
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            //Tp4 Q13
            builder.OwnsOne(p => p.FullName,f => 
            { 
                f.Property(full => full.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
                f.Property(full => full.LastName).IsRequired().HasColumnName("PassLastName");
            }
            );
            //tp5 Q1
            //builder.HasDiscriminator<string>("is traveller")
            //    .HasValue<Traveller>("1")
            //    .HasValue<Staff>("2")
            //    .HasValue<Passenger>("0");

        }
    }
}
