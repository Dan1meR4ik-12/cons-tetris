using System;
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
            },
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
            },
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
            },
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
            },
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
            },
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
            },
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
            }
        };
        public int sel = 0;
        public int rot = 0;
        private Random rnd = new Random();

        public void Move(int dirX = 0, int dirY = 1)
        {
            x += dirX;
            y += dirY;
        }

        public void Init()
        {
            sel = rnd.Next(0, type.GetLength(0));
            rot = rnd.Next(0, 4);
            fig = type[sel, rot];
            //Rotate(true);
        }

        public void Rotate(bool random = false)
        {
            //int[,] prevPic = fig;
            //fig = new int[prevPic.GetLength(1), prevPic.GetLength(0)];

            //int round;
            //if (random)
            //    round = rnd.Next(0, 4);
            //else
            //    round = 1;

            //for (int r = 0; r < round; r++)
            //{
            //    for (int i = 0; i < prevPic.GetLength(1); i++)
            //    {
            //        for (int j = 0; j < prevPic.GetLength(0); j++)
            //        {
            //            fig[i, j] = prevPic[prevPic.GetLength(0) - j - 1, i];
            //        }
            //    }
            //}
            rot--;
            if (rot < 0)
                rot = 3;
            fig = type[sel, rot];
        }

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
        }
        
    }

    class Screen
    {
        public int score = 0;
        public int[,] Field = new int[20,10];
        public int[,] PersistanceField = new int[20, 10];
        public Figure figure;
        public ConsoleKeyInfo cki;

        public string debugValue1 = "";

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
                        Field[figure.y + l, figure.x + k] = 1; //figure.fig[k, l];
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
        }

        public void Debug()
        {
            Console.WriteLine("FIGURE DEBUG\nX: " + figure.x + "; Y: " + figure.y +
                "\nType: " + figure.sel + " \\ " + (figure.type.GetLength(0) - 1) + 
                "\nRotation: " + figure.rot + " \\ 3" + 
                "\nWidth: " + figure.fig.GetLength(1) + "; Height: " + figure.fig.GetLength(0));

            figure.DDraw();

        }

        public void DownFigureMove() {
            bool collision = false;
            bool full = true;
            int row = 0;
            for (int i = 0; i < figure.fig.GetLength(0); i++)
            {
                for (int j = 0; j < figure.fig.GetLength(1); j++)
                {
                    //if (figure.y + j + 1 < 16)// && figure.fig[i, j] == 0)
                    {
                        if (figure.fig[i, j] == 1)
                        {
                            if (figure.y + j + 1 > Field.GetLength(0) - 1)
                                collision = true;
                            else if (PersistanceField[figure.y + j + 1, figure.x + i] == 1)// && figure.fig[i, j] == 1)
                                    collision = true;
                            
                        }
                    }
                    //else
                       // collision = true;
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
                } // Запекаем столкнувшуюся фигуру в поле
                //for (int i = 0; i < PersistanceField.GetLength(0); i++)
                //{
                //    while (full)
                //    {
                //        for (int j = 0; j < PersistanceField.GetLength(1); j++)
                //        {
                //            row = i;
                //            if (PersistanceField[PersistanceField.GetLength(0) - 1 - i, j] == 0)
                //            {
                //                full = false;
                //                continue;
                //            }
                //        }
                //        if (full)
                //        {
                //            Clean(row);
                //            //Refill();
                //        }
                //    }
                //} // Очищаем получившиеся заполненные строки

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
                        //while (full)
                        //{
                        //    row = i;
                        //    if (PersistanceField[PersistanceField.GetLength(0) - 1 - i, j] == 0)
                        //    {
                        //        full = false;
                        //        continue;
                        //    }
                        //}
                        //if (full)
                        //{
                        //    Clean(row);
                        //    //Refill();
                        //}
                        //else
                        //{
                        //    break;
                        //}
                    }
                    if (full)
                    {
                        debugValue1 += i.ToString() + "; ";
                        Console.Title = debugValue1;
                        Clean(i);
                        //Refill();
                    }
                }
                debugValue1 = "";
                figure.y = 0;
                figure.x = 3;
                figure.Init(); // Сбрасываем положение для новой тетрамино
            } else
            {
                figure.Move();
            }
        } // Логика падения тетрамино вниз

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

            //for (int i = 0; i < PersistanceField.GetLength(1); i++)
            //{
            //    PersistanceField[PersistanceField.GetLength(0) - 1 - row, i] = 0;
            //}

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

            //for (int i = 1; i < PersistanceField.GetLength(0) - row; i++)
            //{
            //    for (int j = 0; j < PersistanceField.GetLength(1); j++)
            //    {
            //        PersistanceField[i, j] = prevPF[i - 1, j];
            //    }
            //}
            score++;
        } // Чистим указанную в аргументе "row" строку и сдвигаем неупавшие блоки
        public void Refill()
        {
            int[,] prevPF = PersistanceField;
            PersistanceField = new int[20, 10];
            for (int i = 1; i < PersistanceField.GetLength(0); i++)
            {
                for (int j = 0; j < PersistanceField.GetLength(1); j++)
                {
                    PersistanceField[i, j] = prevPF[i - 1, j];
                }
            }
        } // Сдвигаем неупавшие блоки вниз на 1 строку
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
                        if (figure.x + i > 0 && figure.x + i + dir < PersistanceField.GetLength(1))
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
        } // Горизонтальное передвижение фигуры

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
        } // Поворачиваем фигуру

        public void Draw()
        {
            Console.Clear();
            Console.Write("[][][][][][][][][][][][]\n");
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

                Console.Write("[]");
                Console.Write("\n");
            }
            Console.Write("[][][][][][][][][][][][]\nСчёт: " + score + "\n");
            
           // Debug(); // Отладка
        } // "Отрисовываем" игру в консоли
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
            while (!startgame)
            {
                validSpeed = true;
                Console.Clear();
                try
                {
                    string spd;
                    Console.Write("ТЕТРИС в консоли на C#\n\nПожалуйста, укажите скорость игры в диапазоне 1-5.\nПо умолчанию - 1\n\nСкорость: ");
                    spd = Console.ReadLine();
                    if (spd == "")
                    {
                        startgame = true;
                    }
                    else
                    {
                        speed = Int32.Parse(spd);
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("ОШИБКА\nВы ввели недопустимое значение!");
                    validSpeed = false;
                    Console.ReadKey();
                }

                if (validSpeed)
                {
                    if (speed < 1 || speed > 5)
                    {
                        Console.Clear();
                        Console.WriteLine("ОШИБКА\nВы вышли за пределы диапазона!");
                        Console.ReadKey();
                    } else
                    {
                        startgame = true;
                    }
                }
            }

            scr.figure = tetramino;
            timer.Elapsed += TickOfGame;
            timer.Interval = 1000 / speed;
            timer.AutoReset = true;
            timer.Start();

            tetramino.Init();
            tetramino.x = 3; tetramino.y = 0;

            scr.Flush();
            scr.Draw();
            while (true)
            {
                scr.cki = Console.ReadKey();
                if (scr.cki.Key == ConsoleKey.Escape)
                    break;
                alreadyPressed = false;
            }
        }

        private static void TickOfGame(object sender, ElapsedEventArgs e)
        {
            if (!alreadyPressed)
            {
                //throw new NotImplementedException();
                if (scr.cki.Key == ConsoleKey.LeftArrow)
                    scr.HorizontalFigureMove(-1);
                else if (scr.cki.Key == ConsoleKey.UpArrow)
                    scr.FigureRotate();
                else if (scr.cki.Key == ConsoleKey.RightArrow)
                    scr.HorizontalFigureMove(1);
                else if (scr.cki.Key == ConsoleKey.DownArrow)
                    scr.DownFigureMove();
                alreadyPressed = true;
            }
            //else
            scr.Flush();
            scr.Draw();
            
        }
    }
}
