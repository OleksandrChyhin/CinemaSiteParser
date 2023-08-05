using CinemaSiteParser;
using CinemaSiteParser.Core.Pages;
using CinemaSiteParser.Core.HttpClientService;
using CinemaSiteParser.Models;
using Frontend;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

Dependencies.RegisterServices(services);

var provider = services.BuildServiceProvider();

var httpClient = provider.GetRequiredService<IHttpClientService>();

StartPageService page = new StartPageService(httpClient);

string htmlText = page.GetHtmlCodeAsync("https://planetakino.ua").Result;

int todaysMoviesCounter;

int moviesQuantity;

IEnumerable<MovieDTO> movies = page.GetMovies(htmlText, out todaysMoviesCounter, out moviesQuantity);

List<MovieDTO> moviesList = movies.ToList();

Console.WriteLine();

List<MovieDetailsService> details = new List<MovieDetailsService>();


for (int i = 0; i < moviesList.Count(); i++)
{
    details.Add(new MovieDetailsService(httpClient, moviesList[i]));
}

List<MovieDetailsPageFrontend> movieDetails = new List<MovieDetailsPageFrontend>();

for (int i = 0; i < todaysMoviesCounter; i++)
{
    if (i % 2 != 0)
    {
        movieDetails.Add(new MovieDetailsPageFrontend(details[i], 1, i - 1));
        continue;
    }
    else
    {
        movieDetails.Add(new MovieDetailsPageFrontend(details[i], 0, i));
        continue;
    }
}
for (int i = todaysMoviesCounter; i < details.Count; i++)
{
    if (todaysMoviesCounter % 2 != 0)
    {
        if (i == todaysMoviesCounter)
        {
            movieDetails.Add(new MovieDetailsPageFrontend(details[i], 0, i + 1));
            continue;
        }
        else if (i == todaysMoviesCounter + 1)
        {
            movieDetails.Add(new MovieDetailsPageFrontend(details[i], 0, i + 2));
            continue;
        }
        else if (i == todaysMoviesCounter + 2)
        {
            movieDetails.Add(new MovieDetailsPageFrontend(details[i], 1, i + 1 ));
            continue;
        }
        else if (i % 2 != 0)
        {
            movieDetails.Add(new MovieDetailsPageFrontend(details[i], 1, i + 2 - 1));
            continue;
        }
        else
        {
            movieDetails.Add(new MovieDetailsPageFrontend(details[i], 0, i + 2));
            continue;
        }
    }
    else
    {
        if (i % 2 != 0)
        {
            movieDetails.Add(new MovieDetailsPageFrontend(details[i], 1, i - 1));
            continue;
        }
        else
        {
            movieDetails.Add(new MovieDetailsPageFrontend(details[i], 0, i));
            continue;
        }
    }
}


StartPageFrontend startPageFrontend = new StartPageFrontend();

startPageFrontend.PrintStartPage(moviesList, todaysMoviesCounter);

MenuNavigation menuNavigation = new MenuNavigation();

menuNavigation.Navigation(movieDetails, moviesList, httpClient, startPageFrontend, todaysMoviesCounter);










