using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return Utilities.Messages.OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                
                return string.Format(Utilities.Messages.OutputMessages.OneRacerIsNotAvailable, racerTwo.Username,
                    racerOne.Username);
            }

            if (!racerTwo.IsAvailable())
            {
               
                return string.Format(Utilities.Messages.OutputMessages.OneRacerIsNotAvailable, racerOne.Username,
                    racerTwo.Username);
            }

            double raceOneMultiplier = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            double raceTwoMultiplier = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;

            double chanceOfWinningRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * raceOneMultiplier;
            double chanceOfWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * raceTwoMultiplier;

            racerOne.Race();
            racerTwo.Race();
            if (chanceOfWinningRacerOne > chanceOfWinningRacerTwo)
            {
                return string.Format(Utilities.Messages.OutputMessages.RacerWinsRace, racerOne.Username,
                    racerTwo.Username, racerOne.Username);
            }

            return string.Format(Utilities.Messages.OutputMessages.RacerWinsRace, racerOne.Username,
                racerTwo.Username, racerTwo.Username);
        }
    }
}
