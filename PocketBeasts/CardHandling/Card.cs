using System;

// Defining a namespace for handling card attributes
namespace PocketBeasts.CardHandling
{
      // ICard interface declares common properties and methods for cards

      public interface ICard
      {
            string Id { get; }

            string Name { get; }

            int ManaCost { get; }

            int Attack { get; }

            int Health { get; }

            void Damage(int amount);

      }

      // CardDecorator abstract class for implementing decorator pattern on card attributes
      public abstract class CardDecorator : ICard
      {
            protected ICard card;

            // constructor to initialize card zttribute
            protected CardDecorator(ICard card)
            {
                  this.card = card;
            }

            // Defined properties of ICard interface
            public string Id => card.Id;

            public string Name => card.Name;

            public virtual int ManaCost => card.ManaCost;

            public virtual int Attack => card.Attack;

            public int Health => card.Health;

            // Defined method of ICard interface
            public void Damage(int amount)
            {
                  card.Damage(amount);
            }

      }

      // Class to modify Attack attribute of card
      public class AttackDecorator : CardDecorator
      {
            private readonly int additionalAttack;

            public AttackDecorator(ICard card, int additionalAttack) : base(card)
            {
                  this.additionalAttack = additionalAttack;
            }

            // Overriding Attack property to add additional attack value
            public override int Attack => base.Attack + additionalAttack;

      }

      // Class to modify Mana Cost attribute of card
      public class CostDecorator : CardDecorator
      {

            private readonly int additionalCost;

            public CostDecorator(ICard card, int additionalCost) : base(card)
            {
                  this.additionalCost = additionalCost;
            }

            // Overriding ManaCost property to add additional cost value
            public override int ManaCost => base.ManaCost + additionalCost;

      }


      // StandardCard class implements ICard interface

      public class StandardCard : ICard
      {
            private readonly string id;
            private readonly string name;
            private readonly int manaCost;
            private readonly int attack;
            private int health;
            // Constructor to initialize card properties

            public StandardCard(string id, string name, int manaCost, int attack, int health)
            {
                  this.id = id;
                  this.name = name;
                  this.manaCost = manaCost;
                  this.attack = attack;
                  this.health = health;
            }

            // Properties implementation of ICard interface
            public string Id => id;

            public string Name => name;

            public int ManaCost => manaCost;

            public int Attack => attack;

            public int Health => health;



            // Method implementation of Damage from ICard interface

            public void Damage(int amount)

            {
                  health -= amount;
            }
      }
}