using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Contracts
{
  public  interface IPasswordHasher
  {
      public string HasPassword(string password);
  }
}
