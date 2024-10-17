using MinesGame.Interfaces;
using Moq;

namespace MinesGame.Test;

public class MinefieldGameTests
{
    [Test]
    public void PlayerHitsMine_ShouldDecreaseLives()
    {
        // Arrange
        var mockGrid = new Mock<IGrid>();
        mockGrid.Setup(g => g.Size).Returns(8);
        mockGrid.Setup(g => g.HasMine(It.IsAny<Position>())).Returns(true); 

        var game = new MinefieldGame(mockGrid.Object);
        game.Lives = 3;

        // Act
        game.MovePlayer("right");
        game.MovePlayer("left");
        game.MovePlayer("down");

        // Assert
        Assert.That(0, Is.EqualTo(game.Lives)); 
    }

    [Test]
    public void PlayerReachesEnd_ShouldWinGame()
    {
        // Arrange
        var mockGrid = new Mock<IGrid>();
        mockGrid.Setup(g => g.Size).Returns(8);
        mockGrid.Setup(g => g.HasMine(It.IsAny<Position>())).Returns(false); 

        var game = new MinefieldGame(mockGrid.Object);
        game.Lives = 3;
       
        //Act
        game.MovePlayer("right"); 
        game.MovePlayer("down");
        game.MovePlayer("right");
        game.MovePlayer("down");
        game.MovePlayer("right");
        game.MovePlayer("down");
        game.MovePlayer("right");
        game.MovePlayer("down");
        game.MovePlayer("right");
        game.MovePlayer("down");
        game.MovePlayer("right");
        game.MovePlayer("down");
        game.MovePlayer("right");
        game.MovePlayer("down");

        // Assert
        Assert.IsTrue(game.IsGameWon()); 
    }
}

