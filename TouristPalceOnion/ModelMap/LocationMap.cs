using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data
{
    public class LocationMap
    {
        public LocationMap(EntityTypeBuilder<Location> entityBuilder)
        {
            entityBuilder.Property(s => s.Country).IsRequired();
            //entityBuilder.HasMany(s => s.Tourists).WithOne(t => t.Location).HasForeignKey(t => t.Location);
        }
    }
}
