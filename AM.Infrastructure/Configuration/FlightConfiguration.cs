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
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //tp4 Q5
            //builder.HasMany(f => f.ListPassenger)
            //    .WithMany(p => p.ListFlight)
            //    .UsingEntity(t => t.ToTable("MyReservations"));

            builder.HasOne(f => f.MyPlane)
                .WithMany(p => p.ListFlight)
                .HasForeignKey(f => f.Planefk)
                .OnDelete(DeleteBehavior.ClientSetNull);//bch kii nfas5 cle primaire ytfas5 cle etranger (delete cascade)
        }
    }
}
