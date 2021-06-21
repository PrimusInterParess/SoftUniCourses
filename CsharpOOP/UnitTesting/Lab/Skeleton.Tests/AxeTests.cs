using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private int durabilityPoints;
    private int attackPoints;
    private Dummy dummy;
    private int healthDummy;
    private int experienceDummy;

    [SetUp]
    public void SetUp()
    {
        this.attackPoints = 5;
        this.durabilityPoints = 5;
        this.axe = new Axe(attackPoints, durabilityPoints);

        this.healthDummy = 5;
        this.experienceDummy = 5;
        this.dummy = new Dummy(healthDummy, experienceDummy);
    }

    [Test]
    public void When_Initialized_ShoudSetAttackPoints()
    {
        Assert.AreEqual(this.attackPoints, this.axe.AttackPoints);
    }

    [Test]
    public void When_Initialized_ShoudSetDurabilityPoints()
    {
        Assert.AreEqual(this.durabilityPoints, this.axe.DurabilityPoints);
    }

    [Test]
    public void WhenAttackNullDummy_ShouldThrowNullReferanceEx()
    {
        Assert.Throws<NullReferenceException>(() =>
        {
            this.axe.Attack(null);
        });
    }

    [Test]
    public void When_DurabilityPointsAreZero_ShouldThrowInvalidOperationEx()
    {
        axe = new Axe(5, 0);

        Assert.That(() =>
        {
            axe.Attack(this.dummy);
        }, Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }

    [Test]
    public void When_Attack_ShouldDecreaseDurabilityPoints()
    {
        
        axe.Attack(dummy);
        Assert.AreEqual(axe.DurabilityPoints, this.durabilityPoints - 1);

    }
}