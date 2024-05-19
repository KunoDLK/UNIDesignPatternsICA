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

namespace PocketBeasts.CardHandling
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
            id = card.id;
            name = card.name;
            manaCost = card.manaCost;
            attack = card.attack;
            health = card.health;
        }

        public string Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public int ManaCost
        {
            get { return manaCost; }
        }

        public int Attack
        {
            get { return attack; }
        }

        public int Health
        {
            get { return health; }
        }

        public void Damage(int amount)
        {
            health -= amount;
        }

        public override string ToString()
        {
            return $"Card{{id='{Id}', name='{Name}', manaCost={ManaCost}, attack={Attack}, health={Health}}}";
        }

        public int CompareTo(Card other)
        {
            return ManaCost.CompareTo(other.ManaCost);
        }
    }
}

