using PocketBeasts.CardHandling;

namespace TestPocketBeasts
{


    [TestFixture]
      public class CardTest
      {
            [Test]
            public void TestGetId()
            {
                  Card instance = new Card("TestID", "TestName", 3, 2, 5);
                  string expResult = "TestID";
                  string result = instance.Id;
                  Assert.That(result, Is.EqualTo(expResult));
            }

            [Test]
            public void TestGetName()
            {
                  Card instance = new Card("TestID", "TestName", 3, 2, 5);
                  string expResult = "TestName";
                  string result = instance.Name;
                  Assert.That(result, Is.EqualTo(expResult));
            }

            [Test]
            public void TestGetManaCost()
            {
                  Card instance = new Card("TestID", "TestName", 3, 2, 5);
                  int expResult = 3;
                  int result = instance.ManaCost;
                  Assert.That(result, Is.EqualTo(expResult));
            }

            [Test]
            public void TestGetAttack()
            {
                  Card instance = new Card("TestID", "TestName", 3, 2, 5);
                  int expResult = 2;
                  int result = instance.Attack;
                  Assert.That(result, Is.EqualTo(expResult));
            }

            [Test]
            public void TestGetHealth()
            {
                  Card instance = new Card("TestID", "TestName", 3, 2, 5);
                  int expResult = 5;
                  int result = instance.Health;
                  Assert.That(result, Is.EqualTo(expResult));
            }

            [Test]
            public void TestDamage()
            {
                  int amount = 3;
                  Card instance = new Card("TestID", "TestName", 3, 2, 5);
                  instance.Damage(amount);
                  int expectedHealth = 2; // Initial health (5) - damage (3)
                  Assert.That(instance.Health, Is.EqualTo(expectedHealth));
            }

            [Test]
            public void TestToString()
            {
                  Card instance = new Card("TestID", "TestName", 3, 2, 5);
                  string expResult = "Card{id='TestID', name='TestName', manaCost=3, attack=2, health=5}";
                  string result = instance.ToString();
                  Assert.That(result, Is.EqualTo(expResult));
            }

            [Test]
            public void TestCompareTo()
            {
                  Card o = new Card("AnotherID", "AnotherName", 2, 1, 4);
                  Card instance = new Card("TestID", "TestName", 3, 2, 5);
                  int expResult = 1; // TestID > AnotherID
                  int result = instance.CompareTo(o);
                  Assert.That(result, Is.EqualTo(expResult));
            }
      }
}