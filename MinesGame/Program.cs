using Microsoft.Extensions.DependencyInjection;
using MinesGame.Interfaces;

namespace MinesGame
{
    class Program
    {
        public static void Main()
        {
            var serviceProvider = new ServiceCollection()
           .AddSingleton<IGrid, Grid>()
           .BuildServiceProvider();

            var scope = serviceProvider.CreateScope();
            var _grid = scope.ServiceProvider.GetRequiredService<IGrid>();
            _grid.Size = 4;

            var game = new MinefieldGame(_grid);
            game.Lives = 3;
            game.Start();
        }
    }
}
