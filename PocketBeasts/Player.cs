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
using PocketBeasts.CardHandling.Stacks;

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
            manaAvailable = 0;
            manaTicker = 0;
            health = 15;
            PlayerCards = new PlayerCards(deck);
            PlayerCards.AddShuffableStack("deck");
            PlayerCards.AddStack("hand");
            PlayerCards.AddStack("inplay");
            PlayerCards.AddStack("graveyard");
            Deck.Cards.AddRange(PlayerCards.Cards);
        }

        public string Name
        {
            get { return name; }
        }

        public int ManaAvailable
        {
            get { return manaAvailable; }
        }

        public int Health
        {
            get { return health; }
        }

        public PlayerCards PlayerCards
        {
            get { return _playerCards; }
            private set { _playerCards = value; }
        }

        public ShuffelableStack Deck
        {
            get { return (ShuffelableStack)PlayerCards.GetStack("deck"); }
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
            Deck.Shuffle();
            for (int i = 0; i < 4; i++)
            {
                Hand.Add(Deck.Draw());
            }
        }

        public void AddMana()
        {
            if (manaTicker < MaxMana)
            {
                manaTicker++;
            }
            manaAvailable = manaTicker;
        }

        public void UseMana(int amount)
        {
            manaAvailable -= amount;
        }

        public bool Damage(int amount)
        {
            health -= amount;
            return health <= 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{name,-9} HEALTH/{health,-5} MANA/{manaAvailable}\n");

            for (int i = 0; i < InPlay.Count + 2; i++)
            {
                sb.Append("+-------+ ");
            }
            sb.Append("\n");

            for (int i = 0; i < 2; i++)
            {
                sb.Append("|       | ");
            }
            for (int i = 0; i < InPlay.Count; i++)
            {
                sb.Append($"{InPlay.Cards[i].ManaCost,7}| ");
            }
            sb.Append("\n");

            sb.Append("| DECK  | ");
            sb.Append("| GRAVE | ");
            for (int i = 0; i < InPlay.Count; i++)
            {
                sb.Append($"{InPlay.Cards[i].Id,-5}| ");
            }
            sb.Append("\n");

            sb.Append($"{Deck.Count,-6}| ");
            sb.Append($"{Graveyard.Count,-6}| ");
            for (int i = 0; i < InPlay.Count; i++)
            {
                sb.Append("|       | ");
            }
            sb.Append("\n");

            for (int i = 0; i < 2; i++)
            {
                sb.Append("|       | ");
            }
            for (int i = 0; i < InPlay.Count; i++)
            {
                sb.Append($"{InPlay.Cards[i].Attack,-2} {InPlay.Cards[i].Health,4}| ");
            }
            sb.Append("\n");

            for (int i = 0; i < InPlay.Count + 2; i++)
            {
                sb.Append("+-------+ ");
            }
            sb.Append("\n");
            sb.Append($"{Hand.Count} card(s) in hand.\n\n");
            sb.Append(Hand.ToString());

            return sb.ToString();
        }
    }
}

