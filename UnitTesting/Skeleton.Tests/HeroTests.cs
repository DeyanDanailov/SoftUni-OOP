using Moq;
using NUnit.Framework;
using Skeleton;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroShouldGainXPWhenTargetDies()
    {
        //Arrange
        Mock fakeAxe = new Mock<IWeapon>();
        fakeAxe
            .SetReturnsDefault<int>(20);
        var hero = new Hero("Barakudata", (IWeapon)fakeAxe.Object);

        var fakeDummy = new Mock<ITarget>();

        fakeDummy
            .Setup(i => i.GiveExperience()).Returns(20);
        fakeDummy
            .Setup(i => i.IsDead()).Returns(true);
        var expected = fakeDummy.Object.GiveExperience();
        //Act
        hero.Attack(fakeDummy.Object);

        //Assert
        var actual = hero.Experience;
        Assert.AreEqual(expected, actual);
    }
}
