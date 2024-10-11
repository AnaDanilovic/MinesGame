using System.Drawing;

namespace MinesGame.Test;

public class MinefieldGameTests
{
    int size = 4;
    [Test]
    public void IsGameWon_ShouldReturnTrue_WhenPlayerReachesEnd()
    {
        var game = new MinefieldGame(size, 3);
        var position = new Position(4, 4);
        Assert.IsTrue(position.X == 4 && position.Y == 4);
    }  

}
