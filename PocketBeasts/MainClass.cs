using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocketBeasts.UserInterface;

namespace PocketBeasts
{
      class MainClass
      {
            public static readonly Card[] StarterCards = new Card[]
            {
            new Card("BR", "Barn Rat", 1, 1, 1),
            new Card("SP", "Scampering Pup", 2, 2, 1),
            new Card("HB", "Hardshell Beetle", 2, 1, 2),
            new Card("VHC", "Vicious House Cat", 3, 3, 2),
            new Card("GD", "Guard Dog", 3, 2, 3),
            new Card("ARH", "All Round Hound", 3, 3, 3),
            new Card("MO", "Moor Owl", 4, 4, 2),
            new Card("HT", "Highland Tiger", 5, 4, 4)
            };

            public static List<Card> GetStarterDeck()
            {
                  List<Card> starterDeck = new List<Card>();

                  for (int i = 0; i < 2; i++)
                  {
                        starterDeck.AddRange(StarterCards.Select(card => new Card(card)));
                  }

                  return starterDeck;
            }

            public void Run(Display display)
            {
                  display.OutputText("");
                  display.OutputText("-+-+-+-+-+-+-+-+-+-+-+-+");
                  display.OutputText("Welcome to PocketBeasts!");
                  display.OutputText("-+-+-+-+-+-+-+-+-+-+-+-+");
                  display.OutputText("");
                  display.OutputText("This basic console application tests our underlying software design patterns.");
                  display.OutputText("");
                  display.OutputText("Here's a key for each card:");
                  display.OutputText("");
                  display.OutputText("                             +-------+ ");
                  display.OutputText("M  = Mana Cost               |      M| ");
                  display.OutputText("ID = Card identifier:        |  ID   | ");
                  display.OutputText("A  = Attack:                 |       | ");
                  display.OutputText("H  = Health:                 |A     H| ");
                  display.OutputText("                             +-------+ ");
                  display.OutputText("");
                  display.OutputText("New players each start with 15 Health and 1 Mana to spend on playing cards.");
                  display.OutputText("At the start of the game each player draws 4 cards from their deck to hand.");
                  display.OutputText("");
                  display.OutputText("Players each take turns. Each turn consists four phases:");
                  display.OutputText("1. Add mana (mana increases by one each turn and replenishes in full).");
                  display.OutputText("2. Draw a card.");
                  display.OutputText("3. Cycle through your cards in play (if any), choosing whether to attack.");
                  display.OutputText("   a. Attacking the other player directly with your card inflicts damage to their health.");
                  display.OutputText("      equal to the attack power of the card.");
                  display.OutputText("   b. Attacking another player's beast will damage both cards (equal to their attack values).");
                  display.OutputText("   c. Any beast with <= 0 health is removed from the play field and placed into the graveyard.");
                  display.OutputText("4. Play cards from hand.");
                  display.OutputText("");

                  display.GetPrompt("Press ENTER to continue...", new string[] { "" });


                  Player[] players = new Player[]
                  {
                        new Player("James", GetStarterDeck()),
                        new Player("Steve", GetStarterDeck())
                  };

                  foreach (Player player in players)
                  {
                        player.NewGame();
                        Console.WriteLine(player);
                  }

                  string winningMessage = "";
                  bool run = true;
                  while (run)
                  {
                        foreach (Player player in players)
                        {
                              // Add mana and draw card
                              player.AddMana();
                              player.DrawCard();

                              // Print initial play state
                              Console.WriteLine(player);

                              // HACK assumes only one other player
                              Player otherPlayer = players.First(p => p != player);
                              if (otherPlayer == null)
                              {
                                    winningMessage = "Something has gone terribly wrong...";
                                    run = false;
                                    break;
                              }

                              // Cycle through cards in play to attack
                              foreach (Card card in player.InPlay.Cards)
                              {
                                    Console.WriteLine(card.ToString());

                                    if (display.GetBooleanPrompt($"{player.Name} attack with {card.Name}?"))
                                    {
                                          // Choose who to attack, player directly or a player's beast
                                          Console.WriteLine("Who would you like to attack? ");
                                          Console.WriteLine("1. " + otherPlayer.Name);

                                          for (int i = 0; i < otherPlayer.InPlay.Count; i++)
                                          {
                                                Console.WriteLine($"{i + 2}. {otherPlayer.InPlay.Cards[i]}");
                                          }

                                          string[] prompts = Enumerable.Range(1, otherPlayer.InPlay.Count + 1)
                                              .Select(i => i.ToString())
                                              .ToArray();

                                          string target = display.GetPrompt("Choose a number: ", prompts);

                                          if (target.Equals("1")) // Player
                                          {
                                                if (otherPlayer.Damage(card.Attack))
                                                {
                                                      // if true returned player's health <= 0
                                                      winningMessage = $"{player.Name} wins!";
                                                      run = false;
                                                      break;
                                                }

                                                Console.WriteLine($"{otherPlayer.Name} is now at {otherPlayer.Health}");
                                          }
                                          else // Beast, index is `target-2`
                                          {
                                                Card targetCard = otherPlayer.InPlay.Cards[int.Parse(target) - 2];
                                                targetCard.Damage(card.Attack);
                                                card.Damage(targetCard.Attack);
                                          }
                                    }
                              }

                              if (!run)
                              {
                                    break;
                              }

                              // Cycle through cards in play remove "dead" cards (health <= 0)
                              List<Card> toRemove = player.InPlay.Cards.Where(card => card.Health <= 0).ToList();

                              foreach (Card card in toRemove)
                              {
                                    player.Graveyard.Add(card);
                              }

                              player.InPlay.RemoveAll(toRemove);

                              toRemove = otherPlayer.InPlay.Cards.Where(card => card.Health <= 0).ToList();

                              foreach (Card card in toRemove)
                              {
                                    otherPlayer.Graveyard.Add(card);
                              }

                              otherPlayer.InPlay.RemoveAll(toRemove);

                              // Play cards from hand
                              toRemove = new List<Card>();
                              foreach (Card card in player.Hand.Cards)
                              {
                                    if (card.ManaCost <= player.ManaAvailable)
                                    {
                                          Console.WriteLine(card.ToString());

                                          if (display.GetBooleanPrompt($"{player.Name} play {card.Name}?"))
                                          {
                                                player.InPlay.Add(card);
                                                player.UseMana(card.ManaCost);
                                                toRemove.Add(card);
                                          }
                                    }
                              }

                              player.Hand.RemoveAll(toRemove);

                              // Print final play state
                              Console.Clear();
                              Console.WriteLine(player);
                        }
                  }

                  Console.WriteLine(winningMessage);
            }
      }
}
