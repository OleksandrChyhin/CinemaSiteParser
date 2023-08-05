using CinemaSiteParser.Models;
using CinemaSiteParser.Shared;
using CinemaSiteParser.Core.HttpClientService;

namespace CinemaSiteParser.Core.Pages
{
    public class StartPageService : IStartPageService
    {
        IHttpClientService _httpClientService;

        public string CurrPage { get; private set; }

        public StartPageService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
            CurrPage = Constants.Pages.HOME_PAGE;
        }

        public async Task<string> GetHtmlCodeAsync(string url)
        {
            string htmlText = await _httpClientService.GetHtmlAsync(url);

            return htmlText;
        }

        public IEnumerable<MovieDTO> GetMovies(string htmlText, out int todaysMoviesCounter, out int moviesQuantity)
        {
            todaysMoviesCounter = 1;
            List<MovieDTO> movies = new List<MovieDTO>();
            htmlText = htmlText.Replace("\n", "").Replace("  ", "").Replace("’", "");
            string[] moviesInfo = htmlText.Split("><");
            for (int i = 0; i < moviesInfo.Length; i++)
            {
                if (ParserRegex.IsHeader(moviesInfo[i]))
                {
                    todaysMoviesCounter = movies.Count;
                }

                if (ParserRegex.GetLink(moviesInfo[i]) != string.Empty)
                {
                    MovieDTO movie = new MovieDTO();
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
            moviesQuantity = movies.Count;
            return movies;
        }
    }
}

