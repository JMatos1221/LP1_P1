using System;

namespace WolfAndSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[8, 8];
            short row, col;
            string coord;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = 0;
                }
            }

            Console.Write(
                "Where do you wanna start as the Wolf? [1B] [1D] [1F] [1H]: ");
            coord = Console.ReadLine();

            row = Convert.ToInt16( coord[0]);
            col = Convert.ToInt16(coord[1]);
            row -= 49;
            col -= 65;

            board[row,col] = 1;

            board[7,0] = board[7,2] = board[7,4] = board[7,6] = 2;

            print_game(board);
        }

        static void print_game(int[,] table)
        {
            Console.WriteLine("   A  B  C  D  E  F  G  H");

            for (int i = 0; i < 8; i++)
            {
                Console.Write($"{i + 1} ");

                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"[{table[i, j]}]");
                }
                Console.WriteLine("");
            }
        }
    }
}

