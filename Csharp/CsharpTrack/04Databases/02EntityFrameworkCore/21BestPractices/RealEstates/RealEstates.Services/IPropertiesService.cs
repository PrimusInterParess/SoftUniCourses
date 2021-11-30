using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace RealEstates.Services.Models
{
    public interface IPropertiesService
    {
        void Add(
            string districtName, int floor, int maxFloor, int size, int yardSize,
            int year, string propertyType, string buildingType, int price);

        IEnumerable<PropertiInfoDto> Search(
            int minPriceRange, int maxPriceRange, 
            int minSizeRange, int maxSizeRange);
    }
}
