using System;
using System.Collections.Generic;
using System.Text;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models
{
    public abstract class Peripheral : Product, IPeripheral
    {
        private string connectionType;

        protected Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string conectionConnectionType)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.ConnectionType = conectionConnectionType;
        }

        public string ConnectionType
        {
            get => this.connectionType;
            private set => this.connectionType = value;

        }

        public override string ToString()
        {
            return $"{base.ToString()} Connection Type: {this.ConnectionType}";
        }
    }
}
