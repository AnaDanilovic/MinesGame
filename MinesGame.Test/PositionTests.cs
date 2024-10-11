namespace MinesGame.Test;

public class Tests
{
    public class PositionTests
    {
        int size = 4; 

        [Test]
        public void MoveUp_ShouldDecreaseX_WhenXGreaterThanZero()
        {
            var position = new Position(1, 1);
            var result = position.MoveUp();
            Assert.IsTrue(result);
            Assert.AreEqual(0, position.X);
        }

        [Test]
        public void MoveUp_ShouldFail_WhenXIsZero()
        {
            var position = new Position(0, 1);
            var result = position.MoveUp();
            Assert.IsFalse(result);
        }

        [Test]
        public void MoveDown_ShouldIncreaseX_WhenXSmallerSizeMinusOne()
        {
            var position = new Position(2, 1);
            var result = position.MoveDown(size);
            Assert.IsTrue(result);
            Assert.AreEqual(3, position.X);
        }

        [Test]
        public void MoveDown_ShouldFail_WhenXIsSizeMinusOne()
        {
            var position = new Position(3, 1);
            var result = position.MoveDown(size);
            Assert.IsFalse(result);
        }

        [Test]
        public void MoveLeft_ShouldDecreaseY_WhenYGreaterThanZero()
        {
            var position = new Position(1, 1);
            var result = position.MoveLeft();
            Assert.IsTrue(result);
            Assert.AreEqual(0, position.Y);
        }

        [Test]
        public void MoveLeft_ShouldFail_WhenYIsZero()
        {
            var position = new Position(1, 0);
            var result = position.MoveLeft();
            Assert.IsFalse(result);
        }

        [Test]
        public void MoveRight_ShouldIncreaseY_WhenYSmallerSizeMinusOne()
        {
            var position = new Position(3, 2);
            var result = position.MoveRight(size);
            Assert.IsTrue(result);
            Assert.AreEqual(3, position.Y);
        }

        [Test]
        public void MoveRight_ShouldFail_WhenYIsEqualSizeMinusOne()
        {
            var position = new Position(1, 3);
            var result = position.MoveRight(size);
            Assert.IsFalse(result);
        }

    }
}