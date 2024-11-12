using System;

class Connect4
{
    const int Rows = 6;
    const int Columns = 7;
    int[,] board = new int[Rows, Columns];
    int currentPlayer = 1;
    Random random = new Random();

    public void PlayGame()
    {
        bool gameWon = false;
        while (!gameWon && !BoardIsFull())
        {
            PrintBoard();

            if (currentPlayer == 1) // Human player's turn
            {
                Console.WriteLine($"Player {currentPlayer}, choose a column (1-{Columns}):");
                int column = int.Parse(Console.ReadLine()) - 1;

                if (column < 0 || column >= Columns || board[0, column] != 0)
                {
                    Console.WriteLine("Invalid move! Try again.");
                    continue;
                }

                int row = DropPiece(column);
                gameWon = CheckForWinner(row, column);
            }
            else // CPU player's turn
            {
                Console.WriteLine("CPU is making a move...");
                int column = GetCpuMove();
                int row = DropPiece(column);
                Console.WriteLine($"CPU dropped in column {column + 1}");
                gameWon = CheckForWinner(row, column);
            }

            if (gameWon)
            {
                PrintBoard();
                Console.WriteLine($"Player {currentPlayer} wins!");
            }
            else if (BoardIsFull())
            {
                PrintBoard();
                Console.WriteLine("It's a draw!");
            }
            else
            {
                currentPlayer = currentPlayer == 1 ? 2 : 1;
            }
        }
    }

    int GetCpuMove()
    {
        int column;
        do
        {
            column = random.Next(0, Columns); // Random column selection
        }
        while (board[0, column] != 0); // Ensure the column isn't full

        return column;
    }

    int DropPiece(int column)
    {
        for (int row = Rows - 1; row >= 0; row--)
        {
            if (board[row, column] == 0)
            {
                board[row, column] = currentPlayer;
                return row;
            }
        }
        return -1;
    }

    bool CheckForWinner(int row, int column)
    {
        return CheckDirection(row, column, 1, 0) || // Horizontal
               CheckDirection(row, column, 0, 1) || // Vertical
               CheckDirection(row, column, 1, 1) || // Diagonal down-right
               CheckDirection(row, column, 1, -1);  // Diagonal up-right
    }

    bool CheckDirection(int row, int column, int rowDelta, int colDelta)
    {
        int count = 1;
        count += CountPieces(row, column, rowDelta, colDelta);
        count += CountPieces(row, column, -rowDelta, -colDelta);
        return count >= 4;
    }

    int CountPieces(int row, int column, int rowDelta, int colDelta)
    {
        int count = 0;
        int player = board[row, column];
        int r = row + rowDelta;
        int c = column + colDelta;

        while (r >= 0 && r < Rows && c >= 0 && c < Columns && board[r, c] == player)
        {
            count++;
            r += rowDelta;
            c += colDelta;
        }

        return count;
    }

    bool BoardIsFull()
    {
        for (int c = 0; c < Columns; c++)
        {
            if (board[0, c] == 0)
                return false;
        }
        return true;
    }

    void PrintBoard()
    {
        Console.Clear();
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                Console.Write(board[r, c] == 0 ? ". " : board[r, c] == 1 ? "X " : "O ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Connect4 game = new Connect4();
        game.PlayGame();
    }
}

