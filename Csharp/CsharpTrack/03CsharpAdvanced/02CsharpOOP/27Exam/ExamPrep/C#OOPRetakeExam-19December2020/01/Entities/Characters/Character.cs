using System;
using System.Transactions;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.


        private readonly double baseHealth;
        private readonly double baseArmor;
        protected readonly double abilityPoints;



        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.baseHealth = health;
            this.Health = health;
            this.baseArmor = armor;
            this.Armor = armor;
            this.abilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public bool IsAlive { get; set; } = true;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Constants.ExceptionMessages.CharacterNameInvalid);
                }

                this.name = value;
            }
        }

        public double BaseArmor => this.baseArmor;

        public double BaseHealth => this.baseHealth;

        public double AbilityPoints => this.abilityPoints;

        public double Health
        {
            get => this.health;
            //???????
            set
            {
                ///????????? Health (current health) should never be more than the BaseHealth or less than 0.

                if (value < 0)
                {
                    this.health = 0;
                    this.IsAlive = false;
                }
                else if (value > baseHealth)
                {
                    this.health = baseHealth;
                }
                else
                {
                    this.health = value;
                }


            }
        }





        public double Armor
        {
            get => this.armor;
            private set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }
                else if (value > this.baseArmor)
                {
                    this.armor = baseArmor;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        public Bag Bag { get; private set; }



        public void TakeDamage(double hitPoints)
        {
            var reducedHitpoints = 0.0;

            this.EnsureAlive();

            var toReduce = hitPoints - this.Armor;
            this.Armor -= hitPoints;

            if (toReduce > 0)
            {
                this.Health -= toReduce;
            }

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }

            //if (this.armor >= hitPoints)
            //{
            //    this.armor -= hitPoints;
            //}
            //else
            //{
            //    reducedHitpoints = hitPoints - this.armor;

            //    armor -= hitPoints;
            //}

            //this.health -= reducedHitpoints;

          
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);

            this.EnsureAlive();

            //TODO The item affects the character with the item effect.
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public override string ToString()
        {
            return string.Format(SuccessMessages.CharacterStats, this.Name, this.Health, this.baseHealth, this.Armor, this.baseArmor, this.IsAlive == true ? "Alive" : "Dead");
        }
    }
}