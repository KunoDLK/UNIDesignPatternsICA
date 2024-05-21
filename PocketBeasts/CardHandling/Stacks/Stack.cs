namespace PocketBeasts.CardHandling.Stacks
{
    public class Stack
      {
            private string _name;
            private List<ICard> _cards;

            public Stack(string name, List<ICard> cards)
            {
                  Name = name;
                  _cards = cards;
            }

            public Stack(string name)
            {
                  Name = name;
                  _cards = new List<ICard>();
            }

            public string Name
            {
                  get { return _name; }
                  private set { _name = value; }
            }

            public int Count
            {
                  get { return _cards.Count; }
            }

            public List<ICard> Cards
            {
                  get { return _cards; }
                  private set { _cards = value; }
            }

            public ICard Draw()
            {
                  ICard card = _cards[0];
                  _cards.RemoveAt(0);
                  return card;
            }

            public void Remove(ICard card)
            {
                  bool sucsesfull = _cards.Remove(card);

                  if (!sucsesfull)
                  {
                        throw new Exception($"Failed to find card in the \"{Name}\" stack");
                  }
            }

            /// <summary>
            /// Removed cards from this stack
            /// </summary>
            /// <param name="cards"> cards to remove</param>
            public void RemoveAll(List<ICard> cards)
            {
                  this._cards.RemoveAll(cards.Contains);
            }

            public void RemoveAll()
            {
                  this._cards.Clear();
            }

            public void Add(ICard card)
            {
                  _cards.Add(card);
            }
      }
}

