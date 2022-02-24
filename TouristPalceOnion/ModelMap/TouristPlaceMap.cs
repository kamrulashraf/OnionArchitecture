using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace OA.Data
{
    public class TouristPlaceMap
    {
        public TouristPlaceMap( EntityTypeBuilder <TouristPlace> entityBuilder)
        {
            entityBuilder.HasKey(s => s.Id);
            entityBuilder.Property(s => s.Address).IsRequired();
            entityBuilder.Property(s => s.Name).IsRequired();
            entityBuilder.HasOne(s => s.Location).WithMany(t => t.Tourists).HasForeignKey(x => x.LocationId);
        }
    }
}
