using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enums;
using MilitaryElite.Exeptions;
using MilitaryElite.Models;

namespace MilitaryElite.Contracts
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = TryParseCorps(corps);
        }



        public Corps Corps { get; private set; }


        private Corps TryParseCorps(string corpsStr)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!parsed)
            {
                throw new InvalidCorpsExeption();
            }

            return corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps.ToString()}";
        }
    }
}
