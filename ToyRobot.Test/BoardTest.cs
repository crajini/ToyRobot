using NUnit.Framework;
using ToyRobot.Simulator.Behaviour;

namespace Tests
{
    [TestFixture]
    public class BoardTest
    {
        [Test]
        public void TestValidPosition()
        {
            //arrange
            var boad = new Board(6, 6);
            var position = new Position(2, 1);

            //act
            var result = boad.IsValidPosition(position);

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestInValidPosition()
        {
            //arrange
            var boad = new Board(1, 2);
            var position = new Position(7, 8);

            //act
            var result = boad.IsValidPosition(position);

            //assert
            Assert.IsFalse(result);
        }
    }
}