using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType != "SleepyBunny" && bunnyType != "HappyBunny")
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.InvalidBunnyType);
            }

            IBunny bunny = null;

            switch (bunnyType)
            {
                case "SleepyBunny":
                    bunny = new SleepyBunny(bunnyName);
                    break;
                case "HappyBunny":
                    bunny = new HappyBunny(bunnyName);
                    break;
            }

            this.bunnies.Add(bunny);

            return string.Format(Utilities.Messages.OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);

            if (this.bunnies.FindByName(bunnyName) == null)
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.InexistentBunny);
            }

            this.bunnies.FindByName(bunnyName).AddDye(dye);

            return string.Format(Utilities.Messages.OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            this.eggs.Add(egg);

            return string.Format(Utilities.Messages.OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {

            ICollection<IBunny> bunniessCollection = this.bunnies.Models
                .Where(b => b.Energy >= 50)
                .OrderByDescending(b => b.Energy).ToList();

            if (!bunniessCollection.Any())
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.BunniesNotReady);
            }

            IEgg egg = this.eggs.FindByName(eggName);


            Workshop workShop = new Workshop();

            while (bunniessCollection.Any())
            {
                IBunny current = bunniessCollection.First();

                workShop.Color(egg, current);

                if (!current.Dyes.Any())
                {
                    bunniessCollection.Remove(current);
                }

                if (current.Energy == 0)
                {
                    bunniessCollection.Remove(current);
                    this.bunnies.Remove(current);
                }

                if (egg.IsDone())
                {
                    break;
                    
                }
            }

            string output = string.Format(egg.IsDone() ? OutputMessages.EggIsDone : OutputMessages.EggIsNotDone,
                eggName);

            return output;
        }

        public string Report()
        {
            int countColoredEggs = this.eggs.Models.Count(e => e.IsDone());

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{countColoredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                int dyeCount = bunny.Dyes.Count(d => !d.IsFinished());

                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {dyeCount} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
