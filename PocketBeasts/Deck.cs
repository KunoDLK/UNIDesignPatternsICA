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

namespace uk.ac.tees.cis2001.pocketbeasts
{
      public class Deck
      {
            private readonly List<Card> cards;

            public Deck(List<Card> cards)
            {
                  this.cards = cards;
            }

            public int Count
            {
                  get { return this.cards.Count; }
            }

            public Card Draw()
            {
                  Card card = this.cards[0];
                  this.cards.RemoveAt(0);
                  return card;
            }

            public void Shuffle()
            {
                  // Using Fisher-Yates shuffle algorithm
                  Random random = new Random();
                  int n = this.cards.Count;
                  for (int i = n - 1; i > 0; i--)
                  {
                        int j = random.Next(0, i + 1);
                        // Swap
                        Card temp = this.cards[i];
                        this.cards[i] = this.cards[j];
                        this.cards[j] = temp;
                  }
            }
      }
}

