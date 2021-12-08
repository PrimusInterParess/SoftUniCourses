using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class ProperiesService : IPropertiesService
    {
        private ApplicationDbContext dbContext;

        public ProperiesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(
            string districtName, int floor,
            int maxFloor, int size,
            int yardSize,
            int year, string propertyTypeName,
            string buildingTypeName, int price)
        {
            var property = new Property
            {
                Size = size,
                Price = price <= 0 ? null : price,
                Floor = floor <= 0 || floor >= 255 ? null : (byte)floor,
                TotalFloors = maxFloor <= 0 || maxFloor >= 255 ? null : (byte)maxFloor,
                YardSize = yardSize <= 0 ? null : yardSize,
                Year = year <= 1800 ? null : year,
            };

            var dbDisctrict = this.dbContext
                .Districts
                .FirstOrDefault(d => d.Name == districtName);


            if (dbDisctrict == null)
            {
                dbDisctrict = new District { Name = districtName };
            }

            property.District = dbDisctrict;

            var dbPropertyType = dbContext
                .PropertyTypes
                .FirstOrDefault(p => p.Name == propertyTypeName);


            if (dbPropertyType == null)
            {
                dbPropertyType = new PropertyType { Name = propertyTypeName };
            }

            property.Type = dbPropertyType;

            var dbBuildingType = dbContext.BuildingTypes.FirstOrDefault(bt => bt.Name == buildingTypeName);

            if (dbBuildingType == null)
            {
                dbBuildingType = new BuildingType { Name = buildingTypeName };
            }

            property.BuildingType = dbBuildingType;

            dbContext.Properties.Add(property);

            dbContext.SaveChanges();
        }

        public IEnumerable<PropertiInfoDto> Search(
            int minPriceRange, int maxPriceRange,
            int minSizeRange, int maxSizeRange)
        {
            var properties = dbContext.Properties.Where(p =>
                p.Price >= minPriceRange && p.Price <= maxPriceRange && p.Size >= minSizeRange &&
                p.Size <= maxSizeRange).Select(p => new PropertiInfoDto()
                {
                    Size = p.Size,
                    BuildingType = p.BuildingType.Name,
                    DistrictName = p.District.Name,
                    PropertyType = p.Type.Name,
                    Price = p.Price ?? 0

                }).ToList();

            return properties;

        }
    }
}
