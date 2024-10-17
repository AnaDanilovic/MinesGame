using MinesGame.Interfaces;

namespace MinesGame;

public class MinefieldGame 
{
    public int Lives { get; set; }
    private readonly IGrid _grid;
    private int _moves;
    private Position _position;


    public MinefieldGame(IGrid grid) 
    {
        _grid = grid;
        _grid.PlaceMines();
        _moves = 0;
        _position = new Position(0, 0);
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Mines game!");
        Console.WriteLine("Move from A1 to C4 without hitting mines.");
        Console.WriteLine("Use commands: 'up', 'down', 'left', 'right'.");
        Console.WriteLine($"You have {Lives} lives.");

        while (Lives > 0 && !IsGameWon())
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

        if (Lives == 0)
        {
            Console.WriteLine("Game Over. You've lost all your lives.");
        }
        else
        {
            Console.WriteLine($"Congratulations! You reached the other side in {_moves} moves.");
        }
    }

    public bool MovePlayer(string direction)
    {
        bool moved = false;
        switch (direction)
        {
            case "up":
                moved = _position.MoveUp();
                if (moved) CheckHasMine();
                return moved;
            case "down":
                moved = _position.MoveDown(_grid.Size);
                if (moved) CheckHasMine();
                return moved;
            case "left":
                moved = _position.MoveLeft();
                if (moved) CheckHasMine();
                return moved;
            case "right":
                moved = _position.MoveRight(_grid.Size);
                if (moved) CheckHasMine();
                return moved;
            default:
                return false;
        }
    }

    public void CheckHasMine()
    {
        if (_grid.HasMine(_position))
        {
            Lives--;
            Console.WriteLine("Boom! You hit a mine.");
        }
    }

    public bool IsGameWon()
    {
        return _position.X == _grid.Size - 1 && _position.Y == _grid.Size - 1;
    }

    private void PrintStatus()
    {
        Console.WriteLine($"You are at {PositionToChessNotation(_position)}. Lives: {Lives}, Moves: {_moves}");
    }

    private string PositionToChessNotation(Position position)
    {
        char column = (char)('A' + position.Y);
        int row = position.X + 1;
        return $"{column}{row}";
    }
}
