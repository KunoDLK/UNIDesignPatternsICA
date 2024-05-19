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
using System.Timers;
using PocketBeasts.CardHandling.Stacks;

namespace PocketBeasts.CardHandling
{
    public class PlayerCards
      {
            private List<Card> _cards;
            private Dictionary<string, Stack> _stacks;

            public PlayerCards(List<Card> cards)
            {
                  Cards = cards;
                  _stacks = new Dictionary<string, Stack>();
            }

            public int TotalCount
            {
                  get { return _cards.Count; }
            }

            public List<Card> Cards
            {
                  get { return _cards; }
                  private set { _cards = value; }
            }

            public Stack GetStack(string name)
            {
                  bool sucsesfull = _stacks.TryGetValue(name, out var stack);

                  if (sucsesfull)
                        return stack;

                  throw new Exception($"Stack \"{name}\" not found");
            }

            public void AddStack(string name)
            {
                  _stacks.Add(name, new Stack(name));
            }

            public void AddShuffableStack(string name)
            {
                  _stacks.Add(name, new ShuffelableStack(name));
            }

            public void TransferToFrom(string source, string destination)
            {
                  var sourceStack = GetStack(source);
                  var destinationStack = GetStack(destination);

                  var card = sourceStack.Draw();
                  destinationStack.Add(card);
            }
      }
}

