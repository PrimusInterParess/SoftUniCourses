using System;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {


        [Test]
        [TestCase("  ", 5, 0)]
        [TestCase(null, 5, 0)]
        [TestCase(null, 0, 0)]
        [TestCase(null, -5, 0)]
        [TestCase(null, 1, -6)]
        public void CtorShould_ThrowExWhenInsertingInvalidData(string name, int damage, int health)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, health));
        }
        
        [Test]
        [TestCase("Attacker", 10, 30, "Attacked", 10, 30)]
        [TestCase("Attacker", 10, 31, "Attacked", 10, 30)]
        [TestCase("Attacker", 10, 40, "Attacked", 41, 31)]
        public void WhenAttack_ShouldThrowEx(
            string attackerName,int attackerDamage,int attackerHealth,
            string attackedName,int attackedDamage,int attackedHealth)
        {
            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHealth);
            Warrior attacked = new Warrior(attackedName, attackedDamage, attackedHealth);

            Assert.Throws<InvalidOperationException>(()=>attacker.Attack(attacked));
        }

        [Test]
        public void Should_DecreaseAttackerHealthWhenAttack()
        {
            Warrior attacker = new Warrior("attacker", 10, 50);
            Warrior attacked = new Warrior("attacked", 10, 50);

            int redusedHealth = attacker.HP - attacked.Damage;
            attacker.Attack(attacked);

            Assert.AreEqual(redusedHealth,attacker.HP);

        }

        [Test]
        public void Should_DecreaseAttackedHealthToZero_WhenAttackWithExceededDamage()
        {
            Warrior attacker = new Warrior("attacker", 50, 50);
            Warrior attacked = new Warrior("attacked", 10, 40);

            int attackedHp = 0;
            attacker.Attack(attacked);

            Assert.AreEqual(attacked.HP, attackedHp);

        }

        [Test]
        public void Should_DecreaseAttackedHealth_WhenAttack()
        {
            Warrior attacker = new Warrior("attacker", 10, 50);
            Warrior attacked = new Warrior("attacked", 10, 50);

            int attackedHp = attacked.HP-attacker.Damage;
            attacker.Attack(attacked);

            Assert.AreEqual(attacked.HP, attackedHp);

        }
    }
}