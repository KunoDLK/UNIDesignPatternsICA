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

namespace uk.ac.tees.cis2001.pocketbeasts
{
      public class Player
      {
            private const int MaxMana = 9;

            private readonly string name;

            private int manaAvailable;
            private int manaTicker;
            private int health;

            private readonly Deck deck;
            private readonly Hand hand;
            private readonly InPlay inPlay;
            private readonly Graveyard graveyard;

            public Player(string name, Deck deck)
            {
                  this.name = name;
                  this.manaAvailable = 0;
                  this.manaTicker = 0;
                  this.health = 15;
                  this.deck = deck;
                  this.hand = new Hand();
                  this.inPlay = new InPlay();
                  this.graveyard = new Graveyard();
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

            public Deck Deck
            {
                  get { return this.deck; }
            }

            public Hand Hand
            {
                  get { return this.hand; }
            }

            public InPlay InPlay
            {
                  get { return this.inPlay; }
            }

            public Graveyard Graveyard
            {
                  get { return this.graveyard; }
            }

            public void NewGame()
            {
                  this.deck.Shuffle();
                  for (int i = 0; i < 4; i++)
                  {
                        this.hand.Add(this.deck.Draw());
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
                  this.hand.Add(this.deck.Draw());
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

                  for (int i = 0; i < this.inPlay.Count + 2; i++)
                  {
                        sb.Append("+-------+ ");
                  }
                  sb.Append("\n");

                  for (int i = 0; i < 2; i++)
                  {
                        sb.Append("|       | ");
                  }
                  for (int i = 0; i < this.inPlay.Count; i++)
                  {
                        sb.Append($"{this.inPlay.GetCard(i).ManaCost,7}| ");
                  }
                  sb.Append("\n");

                  sb.Append("| DECK  | ");
                  sb.Append("| GRAVE | ");
                  for (int i = 0; i < this.inPlay.Count; i++)
                  {
                        sb.Append($"{this.inPlay.GetCard(i).Id,-5}| ");
                  }
                  sb.Append("\n");

                  sb.Append($"{this.deck.Count,-6}| ");
                  sb.Append($"{this.graveyard.Count,-6}| ");
                  for (int i = 0; i < this.inPlay.Count; i++)
                  {
                        sb.Append("|       | ");
                  }
                  sb.Append("\n");

                  for (int i = 0; i < 2; i++)
                  {
                        sb.Append("|       | ");
                  }
                  for (int i = 0; i < this.inPlay.Count; i++)
                  {
                        sb.Append($"{this.inPlay.GetCard(i).Attack,-2} {this.inPlay.GetCard(i).Health,4}| ");
                  }
                  sb.Append("\n");

                  for (int i = 0; i < this.inPlay.Count + 2; i++)
                  {
                        sb.Append("+-------+ ");
                  }
                  sb.Append("\n");
                  sb.Append($"{this.hand.Count} card(s) in hand.\n\n");
                  sb.Append(this.hand.ToString());

                  return sb.ToString();
            }
      }
}

