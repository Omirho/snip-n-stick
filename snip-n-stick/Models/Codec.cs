using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snip_n_stick.Models
{
    public class Codec
    {

        public static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
        public static readonly int Base = Alphabet.Length;

        public static string Encode(int i)
        {
            if (i == 0) return Alphabet[0].ToString();

            i += 100000;

            var s = string.Empty;

            while (i > 0)
            {
                s += Alphabet[i % Base];
                i = i / Base;
            }

            return string.Join(string.Empty, s.Reverse());
        }

        public static int Decode(string s)
        {
            var i = 0;
            if (s == null) return -1;
            foreach (var c in s)
            {
                i = (i * Base) + Alphabet.IndexOf(c);
            }

            i -= 100000;

            return i;
        }

    }
}