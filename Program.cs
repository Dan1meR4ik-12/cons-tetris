﻿using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConTetris
{
    class Figure
    {
        public int x = 0;
        public int y = 0;
        public int[,] fig;
        public int[,][,] type = {
            {
                new int[,] {
                    { 0, 1, 0 },
                    { 1, 1, 0 },
                    { 0, 1, 0 }
                }, new int[,] {
                    { 0, 1, 0 },
                    { 1, 1, 1 },
                    { 0, 0, 0 }
                }, new int[,] {
                    { 0, 1, 0 },
                    { 0, 1, 1 },
                    { 0, 1, 0 }
                }, new int[,] {
                    { 0, 0, 0 },
                    { 1, 1, 1 },
                    { 0, 1, 0 }
                }
            }, // T
            {
                new int[,] {
                    { 1, 1 },
                    { 1, 1 }
                }, new int[,] {
                    { 1, 1 },
                    { 1, 1 }
                }, new int[,] {
                    { 1, 1 },
                    { 1, 1 }
                }, new int[,] {
                    { 1, 1 },
                    { 1, 1 }
                }
            }, // Square
            {
                new int[,] {
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 0 }
                }, new int[,] {
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 1, 1, 1, 1 },
                    { 0, 0, 0, 0 }
                }, new int[,] {
                    { 0, 1, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 1, 0, 0 }
                }, new int[,] {
                    { 0, 0, 0, 0 },
                    { 1, 1, 1, 1 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 }
                }
            }, // Stick
            {
                new int[,] {
                    { 1, 0, 0 },
                    { 1, 1, 0 },
                    { 0, 1, 0 }
                }, new int[,] {
                    { 0, 1, 1 },
                    { 1, 1, 0 },
                    { 0, 0, 0 }
                }, new int[,] {
                    { 0, 1, 0 },
                    { 0, 1, 1 },
                    { 0, 0, 1 }
                }, new int[,] {
                    { 0, 0, 0 },
                    { 0, 1, 1 },
                    { 1, 1, 0 }
                }
            }, // Ladder to right
            {
                new int[,] {
                    { 0, 1, 0 },
                    { 1, 1, 0 },
                    { 1, 0, 0 }
                }, new int[,] {
                    { 1, 1, 0 },
                    { 0, 1, 1 },
                    { 0, 0, 0 }
                },new int[,] {
                    { 0, 0, 1 },
                    { 0, 1, 1 },
                    { 0, 1, 0 }
                },new int[,] {
                    { 0, 0, 0 },
                    { 1, 1, 0 },
                    { 0, 1, 1 }
                }
            }, // Ladder to left
            {
                new int[,] {
                    { 1, 1, 0 },
                    { 1, 0, 0 },
                    { 1, 0, 0 }
                }, new int[,] {
                    { 1, 1, 1 },
                    { 0, 0, 1 },
                    { 0, 0, 0 }
                }, new int[,] {
                    { 0, 0, 1 },
                    { 0, 0, 1 },
                    { 0, 1, 1 }
                }, new int[,] {
                    { 0, 0, 0 },
                    { 1, 0, 0 },
                    { 1, 1, 1 }
                }
            }, // Г
            {
                new int[,] {
                    { 0, 1, 1 },
                    { 0, 0, 1 },
                    { 0, 0, 1 }
                }, new int[,] {
                    { 0, 0, 0 },
                    { 0, 0, 1 },
                    { 1, 1, 1 }
                }, new int[,] {
                    { 1, 0, 0 },
                    { 1, 0, 0 },
                    { 1, 1, 0 }
                }, new int[,] {
                    { 1, 1, 1 },
                    { 1, 0, 0 },
                    { 0, 0, 0 }
                }
            } // Mirrored Г
        };
        public int sel = 0;
        public int rot = 0;
        private Random rnd = new Random();

        public void Move(int dirX = 0, int dirY = 1)
        {
            x += dirX;
            y += dirY;
        } // Just moving the Tetramino by changing its position

        public void Init()
        {
            y = 0;
            x = 3;
            sel = rnd.Next(0, type.GetLength(0));
            rot = rnd.Next(0, 4);
            fig = type[sel, rot];
            //Rotate(true);
        } // Initializing a new Tetramino

        public void Rotate(bool random = false)
        {
            rot--;
            if (rot < 0)
                rot = 3;
            fig = type[sel, rot];
        }  // Rotate Tetramino using its next rotation variation
        

        public Figure Clone()
        {
            Figure newFig = new Figure()
            {
                fig = fig,
                type = type,
                sel = sel,
                rot = rot
            };

            return newFig;
        } // Clone the Tetramino for further using

        public void DDraw()
        {
            for (int i = 0; i < fig.GetLength(0); i++)
            {
                for (int j = 0; j < fig.GetLength(1); j++)
                {
                    if (fig[i, j] == 1)
                    {
                        Console.Write("#");
                    } else
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        } // Drawing the Tetramino using '#' char
        
    }

    class Screen
    {
        public bool isRus = System.Globalization.CultureInfo.CurrentCulture.EnglishName.ToString().Contains("Russian");
        public int score = 0;
        public bool GAME = true;
        public bool gameOver = false;

        public int[,] Field = new int[20,10]; // Game field
        public int[,] PersistanceField = new int[20, 10]; // Baked-blocks field
        
        public Figure figure;
        public Figure nextFigure;
        public Figure holdedFigure;
        public bool alreadyHolded = false;

        public ConsoleKeyInfo cki;


        private bool hfmDone = true;

        public void Flush()
        {
            Field = new int[20, 10];
            DownFigureMove();
            for (int k = 0; k < figure.fig.GetLength(0); k++)
            {
                for (int l = 0; l < figure.fig.GetLength(1); l++)
                {
                    if (figure.fig[k, l] == 1)
                        Field[figure.y + l, figure.x + k] = 1;
                }
            }
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if (PersistanceField[i, j] != 0)
                        Field[i, j] = PersistanceField[i, j];
                }
            }
        } // Combining the Tetramino and the Baked-blocks field
        public void Clean(int row)
        {
            int[,] prevPF = new int[20, 10];
            for (int i = 0; i < PersistanceField.GetLength(0); i++)
            {
                for (int j = 0; j < PersistanceField.GetLength(1); j++)
                {
                    prevPF[i, j] = PersistanceField[i, j];
                }
            }

            PersistanceField = new int[20, 10];
            
            for (int i = PersistanceField.GetLength(0) - row; i < PersistanceField.GetLength(0); i++)
            {
                for (int j = 0; j < PersistanceField.GetLength(1); j++)
                {
                    PersistanceField[i, j] = prevPF[i, j];
                }
            }
            for (int i = PersistanceField.GetLength(0) - 1 - row; i > 0; i--)
            {
                for (int j = 0; j < PersistanceField.GetLength(1); j++)
                {
                    PersistanceField[i, j] = prevPF[i-1, j];
                }
            }
            
            score++;
        } // Cleaning selected "row" row and moving further blocks down

        public void Debug()
        {
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("FIGURE DEBUG\nX: " + figure.x + "; Y: " + figure.y +
                "\nType: " + figure.sel + " \\ " + (figure.type.GetLength(0) - 1) + 
                "\nRotation: " + figure.rot + " \\ 3" + 
                "\nWidth: " + figure.fig.GetLength(1) + "; Height: " + figure.fig.GetLength(0));

            //figure.DDraw();

        } // Show the information you may need

        public void DownFigureMove() {
            bool collision = false;
            bool full = true;
            for (int i = 0; i < figure.fig.GetLength(0); i++)
            {
                for (int j = 0; j < figure.fig.GetLength(1); j++)
                {
                    {
                        if (figure.fig[i, j] == 1)
                        {
                            if (figure.y + j + 1 > Field.GetLength(0) - 1)
                                collision = true;
                            else if (PersistanceField[figure.y + j + 1, figure.x + i] == 1)// && figure.fig[i, j] == 1)
                                    collision = true;
                            
                        }
                    }
                }
            }
            if (collision)
            {
                for (int i = 0; i < figure.fig.GetLength(0); i++)
                {
                    for (int j = 0; j < figure.fig.GetLength(1); j++)
                    {
                        if (figure.fig[i ,j] == 1)
                            PersistanceField[figure.y + j, figure.x + i] = 1;
                    }
                } // Baking collided Tetramino into the field
                for (int i = PersistanceField.GetLength(0) - 1; i >= 0; i--)
                {
                    full = true;
                    for (int j = 0; j < PersistanceField.GetLength(1); j++)
                    {
                        if (PersistanceField[PersistanceField.GetLength(0) - 1 - i, j] == 0)
                        {
                            full = false;
                            break; //continue;
                        }
                    }
                    if (full)
                    {
                        Clean(i);
                    }
                } // Cleaning filled rows
                for (int i = 0; i < PersistanceField.GetLength(1); i++)
                {
                    if (PersistanceField[0, i] == 1)
                    {
                        gameOver = true;
                        GAME = false;
                        return;
                    }
                } // If the Tetramino reched the top corner then game over

                alreadyHolded = false;

                figure = nextFigure.Clone();
                figure.y = 0;
                figure.x = 3;

                nextFigure.Init();
            } else
            {
                figure.Move();
            }
        } // Logick of Tetramino's down-moving
        public void HorizontalFigureMove(int dir) {
            if (dir == 0 || !hfmDone)
                return;
            hfmDone = false;

            bool collision = false;
            for (int i = 0; i < figure.fig.GetLength(0); i++)
            {
                for (int j = 0; j < figure.fig.GetLength(1); j++)
                {
                    if (figure.fig[i, j] == 1)
                    {
                        if ((dir == 1 ? true : figure.x + i > 0) && figure.x + i + dir < PersistanceField.GetLength(1))
                        {
                            if (PersistanceField[figure.y + j, figure.x + i + dir] == 1)
                            {
                                collision = true;
                                break;
                            }
                        }
                        else
                        {
                            collision = true;
                            break;
                        }

                    }
                }
            }
            if (!collision)
            {
                figure.Move(dir, 0);
            }
            hfmDone = true;
        } // Logick of Tetramino's horizontal moving
        public void FigureRotate()
        {
            bool collision = false;
            Figure nxtFig = figure;
            nxtFig.Rotate();
            if (nxtFig.x + nxtFig.fig.GetLength(0) > Field.GetLength(1) - 1)
            {
                nxtFig.x -= nxtFig.x + nxtFig.fig.GetLength(0) - (Field.GetLength(1) - 1);
            }
            if (nxtFig.x < 0)
                nxtFig.x = 0;
            for (int i = 0; i < nxtFig.fig.GetLength(0); i++)
            {
                for (int j = 0; j < nxtFig.fig.GetLength(1); j++)
                {
                    if (PersistanceField[figure.y + j, figure.x + i] == 1)
                    {
                        collision = true;
                    }
                }
            }
            if (!collision)
            {
                figure = nxtFig;
            }
        } // Rotating the Tetramino
        public void HoldFigure()
        {
            if (!alreadyHolded)
            {
                if (holdedFigure == null)
                {
                    holdedFigure = figure.Clone();
                    figure.Init();
                }
                else
                {

                    Figure temp = holdedFigure.Clone();
                    holdedFigure = figure.Clone();
                    figure = temp.Clone();
                    figure.x = 3;
                    figure.y = 0;
                }
            }
            alreadyHolded = true;
        } // Holding the Tetramino

        public void Draw()
        {
            if (nextFigure == null)
            {
                nextFigure = new Figure();
                nextFigure.Init();
            }
            Console.SetCursorPosition(0, 0);
            Console.Write("[][][][][][][][][][][][]  \n");
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                Console.Write("[]");
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if (Field[i, j] == 1)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" ");
                }

                Console.Write("[]  ");
                Console.Write("\n");
            }

            Console.Write("[][][][][][][][][][][][]  ");
            Console.Write((isRus ? "\n\nСчёт: " : "\n\nScore: ") + score + "\n");

            Console.SetCursorPosition(25, 0);
            Console.Write(isRus ? "УДЕРЖ:  " : "HOLD:  ");
            if (holdedFigure != null)
            {
                Console.SetCursorPosition(25, 2);
                Console.Write("          ");
                Console.SetCursorPosition(25, 3);
                Console.Write("          ");
                Console.SetCursorPosition(25, 4);
                Console.Write("          ");
                Console.SetCursorPosition(25, 5);
                Console.Write("          ");
                Console.SetCursorPosition(25, 6);
                Console.Write("          ");
                for (int k = 0; k < holdedFigure.fig.GetLength(1); k++)
                {
                    Console.SetCursorPosition(25, k + 2);
                    for (int l = 0; l < holdedFigure.fig.GetLength(0); l++)
                    {
                        if (holdedFigure.fig[l, k] == 1)
                            Console.Write("#");
                        else
                            Console.Write(" ");
                        Console.Write(" ");
                    }
                }
            }

            Console.SetCursorPosition(25, 8);
            Console.Write(isRus ? "СЛЕД:  " : "NEXT:  ");

            Console.SetCursorPosition(25, 10);
            Console.Write("          ");
            Console.SetCursorPosition(25, 11);
            Console.Write("          ");
            Console.SetCursorPosition(25, 12);
            Console.Write("          ");
            Console.SetCursorPosition(25, 13);
            Console.Write("          ");
            Console.SetCursorPosition(25, 14);
            Console.Write("          ");
            for (int k = 0; k < nextFigure.fig.GetLength(1); k++)
            {
                Console.SetCursorPosition(25, k + 10);
                for (int l = 0; l < nextFigure.fig.GetLength(0); l++)
                {
                    if (nextFigure.fig[l, k] == 1)
                        Console.Write("#");
                    else
                        Console.Write(" ");
                    Console.Write(" ");
                }
            }

            // Debug(); // Отладка
        } // Drawing the game in the Console
    }

    class Program
    {
        public static Figure tetramino = new Figure();
        public static Screen scr = new Screen();
        public static Timer timer = new Timer();
        public static bool alreadyPressed = false;
        public static int speed = 1;
        static bool startgame = false;
        static bool validSpeed = true;

        static void Main(string[] args)
        {
            Console.Title = scr.isRus ? "C# ТЕТРИС" : "C# TETRIS";
            while (!startgame)
            {
                validSpeed = true;
                Console.Clear();
                try
                {
                    string spd;
                    Console.Write( scr.isRus ? "ТЕТРИС в консоли на C#" +
                        "\n\nУправление:" +
                        "\nСтрелки Влево, Вправо, Вниз отвечают за соответствующее передвижение тетрамино" +
                        "\nСтрелка Вверх - поворачивает тетрамино" +
                        "\nЦифра 0 на цифровой клавиатуре ИЛИ Клавиша End - удержать/заместить данную фигуру" +
                        "\nESC - Выход" +
                        "\n\nПожалуйста, укажите скорость игры в диапазоне 1-5." +
                        "\nПо умолчанию - 1" +
                        "\n\nСкорость: " :
                        "TETRIS in the console on C#" +
                        "\n\nHow to play:" +
                        "\nArrows Left, Right, Down moving the Tetramino by its direction" +
                        "\nArrow Up is Rotate the Tetramino" +
                        "\nNumpad 0 OR the End key is Hold current Tetramino" +
                        "\nESC is exit" +
                        "\n\nPlease, choose speed of the game (1-5)" +
                        "\nDefault is 1" +
                        "\n\nSpeed: ");
                    spd = Console.ReadLine();
                    if (spd == "")
                    {
                        startgame = true;
                    }
                    else
                    {
                        speed = int.Parse(spd);
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine(scr.isRus ? "ОШИБКА\nВы ввели недопустимое значение!" : "ERROR\nIncorrect value!");
                    validSpeed = false;
                    Console.ReadKey();
                }

                if (validSpeed)
                {
                    if (speed > 5)
                    {
                        Console.Clear();
                        Console.WriteLine(scr.isRus ? "ОШИБКА\nВы вышли за пределы диапазона!" : "ERROR\nOut of bounds!");
                        Console.ReadKey();
                    }
                    else if (speed == 0)
                    {
                        Console.Clear();
                        Console.WriteLine(scr.isRus ? "ОШИБКА\nИзвините, но мне кажется, играть в застывшую картинку вовсе не интересно.":"ERROR\nSorry but playing the static picture doesn't look interesting");
                        Console.ReadKey();
                    }
                    else if (speed < 0)
                    {
                        Console.Clear();
                        Console.WriteLine(scr.isRus ? "ОШИБКА\nА как Вы представляете себе игру с отрицательной скоростью?":"ERROR\nHow can you imagine playing a game with negative speed?");
                        Console.ReadKey();
                    }
                    else
                    {
                        startgame = true;
                    }
                }
            } // Choosing the speed of the game

            scr.figure = tetramino;
            timer.Elapsed += TickOfGame;
            timer.Interval = 1000 / speed;
            timer.AutoReset = true;
            timer.Start(); // This is the tick-timer

            tetramino.Init();

            Console.Clear();
            Console.SetWindowSize(50, 30);
            Console.SetBufferSize(50, 30);
            scr.Flush();
            scr.Draw();
            while (scr.GAME)
            {
                scr.cki = Console.ReadKey();
                if (scr.cki.Key == ConsoleKey.Escape)
                    break;
                alreadyPressed = false;
            } // Endless game cycle (ESC = exit)
        }

        private static void TickOfGame(object sender, ElapsedEventArgs e)
        {
            if (!alreadyPressed)
            {
                if (scr.cki.Key == ConsoleKey.LeftArrow)
                    scr.HorizontalFigureMove(-1);
                else if (scr.cki.Key == ConsoleKey.UpArrow)
                    scr.FigureRotate();
                else if (scr.cki.Key == ConsoleKey.RightArrow)
                    scr.HorizontalFigureMove(1);
                else if (scr.cki.Key == ConsoleKey.DownArrow)
                    scr.DownFigureMove();
                else if (scr.cki.Key == ConsoleKey.End || scr.cki.Key == ConsoleKey.NumPad0)
                    scr.HoldFigure();
                alreadyPressed = true;
            } // Reading input keys
            if (scr.gameOver)
            {
                timer.Stop();
                Console.SetCursorPosition(0, 22);
                Console.WriteLine(
                    System.Globalization.CultureInfo.CurrentCulture.EnglishName.ToString().Contains("Russian") ? 
                    "ИГРА ОКОНЧЕНА" : "GAME OVER");
                if (!alreadyPressed)
                    Console.ReadKey();
                return;
            } // If the game is over then show the message and stop the game

            scr.Flush();
            scr.Draw();
            
        }
    }
}
