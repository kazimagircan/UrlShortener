using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UrlShortener.Core.Models;

namespace UrlShortener.Core.Helpers
{
    public class ShortUrl
    {
        private const string Alphabet = "1234567890abcdefghijklmnopqrstuvwxyzABCDFGHJKLMNPQRSTVWXYZ";

        public static string Encode()
        {
            var random = new Random();
            var size = random.Next(1, 6);
            var result = new string(Enumerable.Repeat(Alphabet, size)
                                              .Select(s => s[random.Next(s.Length)])
                                              .ToArray());
            return result;
        }

        public static bool Check(string str)
        {
            for (var i = 0; i < str.Length; i++)
            {
                if (Alphabet.IndexOf(str.ElementAt(i)) == -1)
                {
                    return false;
                }
            }
            return true;

        }
    }
}
