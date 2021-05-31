using System;
using System.Collections.Generic;
using System.Text;
using SOLID.Layouts;

namespace SOLID.Core.Factories
{
   public interface ILayoutFactory
   {

       ILayout CreateLayout(string type);


   }
}
