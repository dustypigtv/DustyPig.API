using System.Collections.Generic;

namespace System
{
    public static partial class Extensions
    {
        public static string SortTitle(this string str) => StringUtils.SortTitle(str);

        public static void SortBySortTitle(this List<string> lst) => StringUtils.SortBySortTitle(lst);

        public static bool ICEquals(this string original, string compare) => StringUtils.ICEquals(original, compare);

        public static bool ICStartsWith(this string str, string text) => StringUtils.ICStartsWith(str, text);

        public static bool ICEndsWith(this string str, string text) => StringUtils.ICEndsWith(str, text);

        public static bool ICContains(this string str, string text) => StringUtils.ICContains(str, text);

        public static bool ICContains(this IEnumerable<string> lst, string text) => StringUtils.ICContains(lst, text);

        public static string NormalizeMiscCharacters(this string str) => StringUtils.NormalizeMiscCharacters(str);

        public static string NormalizeText(this string str) => StringUtils.NormalizeText(str);

        public static string NormalizedQueryString(this string text) => StringUtils.NormalizedQueryString(text);

        public static List<string> Tokenize(this string text) => StringUtils.Tokenize(text);

        public static List<string> ConvertToList(this string str) => StringUtils.ConvertToList(str);

        public static string ConvertToString(this List<string> lst) => StringUtils.ConvertToString(lst);

        public static string ConvertToString(this List<string> lst, int maxLen) => StringUtils.ConvertToString(lst, maxLen);

        public static string FixSpaces(this string str) => StringUtils.FixSpaces(str);

        public static string RemoveDiacritics(this string str) => StringUtils.RemoveDiacritics(str);

        public static string GetInitials(this string str) => StringUtils.GetInitials(str);
    }
}
