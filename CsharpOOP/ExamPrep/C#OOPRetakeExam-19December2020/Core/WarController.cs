using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> party;
        private List<Item> pool;

        public WarController()
        {
            this.party = new List<Character>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            if (characterType != "Priest" || characterType != "Warrior")
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.InvalidCharacterType,
                    characterType));
            }

            Character character = null;

            switch (characterType)
            {
                case "Priest":
                    character = new Priest(name);
                    break;
                case "Warrior":
                    character = new Warrior(name);
                    break;

            }

            this.party.Add(character);

            return string.Format(Constants.SuccessMessages.JoinParty, name);


        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];


            if (itemName != "FirePotion" || itemName != "HealthPotion")
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.InvalidItem, itemName));
            }

            Item item = null;

            switch (itemName)
            {
                case "FirePotion":
                    item = new FirePotion();
                    break;
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
            }

            this.pool.Add(item);

            return string.Format(Constants.SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string name = args[0];

            Character character = this.party.FirstOrDefault(c => c.Name == name);

            if (character == null)
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, name));
            }

            if (this.pool.Count == 0)
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.ItemPoolEmpty);
            }

            Item item = this.pool[this.pool.Count - 1];

            character.Bag.AddItem(item);

            return string.Format(Constants.SuccessMessages.PickUpItem, name, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return string.Format(Constants.SuccessMessages.UsedItem, character.Name, item.GetType().Name);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            var toGetStats = this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health);

            foreach (var character in toGetStats)
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string attackedName = args[1];

            var characterAttacker = this.party.FirstOrDefault(c => c.Name == attackerName);
            var characterAttacked = this.party.FirstOrDefault(c => c.Name == attackedName);

            if (characterAttacker == null)
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.CharacterNotInParty, attackerName));

            }

            if (characterAttacked == null)
            {
                throw new ArgumentException(
                    string.Format(Constants.ExceptionMessages.CharacterNotInParty, attackedName));
            }

            if (characterAttacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException(ExceptionMessages.AttackFail, attackerName);
            }


            Warrior warrior = (Warrior)characterAttacker;

            warrior.Attack(characterAttacked);

            return string.Format(SuccessMessages.AttackCharacter,warrior.Name,attackedName,warrior.AbilityPoints,characterAttacked.Name,characterAttacked.Health,characterAttacked.)
        }

        public string Heal(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
