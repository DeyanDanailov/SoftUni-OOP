using System;
using Moq;
using NUnit.Framework;
using Skeleton;

[TestFixture]
public class AxeTests
{
    private Axe axe;

    //private Dummy dummy;

    [SetUp]
    public void SetAxeAndDummy()
    {
        this.axe = new Axe(10, 10);
        //this.dummy = new Dummy(20, 20);
       
    }
    [Test]
    public void AxeShouldNotLoseDurabilityAfterAttack()
    {
        //Arrange
        var fakeDummy = new Mock<ITarget>();

        //fakeDummy
        //    .Setup(i => i.TakeAttack(It.IsAny<int>()))
        //    .Callback((int attackPoints) =>attPoints = attackPoints);

        //fakeDummy
        //    .Setup(i => i.IsDead()).Returns(false);

        fakeDummy
            .Setup(i => i.GiveExperience()).Returns(20);
        fakeDummy
            .Setup(i => i.Health).Returns(20);

        //Act
        //this.axe.Attack(this.dummy);
        this.axe.Attack(fakeDummy.Object);
        //Assert
        Assert.That(this.axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change affter attack.");
    }
    [Test]
    public void AxeShouldThrowExceptionIfAttackWithBrokenWeapon()
    {
        //Arrange
        var brokenAxe = new Axe(10, 0);
        var fakeDummy = new Mock<ITarget>();

        fakeDummy
            .Setup(i => i.GiveExperience()).Returns(20);
        fakeDummy
            .Setup(i => i.Health).Returns(20);

        //Assert
        Assert.That(() => brokenAxe.Attack(fakeDummy.Object), //Act
            Throws.InvalidOperationException
            .With.Message.EqualTo("Axe is broken."));

    }
}