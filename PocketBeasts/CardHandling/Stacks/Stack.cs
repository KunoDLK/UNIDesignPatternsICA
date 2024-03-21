namespace PocketBeasts.CardHandling.Stacks
{
    public class Stack
    {
        private string _name;
        private List<Card> cards;

        public Stack(string name, List<Card> cards)
        {
            Name = name;
            Cards = cards;
        }

        public Stack(string name)
        {
            Name = name;
            Cards = new List<Card>();
        }

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public int Count
        {
            get { return cards.Count; }
        }

        public List<Card> Cards
        {
            get { return cards; }
            private set { cards = value; }
        }

        public Card Draw()
        {
            Card card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }

        public void Remove(Card card)
        {
            bool sucsesfull = cards.Remove(card);

            if (!sucsesfull)
            {
                throw new Exception($"Failed to find card in the \"{Name}\" stack");
            }
        }

        public void RemoveAll(List<Card> cards)
        {
            this.cards.RemoveAll(cards.Contains);
        }

        internal void Add(Card card)
        {
            Cards.Add(card);
        }
    }
}

