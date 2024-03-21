using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PocketBeasts.UserInterface
{
      public class ConsoleDisplay
      {
            private static readonly string[] PositiveResponses = ["y", "yes"];

            private static readonly string[] NegativeResponses = ["n", "no", "nope"];

            public static bool GetBooleanPrompt(string prompt)
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

            public static bool? ReadConsole(string[] positiveResponses, string[] negativeResponses)
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


            public static string GetPrompt(string prompt, string[] validResponse)
            {
                  string response = string.Empty;

                  do
                  {
                        Console.Write(prompt);
                        response = Console.ReadLine();

                  } while (!validResponse.Contains(response, StringComparer.OrdinalIgnoreCase));

                  return response;
            }

      }
}
