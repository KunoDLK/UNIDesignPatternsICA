namespace TestPocketBeasts
{
      using PocketBeasts.UserInterface;

      [TestFixture]
      public class ConsoleDisplayTest
      {
            [Test]
            public void PositiveResultsPass()
            {
                  string input = "yes"; // Simulate user input
                  using (StringReader sr = new StringReader(input))
                  {
                        Console.SetIn(sr);

                        bool response = ConsoleDisplay.GetBooleanPrompt("Enter Positive Response");

                        Assert.That(response, Is.True);
                  }
            }

            [Test]
            public void NegativeResults()
            {
                  string input = "no"; // Simulate user input
                  using (StringReader sr = new StringReader(input))
                  {
                        Console.SetIn(sr);

                        bool response = ConsoleDisplay.GetBooleanPrompt("Enter Negative Response");

                        Assert.That(response, Is.False);
                  }
            }

            [Test]
            public void InputMatchPositiveResults()
            {
                  string input = "Positive"; // Simulate user input
                  using (StringReader sr = new StringReader(input))
                  {
                        Console.SetIn(sr);

                        bool? response = ConsoleDisplay.ReadConsole(["positive"], ["negative"]);

                        Assert.That(response, Is.True);
                  }
            }

            [Test]
            public void InputMatchNegativeResults()
            {
                  string input = "Negative"; // Simulate user input
                  using (StringReader sr = new StringReader(input))
                  {
                        Console.SetIn(sr);

                        bool? response = ConsoleDisplay.ReadConsole(["positive"], ["negative"]);

                        Assert.That(response, Is.False);
                  }
            }

            [Test]
            public void InputNotMatch()
            {
                  string input = "Apple"; // Simulate user input
                  using (StringReader sr = new StringReader(input))
                  {
                        Console.SetIn(sr);

                        bool? response = ConsoleDisplay.ReadConsole(["positive"], ["negative"]);

                        Assert.That(response, Is.Null);
                  }
            }
      }
}
