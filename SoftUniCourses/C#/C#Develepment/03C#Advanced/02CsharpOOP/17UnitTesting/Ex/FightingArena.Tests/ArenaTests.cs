using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
       

        [Test]
        public void EnrowShouldThrowExIfWarriorExists()
        {
            Arena arena = new Arena();

            Warrior firstWarioWarrior = new Warrior("Dani" ,50, 150);
            Warrior secondWarrior = new Warrior("Tosho" ,450, 125);
            Warrior primus = new Warrior("Kire", 10000, 10000);

            arena.Enroll(firstWarioWarrior);
            arena.Enroll(secondWarrior);
            arena.Enroll(primus);

            Assert.Throws<InvalidOperationException>(()=> arena.Enroll(firstWarioWarrior));
        }

        [Test]
        public void Enroll_ShouldAdd_Warrior()
        {
            Arena arena = new Arena();

            Warrior primus = new Warrior("Kire", 10000, 10000);

            arena.Enroll(primus);

            Assert.That(()=>arena.Warriors.Contains(primus));
        }

        [Test]
        [TestCase("tosho","mosho")]
       
        public void Fight_Should_ThrowExWithIncorectData(string firstName,string secondName)
        {
            Warrior first = new Warrior(firstName, 15, 60);
            Warrior second = new Warrior(secondName, 15, 60);


            Arena arena = new Arena();

            arena.Enroll(first);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(firstName, secondName));

            string nikoi = "nikoi";
            Assert.Throws<InvalidOperationException>(() => arena.Fight(nikoi, firstName));


        }

        [Test]
        [TestCase("tosho", "mosho")]
        public void FightShouldWorkCorectlyWithCorrectData(string firstName,string secondName)
        {

            Arena arena = new Arena();


            Warrior first = new Warrior(firstName, 15, 60);
            Warrior second = new Warrior(secondName, 15, 60);

            arena.Enroll(first);
            arena.Enroll(second);
            int attackedhp = second.HP - first.Damage;


            arena.Fight(firstName, secondName);

            Assert.AreEqual(attackedhp,first.HP);
            Assert.AreEqual(attackedhp,second.HP);
        }
    }
}
