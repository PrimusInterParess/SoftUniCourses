<<<<<<< HEAD
﻿using NUnit.Framework;
=======
﻿using System;
using NUnit.Framework;
>>>>>>> a46c38cc30528473311063b476212d7a11da7644

[TestFixture]
public class DummyTests
{
<<<<<<< HEAD
    [Test]
    public void Test1()
    {

=======
    private Dummy dummy;
    private int health;
    private int experience;

    [SetUp]
    public void SetUp()
    {
        this.health = 5;
        this.experience = 5;
        this.dummy = new Dummy(health, experience);
    }

    [Test]
    public void When_Initialized_ShouldSetHealth()
    {
        Assert.AreEqual(this.health, dummy.Health);
    }
    [Test]
    public void When_TakeAttack_ShouldSetReduceHealth()
    {
        int reducingHealth = 1;

        dummy.TakeAttack(reducingHealth);

        Assert.AreEqual(dummy.Health, this.health - reducingHealth);
    }

    [Test]
    public void When_IsDead_ShouldThrowIvalidOperationExpetion()
    {
        dummy.TakeAttack(5);

        Assert.That(() =>
        {
            dummy.TakeAttack(1);
        },Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void When_HealthIsZeroOrLess_ShouldBeDead()
    {
        dummy = new Dummy(-5, 5);

        Assert.AreEqual(true,dummy.IsDead());
    }

    [Test]
    public void When_NotDead_DoesntGiveExperience()
    {
        Assert.That(()=>
        {
             dummy.GiveExperience();
        },Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }

    [Test]
    public void When_IsDead_ShouldReturnExperience()
    {
        dummy = new Dummy(0, 5);

        Assert.AreEqual(dummy.GiveExperience(),this.experience);
>>>>>>> a46c38cc30528473311063b476212d7a11da7644
    }
}
