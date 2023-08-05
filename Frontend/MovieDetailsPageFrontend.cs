using CinemaSiteParser.Core.HttpClientService;
using CinemaSiteParser.Core.Pages;
using CinemaSiteParser.Models;
using System.Text;

namespace Frontend
{
    public class MovieDetailsPageFrontend
    {
        public int PositionX { get; private set; }

        public int PositionY { get; private set; }

        public IMovieDetailsService MovieDetails { get; private set; }

        public MovieDetailsPageFrontend(IMovieDetailsService movieDetailsService, int positionX, int positionY)
        {
            MovieDetails = movieDetailsService;
            PositionX = positionX;
            PositionY = positionY;
        }

        public MovieDetailsDTO GetMovieDetails()
        {
            string htmlCode =  MovieDetails.GetHtmlCodeAsync(MovieDetails.CurrPage).Result;
            return MovieDetails.GetMovieDetails(htmlCode);
        }
                
         public void PrintMovieDetails(MovieDetailsDTO movieDetails)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(50, 0);
            Console.Write($"{movieDetails.MovieName}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"Рік випуску: {movieDetails.ReleaseYear}");
            Console.WriteLine($"Країна: {movieDetails.Country}");
            Console.WriteLine($"Мова: {movieDetails.Language}");
            Console.WriteLine($"Жанр: {movieDetails.Genre}");
            Console.WriteLine($"У головних ролях: {movieDetails.Cast}");
            Console.WriteLine($"Режисер: {movieDetails.Directors}");
            Console.WriteLine($"Сценарій: {movieDetails.ScriptAuthors}");
            Console.WriteLine($"У прокаті: {movieDetails.Rolling}");
            Console.WriteLine($"Тривалість: {movieDetails.Duration}");

            if (movieDetails.AgeRestriction == "1")
            {
                Console.WriteLine("Вікові обмеження: не встановлені");
            }

            else
            {
                Console.WriteLine($"Вікові обемеження: {movieDetails.AgeRestriction}");
            }

            string[] description = movieDetails.Description.Split(" ");
            for (int i = 0; i < description.Length; i++)
            {
                if (i > 0 && i % 10 == 0)
                {
                    Console.Write("\n");
                }
                Console.Write($"{description[i]} ");
            }            
        }
    }
}
