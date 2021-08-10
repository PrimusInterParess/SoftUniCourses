using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double baseHealth = 100;
        private const double baseArmor = 50;
        private const double abilityPoints = 40;


        public Warrior(string name)
             : base(name, baseHealth, baseArmor, abilityPoints, new Satchel())
        {
        }



        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (this.Equals(character))
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(base.abilityPoints);
        }
    }
}
