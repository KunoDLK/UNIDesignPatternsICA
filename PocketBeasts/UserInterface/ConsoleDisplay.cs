using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PocketBeasts.UserInterface
{
      internal class ConsoleDisplay
      {
            private static readonly string[] PositiveResponses = new string[] { "y", "yes" };

            private static readonly string[] NegativeResponses = new string[] { "n", "no", "nope" };

            public static bool GetBooleanPrompt(string prompt)
            {
                  bool? returnValue = null;

                  Console.Write(prompt);
                  Console.Write(" (Y/N): ");

                  while (returnValue == null)
                  {
                        returnValue = ReadConsole(PositiveResponses, NegativeResponses);

                        // Clear the input buffer
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                  }

                  return (bool)returnValue;
            }

            private static bool? ReadConsole(string[] positiveResponses, string[] negativeResponses)
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

      }
}
