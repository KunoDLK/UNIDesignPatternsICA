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

namespace uk.ac.tees.cis2001.pocketbeasts
{
    public class Card : IComparable<Card>
    {
        private readonly string id;
        private readonly string name;
        private readonly int manaCost;
        private readonly int attack;
        private int health;

        public Card(string id, string name, int manaCost, int attack, int health)
        {
            this.id = id;
            this.name = name;
            this.manaCost = manaCost;
            this.attack = attack;
            this.health = health;
        }

        public Card(Card card)
        {
            this.id = card.id;
            this.name = card.name;
            this.manaCost = card.manaCost;
            this.attack = card.attack;
            this.health = card.health;
        }

        public string Id
        {
            get { return this.id; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public int ManaCost
        {
            get { return this.manaCost; }
        }

        public int Attack
        {
            get { return this.attack; }
        }

        public int Health
        {
            get { return this.health; }
        }

        public void Damage(int amount)
        {
            this.health -= amount;
        }

        public override string ToString()
        {
            return $"Card{{id='{this.Id}', name='{this.Name}', manaCost={this.ManaCost}, attack={this.Attack}, health={this.Health}}}";
        }

        public int CompareTo(Card other)
        {
            return this.ManaCost.CompareTo(other.ManaCost);
        }
    }
}

