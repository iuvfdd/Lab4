using System.Diagnostics;

namespace Lab2_L
{
    class Programm
    {
        static void Main()
        {
            bool LiveProg = true;
            while (LiveProg == true)
            {
                Console.WriteLine("Выберите один из вариантов.\n1. Отгадать ответ\n2. Об авторе\n3. Сортировка массива\n4. Игра ТЕТРИС\n5.Выход");
                switch (IntNumber())
                {
                    case 1:
                        case1();
                        break;
                    case 2:
                        case2();
                        break;
                    case 3:
                        case3();
                        break;
                    case 4:
                        case4();
                        break;
                    case 5:
                        LiveProg = case5();
                        break;
                }
            }
            Console.ReadKey();
        }
        //------------M A T H G A M E-------------------

        static void case1()
        {
            Console.WriteLine("Введите число А: ");
            int a = IntNumber();
            Console.WriteLine("Введите число B: ");
            int b = IntNumber();


            double result = functional(a, b);
            GuessUser(Math.Round(result, 2));

        }
        static double functional(int a, int b)
        {
            double result;
            result = Math.PI * Math.Pow(Math.Log(b), 5) / (Math.Sin(a) + 1);
            return result;
        }
        static void GuessUser(double result)
        {
            int Attempt = 3;
            Console.Write("Ваше выражение: Pi * (ln(b)^5)/ (sin(a) + 1)\nОтгадайте ответ: ");
            double answer;
            while (!double.TryParse(Console.ReadLine(), out answer))
            {
                Console.Write("Ответ в виде числа. Введите число: ");
            }
            if (answer == result)
                Console.WriteLine("Молодцы! Вы угадали ответ!\n");
            else
            {
                while (Attempt >= 2)
                {
                    Console.WriteLine("Неверно. У вас осталось {0} попытки(ка). Попробуйте снова.", Attempt - 1);
                    Attempt--;
                    while (!double.TryParse(Console.ReadLine(), out answer))
                    {
                        Console.WriteLine("Ошибка. Введите число");
                    }
                }
                Console.WriteLine("Ваше кол-во попыток исчерпано! Ответ: {0}\n", Math.Round(result, 2));
            }

        }
        static int IntNumber()
        {
            int Out;
            while (!int.TryParse(Console.ReadLine(), out Out))
            {
                Console.WriteLine("Неверное значение");
            }
            return Out;
        }


        //----------I N F O---------------

        static void case2()
        {
            Console.WriteLine("ОБ АВТОРЕ\nФИО: Григорова Лада Алексеевна\nГруппа: 6106-090301D\n");
            Console.WriteLine("Возвращаем Вас в меню...\n");
        }

        //-------------M A S S I V E--------------

        static void case3()
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.Write("Введите размер массива: ");
            int SizeArr = LenMass();
            int[] array = CreateMass(SizeArr);
            int[] array2 = CopyMassive(array);

            stopwatch.Start();
            BubbleSort(array);
            stopwatch.Stop();
            int TimeBS = (int)stopwatch.ElapsedMilliseconds;

            stopwatch.Start();
            InsertionSort(array2);
            stopwatch.Stop();
            int TimeIS = (int)stopwatch.ElapsedMilliseconds;

            if (TimeBS > TimeIS)
            {
                Console.WriteLine("Сортировка ставками быстрее пузырька на {0} ms", TimeBS - TimeIS);
            }
            else if (TimeBS < TimeIS)
            {
                Console.WriteLine("Сортировка ставками быстрее пузырька на {0} ms", TimeIS - TimeBS);
            }
            else
            {
                Console.WriteLine("Метод сортировок равен");
            }
            Console.WriteLine(" ");
        }


