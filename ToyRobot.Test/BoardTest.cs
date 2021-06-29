using NUnit.Framework;
using ToyRobot.Simulator.Behaviour;

namespace ToyRobot.Simulator.Test
{
    [TestFixture]
    public class BoardTest
    {
        [TestCase(2,1,ExpectedResult =true, Description ="To test the valid position")]
        [TestCase(6, 8, ExpectedResult = false,Description = "To test the invalid position")]
        public bool TestPosition(int x, int y)
        {
            //arrange
            var boad = new Board(6, 6);
            var position = new Position(x, y);

            //act
            return boad.IsValidPosition(position);

            //assert
        }       
    }
}