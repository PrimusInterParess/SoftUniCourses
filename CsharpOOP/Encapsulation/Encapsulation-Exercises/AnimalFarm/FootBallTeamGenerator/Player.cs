using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallTeamGenerator
{
    public class Player
    {
        private const int MinStats = 0;
        private const int maxStats = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfNameIsInvalid(value, GlobalConstants.InvalidExeptionMassege);

                this.name = value;
            }

        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                Validator.
                    ThrowIfStatsIsInvalid(
                        value,
                        MinStats,
                        maxStats,
                        $"{nameof(Endurance)} should be between {MinStats} and {maxStats}.");

                this.endurance = value;
            }
        }


        public int Sprint
        {
            get => this.sprint;
            private set
            {
                Validator.
                    ThrowIfStatsIsInvalid(
                        value,
                        MinStats,
                        maxStats,
                        $"{nameof(Sprint)} should be between {MinStats} and {maxStats}.");

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                Validator.
                    ThrowIfStatsIsInvalid(
                        value,
                        MinStats,
                        maxStats,
                        $"{nameof(Dribble)} should be between {MinStats} and {maxStats}.");

                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                Validator.
                    ThrowIfStatsIsInvalid(
                        value,
                        MinStats,
                        maxStats,
                        $"{nameof(Passing)} should be between {MinStats} and {maxStats}.");

                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                Validator.
                    ThrowIfStatsIsInvalid(
                        value,
                        MinStats,
                        maxStats,
                        $"{nameof(Shooting)} should be between {MinStats} and {maxStats}.");

                this.shooting = value;
            }
        }

        public double AverageStats
        {
            get => (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0;
        }

    }
}
