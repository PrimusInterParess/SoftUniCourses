using SUHttpServer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUHttpServer.HTTP
{
    public class Cookie
    {
        public Cookie(string name, string value)
        {
            Guard.AgainstNull(name);
            Guard.AgainstNull(value);

            this.Name = name;
            this.Value = value;
        }

        public string Name { get; init; }

        public string Value { get; init; }

        public override string ToString()
        {
            return $"{this.Name}={this.Value}";
        }
    }
}
