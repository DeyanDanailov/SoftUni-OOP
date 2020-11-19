using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Axe axe;

    private Dummy dummy;

    [SetUp]
    public void SetAxeAndDummy()
    {
        this.axe = new Axe(10, 10);
        this.dummy = new Dummy(20, 20);
    }
    [Test]
    public void AxeShouldNotLoseDurabilityAfterAttack()
    {
       
        //Act
        this.axe.Attack(this.dummy);

        //Assert
        Assert.That(this.axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change affter attack.");
    }
    [Test]
    public void AxeShouldThrowExceptionIfAttackWithBrokenWeapon()
    {
        //Arrange
        var brokenAxe = new Axe(10, 0);

        //Assert
        Assert.That(() => brokenAxe.Attack(this.dummy), //Act
            Throws.InvalidOperationException
            .With.Message.EqualTo("Axe is broken."));

    }
}