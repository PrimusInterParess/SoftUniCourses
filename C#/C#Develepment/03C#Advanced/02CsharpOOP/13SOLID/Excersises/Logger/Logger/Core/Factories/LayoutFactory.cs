using System;
using System.Collections.Generic;
using System.Text;
using SOLID.Layouts;

namespace SOLID.Core.Factories
{
   public class LayoutFactory:ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout layout;

            switch (type)
            {
                case nameof(SimpleLayout):
                    layout = new SimpleLayout();
                    break;
                case nameof(JsonLayout):
                    layout = new JsonLayout();
                    break;
                case nameof(XmlLayout):
                    layout = new XmlLayout();
                    break;
               default: throw new ArgumentException($"{type} is invalid Layout type");

            }

            return layout;
        }
    }
}
