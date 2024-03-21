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
using System.Text;
using PocketBeasts.CardHandling;

namespace PocketBeasts
{
      public class Player
      {
            private const int MaxMana = 9;

            private readonly string name;

            private int manaAvailable;
            private int manaTicker;
            private int health;

            private PlayerCards _playerCards;

            public Player(string name, List<Card> deck)
            {
                  this.name = name;
                  this.manaAvailable = 0;
                  this.manaTicker = 0;
                  this.health = 15;
                  PlayerCards = new PlayerCards(deck);
                  PlayerCards.AddStack("deck");
                  PlayerCards.AddStack("hand");
                  PlayerCards.AddStack("inplay");
                  PlayerCards.AddStack("graveyard");
                  Deck.Cards.AddRange(PlayerCards.Cards);
            }

            public string Name
            {
                  get { return this.name; }
            }

            public int ManaAvailable
            {
                  get { return this.manaAvailable; }
            }

            public int Health
            {
                  get { return this.health; }
            }

            public PlayerCards PlayerCards
            {
                  get { return _playerCards; }
                  private set { _playerCards = value; }
            }

            public Stack Deck
            {
                  get { return PlayerCards.GetStack("deck"); }
            }

            public Stack Hand
            {
                  get { return PlayerCards.GetStack("hand"); }
            }

            public Stack InPlay
            {
                  get { return PlayerCards.GetStack("inplay"); }
            }

            public Stack Graveyard
            {
                  get { return PlayerCards.GetStack("graveyard"); }
            }

            public void NewGame()
            {
                  this.Deck.Shuffle();
                  for (int i = 0; i < 4; i++)
                  {
                        this.Hand.Add(this.Deck.Draw());
                  }
            }

            public void AddMana()
            {
                  if (this.manaTicker < MaxMana)
                  {
                        this.manaTicker++;
                  }
                  this.manaAvailable = manaTicker;
            }

            public void UseMana(int amount)
            {
                  this.manaAvailable -= amount;
            }

            public void DrawCard()
            {
                  this.Hand.Add(this.Deck.Draw());
            }

            public bool Damage(int amount)
            {
                  this.health -= amount;
                  return this.health <= 0;
            }

            public override string ToString()
            {
                  StringBuilder sb = new StringBuilder();
                  sb.Append($"{this.name,-9} HEALTH/{this.health,-5} MANA/{this.manaAvailable}\n");

                  for (int i = 0; i < InPlay.Count + 2; i++)
                  {
                        sb.Append("+-------+ ");
                  }
                  sb.Append("\n");

                  for (int i = 0; i < 2; i++)
                  {
                        sb.Append("|       | ");
                  }
                  for (int i = 0; i < this.InPlay.Count; i++)
                  {
                        sb.Append($"{this.InPlay.Cards[i].ManaCost,7}| ");
                  }
                  sb.Append("\n");

                  sb.Append("| DECK  | ");
                  sb.Append("| GRAVE | ");
                  for (int i = 0; i < this.InPlay.Count; i++)
                  {
                        sb.Append($"{this.InPlay.Cards[i].Id,-5}| ");
                  }
                  sb.Append("\n");

                  sb.Append($"{this.Deck.Count,-6}| ");
                  sb.Append($"{this.Graveyard.Count,-6}| ");
                  for (int i = 0; i < this.InPlay.Count; i++)
                  {
                        sb.Append("|       | ");
                  }
                  sb.Append("\n");

                  for (int i = 0; i < 2; i++)
                  {
                        sb.Append("|       | ");
                  }
                  for (int i = 0; i < this.InPlay.Count; i++)
                  {
                        sb.Append($"{this.InPlay.Cards[i].Attack,-2} {this.InPlay.Cards[i].Health,4}| ");
                  }
                  sb.Append("\n");

                  for (int i = 0; i < this.InPlay.Count + 2; i++)
                  {
                        sb.Append("+-------+ ");
                  }
                  sb.Append("\n");
                  sb.Append($"{this.Hand.Count} card(s) in hand.\n\n");
                  sb.Append(this.Hand.ToString());

                  return sb.ToString();
            }
      }
}

