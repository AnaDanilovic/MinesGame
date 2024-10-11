using System;

namespace MinesGame
{
    class Program
    {
        static void Main(string[] args)
        {
            MinefieldGame game = new MinefieldGame(4, 3); 
            game.Start();
        }
    }
}
