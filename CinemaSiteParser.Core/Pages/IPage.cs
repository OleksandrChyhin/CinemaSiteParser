using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSiteParser.Core.Pages
{
    public interface IPage
    {
        public Task<string> GetHtmlCodeAsync(string url);
    }
}
