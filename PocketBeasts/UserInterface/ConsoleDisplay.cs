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

            public override void OutputPlayer(Player player)
            {
                  StringBuilder sb = new StringBuilder();
                  sb.Append($"{player.Name,-9} HEALTH/{player.Health,-5} MANA/{player.ManaAvailable}\n");

                  for (int i = 0; i < player.InPlay.Count + 2; i++)
                  {
                        sb.Append("+-------+ ");
                  }
                  sb.Append("\n");

                  for (int i = 0; i < 2; i++)
                  {
                        sb.Append("|       | ");
                  }
                  for (int i = 0; i < player.InPlay.Count; i++)
                  {
                        sb.Append($"{player.InPlay.Cards[i].ManaCost,7}| ");
                  }
                  sb.Append("\n");

                  sb.Append("| DECK  | ");
                  sb.Append("| GRAVE | ");
                  for (int i = 0; i < player.InPlay.Count; i++)
                  {
                        sb.Append($"{player.InPlay.Cards[i].Id,-5}| ");
                  }
                  sb.Append("\n");

                  sb.Append($"{player.Deck.Count,-6}| ");
                  sb.Append($"{player.Graveyard.Count,-6}| ");
                  for (int i = 0; i < player.InPlay.Count; i++)
                  {
                        sb.Append("|       | ");
                  }
                  sb.Append("\n");

                  for (int i = 0; i < 2; i++)
                  {
                        sb.Append("|       | ");
                  }
                  for (int i = 0; i < player.InPlay.Count; i++)
                  {
                        sb.Append($"{player.InPlay.Cards[i].Attack,-2} {player.InPlay.Cards[i].Health,4}| ");
                  }
                  sb.Append("\n");

                  for (int i = 0; i < player.InPlay.Count + 2; i++)
                  {
                        sb.Append("+-------+ ");
                  }
                  sb.Append("\n");
                  sb.Append($"{player.Hand.Count} card(s) in hand.\n\n");
                  sb.Append(player.Hand.ToString());

                  Console.WriteLine(sb.ToString());
            }

      }
}
