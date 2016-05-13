using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace UwizardWPF.Extensions
{
    public static class StringExtensions
    {
        public static string EncodeDecode(this string text)
        {
            var ret = "";
            for (var c = 0; c < text.Length; c++)
            {
                var ch = (byte)(255 - Strings.Asc(text[c]));
                if (c > 0) ch = (byte)(ch ^ (c & 255));
                ret = ret + Strings.Chr(ch);
            }
            return ret;
        }

        public static byte[] ToByteArray(this string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
