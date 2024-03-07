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

using System.Collections.Generic;

namespace PocketBeasts
{
      public class InPlay
      {
            private readonly List<Card> cards;

            public InPlay()
            {
                  this.cards = new List<Card>();
            }

            public List<Card> Cards
            {
                  get { return this.cards; }
            }

            public Card GetCard(int index)
            {
                  return this.cards[index];
            }

            public void Add(Card card)
            {
                  this.cards.Add(card);
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
      }
}

