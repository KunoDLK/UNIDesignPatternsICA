/*
 * This file is part of PocketBeasts.
 *
 * PocketBeasts is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * PocketBeasts is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Foobar.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
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

            public static string GetPrompt(string prompt, string[] validResponse)
            {
                  Console.Write(prompt);

                  string response = Console.ReadLine();

                  if (validResponse.Contains(response, StringComparer.OrdinalIgnoreCase))
                  {
                        return response;
                  }

                  return GetPrompt(prompt, validResponse);
            }

            public static void Main(string[] args)
            {
                  Console.WriteLine("");
                  Console.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+");
                  Console.WriteLine("Welcome to PocketBeasts!");
                  Console.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+");
                  Console.WriteLine("");
                  Console.WriteLine("This basic console application tests our underlying software design patterns.");
                  Console.WriteLine("");
                  Console.WriteLine("Here's a key for each card:");
                  Console.WriteLine("");
                  Console.WriteLine("                             +-------+ ");
                  Console.WriteLine("M  = Mana Cost               |      M| ");
                  Console.WriteLine("ID = Card identifier:        |  ID   | ");
                  Console.WriteLine("A  = Attack:                 |       | ");
                  Console.WriteLine("H  = Health:                 |A     H| ");
                  Console.WriteLine("                             +-------+ ");
                  Console.WriteLine("");
                  Console.WriteLine("New players each start with 15 Health and 1 Mana to spend on playing cards.");
                  Console.WriteLine("At the start of the game each player draws 4 cards from their deck to hand.");
                  Console.WriteLine("");
                  Console.WriteLine("Players each take turns. Each turn consists four phases:");
                  Console.WriteLine("1. Add mana (mana increases by one each turn and replenishes in full).");
                  Console.WriteLine("2. Draw a card.");
                  Console.WriteLine("3. Cycle through your cards in play (if any), choosing whether to attack.");
                  Console.WriteLine("   a. Attacking the other player directly with your card inflicts damage to their health.");
                  Console.WriteLine("      equal to the attack power of the card.");
                  Console.WriteLine("   b. Attacking another player's beast will damage both cards (equal to their attack values).");
                  Console.WriteLine("   c. Any beast with <= 0 health is removed from the play field and placed into the graveyard.");
                  Console.WriteLine("4. Play cards from hand.");
                  Console.WriteLine("");

                  Console.WriteLine("Press ENTER to continue...");
                  Console.ReadLine();

                  Player[] players = new Player[]
                  {
                new Player("James", new Deck(GetStarterDeck())),
                new Player("Steve", new Deck(GetStarterDeck()))
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

                                    if (ConsoleDisplay.GetBooleanPrompt($"{player.Name} attack with {card.Name}?"))
                                    {
                                          // Choose who to attack, player directly or a player's beast
                                          Console.WriteLine("Who would you like to attack? ");
                                          Console.WriteLine("1. " + otherPlayer.Name);

                                          for (int i = 0; i < otherPlayer.InPlay.Count; i++)
                                          {
                                                Console.WriteLine($"{i + 2}. {otherPlayer.InPlay.GetCard(i)}");
                                          }

                                          string[] prompts = Enumerable.Range(1, otherPlayer.InPlay.Count + 1)
                                              .Select(i => i.ToString())
                                              .ToArray();

                                          string target = GetPrompt("Choose a number: ", prompts);

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
                                                Card targetCard = otherPlayer.InPlay.GetCard(int.Parse(target) - 2);
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

                                          if (ConsoleDisplay.GetBooleanPrompt($"{player.Name} play {card.Name}?"))
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
