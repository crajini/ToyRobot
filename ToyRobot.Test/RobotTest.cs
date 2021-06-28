using NUnit.Framework;
using ToyRobot.Simulator.Behaviour;

namespace ToyRobot.Simulator.Test
{
    [TestFixture]
    public class RobotTest
    {
        [Test]
        public void ValidNorthMove()
        {
            //assign
            var robot = new Robot { Direction = Direction.NORTH, Position = new Position(1, 3) };

            //act
            var position = robot.GetNextPosition();

            //assert
            Assert.AreEqual(1, position.X);
            Assert.AreEqual(4, position.Y);
            Assert.AreEqual(Direction.NORTH, robot.Direction);
        }

        [Test]
        public void ValidSouthMove()
        {
            //assign
            var robot = new Robot { Direction = Direction.SOUTH, Position = new Position(2, 3) };

            //act
            var position = robot.GetNextPosition();

            //assert
            Assert.AreEqual(2, position.X);
            Assert.AreEqual(2, position.Y);
            Assert.AreEqual(Direction.SOUTH, robot.Direction);
        }

        [Test]
        public void ValidEastMove()
        {
            //assign
            var robot = new Robot { Direction = Direction.EAST, Position = new Position(2, 3) };

            //act
            var position = robot.GetNextPosition();

            //assert
            Assert.AreEqual(3, position.X);
            Assert.AreEqual(3, position.Y);
            Assert.AreEqual(Direction.EAST, robot.Direction);
        }

        [Test]
        public void ValidWestMove()
        {
            //assign
            var robot = new Robot { Direction = Direction.WEST, Position = new Position(2, 3) };

            //act
            var position = robot.GetNextPosition();

            //assert
            Assert.AreEqual(1, position.X);
            Assert.AreEqual(3, position.Y);
            Assert.AreEqual(Direction.WEST, robot.Direction);
        }

        [Test]
        public void RotateLeft()
        {
            //assign
            var robot = new Robot { Direction = Direction.WEST, Position = new Position(2, 3) };

            //act
            robot.Rotate(-1);

            //assert
            Assert.AreEqual(Direction.SOUTH, robot.Direction);
            Assert.AreEqual(2, robot.Position.X);
            Assert.AreEqual(3, robot.Position.Y);
        }

        [Test]
        public void ValidRotateRight()
        {
            //assign
            var robot = new Robot { Direction = Direction.WEST, Position = new Position(2, 3) };

            //act
            robot.Rotate(1);

            //assert
            Assert.AreEqual(Direction.NORTH, robot.Direction);
            Assert.AreEqual(2, robot.Position.X);
            Assert.AreEqual(3, robot.Position.Y);
        }

        [Test]
        public void ValidPlaceAndDirection()
        {
            //assign
            var robot = new Robot();
            var possition = new Position(1, 3);

            //act
            robot.Place(possition, Direction.SOUTH);

            //assert
            Assert.AreEqual(Direction.SOUTH, robot.Direction);
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(3, robot.Position.Y);
        }
    }
}
