using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }

        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy > 0 && bunny.Dyes.Any())
            {
                IDye current = bunny.Dyes.First();

                while (!egg.IsDone() && bunny.Energy > 0 && !current.IsFinished())
                {
                    bunny.Work();
                    egg.GetColored();
                    current.Use();
                }

                if (current.IsFinished())
                {
                    bunny.Dyes.Remove(current);

                }

                if (egg.IsDone())
                {
                    break;
                }
            }



            //if (bunny.Energy > 0 && bunny.Dyes.Any(d => !d.IsFinished()))
            //{
            //    foreach (var dye in bunny.Dyes)
            //    {
            //        while (bunny.Energy > 0)
            //        {
            //            if (egg.IsDone())
            //            {
            //                break;
            //            }

            //            if (dye.IsFinished())
            //            {
            //                break;
            //            }

            //            bunny.Work();
            //            egg.GetColored();
            //            dye.Use();
            //        }
            //    }
        }
    }
}

