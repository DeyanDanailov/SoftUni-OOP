
using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private const string INVALID_WARRIOR_ENROLL = "Warrior is already enrolled for the fights!";
        private Arena arena;
        private Warrior warrior;
        private Warrior secondWarrior;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior = new Warrior("Sudjuka", 50, 18);
            this.secondWarrior = new Warrior("Bastuna", 78, 50);
        }

        [Test]
        public void CheckConstructor()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }
        
        [Test]
        public void WarriorsPropShouldReturnWarriorsCollection()
        {
            var expected =  new List<Warrior>();
            var actual = this.arena.Warriors;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EnrollShouldThrowExcWhenWarriorIsInCollection()
        {
            this.arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => 
            this.arena.Enroll(warrior),
                INVALID_WARRIOR_ENROLL);
        }

        [Test]
        public void EnrollShouldAddWarrior()
        {
            this.arena.Enroll(warrior);
            Assert.That(this.arena.Warriors, Has.Member(this.warrior));
        }

        [Test]
        public void CountShouldReturnWarriorsCount()
        {
            this.arena.Enroll(this.warrior);
            var expected = 1;
            var actual = this.arena.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Leshpera", "Bastuna")]
        [TestCase("Sudjuka", "Dimitrichko")]
        public void FightShouldThrowExceptionIfAttackerIsNotInCollection(string attackerName, string defenderName)
        {
            //Arrange
            this.arena.Enroll(this.warrior);
            this.arena.Enroll(this.secondWarrior);
            string missingName = String.Empty;
            if (this.arena.Warriors.Any(w=>w.Name != attackerName))
            {
                missingName = attackerName;
            }
            else
            {
                missingName = defenderName;
            }
           
            //Assert
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName), // Act
                $"There is no fighter with name {0} enrolled for the fights!", missingName);

        }

        //[TestCase("Sudjuka", "Bastuna")]
        //public void FightShouldGetAttackIfBothAreInCollection(string attackerName, string defenderName)
        //{
        //    Warrior attacker = this.arena.Warriors
        //        .FirstOrDefault(w => w.Name == attackerName);
        //    Warrior defender = this.arena.Warriors
        //        .FirstOrDefault(w => w.Name == defenderName);
        //    warrior.Attack(secondWarrior);

        //    Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender),
        //        "Your HP is too low in order to attack other warriors!");
        //}
    }
}
