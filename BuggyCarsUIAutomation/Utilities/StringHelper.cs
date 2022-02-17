using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsUIAutomation.Utilities
{
    public static class StringHelper
    {
        public static string GenerateRandomString(int length, bool capital = false)
        {
            return capital ? GenerateRandom(length, 4) : GenerateRandom(length, 3);
        }

        private static string GenerateRandom(int length, int option = 0)
        {
            string chars = "";
            switch (option)
            {
                case 0:
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                    break;
                case 1:
                    chars = "0123456789";
                    break;
                case 2:
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    break;
                case 3:
                    chars = "abcdefghijklmnopqrstuvwxyz";
                    break;
                case 4:
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    break;
            }
            var random = new Random(Guid.NewGuid().GetHashCode());
            var result = new string(
                Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;

        }
    }
}
