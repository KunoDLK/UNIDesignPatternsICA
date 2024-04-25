using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PocketBeasts.UserInterface
{
      public class ConsoleDisplay : Display
      {
            private readonly string[] PositiveResponses = ["y", "yes", "yeah"];

            private readonly string[] NegativeResponses = ["n", "no", "nope"];

            public override bool GetBooleanPrompt(string prompt)
            {
                  bool? returnValue = null;

                  Console.Write(prompt);
                  Console.Write(" (Y/N): ");

                  while (returnValue == null)
                  {
                        returnValue = ReadConsole(PositiveResponses, NegativeResponses);
                  }

                  return (bool)returnValue;
            }

            public bool? ReadConsole(string[] positiveResponses, string[] negativeResponses)
            {
                  bool? returnValue = null;

                  string userInput = Console.ReadLine().ToLower();

                  if (positiveResponses.Contains(userInput))
                  {
                        returnValue = true;
                  }
                  else if (negativeResponses.Contains(userInput))
                  {
                        returnValue = false;
                  }

                  return returnValue;
            }


            public override string GetPrompt(string prompt, string[] validResponse)
            {
                  string response = string.Empty;

                  do
                  {
                        Console.Write(prompt);
                        response = Console.ReadLine();

                  } while (response == null || !validResponse.Contains(response, StringComparer.OrdinalIgnoreCase));

                  return response;
            }


            public override void OutputText(string text) => Console.WriteLine(text);

            public override void Clear() => Console.Clear();
           
      }
}
