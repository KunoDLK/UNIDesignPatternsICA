using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocketBeasts.CardHandling;

namespace TestPocketBeasts
{
      [TestFixture]
      public class DecoratorExample
      {
            [Test]
            public void CostDecorator() 
            {
                  int cost = 3;
                        int adjustment = -2;

                  ICard instance = new StandardCard("TestID", "TestName", cost, 2, 5);
                  instance = new CostDecorator(instance, adjustment);

                  Assert.That(instance.ManaCost, Is.EqualTo(cost + adjustment));
            }

            [Test]
            public void AttackDecorator()
            {
                  int strength = 5;
                  int adjustment = 3;

                  ICard instance = new StandardCard("TestID", "TestName", 3, strength, 5);
                  instance = new AttackDecorator(instance, adjustment);

                  Assert.That(instance.Attack, Is.EqualTo(strength + adjustment));
            }

            [Test]
            public void HealthDecorator()
            {
                  int health = 5;
                  int adjustment = -2;

                  ICard instance = new StandardCard("TestID", "TestName", 3, 2, health);
                  instance = new HealthDecorator(instance, adjustment);

                  Assert.That(instance.Health, Is.EqualTo(health + adjustment));
            }
      }
}
