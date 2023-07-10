using System.Drawing;
using System.Text.RegularExpressions;

namespace CinemaSiteParser.Shared
{
    public static class ParserRegex
    {
        public static bool IsHeader(string sourse)
        {
            var regex = new Regex(Constants.Regex.HEADER_REGEX);
            return regex.IsMatch(sourse);
        }

        public static string GetName(string source)
        {
            Regex regex = new Regex(Constants.Regex.NAME_REGEX);
            string match = regex.Match(source).Value;
            Regex innerText = new Regex(">(((.\\w+.)+)|(\\w+.\\w+.\\w+.\\w+.\\w+.\\w)|(\\w+...)|(\\w+.\\w+))+<");
            match = innerText.Match(match).Value;
            match = match.Replace(">", "");
            match = match.Replace("<", "");
            return match;
        }

        public static string GetLink(string source)
        {
            Regex regex = new Regex(Constants.Regex.LINK_REGEX);
            string match = regex.Match(source).Value;
            Regex innerText = new Regex("/movies/((\\w+.)|\\w+)+/");
            match = innerText.Match(match).Value;
            return match;
        }

        public static string GetTopInfo(string source)
        {
            Regex regex = new Regex(Constants.Regex.TOP_INFO_REGEX);
            string match = regex.Match(source).Value;
            Regex innerText = new Regex(">\\w+");
            match = innerText.Match(match).Value;
            match = match.Replace(">", "");
            return match;
        }

        public static string GetAge(string source)
        {
            Regex regex = new Regex(Constants.Regex.AGE_REGEX);
            string match = regex.Match(source).Value;
            Regex innerText = new Regex(">\\d+\\+");
            match = innerText.Match(match).Value;
            match = match.Replace(">", "");
            if (match != string.Empty)
            {
                return match;
            }
            return "1";
        }

        public static string GetBottomInfo(string source)
        {
            Regex regex = new Regex(Constants.Regex.BOTTOM_INFO_REGEX);
            string match = regex.Match(source).Value;
            Regex innerText = new Regex(">\\w+.\\w+");
            match = innerText.Match(match).Value;
            match = match.Replace(">", "");
            match = match.Replace("<", "");
            return match;
        }

        public static string GetCountry(string source)
        {
            Regex regex = new Regex(Constants.Regex.COUNTRY_REGEX);
            string match = regex.Match(source).Value;
            Regex innerText = new Regex("(>\\w+..\\w+<)|(>\\w+<)");
            match = innerText.Match(match).Value;
            match = match.Replace(">", "");
            match = match.Replace("<", "");
            return match;
        }
        public static string GetLanguage(string source)
        {
            Regex regex = new Regex(Constants.Regex.LANGUAGE_REGEX);
            string match = regex.Match(source).Value;
            Regex innerText = new Regex("українська\\s\\(\\w+\\)|in\\sEnglish\\s\\(with\\sUkrainian\\ssubtitles\\)|українська|без\\sдіалогів");
            match = innerText.Match(match).Value;
            return match;
        }
        public static string GetGenre(string source)
        {
            Regex regex = new Regex(Constants.Regex.GENRE_REGEX);
            string match = regex.Match(source).Value;
            Regex innerText = new Regex("\\w+,(\\s\\w+,)+\\s\\w+|[^Жанр</dt><dd>]\\w+|\\w+-\\w+");
            match = innerText.Match(match).Value;
            return match;
        }
        public static string GetCast(string source)
        {
            Regex regex = new Regex(Constants.Regex.CAST_REGEX);
            string match = regex.Match(source).Value;
            Regex innerText = new Regex("\\w+\\s\\w+,(\\s\\w+\\s\\w+,)+\\s\\w+\\s\\w+");
            match = innerText.Match(match).Value;
            return match;
        }
        public static string GetDirector(string source)
        {
            Regex regex = new Regex(Constants.Regex.DIRECTORS_REGEX);
            string match = regex.Match(source).Value;
            Regex innerText = new Regex("\\w+\\s\\w+|\\w+\\s\\w+,\\s(\\w+\\s\\w+,)+\\s\\w+\\s\\w+");
            match = innerText.Match(match).Value;
            return match;
        }
        public static string GetScriptAuthor(string source)
        {
            Regex regex = new Regex(Constants.Regex.SCRIPT_AUTHORS_REGEX);
            string match = regex.Match(source).Value;
            Regex innerText = new Regex("\\w+\\s\\w+|\\w+\\s\\w+,\\s(\\w+\\s\\w+,)+\\s\\w+\\s\\w+");
            match = innerText.Match(match).Value;
            return match;
        }
        public static string GetRolling(string source)
        {
            Regex regex1 = new Regex(Constants.Regex.ROLLING_FROM_REGEX);
            Regex regex2 = new Regex(Constants.Regex.ROLLING_TO_REGEX);
            string match1 = regex1.Match(source).Value;
            string match2 = regex2.Match(source).Value;
            Regex fromDate = new Regex("З\\s\\w+\\s\\w+\\s\\w+");
            Regex toDate = new Regex("до\\s\\w+\\s\\w+\\s\\w+");
            string match = fromDate.Match(match1).Value + " " +  toDate.Match(match2).Value;
            return match;
        }
        public static string GetDuration(string source)
        {
            Regex regex = new Regex(Constants.Regex.DURATION_REGEX);
            string match = regex.Match(source).Value;
            Regex innerText = new Regex("\\d+\\sхв\\.");
            match = innerText.Match(match).Value;
            return match;
        }
        public static string GetDescription(string source)
        {
            Regex regex = new Regex(Constants.Regex.DESCRIPRION_REGEX);
            string match = regex.Match(source).Value;
            match = match.Substring(0, match.Length - 2);
            return match;
        }
        public static string GetReleaseYear(string source)
        {
            Regex regex = new Regex(Constants.Regex.RELEASE_YEAR_REGEX);
            string match = regex.Match(source).Value;
            Regex innerText = new Regex("\\d{4}");
            match = innerText.Match(match).Value;
            return match;
        }
    }
}