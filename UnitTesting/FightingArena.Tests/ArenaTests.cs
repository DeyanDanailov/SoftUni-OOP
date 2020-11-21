
using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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
        public void EnrollShouldThrowExcWhenWarriorHasSameName()
        {
            this.arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
            this.arena.Enroll(new Warrior("Sudjuka", 78,90)),
                INVALID_WARRIOR_ENROLL);
        }

        [Test]
        public void EnrollShouldAddWarrior()
        {
            this.arena.Enroll(warrior);
            Assert.That(this.arena.Warriors, Has.Member(this.warrior));
        }

        [Test]
        public void EnrollShouldIncreaseCount()
        {
            var expectedCount = 2;
            this.arena.Enroll(this.warrior);
            this.arena.Enroll(this.secondWarrior);
            Assert.AreEqual(expectedCount, this.arena.Count);
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
        public void FightShouldThrowExceptionIfAttackerIsNotInCollection(string attackerName, string defenderName)
        {
            //Arrange
            this.arena.Enroll(this.warrior);
            this.arena.Enroll(this.secondWarrior);

            //Assert
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName)); //Act

        }

        [TestCase("Sudjuka", "Dimitrichko")]
        public void FightShouldThrowExceptionIfdeffenderIsNotInCollection(string attackerName, string defenderName)
        {
            //Arrange
            this.arena.Enroll(this.warrior);
            this.arena.Enroll(this.secondWarrior);
            
            //Assert
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName)); //Act

        }
        [TestCase("Duhcho", "Bastuna")]
        public void FightShouldGetAttackIfBothAreInCollection(string attackerName, string defenderName)
        {
            //Arrange
            this.arena.Enroll(this.warrior);
            this.arena.Enroll(this.secondWarrior);
            var megaDeffender = new Warrior("Duhcho", 40, 100);
            this.arena.Enroll(megaDeffender);
            var expAttHP = megaDeffender.HP - this.secondWarrior.Damage;
            var expDeffHP = this.secondWarrior.HP - megaDeffender.Damage;

            //Act
            this.arena.Fight(attackerName, defenderName);

            //Assert
            Assert.AreEqual(expAttHP, megaDeffender.HP);
            Assert.AreEqual(expDeffHP, this.secondWarrior.HP);
        }
    }
}
