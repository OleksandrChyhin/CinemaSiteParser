using CinemaSiteParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSiteParser.Core.Pages
{
    public interface IMovieDetailsService
    {
        public Task<string> GetHtmlCodeAsync(string url);

        public MovieDetailsDTO GetMovieDetails(string htmlCode);

        public string PrevPage { get; }

        public string CurrPage { get; }

    }
}
