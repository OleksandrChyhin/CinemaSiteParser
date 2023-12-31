﻿using CinemaSiteParser;
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

StartPageFrontend startPageFrontend = new StartPageFrontend();

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Використовуйте стрілки для навігації, Enter - для переходу вперед та Escape для переходу назад та завершення роботи програми. Для початку роботи натисніть Enter");

while (true)
{
    ConsoleKey key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.Enter)
    {
        break;
    }
}

Console.Clear();

startPageFrontend.PrintStartPage(moviesList, todaysMoviesCounter);

MenuNavigation menuNavigation = new MenuNavigation();

menuNavigation.Navigation(movieDetails, moviesList, httpClient, startPageFrontend, todaysMoviesCounter);










