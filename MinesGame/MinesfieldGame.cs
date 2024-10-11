namespace MinesGame;

public class MinefieldGame
{
    private readonly Grid _grid;
    private int _lives;
    private int _moves;
    private Position _position;

    public MinefieldGame(int size, int lives)
    {
        _grid = new Grid(size);
        _lives = lives;
        _moves = 0;
        _position = new Position(0, 0); 
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Mines game!");
        Console.WriteLine("Move from A1 to C4 without hitting mines.");
        Console.WriteLine("Use commands: 'up', 'down', 'left', 'right'.");
        Console.WriteLine($"You have {_lives} lives.");

        while (_lives > 0 && !IsGameWon())
        {
            PrintStatus();
            try
            {
                var direction = Console.ReadLine()?.Trim().ToLower();
                if (!string.IsNullOrEmpty(direction))
                {
                    if (MovePlayer(direction))
                    {
                        _moves++;
                        if (_grid.HasMine(_position))
                        {
                            _lives--;
                            Console.WriteLine("Boom! You hit a mine.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Use one of the available commands: 'up', 'down', 'left', 'right'");
                }
                }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString()); 
            }
        }

        if (_lives == 0)
        {
            Console.WriteLine("Game Over. You've lost all your lives.");
        }
        else
        {
            Console.WriteLine($"Congratulations! You reached the other side in {_moves} moves.");
        }
    }

    private bool MovePlayer(string direction)
    {
        switch (direction)
        {
            case "up":
                return _position.MoveUp();
            case "down":
                return _position.MoveDown(_grid.Size);
            case "left":
                return _position.MoveLeft();
            case "right":
                return _position.MoveRight(_grid.Size);
            default:
                return false;
        }
    }

    private bool IsGameWon()
    {
        return _position.X == _grid.Size - 1 && _position.Y == _grid.Size - 1;
    }

    private void PrintStatus()
    {
        Console.WriteLine($"You are at {PositionToChessNotation(_position)}. Lives: {_lives}, Moves: {_moves}");
    }

    private string PositionToChessNotation(Position position)
    {
        char column = (char)('A' + position.Y);
        int row = position.X + 1;
        return $"{column}{row}";
    }
}
