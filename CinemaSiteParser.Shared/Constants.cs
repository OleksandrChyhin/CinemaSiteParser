namespace CinemaSiteParser.Shared
{
    public class Constants
    {
        public class FrontConstants
        {
            public const int MOVIE_BLOCK_HEIGHT = 4;
            public const int MOVIE_BLOCK_WIDTH = 55;
            public const int NAVIGATION_START_POS_X = 0;
            public const int NAVIGATION_START_POS_Y = 4;
            public const int STEP_X = 55;
            public const int STEP_Y = 6;
        }

        public class Regex
        {
            public const string HEADER_REGEX = "h1>Скоро\\sна\\sекранах";

            public const string NAME_REGEX = "div\\sclass=.movie-block__title-inner.>(((.\\w+.)+)|(\\w+.\\w+.\\w+.\\w+.\\w+.\\w)|(\\w+...)|(\\w+.\\w+))+</div";

            public const string LINK_REGEX = "a\\sclass=.movie-block__link.\\shref=./movies/(((\\w+.)+)|(\\w+.\\w+.\\w+.\\w+.\\w+.\\w))/.";

            public const string TOP_INFO_REGEX = "div\\sclass=.movie-block__ds-el.>\\w+</div";

            public const string AGE_REGEX = "div\\sclass=.movie-block__age.>\\d+.</div";

            public const string BOTTOM_INFO_REGEX = "span\\sclass=.movie-block__techs-el.>\\w+.\\w+.</span";

            public const string RELEASE_YEAR_REGEX = "<dd>\\d{4}</dd>";

            public const string COUNTRY_REGEX = "Країна</dt><dd>\\w+..\\w+</dd>|Країна</dt><dd>\\w+[^\\\\d+]</dd>";

            public const string LANGUAGE_REGEX = "<dd>українська\\s\\(\\w+\\)</dd>|<dd>in\\sEnglish\\s\\(with Ukrainian\\ssubtitles\\)</dd>|<dd>українська</dd>|без\\sдіалогів";

            public const string GENRE_REGEX = "Жанр</dt><dd>\\w+,(\\s\\w+,)*\\s\\w+|Жанр</dt><dd>\\w+|Жанр</dt><dd>\\w+-\\w+";

            public const string CAST_REGEX = "<dd>\\w+.\\w+\\s\\w+.\\w+,(\\s((\\w+.\\w+)|(\\w+\\s\\w+-\\w+.))+\\s\\w+,)+\\s\\w+.\\w+\\s\\w+.\\w+</dd>|<dd>\\w+\\s\\w+,\\s\\w+\\s\\w+</dd>|У\\sголовних\\sролях</dt><dd>(\\w+.)+,(\\s(\\w+.)+,)+\\s(\\w+.)+";

            public const string DIRECTORS_REGEX = "<dd>\\w+\\s\\w+</dd>|<dd>\\w+\\s\\w+,\\s(\\w+\\s\\w+,)+\\s\\w+\\s\\w+</dd>|Режисер</dt><dd>(\\w+.)+</dd>";

            public const string SCRIPT_AUTHORS_REGEX = "<dd>\\w+\\s\\w+</dd>|<dd>\\w+\\s\\w+,\\s(\\w+\\s\\w+,)+\\s\\w+\\s\\w+</dd>|Сценарій</dt><dd>(\\w+.)+";

            public const string ROLLING_FROM_REGEX = "<span>З\\s\\w+\\s\\w+\\s\\w+";

            public const string ROLLING_TO_REGEX = "<span>до\\s\\w+\\s\\w+\\s\\w+";

            public const string DURATION_REGEX = "<dd>\\d+\\sхв\\.</dd>";

            public const string DESCRIPRION_REGEX = "<p>(\\w|\\s|\\.|\\,|\\'|–|\\(|\\)|-|’|\\!|—|:|;|\\?|«|»|\"|%)+</p>";
        }

        public class Pages
        {
            public const string HOME_PAGE = "https://planetakino.ua";
        }
    }
}
