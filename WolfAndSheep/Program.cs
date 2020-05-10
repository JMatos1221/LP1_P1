using System;

namespace WolfAndSheep
{
    class Program
    {
        /// <summary>
        /// Main method of the program. The program starts here.
        /// </summary>
        /// <param name="args">Command line arguments when running the program</param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Declaring/Initializing Variables
            /// </summary>
            int[,] board = new int[8, 8];
            short row, col, rowm, colm;
            playerName player = playerName.Wolf;
            string coord;
            bool gameOver = false;

            //Fills the game board (bidimensional array) with empty positions
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = 0;
                }
            }

            /// <summary>
            /// Placing the Sheep on the Game board
            /// </summary>
            board[7, 0] = board[7, 2] = board[7, 4] = board[7, 6] = 2;

            //Prints Welcome messages and instructions
            Console.WriteLine("Welcome to Wolf and Sheep!");
            Console.WriteLine("The rules are very simple.");
            PrintInstructions();
            Console.WriteLine("You can request this menu during "
                + "the game by typing 'help'");

            ///Prints the Game board
            PrintGame(board);

            Console.Write(
                "Where do you wanna start as the Wolf? [1B] [1D] [1F] [1H]: ");

            /// <summary>
            /// Loop asking the Wolfs starting position until position is valid
            /// </summary>
            /// <value>true</value>
            do
            {
                //Converts from ASCII to short int
                coord = Console.ReadLine();
                row = Convert.ToInt16(coord[0]);
                col = Convert.ToInt16(coord[1]);
                row -= 49;
                col -= 65;

                //Checks for help command, prints instructions
                if (coord == "help")
                {
                    PrintInstructions();
                    PrintGame(board);
                    Console.Write("Where do you wanna start? "
                    + "[1B] [1D] [1F] [1H]: ");
                }

                /// <summary>
                /// Checks if the inserted position is valid, breaks the cycle if so
                /// </summary>
                else if (row == 0 & (col == 1 || col == 3 ||
                        col == 5 || col == 7)) break;

                /// <summary>
                /// If none of the above are true, this runs
                /// </summary>
                else Console.Write("Invalid position. Where do you wanna " +
                    "start? [1B] [1D] [1F] [1H]: ");

            } while (true);

            /// <summary>
            /// Saves the Wolfs position and placing him on board
            /// </summary>
            /// <value>Wolfs position</value>
            int[] wolfPos = { row, col };

            board[row, col] = 1;

            do
            {
                //Prints the Game board, asks and reads the move
                PrintGame(board, player);

                Console.Write("What's your move? ");
                coord = Console.ReadLine();

                /// <summary>
                /// Checks for help command, prints instructions
                /// </summary>
                /// <returns>Instructions content</returns>
                if (coord == "help") PrintInstructions();

                /// <summary>
                /// Checking if its Player 1s turn and if the Input length is 2
                /// </summary>
                else if ((int)player == 1 & coord.Length == 2)
                {
                    //Converts Input from ASCII to int
                    row = Convert.ToInt16(coord[0]);
                    col = Convert.ToInt16(coord[1]);
                    row -= 49;
                    col -= 65;

                    /// <summary>
                    /// Checks if the desired move is a diagonal
                    /// </summary>
                    /// <param name="row">Desired row to move to</param>
                    /// <param name="col">Desired column to move to</param>
                    /// <returns>true/false</returns>
                    if (Math.Abs(wolfPos[0] - row) == 1 &
                        Math.Abs(wolfPos[1] - col) == 1 &
                        0 <= row & row <= 7 & 0 <= col & col <= 7 &
                        board[row, col] != 2)
                    {
                        //Moves the wolf to the new position and empties the previous one
                        board[wolfPos[0], wolfPos[1]] = 0;
                        wolfPos[0] = row; wolfPos[1] = col;
                        board[wolfPos[0], wolfPos[1]] = 1; 

                        //Changes to Player 2 (Sheep) 
                        player = playerName.Sheep;
                    }
                    /// <summary>
                    /// If the desired position is not a diagonal, prints this
                    /// </summary>
                    else Console.Write("Invalid position.\n");
                }

                /// <summary>
                /// Checks if its Player 2s turn and if the Input length is 5
                /// </summary>
                else if ((int)player == 2 & coord.Length == 5)
                {
                    //Converts Input from ASCII to int
                    row = Convert.ToInt16(coord[0]);
                    col = Convert.ToInt16(coord[1]);
                    row -= 49;
                    col -= 65;

                    rowm = Convert.ToInt16(coord[3]);
                    colm = Convert.ToInt16(coord[4]);
                    rowm -= 49;
                    colm -= 65;

                    //Checks if the Input position is in the Games board range
                    if (0 <= row & row <= 7 & 0 <= col & col <= 7 &
                        0 <= rowm & rowm <= 7 & 0 <= colm & colm <= 7)
                    {
                        //Checks if there is a Sheep on the Input position
                        if (board[row, col] == 2)
                        {
                            //Checks if the desired move is a diagonal of the selected Sheep
                            if (row - rowm == 1 & Math.Abs(col - colm) == 1 &
                                board[rowm, colm] != 1)
                            {
                                board[row, col] = 0;
                                board[rowm, colm] = 2;

                                player = playerName.Wolf;
                            }
                            /// <summary>
                            /// Prints if the desired move position is invalid
                            /// </summary>
                            else Console.Write("Invalid position.\n");
                        }
                        /// <summary>
                        /// Prints if there is no Sheep in the Input position
                        /// </summary>
                        else Console.Write("There is no sheep.\n");
                    }
                    /// <summary>
                    /// Prints if the Input is out of the Game board range
                    /// </summary>
                    else Console.Write("Invalid Input.\n");
                }
                /// <summary>
                /// Prints if the Input length is not the correct
                /// </summary>
                else Console.Write("Invalid Input.\n");

                //Updates the game over variable
                gameOver = GameCheck(board, wolfPos);

            } while (!gameOver);
        }

        /// <summary>
        /// Prints the Game board
        /// </summary>
        /// <param name="table">Game board</param>
        private static void PrintGame(int[,] table)
        {
            Console.WriteLine("\n###############################\n");

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
        
        /// <summary>
        /// Prints the Game board
        /// </summary>
        /// /// <param name="table">Game board</param>
        /// <param name="player_name">Current Players turn</param>
        private static void PrintGame(int[,] table, playerName player_name)
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

        /// <summary>
        /// Prints Instructions ('help' command)
        /// </summary>
        private static void PrintInstructions()
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

        /// <summary>
        /// Checks if the game is over or not and prints the winner when over, quits game loop
        /// </summary>
        /// <param name="table">Game board</param>
        /// <param name="wolf">Wolfs position</param>
        /// <returns>bool true/false</returns>
        private static bool GameCheck(int[,] table, int[] wolf)
        {
            bool canMove = false;

            if (wolf[0] == 7)
            {
                PrintGame(table);
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
                    PrintGame(table);
                    Console.WriteLine("The Sheep won the game!");
                    return true;
                }
            }
            return false;
        }
    }
}