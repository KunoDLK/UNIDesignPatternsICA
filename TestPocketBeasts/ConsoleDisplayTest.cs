namespace TestPocketBeasts
{
      using PocketBeasts.UserInterface;

      [TestFixture]
      public class ConsoleDisplayTest
      {
            public Display Display { get; set; }

            public ConsoleDisplayTest()
            {
                  Display = new ConsoleDisplay();
            }

            [Test]
            public void PositiveResultsPass()
            {
                  string input = "yes"; // Simulate user input
                  using (StringReader sr = new StringReader(input))
                  {
                        Console.SetIn(sr);

                        bool response = Display.GetBooleanPrompt("Enter Positive Response");

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

                        bool response = Display.GetBooleanPrompt("Enter Negative Response");

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

                        bool? response = ((ConsoleDisplay)Display).ReadConsole(["positive"], ["negative"]);

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

                        bool? response = ((ConsoleDisplay)Display).ReadConsole(["positive"], ["negative"]);

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

                        bool? response = ((ConsoleDisplay)Display).ReadConsole(["positive"], ["negative"]);

                        Assert.That(response, Is.Null);
                  }
            }

            [Test]
            public void GetPromptValidResponse()
            {
                  string input = "jam jar"; // Simulate user input
                  using (StringReader sr = new StringReader(input))
                  {
                        Console.SetIn(sr);

                        Display.GetPrompt("This is a prompt", ["jam jar"]);
                  }
            }

            [Test]
            public void GetPromptInvalidResponse()
            {
                  Task task = Task.Run(() =>
                  {
                        string input = "mars"; // Simulate user input
                        using (StringReader sr = new StringReader(input))
                        {
                              Console.SetIn(sr);

                              Display.GetPrompt("This is a prompt", new[] { "moon" });
                        }
                  });

                  Thread.Sleep(100);
                  Assert.That(task.IsCompleted, Is.False);

                  using (StringReader sr = new StringReader("moon"))
                  {
                        Console.SetIn(sr);
                  }
                  task.Wait();
            }
      }
}