        static int[] CreateMass(int N)
        {
            Random rand = new Random();

            int[] mass = new int[N];
            for (int i = 0; i < N; i++)
            {
                mass[i] = rand.Next(-1000, 1000);
            }
            return mass;
        }
        static int[] CopyMassive(int[] array)
        {
            int[] array1 = new int[array.Length];
            for (int i = array.Length - 1; i >= 0; i--)
            {
                array1[i] = array[i];
            }
            return array1;
        }
        static void TenMassive(int[] array)
        {
            if (array.Length < 10)
            {
                foreach (int i in array)
                {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Длинна массива превышает 10 элементов.");
            }
        }
        static int LenMass()
        {
            int N = -1;
            while (N <= 0)
            {
                N = IntNumber();
                if (N <= 0)
                {
                    Console.WriteLine("Длинна массива не может быть меньше 1");
                }
            }
            return N;
        }
        static int[] InsertionSort(int[] array)
        {
            Console.WriteLine("\nМассив до сортировки:");
            TenMassive(array);
            for (int i = 1; i < array.Length; i++)
            {
                int k = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > k)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = k;
            }
            Console.WriteLine("Массив после сортировки:");
            TenMassive(array);
            return array;
        }
        static int[] BubbleSort(int[] array)
        {
            bool swapped;
            Console.WriteLine("\nМассив до сортировки:");
            TenMassive(array);
            for (int i = 0; i < array.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
            Console.WriteLine("Массив после сортировки:");
            TenMassive(array);
            return array;
        }



        // --------------------G A M E----------------------------



        static char[][,] FigureT = new char[][,]
        {
            new char[,] { { '█', '█', '█', '█' } }, // I
            new char[,] { { '█', '█' }, { '█', '█' } }, // O
            new char[,] { { ' ', '█', ' ' }, { '█', '█', '█' } }, // T
            new char[,] { { '█', ' ', ' ' }, { '█', '█', '█' } }, // L
            new char[,] { { ' ', ' ', '█' }, { '█', '█', '█' } }, // J
            new char[,] { { ' ', '█', '█' }, { '█', '█', ' ' } }, // S
            new char[,] { { '█', '█', ' ' }, { ' ', '█', '█' } }  // Z
        };

        static int curr_figure_X, curr_figure_Y;
        static int[,] currentFigure;

        static char[,] GameField = new char[10, 10];
        static void case4()
        {
            bool exit = false;

            while (!exit)
            {

            }
        }

        static void InzGame()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    GameField[x, y] = ' ';
                }
            }
        }

        static void DrawField()
        {
            char[,] tempField = (char[,])GameField.Clone();

            for (int py = 0; py < currentFigure.GetLength(0); py++)
            {
                for (int px = 0; px < currentFigure.GetLength(1); px++)
                {
                    if (currentPiece.Shape[py, px] != ' ')
                    {
                        int fieldX = currentX + px;
                        int fieldY = currentY + py;

                        if (fieldY >= 0 && fieldY < HEIGHT && fieldX >= 0 && fieldX < WIDTH)
                        {
                            tempField[fieldY, fieldX] = currentPiece.Shape[py, px];
                        }
                    }
                }
            }
            Console.WriteLine("┌────────────────────");
            for (int x = 0; x < 10; x++)
            {
                Console.WriteLine("║");
                for (int y = 0; y < 10; y++)
                {
                    {

                    }
                }
            }
        }

        static void MovePlayer()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.A:
                    if (MoveLeft())
                    {
                        curr_figure_X--;
                    }
                    break;
                case ConsoleKey.D:
                    if (MoveRight())
                    {
                        curr_figure_X++;
                    }
                    break;
                case ConsoleKey.S:
                    MoveDown();
                    break;
                case ConsoleKey.W:
                    Rotate();
                    break;
            }
        }

        static bool MoveLeft()
        {
            for (int x = 0; x < currentFigure.GetLength(0); x++)
            {
                for (int y = 0; y < currentFigure.GetLength(1); y++)
                {
                    if (currentFigure[x, y] == 1)
                    {
                        int newX = curr_figure_X + y - 1;
                        int newY = curr_figure_Y + x;

                        if (newX < 0 || (newY >= 0 && newY < 10 && GameField[newY, newX] == '█'))
                            return false;
                    }

                }
            }
            return true;
        }
        static bool MoveRight()
        {
            for (int x = 0; x < currentFigure.GetLength(0); x++)
            {
                for (int y = 0; y < currentFigure.GetLength(1); y++)
                {
                    if (currentFigure[x, y] == 1)
                    {
                        int newX = curr_figure_X + y - 1;
                        int newY = curr_figure_Y + x;

                        if (newX >= 10 || (newY >= 0 && newY < 10 && GameField[newY, newX] == '█'))
                            return false;
                    }
                }
            }
            return true;
        }
        static bool MoveDown()
        {
            for (int x = 0; x < currentFigure.GetLength(0); x++)
            {
                for (int y = 0; y < currentFigure.GetLength(1); y++)
                {
                    if (currentFigure[x, y] == 1)
                    {
                        int newX = curr_figure_X + y + 1;
                        int newY = curr_figure_Y + x;

                        if (newX >= 10 || (newY >= 0 && GameField[newY, newX] == '█'))
                            return false;
                    }
                }
            }
            return true;
        }
        static void Rotate()
        {
            int[,] rotated = new int[currentFigure.GetLength(1), currentFigure.GetLength(0)];
            for (int x = 0; x < currentFigure.GetLength(0); x++)
            {
                for (int y = 0; y < currentFigure.GetLength(1); y++)
                {
                    rotated[y, currentFigure.GetLength(0) - 1 - y] = currentFigure[x, y];
                }
            }
            if (CanPlaceFigure(rotated, curr_figure_X, curr_figure_Y))
            {
                currentFigure = rotated;
            }
        }

        static bool CanPlaceFigure(int[,] figure, int x, int y)
        {
            for (int i = 0; i < figure.GetLength(0); i++)
            {
                for (int j = 0; j < figure.GetLength(1); j++)
                {
                    if (figure[i, j] == ' ')
                    {
                        int fieldX = i + x;
                        int fieldY = j + y;

                        if (fieldX < 0 || fieldX >= 10 || fieldY <= 10)
                            return true;
                        if (fieldY >= 0 && GameField[fieldY, fieldX] != ' ')
                            return true;
                    }
                }
            }
            return true;
        }

        



            //--------------------------L E A V E--------------------------
            static bool case5()
        {
            Console.WriteLine("Вы точно хотите выйти?\nД - Да\nН - Нет");
            string answerDN = Console.ReadLine();
            if (answerDN == "Н" | answerDN == "н")
            {
                Console.WriteLine("Возвращаем вас в меню...\n");
                return true;
            }
            else if (answerDN == "Д" | answerDN == "д")
            {
                Console.WriteLine("До встречи! Нажмите любую кнопку, чтобы выйти.");
                return false;
            }
            else
            {
                Console.WriteLine("Неверный ввод.");
                return true;
            }
        }

    }
}