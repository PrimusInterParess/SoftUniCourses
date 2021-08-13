using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.InvalidAquariumType);
            }

            IAquarium aquarium = null;

            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;
                case "SaltwaterAquarium":
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;
            }



            this.aquariums.Add(aquarium);

            return string.Format(Utilities.Messages.OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Plant" && decorationType != "Ornament")
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.InvalidDecorationType);
            }

            IDecoration decoration = null;

            switch (decorationType)
            {
                case "Plant":
                    decoration = new Plant();
                    break;
                case "Ornament":
                    decoration = new Ornament();
                    break;
            }

            this.decorations.Add(decoration);

            return string.Format(Utilities.Messages.OutputMessages.SuccessfullyAdded, decorationType);

        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            IDecoration decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);

            return string.Format(Utilities.Messages.OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);


        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            string aquariumType = aquarium.GetType().Name;

            if (aquariumType.StartsWith("Salt") && fishType.StartsWith("Fresh"))
            {
                return Utilities.Messages.OutputMessages.UnsuitableWater;
            }

            if (aquariumType.StartsWith("Fresh") && fishType.StartsWith("Salt"))
            {
                return Utilities.Messages.OutputMessages.UnsuitableWater;
            }

            IFish fish = null;

            switch (fishType)
            {
                case "FreshwaterFish":
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case "SaltwaterFish":
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;

            }

            aquarium.AddFish(fish);

            return string.Format(Utilities.Messages.OutputMessages.EntityAddedToAquarium, fishType, aquariumName);

        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            aquarium.Feed();

            return string.Format(Utilities.Messages.OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            decimal fishSum = aquarium.Fish.Sum(f => f.Price);
            decimal decorationSum = aquarium.Decorations.Sum(d => d.Price);

            decimal total = fishSum + decorationSum;

            return string.Format(Utilities.Messages.OutputMessages.AquariumValue, aquariumName, $"{total:f2}");
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
