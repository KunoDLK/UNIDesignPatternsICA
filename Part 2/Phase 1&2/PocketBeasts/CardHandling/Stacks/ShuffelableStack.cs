namespace PocketBeasts.CardHandling.Stacks
{
      public class ShuffelableStack : Stack
      {
            public ShuffelableStack(string name) : base(name)
            {
            }

            public ShuffelableStack(string name, List<ICard> ICards) : base(name, ICards)
            {
            }

            public void Shuffle()
            {
                  // Using Fisher-Yates shuffle algorithm
                  Random random = new Random();
                  int n = Cards.Count;
                  for (int i = n - 1; i > 0; i--)
                  {
                        int j = random.Next(0, i + 1);
                        // Swap
                        ICard temp = Cards[i];
                        Cards[i] = Cards[j];
                        Cards[j] = temp;
                  }
            }
      }
}
