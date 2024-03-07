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
using System.Text;

namespace uk.ac.tees.cis2001.pocketbeasts
{
      public class Hand
      {
            private readonly List<Card> cards;

            public Hand()
            {
                  this.cards = new List<Card>();
            }

            public List<Card> Cards
            {
                  get { return this.cards; }
            }

            public void Add(Card card)
            {
                  this.cards.Add(card);
                  this.Sort();
            }

            public void Remove(Card card)
            {
                  this.cards.Remove(card);
            }

            public void RemoveAll(List<Card> cards)
            {
                  this.cards.RemoveAll(cards.Contains);
            }

            public int Count
            {
                  get { return this.cards.Count; }
            }

            public void Sort()
            {
                  this.cards.Sort();
            }

            public override string ToString()
            {
                  StringBuilder sb = new StringBuilder();

                  for (int i = 0; i < this.Count; i++)
                  {
                        sb.Append("+-------+ ");
                  }
                  sb.Append("\n");

                  foreach (Card card in this.Cards)
                  {
                        sb.Append(string.Format("|{0,7}| ", card.ManaCost));
                  }
                  sb.Append("\n");

                  foreach (Card card in this.Cards)
                  {
                        sb.Append(string.Format("|  {0,-5}| ", card.Id));
                  }
                  sb.Append("\n");

                  for (int i = 0; i < this.Count; i++)
                  {
                        sb.Append("|       | ");
                  }
                  sb.Append("\n");

                  foreach (Card card in this.Cards)
                  {
                        sb.Append(string.Format("|{0, -2} {1,4}| ", card.Attack, card.Health));
                  }
                  sb.Append("\n");

                  for (int i = 0; i < this.Count; i++)
                  {
                        sb.Append("+-------+ ");
                  }
                  sb.Append("\n");

                  return sb.ToString();
            }
      }
}

