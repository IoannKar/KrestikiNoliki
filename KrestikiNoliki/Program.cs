using System;

class KrestikINoliki
{
    static int Player = 1;
    static char[,] kletka = new char[3, 3];
    private static int kolichestvoHodov = 0;

    static void Main()
    {

        do
        {
            Tablica();
            vvodchisla();
        } while (kolichestvoHodov < 9 && !proverka());
    }

    public static void Tablica()
    {
        Console.Clear();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (kletka[i, j] == '\0')
                    Console.Write($"{(i * 3 + j + 1)}|");
                else
                {

                    if (kletka[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("X|");
                    }
                    else if (kletka[i, j] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("O|");
                    }
                }
                Console.ResetColor();
            }

            Console.WriteLine();
        }



    }

    public static void vvodchisla()
    {
        string input;
        int prediction;

        do
        {
            Console.WriteLine("Игрок {0}, пожалуйста, введите число от 1 до 9:", Player); ;
            input = Console.ReadLine();
            if (int.TryParse(input, out prediction))
            {
                if (prediction < 1 || prediction > 9)
                {
                    Console.WriteLine("Ошибка: введите число в диапазоне от 1 до 9.");
                }
                else
                {
                    int g = (prediction - 1) / 3;
                    int v = (prediction - 1) % 3;

                    if (kletka[g, v] == '\0')
                    {
                        kletka[g, v] = (Player == 1) ? 'X' : 'O';
                        kolichestvoHodov++;
                        if (proverka())
                        {
                            Tablica();
                            Console.WriteLine($"Игрок {Player} выиграл!");
                            return;
                        }
                        if (kolichestvoHodov == 9)
                        {
                            Tablica();
                            Console.WriteLine("Игра завершена ничьей!");
                            return;
                        }
                        Player = (Player == 1) ? 2 : 1;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: эта клетка уже занята.");
                    }
                    Tablica();
                }
            }
            else
            {
                Console.WriteLine("Ошибка: введите корректное число.");
                prediction = 0;
            }
        } while (prediction < 1 || prediction > 9);
    }

    public static bool proverka()
    {


        for (int i = 0; i < 3; i++)
        {
            if (kletka[i, 0] != '\0' && kletka[i, 0] == kletka[i, 1] && kletka[i, 1] == kletka[i, 2])
            {
                return true;
            }
        }


        for (int i = 0; i < 3; i++)
        {
            if (kletka[0, i] != '\0' && kletka[0, i] == kletka[1, i] && kletka[1, i] == kletka[2, i])
            {
                return true;
            }
        }


        if (kletka[0, 0] != '\0' && kletka[0, 0] == kletka[1, 1] && kletka[1, 1] == kletka[2, 2])
        {
            return true;
        }
        if (kletka[0, 2] != '\0' && kletka[0, 2] == kletka[1, 1] && kletka[1, 1] == kletka[2, 0])
        {
            return true;
        }

        return false;
    }
}