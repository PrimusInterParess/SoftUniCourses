using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services.Models
{
  public  interface IDistrictService
  {

     public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count);
  }

  
}
