using System;

class TicTacToe
{
    static int Player = 1;
    const char X = 'X';
    const char O = 'O';
    static char[,] chars = new char[3, 3];
    private static int NumberOfMoves = 0;

    static void Main()
    {
        do
        {
            GenerationTable();
            BasicProcessing();
        } while (NumberOfMoves < 9 && !CheckingForWin());
    }

    public static void GenerationTable()
    {
        Console.Clear();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (chars[i, j] == '\0')
                    Console.Write($"{(i * 3 + j + 1)}|");
                else
                {
                    if (chars[i, j] == X)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"{X}|");
                    }
                    else if (chars[i, j] == O)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{O}|");
                    }
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

    public static void BasicProcessing()
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

                    if (chars[g, v] == '\0')
                    {
                        chars[g, v] = (Player == 1) ? X : O;
                        NumberOfMoves++;
                        if (CheckingForWin())
                        {
                            GenerationTable();
                            Console.WriteLine($"Игрок {Player} выиграл!");
                            return;
                        }
                        if (NumberOfMoves == 9)
                        {
                            GenerationTable();
                            Console.WriteLine("Игра завершена ничьей!");
                            return;
                        }
                        Player = (Player == 1) ? 2 : 1;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: эта клетка уже занята.");
                    }
                    GenerationTable();
                }
            }
            else
            {
                Console.WriteLine("Ошибка: введите корректное число.");
                prediction = 0;
            }
        } while (prediction < 1 || prediction > 9);
    }

    public static bool CheckingForWin()
    {


        for (int i = 0; i < 3; i++)
        {
            if (chars[i, 0] != '\0' && chars[i, 0] == chars[i, 1] && chars[i, 1] == chars[i, 2])
            {
                return true;
            }
        }


        for (int i = 0; i < 3; i++)
        {
            if (chars[0, i] != '\0' && chars[0, i] == chars[1, i] && chars[1, i] == chars[2, i])
            {
                return true;
            }
        }


        if (chars[0, 0] != '\0' && chars[0, 0] == chars[1, 1] && chars[1, 1] == chars[2, 2])
        {
            return true;
        }
        if (chars[0, 2] != '\0' && chars[0, 2] == chars[1, 1] && chars[1, 1] == chars[2, 0])
        {
            return true;
        }
        return false;
    }
}