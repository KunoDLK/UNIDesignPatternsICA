using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocketBeasts.CardHandling;
using PocketBeasts.CardHandling.Stacks;

namespace TestPocketBeasts
{
    [TestFixture]
      public class PlayerCardsTest
      {

            public static readonly List<ICard> StarterCards = new List<ICard>
            {
                  new StandardCard("BR", "Barn Rat", 1, 1, 1),
                  new StandardCard("SP", "Scampering Pup", 2, 2, 1),
                  new StandardCard("HB", "Hardshell Beetle", 2, 1, 2),
                  new StandardCard("VHC", "Vicious House Cat", 3, 3, 2),
                  new StandardCard("GD", "Guard Dog", 3, 2, 3),
                  new StandardCard("ARH", "All Round Hound", 3, 3, 3),
                  new StandardCard("MO", "Moor Owl", 4, 4, 2),
                  new StandardCard("HT", "Highland Tiger", 5, 4, 4)
            };

            private PlayerCards CreateDeck()
            {
                  return new PlayerCards(StarterCards);
            }

            [Test]
            public void TestCreation()
            {
                  var deck = CreateDeck();

                  Assert.That(StarterCards, Is.EqualTo(deck.Cards));
            }

            [Test]
            public void TestStackCreation()
            {
                  var deck = CreateDeck();

                  deck.AddStack("Test");

                  var stack = deck.GetStack("Test");

                  Assert.That(stack, Is.Not.Null);
            }

            [Test]
            public void TestStackCard()
            {
                  var deck = CreateDeck();

                  deck.AddStack("Test");

                  var stack = deck.GetStack("Test");
                  stack.Add(deck.Cards.First());

                  var card = deck.GetStack("Test").Draw();

                  Assert.That(card, Is.EqualTo(deck.Cards.First()));
            }

            [Test]
            public void TestStackCardTransferCardArrived()
            {
                  PlayerCards deck = TransferTest();

                  var card = deck.GetStack("Test1").Draw();

                  Assert.That(card, Is.EqualTo(deck.Cards.First()));
            }

            [Test]
            public void TestStackCardTransferCardLeft()
            {
                  PlayerCards deck = TransferTest();

                  var stack = deck.GetStack("Test");

                  Assert.That(stack.Count, Is.EqualTo(0));
            }

            private PlayerCards TransferTest()
            {
                  var deck = CreateDeck();

                  deck.AddStack("Test");
                  deck.AddStack("Test1");

                  var stack = deck.GetStack("Test");
                  stack.Add(deck.Cards.First());

                  deck.TransferToFrom("Test", "Test1");
                  return deck;
            }

            [Test]
            public void TestRemoveAll()
            {
                  PlayerCards deck = CreateDeck();

                  deck.AddStack("Test");
                  var stack = deck.GetStack("Test");

                  stack.Add(deck.Cards.First());
                  stack.Add(deck.Cards.First());

                  stack.RemoveAll();

                  Assert.That(stack.Count, Is.EqualTo(0));
            }

            [Test]
            public void TestShuffle()
            {
                  PlayerCards deck = CreateDeck();

                  deck.AddShuffableStack("Test");
                  var stack = deck.GetStack("Test");

                  foreach (var item in deck.Cards)
                  {
                        stack.Add(item);
                  }

                  ((ShuffelableStack)stack).Shuffle();

                  int different = 0;

                  for (int i = 0; i < stack.Count; i++)
                  {
                        if (stack.Cards[i] != deck.Cards[i])
                        {
                              different++;
                        }
                  }

                  if (different > 0)
                  {
                        Assert.Pass();
                  }

                  different = 0;
                  ((ShuffelableStack)stack).Shuffle();

                  for (int i = 0; i < stack.Count; i++)
                  {
                        if (stack.Cards[i] != deck.Cards[i])
                        {
                              different++;
                        }
                  }

                  if (different == 0)
                  {
                        Assert.Fail();
                  }
                  else
                  {
                        Assert.Pass();
                  }

            }
      }
}
