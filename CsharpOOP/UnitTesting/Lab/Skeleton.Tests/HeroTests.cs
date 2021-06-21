using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private Hero hero;
    private string name;
    private Dummy dummy;
   
   

    [SetUp]
    public void SetUp()
    {
        this.name = "Oliver";
       
        this.hero = new Hero(name);
    }

    [Test]
    public void When_Initialized_ShouldSetName()
    {
        Assert.AreEqual(this.name,hero.Name);
    }

    [Test]
    public void When_Initialized_ShoudSetExperienceToZero()
    {
        Assert.AreEqual(0, hero.Experience);
        
    }

    [Test]
    public void When_AttacksAndKillDummyShouldIncreaseExpirience()
    {
        int expectedExpirience = 5;

        dummy = new Dummy(5, 5);
        
        hero.Attack(dummy);

        Assert.AreEqual(expectedExpirience,hero.Experience);
    }
}