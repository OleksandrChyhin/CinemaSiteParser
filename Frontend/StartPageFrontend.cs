using CinemaSiteParser.Core.Pages;
using CinemaSiteParser.Models;
using System.Text;
using System;
using CinemaSiteParser.Core.HttpClientService;
using CinemaSiteParser.Shared;

namespace Frontend
{
    public class StartPageFrontend
    {
        public void PrintStartPage(IEnumerable<MovieDTO> movies, int counter)
        {
            List<MovieDTO> moviesList = movies.ToList();
            int x = 0;
            int y = 6;
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetCursorPosition(50, 0);
            Console.Write("Cьогодні в кіно");

            for (int i = 0; i < counter; i++)
            {
                if (x > 55)
                {
                    x = 55;
                }
                Console.SetCursorPosition(x, y);

                if (i % 2 == 0 && i > 0)
                {
                    x = 0;
                    y += 6;
                    Console.SetCursorPosition(x, y);
                }                

                PrintMovieBlock(x, y, moviesList[i]);
                x += 55;
            }
        }
        void PrintMovieBlock(int x, int y, MovieDTO movie)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (movie.MovieName.ToCharArray().Length > Constants.FrontConstants.STEP_X)
            {
                string[] name = movie.MovieName.Split(" ");
                for (int i = 0; i < name.Length; i++)
                {
                    if (i > 0 && i % 3 == 0)
                    {
                        y++;
                        Console.SetCursorPosition(x, y);
                    }
                    Console.Write($"{name[i]} ");
                }
            }

            else
            {
                Console.WriteLine($"{movie.MovieName}");
            }

            if (movie.AgeRestriction != "1")
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write($"{movie.AgeRestriction}");
            }

            else
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write("Доступ необмежений");
            }

            Console.ForegroundColor = ConsoleColor.White;
            string techs = string.Join(", ", movie.Technologies);
            Console.SetCursorPosition(x, y + 2);
            Console.Write($"{techs}");
            string currTechs = string.Join(", ", movie.CurrentTechnologies);
            Console.SetCursorPosition(x, y + 3);
            Console.Write($"{currTechs}");
            Console.WriteLine();
        }
    }
}
