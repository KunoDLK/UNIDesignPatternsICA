﻿/*
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

namespace uk.ac.tees.cis2001.pocketbeasts
{
    public class Graveyard
    {
        private readonly List<Card> cards;

        public Graveyard()
        {
            this.cards = new List<Card>();
        }

        public void Add(Card card)
        {
            this.cards.Add(card);
        }

        public int Count
        {
            get { return this.cards.Count; }
        }
    }
}
