using CinemaSiteParser;
using CinemaSiteParser.Core;
using CinemaSiteParser.Core.Pages;
using CinemaSiteParser.Models;
using CinemaSiteParser.Shared;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

Dependencies.RegisterServices(services);

var provider = services.BuildServiceProvider();

var httpClient = provider.GetRequiredService<IHttpClientService>();

StartPage page = new StartPage(httpClient);

string htmlText = page.GetHtmlCodeAsync("https://planetakino.ua").Result;

IEnumerable<MovieDTO> movies = page.GetMovies(htmlText);

List<MovieDTO> movies1 = movies.ToList();

Console.WriteLine();

MovieDetailsPage[] movieDetails = new MovieDetailsPage[movies.Count()];


for (int i = 0; i < movies.Count(); i++)
{
    movieDetails[i] = new MovieDetailsPage(httpClient, movies1[i]);
}

Console.WriteLine();

MovieDetailsDTO[] movieDetails2 = new MovieDetailsDTO[movieDetails.Length];

for (int i = 0; i < movieDetails2.Length; i++)
{
    string htmlText1 = movieDetails[i].GetHtmlCodeAsync(movieDetails[i].CurrPage).Result;

    movieDetails2[i] = movieDetails[i].GetMovieDetails(htmlText1);
}

Console.WriteLine();

Console.WriteLine();

//movies = movies.ToArray();

//MovieDTO movie = movies.Last();

//MovieDetailsPage movieDetailsPage = new MovieDetailsPage(httpClient, movie);

//string htmlText2 = movieDetailsPage.GetHtmlCodeAsync(movieDetailsPage.CurrPage).Result;

//htmlText2 = htmlText2.Replace("\n", "");

//htmlText2 = htmlText2.Replace("  ", "");

//MovieDetailsDTO movieDetailsDTO = movieDetailsPage.GetMovieDetails(htmlText2);

//Console.WriteLine();
