using CinemaSiteParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSiteParser.Core.Pages
{
    public interface IStartPageService
    {
        public Task<string> GetHtmlCodeAsync(string url);

        public IEnumerable<MovieDTO> GetMovies(string htmlText, out int todaysMoviesCounter, out int moviesQuantity);
    }
}
