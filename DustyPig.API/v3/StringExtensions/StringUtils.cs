﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    public static class StringUtils
    {
        private static readonly List<string> RemovePrefixes = new List<string> { "the", "a", "an", "la", "les", "des", "l", "un", "el", "il", "le", "uno", };
        private static readonly char[] RemovePreCharacters = new char[] { '\'', '¡' };

        private static readonly Regex _hashRegex = new Regex("[^a-z0-9]", RegexOptions.Compiled);
        private static readonly MD5 _md5 = MD5.Create();


        /// <summary>
        /// Converts a string to a list, splitting on null characters (\0)
        /// </summary>
        public static List<string> ConvertToList(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return new List<string>();
            return str.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        /// <summary>
        /// Converts a list of strings to a single null separated string
        /// </summary>
        public static string ConvertToString(List<string> lst)
        {
            if (lst == null || lst.Count == 0)
                return null;
            return string.Join("\0", lst);
        }


        /// <summary>
        /// Converts a list of strings to a single null separated string
        /// </summary>
        public static string ConvertToString(List<string> lst, int maxLen)
        {
            if (lst == null || lst.Count == 0)
                return null;

            string ret = string.Empty;
            for (int i = 0; i < lst.Count; i++)
            {
                int newLen = lst[i].Length;
                if (ret.Length > 0)
                    newLen++;

                if (ret.Length + newLen > maxLen)
                    return ret;

                if (ret.Length > 0)
                    ret += '\0';
                ret += lst[i];
            }

            return ret;
        }


        public static string Coalesce(params string[] values)
        {
            foreach (var value in values)
                if (!string.IsNullOrWhiteSpace(value))
                    return value;
            return null;
        }

        public static string SortTitle(string title)
        {
            title = (title + string.Empty).Trim().Trim(RemovePreCharacters);
            var parts = (title + string.Empty).Trim().Split(' ').ToList();
            if (parts.Count > 1)
            {
                if (RemovePrefixes.ICContains(parts[0]))
                    parts.RemoveAt(0);
                title = string.Join(" ", parts);
            }

            return title;
        }

        public static void SortBySortTitle(List<string> lst)
        {
            lst.Sort((x, y) => x.SortTitle().CompareTo(y.SortTitle()));
        }

        public static bool ICEquals(string original, string compare)
        {
            if (original == null && compare == null)
                return true;

            if (original == null || compare == null)
                return false;

            return original.Equals(compare, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool ICStartsWith(string str, string text)
        {
            if (str == null && text == null)
                return true;

            if (str == null || text == null)
                return false;

            return str.StartsWith(text, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool ICEndsWith(string str, string text)
        {
            if (str == null && text == null)
                return true;

            if (str == null || text == null)
                return false;

            return str.EndsWith(text, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool ICContains(string str, string text)
        {
            if (str == null && text == null)
                return true;

            if (str == null || text == null)
                return false;

            return str.ToLower().Contains(text.ToLower());
        }

        public static bool ICContains(IEnumerable<string> lst, string text)
        {
            if (lst == null)
                return false;

            return lst.Any(item => item.ICEquals(text));
        }

        public static string NormalizeMiscCharacters(string str)
        {
            str = (str + string.Empty).Trim();

            return str

               //The original annoyances
               .Replace("â€˜", "\"")
               .Replace("â€™", "'")
               .Replace("â€¦", "!")
               .Replace("â€œ", "\"")
               .Replace("â€", "\"")
               .Replace("â€“", "-")

               //Handle latin chars
               .Replace("Á", "A")
               .Replace("á", "a")
               .Replace("É", "E")
               .Replace("é", "e")
               .Replace("Í", "I")
               .Replace("í", "i")
               .Replace("Ñ", "N")
               .Replace("ñ", "n")
               .Replace("Ó", "O")
               .Replace("ó", "o")
               .Replace("Ú", "U")
               .Replace("ú", "u")
               .Replace("Ü", "U")
               .Replace("ü", "u")

               //Handle wierd versions of common chars
               .Replace("‘", "'")
               .Replace("’", "'")
               .Replace("–", "-")
               .Replace("·", "-")

               //Other misc fixes
               .Replace("\0", "")
               .Trim();
        }

        public static string NormalizeText(string str)
        {
            str = (str + string.Empty).Trim();
            if (str.ICEquals("N/A"))
                str = string.Empty;

            return str
                .NormalizeMiscCharacters()

               //Other misc fixes
               .Replace("  ", " ")
               .Replace("\"\"", "\"")
               .Trim();
        }

        public static string NormalizedQueryString(string str)
        {
            str = NormalizeText(str);
            var tokens = Tokenize(str);

            if (tokens.Count == 0)
                return null;

            if (tokens.Count == 1)
            {
                if (tokens[0].Length < 3)
                    return null;

                if (tokens[0] == "the")
                    return null;
            }

            return string.Join(" ", tokens).Trim();
        }

        public static string NormalizedHash(string str) =>
           BitConverter.ToString(_md5.ComputeHash(Encoding.UTF8.GetBytes(_hashRegex.Replace((str + string.Empty).ToLower(), string.Empty)))).Replace("-", string.Empty).ToLower();

        public static List<string> Tokenize(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return new List<string>();

            // Remove movie year
            int pos = str.LastIndexOf("(");
            if (pos > 0)
                str = str.Substring(0, pos).Trim();

            if (string.IsNullOrWhiteSpace(str))
                return new List<string>();

            //The remove things like 'the' from the beginning of the title
            str = str.SortTitle().ToLower();
            str = str.Replace("'", "");
            str = Regex.Replace(str, "[^a-z0-9 ]", " ");
            var ret = new List<string>(str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            ret = ret.Distinct().ToList();


            return ret;
        }

        public static string FixSpaces(string text)
        {
            text += string.Empty;
            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }
            return text.Trim();
        }



    }
}
