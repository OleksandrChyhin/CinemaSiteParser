using CinemaSiteParser.Core.HttpClientService;
using CinemaSiteParser.Core.Pages;
using CinemaSiteParser.Models;
using CinemaSiteParser.Shared;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Windows.Input;
namespace Frontend
{
    public class MenuNavigation
    {
        public void Navigation(List<MovieDetailsPageFrontend> movieDetailsPageFrontend, List<MovieDTO> Movies, IHttpClientService httpClientService, StartPageFrontend startPageFrontend, int counter)
        {
            int posX = 0;
            int posY = 0;
            int endPos = movieDetailsPageFrontend.Count;
            int startPosX = 0;
            int startPosY = 0;
            int curPos = 0;
            Console.SetCursorPosition(0, 6);
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (startPosY == posY || posY - 1 < startPosX)
                        {
                            break;
                        }

                        else
                        {
                            curPos -= 2;
                            posY--;
                            HightlightPosition(posX, posY);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        if (posY >= endPos || posY + 1 > endPos)
                        {
                            break;
                        }
                        if (counter % 2 != 0 && posY + 1 >= endPos)
                        {
                            break;
                        }
                        else
                        {
                            curPos += 2;
                            posY++;
                            HightlightPosition(posX, posY);
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        if (curPos == startPosX)
                        {
                            break;
                        }
                        else
                        {
                            if (posX <= 0)
                            {
                                curPos--;
                                posX = 1;
                                posY-=1;
                                HightlightPosition(posX, posY);
                                break;
                            }
                            posX-=1;
                            curPos-=1;
                            HightlightPosition(posX, posY);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        if (curPos + 1 == endPos)
                        {
                            break;
                        }
                        else if (posX >= 1)
                        {
                            curPos++;
                            posX = 0;
                            posY++;
                            HightlightPosition(posX, posY);
                            break;
                        }
                        curPos++;
                        posX++;
                        HightlightPosition(posX, posY);
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        while (key != ConsoleKey.Escape)
                        {
                            movieDetailsPageFrontend[curPos].PrintMovieDetails(movieDetailsPageFrontend[curPos].GetMovieDetails());
                            key = Console.ReadKey(true).Key;
                        }
                        Console.Clear();
                        startPageFrontend.PrintStartPage(Movies, counter);
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.Write(" Гарного Вам дня! ");
                        return;
                }
            }
        }
        void HightlightPosition(int posX, int posY)
        {
            if (posY == 0)
            {
                Console.SetCursorPosition(posX * Constants.FrontConstants.STEP_X, posY * Constants.FrontConstants.STEP_Y + 6);
                return;
            }
            else if (posY == 1)
            {
                Console.SetCursorPosition(posX * Constants.FrontConstants.STEP_X, posY * Constants.FrontConstants.STEP_Y + 6);
                return;
            }
            else
            {
                Console.SetCursorPosition(posX * Constants.FrontConstants.STEP_X, posY * Constants.FrontConstants.STEP_Y + 6);
                return;
            }
        }
    }
}

