using System;

namespace WolfAndSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[8, 8];
            short row, col, rowm, colm, player = 1;
            string coord;
            bool gameOver = false;

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

            row = Convert.ToInt16(coord[0]);
            col = Convert.ToInt16(coord[1]);
            row -= 49;
            col -= 65;

            board[row, col] = 1;
            int[] wolfPos = { row, col };

            board[7, 0] = board[7, 2] = board[7, 4] = board[7, 6] = 2;

            print_game(board);

            do
            {
                if (player == 1)
                {
                    coord = Console.ReadLine();

                    row = Convert.ToInt16(coord[0]);
                    col = Convert.ToInt16(coord[1]);
                    row -= 49;
                    col -= 65;

                    if ((wolfPos[0] + 1 == row || wolfPos[0] - 1 == row) &
                    (wolfPos[1] + 1 == col || wolfPos[1] - 1 == col))
                    {
                        board[wolfPos[0], wolfPos[1]] = 0;
                        wolfPos[0] = row; wolfPos[1] = col;
                        board[wolfPos[0], wolfPos[1]] = 1;

                        player = 2;

                        print_game(board);
                    }

                    else
                    {
                        Console.Write("Invalid move, try again: ");
                    }
                }

                else if (player == 2)
                {
                    coord = Console.ReadLine();

                    row = Convert.ToInt16(coord[0]);
                    col = Convert.ToInt16(coord[1]);
                    row -= 49;
                    col -= 65;

                    rowm = Convert.ToInt16(coord[3]);
                    colm = Convert.ToInt16(coord[4]);
                    rowm -= 49;
                    colm -= 65;

                    if (board[row, col] == 2)
                    {
                        if (row - 1 == rowm && (col - 1 == colm || col + 1 == colm))
                        {
                            board[row, col] = 0;
                            board[rowm, colm] = 2;

                            player = 1;

                            print_game(board);
                        }

                        else
                        {
                            Console.Write("Invalid position, try again: ");
                        }
                    }

                    else
                    {
                        Console.Write("There is no sheep, try again: ");
                    }
                }
            } while (!gameOver);
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

