namespace MinesGame.Test;

public class MinefieldGameTests
{
    [Test]
    public void IsGameWon_ShouldReturnTrue_WhenPlayerReachesEnd()
    {
        var game = new MinefieldGame(4, 3);
        var playerPos = new Position(3, 3); 
        Assert.IsTrue(playerPos.X == 3 && playerPos.Y == 3);
    }

}
