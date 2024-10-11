namespace MinesGame
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool MoveUp()
        {
            if (X > 0)
            {
                X--;
                return true;
            }
            return false;
        }

        public bool MoveDown(int size)
        {
            if (X < size - 1)
            {
                X++;
                return true;
            }
            return false;
        }

        public bool MoveLeft()
        {
            if (Y > 0)
            {
                Y--;
                return true;
            }
            return false;
        }

        public bool MoveRight(int size)
        {
            if (Y < size - 1)
            {
                Y++;
                return true;
            }
            return false;
        }
    }
}
