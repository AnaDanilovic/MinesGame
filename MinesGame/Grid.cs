using MinesGame.Interfaces;

namespace MinesGame;

public class Grid : IGrid
{
    private bool[,] _mines;
    public int Size { get; set; }

    public void PlaceMines()
    {
        _mines = new bool[Size, Size];
        Random random = new Random();
        int mineCount = Size; 
        for (int i = 0; i < mineCount; i++)
        {
            int x;
            int y;
            do
            {
                x = random.Next(Size);
                y = random.Next(Size);
            } 
            while (_mines[x, y] || (x == 0 && y == 0) || (x == Size - 1 && y == Size - 1)); 

            _mines[x, y] = true;
        }
    }

    public bool HasMine(Position position)
    {
        return _mines[position.X, position.Y];
    }
}
