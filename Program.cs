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
            y = 0;
            x = 3;
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
        public bool GAME = true;
        public bool gameOver = false;

        public int[,] Field = new int[20,10];
        public int[,] PersistanceField = new int[20, 10];
        
        public Figure figure;
        public Figure nextFigure;
        public Figure holdedFigure;
        public bool alreadyHolded = false;

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
        } // Чистим указанную в аргументе "row" строку и сдвигаем неупавшие блоки

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
                } // Запекаем столкнувшуюся фигуру в поле

                

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
                } // Очищаем получившиеся заполненные строки
                for (int i = 0; i < PersistanceField.GetLength(1); i++)
                {
                    if (PersistanceField[0, i] == 1)
                    {
                        gameOver = true;
                        GAME = false;
                        return;
                    }
                }

                alreadyHolded = false;

                figure = nextFigure.Clone();
                figure.y = 0;
                figure.x = 3;

                nextFigure.Init();
                //figure.Init(); // Инициализируем новую тетрамино
            } else
            {
                figure.Move();
            }
        } // Логика падения тетрамино вниз
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
        }

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
            Console.Write("\n\nСчёт: " + score + "\n");

            Console.SetCursorPosition(25, 0);
            Console.Write("УДЕРЖ:  ");
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
            Console.Write("СЛЕД:  ");

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
            Console.Title = "C# ТЕТРИС";
            while (!startgame)
            {
                validSpeed = true;
                Console.Clear();
                try
                {
                    string spd;
                    Console.Write("ТЕТРИС в консоли на C#\n\nУправление:\nСтрелки Влево, Вправо, Вниз отвечают за соответствующее передвижение тетрамино\nСтрелка Вверх - поворачивает тетрамино\nЦифра 0 на цифровой клавиатуре ИЛИ Клавиша End - удержать/заместить данную фигуру\nESC - Выход\n\nПожалуйста, укажите скорость игры в диапазоне 1-5.\nПо умолчанию - 1\n\nСкорость: ");
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
                    Console.WriteLine("ОШИБКА\nВы ввели недопустимое значение!");
                    validSpeed = false;
                    Console.ReadKey();
                }

                if (validSpeed)
                {
                    if (speed > 5)
                    {
                        Console.Clear();
                        Console.WriteLine("ОШИБКА\nВы вышли за пределы диапазона!");
                        Console.ReadKey();
                    }
                    else if (speed == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("ОШИБКА\nИзвините, но мне кажется, играть в застывшую картинку вовсе не интересно.");
                        Console.ReadKey();
                    }
                    else if (speed < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("ОШИБКА\nА как Вы представляете себе игру с отрицательной скоростью?");
                        Console.ReadKey();
                    }
                    else
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
                else if (scr.cki.Key == ConsoleKey.End || scr.cki.Key == ConsoleKey.NumPad0)
                    scr.HoldFigure();
                alreadyPressed = true;
            }
            if (scr.gameOver)
            {
                timer.Stop();
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("ИГРА ОКОНЧЕНА");
                if (!alreadyPressed)
                    Console.ReadKey();
                return;
            } // Проверяем, если игра уже окончена, то выводим сообщение об этом и прекращаем дальнейшие действия

            scr.Flush();
            scr.Draw();
            
        }
    }
}
