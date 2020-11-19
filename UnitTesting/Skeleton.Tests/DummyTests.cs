using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int EXPERIENCE = 20;
    private Dummy deadDummy;
    private Dummy aliveDummy;

    [SetUp]
    public void SetAliveAndDeadDummy()
    {
        this.aliveDummy = new Dummy(20, EXPERIENCE);
        this.deadDummy = new Dummy(0, EXPERIENCE);
    }
    [Test]
    public void DummyShouldLoseHealthAfterAttack()
    {
        //Act
        this.aliveDummy.TakeAttack(10);

        //Assert
        Assert.That(this.aliveDummy.Health.Equals(10));
    }
    [Test]
    public void DeadDummyShouldThrowExceptionIfAttacked()
    {


        //Assert
        Assert.That(() => this.deadDummy.TakeAttack(10), // Act
            Throws.InvalidOperationException
            .With.Message.EqualTo("Dummy is dead."));
       
    }
    [Test]
    public void DeadDummyShouldGiveExperience()
    {

        //Act
        var exp = this.deadDummy.GiveExperience();

        //Assert
        Assert.AreEqual(exp, EXPERIENCE);
    }
    [Test]
    public void AliveDummyCannotGiveExperience()
    {

        //Assert
        Assert.That(() => this.aliveDummy.GiveExperience(), //Act
           Throws.InvalidOperationException
           .With.Message.EqualTo("Target is not dead."));
    }
}
