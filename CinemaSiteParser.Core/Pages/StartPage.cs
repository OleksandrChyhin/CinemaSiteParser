using CinemaSiteParser.Models;
using CinemaSiteParser.Shared;
using System.Text.RegularExpressions;

namespace CinemaSiteParser.Core.Pages
{
    public class StartPage : IPage
    {
        IHttpClientService _httpClientService;

        public string CurrPage { get; private set; }

        public StartPage(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
            CurrPage = Constants.Pages.HOME_PAGE;
        }

        public async Task<string> GetHtmlCodeAsync(string url)
        {
            string htmlText = await _httpClientService.GetHtmlAsync(url);

            return htmlText;
        }

        public IEnumerable<MovieDTO> GetMovies(string htmlText)
        {
            var str = Constants.Regex.HEADER_REGEX;
            List<MovieDTO> movies = new List<MovieDTO>();
            htmlText = htmlText.Replace("\n", "").Replace("  ", "").Replace("’", "");
            string[] moviesInfo = htmlText.Split("><");
            for (int i = 0; i < moviesInfo.Length; i++)
            {
                MovieDTO movie = new MovieDTO();
                if (ParserRegex.GetLink(moviesInfo[i]) != string.Empty)
                {
                    movie.MovieLink = ParserRegex.GetLink(moviesInfo[i]);
                    i++;
                    while (ParserRegex.GetTopInfo(moviesInfo[i]) == string.Empty)
                    {
                        i++;
                    }
                    List<string> technologies = new List<string>();
                    while (ParserRegex.GetTopInfo(moviesInfo[i]) != string.Empty)
                    {
                        technologies.Add(ParserRegex.GetTopInfo(moviesInfo[i]));
                        i++;
                    }
                    movie.Technologies = technologies;

                    int iterCounter = 0;

                    while (ParserRegex.GetAge(moviesInfo[i]) == "1")
                    {
                        if (iterCounter > 1)
                        {
                            break;
                        }
                        iterCounter++;
                        i++;
                    }
                    movie.AgeRestriction = ParserRegex.GetAge(moviesInfo[i]);
                    i++;
                    while (ParserRegex.GetName(moviesInfo[i]) == string.Empty)
                    {
                        i++;
                    }
                    movie.MovieName = ParserRegex.GetName(moviesInfo[i]);
                    i++;
                    while (ParserRegex.GetBottomInfo(moviesInfo[i]) == string.Empty)
                    {
                        i++;
                    }
                    List<string> currTechs = new List<string>();
                    while (ParserRegex.GetBottomInfo(moviesInfo[i]) != string.Empty)
                    {
                        currTechs.Add(ParserRegex.GetBottomInfo(moviesInfo[i]));
                        i++;
                    }
                    movie.CurrentTechnologies = currTechs;
                    movies.Add(movie);
                    i--;
                }
            }
            return movies;
        }


    }
}
