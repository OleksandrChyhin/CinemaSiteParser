using CinemaSiteParser.Core.HttpClientService;
using CinemaSiteParser.Models;
using CinemaSiteParser.Shared;

namespace CinemaSiteParser.Core.Pages
{
    public class MovieDetailsService : IMovieDetailsService
    {
        IHttpClientService _httpClientService;

        MovieDTO _movie;

        public string PrevPage { get; private set; }

        public string CurrPage { get; private set; }

        public MovieDetailsService(IHttpClientService httpClientService, MovieDTO movie)
        {
            _httpClientService = httpClientService;
            _movie = movie;
            PrevPage = Constants.Pages.HOME_PAGE;
            CurrPage = PrevPage + movie.MovieLink;
        }

        public async Task<string> GetHtmlCodeAsync(string url)
        {
            string htmlText = await _httpClientService.GetHtmlAsync(url);

            return htmlText;
        }

        public MovieDetailsDTO GetMovieDetails(string htmlCode)
        {
            htmlCode = htmlCode.Replace("\n", "");

            htmlCode = htmlCode.Replace("  ", "");

            MovieDetailsDTO movieDetails = new MovieDetailsDTO();

            movieDetails.MovieName = _movie.MovieName;

            movieDetails.AgeRestriction = _movie.AgeRestriction;

            movieDetails.ReleaseYear = ParserRegex.GetReleaseYear(htmlCode);

            movieDetails.Country = ParserRegex.GetCountry(htmlCode);

            movieDetails.Language = ParserRegex.GetLanguage(htmlCode);

            movieDetails.Genre = ParserRegex.GetGenre(htmlCode);

            movieDetails.Cast = ParserRegex.GetCast(htmlCode);

            movieDetails.Directors = ParserRegex.GetDirector(htmlCode);

            movieDetails.ScriptAuthors = ParserRegex.GetScriptAuthor(htmlCode);

            movieDetails.Rolling = ParserRegex.GetRolling(htmlCode);

            movieDetails.Duration = ParserRegex.GetDuration(htmlCode);

            movieDetails.Description = ParserRegex.GetDescription(htmlCode);

            return movieDetails;
        }
    }
}
