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
            int prevPos = 0;
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
                        else if (curPos == counter)
                        {
                            prevPos = curPos;
                            curPos -= 1;
                            posY -= 2;
                            HightlightPosition(posX, posY, counter, curPos);
                            break;
                        }
                        else
                        {
                            prevPos = curPos;
                            curPos -= 2;
                            posY--;
                            HightlightPosition(posX, posY, counter, curPos);
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
                        else if (curPos + 1 == counter)
                        {
                            prevPos = curPos;
                            curPos += 1;
                            posY += 2;
                            HightlightPosition(posX, posY, counter, curPos);
                            break;
                        }
                        else if (curPos == counter)
                        {
                            prevPos = curPos;
                            curPos += 1;
                            posY += 1;
                            HightlightPosition(posX, posY, counter, curPos);
                            break;
                        }
                        else
                        {
                            prevPos = curPos;
                            curPos += 2;
                            posY++;
                            HightlightPosition(posX, posY, counter, curPos);
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        if (posX == startPosX)
                        {
                            break;
                        }
                        else
                        {
                            if (posX <= 0)
                            {
                                prevPos = curPos;
                                curPos--;
                                posX = 1;
                                posY--;
                                HightlightPosition(posX, posY, counter, curPos);
                                break;
                            }
                            if (curPos == counter)
                            {
                                prevPos = curPos;
                                curPos -= 1;
                                posX = 0;
                                posY--;
                                HightlightPosition(posX, posY, counter, curPos);
                                break;
                            }
                            prevPos = curPos;
                            posX--;
                            curPos--;
                            HightlightPosition(posX, posY, counter, curPos);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        if (curPos == endPos)
                        {
                            break;
                        }
                        else if (posX >= 1)
                        {
                            prevPos = curPos;
                            curPos++;
                            posX = 0;
                            posY++;
                            HightlightPosition(posX, posY, counter, curPos);
                            break;
                        }
                        if (curPos + 1 == counter)
                        {
                            prevPos = curPos;
                            curPos += 1;
                            posX = 0;
                            posY++;
                            HightlightPosition(posX, posY, counter, curPos);
                            break;
                        }
                        if (curPos == counter + 1)
                        {
                            prevPos = curPos;
                            curPos += 1;
                            posX = 0;
                            posY++;
                            HightlightPosition(posX, posY, counter, curPos);
                            break;
                        }
                        prevPos = curPos;
                        curPos++;
                        posX++;
                        HightlightPosition(posX, posY, counter, curPos);
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
        void HightlightPosition(int posX, int posY, int counter, int curPos, int prevPos = 0)
        {
            if (posY < counter)
            {
                if (posY == 0)
                {
                    Console.SetCursorPosition(posX * Constants.FrontConstants.STEP_X, posY * Constants.FrontConstants.STEP_Y + 6);
                    return;
                }
                if (curPos == counter - 1 && prevPos == counter)
                {
                    Console.SetCursorPosition(posX * Constants.FrontConstants.STEP_X, posY * Constants.FrontConstants.STEP_Y - 12);
                    return;
                }
                if (curPos == counter  && prevPos == counter)
                {
                    Console.SetCursorPosition(posX * Constants.FrontConstants.STEP_X, posY * Constants.FrontConstants.STEP_Y + 12);
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
            if (curPos > counter)
            {
                Console.SetCursorPosition(posX * Constants.FrontConstants.STEP_X, posY * Constants.FrontConstants.STEP_Y + 6);
                return;
            }
        }

    }
}

