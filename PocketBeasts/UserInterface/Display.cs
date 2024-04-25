using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PocketBeasts.UserInterface
{
      public abstract class Display
      {
            public abstract bool GetBooleanPrompt(string prompt);

            public abstract string GetPrompt(string prompt, string[] validResponse);

            public abstract void OutputText(string text);

      }
}
