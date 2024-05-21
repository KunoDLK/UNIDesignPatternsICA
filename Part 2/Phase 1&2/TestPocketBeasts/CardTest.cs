using PocketBeasts.CardHandling;

namespace TestPocketBeasts
{


    [TestFixture]
      public class CardTest
      {
            [Test]
            public void TestGetId()
            {
                  StandardCard instance = new StandardCard("TestID", "TestName", 3, 2, 5);
                  string expResult = "TestID";
                  string result = instance.Id;
                  Assert.That(result, Is.EqualTo(expResult));
            }

            [Test]
            public void TestGetName()
            {
                  StandardCard instance = new StandardCard("TestID", "TestName", 3, 2, 5);
                  string expResult = "TestName";
                  string result = instance.Name;
                  Assert.That(result, Is.EqualTo(expResult));
            }

            [Test]
            public void TestGetManaCost()
            {
                  StandardCard instance = new StandardCard("TestID", "TestName", 3, 2, 5);
                  int expResult = 3;
                  int result = instance.ManaCost;
                  Assert.That(result, Is.EqualTo(expResult));
            }

            [Test]
            public void TestGetAttack()
            {
                  StandardCard instance = new StandardCard("TestID", "TestName", 3, 2, 5);
                  int expResult = 2;
                  int result = instance.Attack;
                  Assert.That(result, Is.EqualTo(expResult));
            }

            [Test]
            public void TestGetHealth()
            {
                  StandardCard instance = new StandardCard("TestID", "TestName", 3, 2, 5);
                  int expResult = 5;
                  int result = instance.Health;
                  Assert.That(result, Is.EqualTo(expResult));
            }

            [Test]
            public void TestDamage()
            {
                  int amount = 3;
                  StandardCard instance = new StandardCard("TestID", "TestName", 3, 2, 5);
                  instance.Damage(amount);
                  int expectedHealth = 2; // Initial health (5) - damage (3)
                  Assert.That(instance.Health, Is.EqualTo(expectedHealth));
            }

            [Test]
            public void TestToString()
            {
                  StandardCard instance = new StandardCard("TestID", "TestName", 3, 2, 5);
                  string expResult = "Card{id='TestID', name='TestName', manaCost=3, attack=2, health=5}";
                  string result = instance.ToString();
                  Assert.That(result, Is.EqualTo(expResult));
            }
      }
}