using System;

namespace WolfAndSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[8, 8];
            short row, col, rowm, colm;
            playerName player = playerName.Wolf;
            string coord;
            bool gameOver = false;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = 0;
                }
            }

            board[7, 0] = board[7, 2] = board[7, 4] = board[7, 6] = 2;

            Console.WriteLine("Welcome to Wolf and Sheep!");
            Console.WriteLine("The rules are very simple.");

            print_instructions();
            print_game(board);

            Console.Write(
                "Where do you wanna start as the Wolf? [1B] [1D] [1F] [1H]: ");

            do
            {
                coord = Console.ReadLine();
                row = Convert.ToInt16(coord[0]);
                col = Convert.ToInt16(coord[1]);
                row -= 49;
                col -= 65;

                if (row == 0 & (col == 1 || col == 3 ||
                        col == 5 || col == 7))
                {
                    break;
                }
                Console.Write("Invalid position. Where do you wanna start? "
                    + "[1B] [1D] [1F] [1H]: ");
            } while (true);

            int[] wolfPos = { row, col };

            board[row, col] = 1;

            do
            {
                print_game(board, player);

                Console.Write("What's your move? ");
                coord = Console.ReadLine();

                if (coord == "help") print_instructions();

                else if ((int)player == 1 & coord.Length == 2)
                {
                    row = Convert.ToInt16(coord[0]);
                    col = Convert.ToInt16(coord[1]);
                    row -= 49;
                    col -= 65;

                    if ((wolfPos[0] + 1 == row || wolfPos[0] - 1 == row) &
                        (wolfPos[1] + 1 == col || wolfPos[1] - 1 == col) &
                        board[row, col] != 2)
                    {
                        board[wolfPos[0], wolfPos[1]] = 0;
                        wolfPos[0] = row; wolfPos[1] = col;
                        board[wolfPos[0], wolfPos[1]] = 1;

                        player = playerName.Sheep;
                    }

                    else
                    {
                        Console.Write("Invalid position.\n");
                    }
                }

                else if ((int)player == 2 & coord.Length == 5)
                {
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
                        if (row - 1 == rowm & (col - 1 == colm ||
                            col + 1 == colm) & board[row, col] != 1)
                        {
                            board[row, col] = 0;
                            board[rowm, colm] = 2;

                            player = playerName.Wolf;
                        }

                        else
                        {
                            Console.Write("Invalid position.\n");
                        }
                    }

                    else
                    {
                        Console.Write("There is no sheep.\n");
                    }
                }
                else Console.Write("Invalid Input.\n");
                gameOver = game_check(board, wolfPos);
            } while (!gameOver);
        }

        static void print_game(int[,] table)
        {
            Console.WriteLine("\n   A  B  C  D  E  F  G  H");

            for (int i = 0; i < 8; i++)
            {
                Console.Write($"{i + 1} ");

                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"[{table[i, j]}]");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
        static void print_game(int[,] table, playerName player_name)
        {
            Console.WriteLine("\n###############################\n");

            Console.WriteLine($"Turn: {player_name}");

            Console.WriteLine("\n   A  B  C  D  E  F  G  H");

            for (int i = 0; i < 8; i++)
            {
                Console.Write($"{i + 1} ");

                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"[{table[i, j]}]");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        static void print_instructions()
        {
            Console.WriteLine("\nThe Wolf starts by choosing where he is "
                + "positioned on the board.");
            Console.WriteLine("The Wolf always moves first.");
            Console.WriteLine("Both the Wolf and the Sheep can only move in "
                + "diagonals, but the Sheep can only move forward.");
            Console.WriteLine("For the Wolf to move, simply write the "
                + "wanted position (ex: 2A, 3B).");
            Console.WriteLine("For the Sheep to move, you have to mention "
                + "the Sheep and the wanted position separated by a "
                + "space (ex: 8A 7B, 8C 7D)");
            Console.WriteLine("Good luck and have fun! :D\n");
        }

        static bool game_check(int[,] table, int[] wolf)
        {
            bool canMove = false;

            if (wolf[0] == 7)
            {
                print_game(table);
                Console.WriteLine("The Wolf won the game!");
                return true;
            }

            else
            {
                if (wolf[0] < 7 & wolf[1] < 7)
                {
                    if (table[wolf[0] + 1, wolf[1] + 1] == 0) canMove = true;
                }

                if (wolf[0] < 7 & wolf[1] > 0)
                {
                    if (table[wolf[0] + 1, wolf[1] - 1] == 0) canMove = true;
                }

                if (wolf[0] > 0 & wolf[1] > 0)
                {
                    if (table[wolf[0] - 1, wolf[1] - 1] == 0) canMove = true;
                }

                if (wolf[0] > 0 & wolf[1] < 7)
                {
                    if (table[wolf[0] - 1, wolf[1] + 1] == 0) canMove = true;
                }

                if (!canMove)
                {
                    print_game(table);
                    Console.WriteLine("The Sheep won the game!");
                    return true;
                }
            }
            return false;
        }
    }
}
