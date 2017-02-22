using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Greetings
    {
        private static readonly Dictionary<string, string> greetings = new Dictionary<string, string>
        {
            ["english"] = "Hello!",
            ["swedish"] = "Hej!",
            ["french"] = "Bonjour!"
        };

        public static string GetGreetingInLanguage(string language)
        {
            if (greetings.ContainsKey(language.ToLower()))
            {
                return greetings[language.ToLower()];
            }

            return greetings["english"];
        }
    }
}
