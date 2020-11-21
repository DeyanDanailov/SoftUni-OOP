using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private const string INVALID_NAME = "Name should not be empty or whitespace!";
        private const string INVALID_DAMAGE = "Damage value should be positive!";
        private const string INVALID_HP = "HP should not be negative!";
        private const string TOO_LOW_HP = "Your HP is too low in order to attack other warriors!";
        private const string TOO_STRONG_ENEMY = "You are trying to attack too strong enemy";
        private const int MIN_ATTACK_HP = 30;
        private Warrior warrior;
        private Warrior secondWarrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Sudjuka", 50, 18);
            this.secondWarrior = new Warrior("Bastuna", 78, 50);
        }

        [Test]
        public void CheckConstructor()
        {
            var expectedName = "Gencho";
            var expectesDamage = 45;
            var expectedHp = 78;
            var megaWarrior = new Warrior(expectedName, expectesDamage, expectedHp);
            var actualName = megaWarrior.Name;
            var actualDamage = megaWarrior.Damage;
            var actualHp = megaWarrior.HP;
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectesDamage, actualDamage);
            Assert.AreEqual(expectedHp, actualHp);
        }

        [Test]
        public void CheckNameGetter()
        {
            var expected = "Sudjuka";
            var actual = this.warrior.Name;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("         ", 40, 80)]
        public void NameShoulThrowExcIfWhiteSpace(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp), //Act
                INVALID_NAME);
        }
        [TestCase("", 40, 80)]
        public void NameShoulThrowExcIfEmptySpace(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp), //Act
                INVALID_NAME);
        }
        [TestCase(null, 40, 80)]
        public void NameShoulThrowExcIfNull(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp), //Act
                INVALID_NAME);
        }

        [Test]
        public void SetterShouldSetName()
        {
            var expected = "Sudjuka";
            var actual = warrior.Name;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void CheckDamageGetter()
        {
            var expected = 50;
            var actual = this.warrior.Damage;
            Assert.AreEqual(expected, actual);
        }

        
        [TestCase("Mamula", -890, 80)]
        public void DamageShoulThrowExcIfNegative(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp), //Act
                INVALID_DAMAGE);
        }

        [TestCase("Mamula", 0, 80)]
        public void DamageShoulThrowExcIfNull(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp), //Act
                INVALID_DAMAGE);
        }

        [Test]
        public void CheckHPGetter()
        {
            var expected = 18;
            var actual = this.warrior.HP;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Mamula", 78, -5)]
        public void HPShoulThrowExcIfNegative(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp), //Act
                INVALID_HP);
        }

        [TestCase("Kochana", 78, 26)]
        public void AttackShouldThrowExcIfHPLessThanMinAttacker(string name, int damage, int hp)
        {
            //Arrange
            var warriorToAttack = new Warrior(name, damage, hp);

            //Assert
            Assert.Throws<InvalidOperationException>(() => 
            this.warrior.Attack(warriorToAttack), TOO_LOW_HP); //Act

            
        }

        [TestCase("Kochana", 78, 30)]
        public void AttackShouldThrowExcIfHPEqualsMinAttacked(string name, int damage, int hp)
        {
            //Arrange
            var warriorToAttack = new Warrior(name, damage, hp);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            this.secondWarrior.Attack(warriorToAttack), $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"); //Act            
        }

        [TestCase("Kochana", 78, 26)]
        public void AttackShouldThrowExcIfHPLessThanMinAttacked(string name, int damage, int hp)
        {
            //Arrange
            var warriorToAttack = new Warrior(name, damage, hp);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            this.secondWarrior.Attack(warriorToAttack), $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"); //Act            
        }

        [TestCase("Kochana", 78, 45)]
        public void AttackShouldThrowExcIfHPLessThanDamageOfAttacked(string name, int damage, int hp)
        {
            //Arrange
            var warriorToAttack = new Warrior(name, damage, hp);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            this.secondWarrior.Attack(warriorToAttack), TOO_STRONG_ENEMY); //Act            
        }

        [TestCase("Kochana", 39, 45)]
        public void AttackShouldDecreaseAtackerHP(string name, int damage, int hp)
        {
            //Arrange
            var warriorToAttack = new Warrior(name, damage, hp);
            //Act
            var expected = secondWarrior.HP - warriorToAttack.Damage;
            this.secondWarrior.Attack(warriorToAttack);
            var actual = this.secondWarrior.HP;

            //AssertOne
            Assert.AreEqual(expected, actual);
            //AssertTwo
            Assert.AreEqual(0, warriorToAttack.HP);
        }

        [TestCase("Kochana", 39, 79)]
        public void AttackShouldDecreaseAtackedHPIfGreaterThanAttackerDamage(string name, int damage, int hp)
        {
            //Arrange
            var megaDeathWarrior = new Warrior("Mecho", 42, 80);           
            var warriorToAttack = new Warrior(name, damage, hp);
           
            var expectedAttHP = megaDeathWarrior.HP - warriorToAttack.Damage;
            var expectedDeffHP = warriorToAttack.HP - megaDeathWarrior.Damage;
            //Act
            megaDeathWarrior.Attack(warriorToAttack);
            
                       
            //AssertTwo
            Assert.AreEqual(expectedAttHP, megaDeathWarrior.HP);
            Assert.AreEqual(expectedDeffHP, warriorToAttack.HP);
        }
    }
}