using NUnit.Framework;
using ToyRobot.Simulator.Behaviour;
using ToyRobot.Simulator.CommandReceiver;

namespace ToyRobot.Test
{
    [TestFixture]
    public class InputParserTest
    {
        [Test]
        public void ValidCommandChecker()
        {
            //assign
            var inputParser = new InputParser();
            var inputCommand = "PLACE 2,1,WEST".Split(' ');

            //act
            var result = inputParser.ParseCommand(inputCommand);

            //assert
            Assert.AreEqual(Command.PLACE, result);
        }

        [Test]
        public void ValidParseCommand()
        {
            //assign
            var inputParser = new InputParser();
            var inputCommand = "PLACE 2,1,WEST".Split(' ');

            //act
            var result = inputParser.ParseCommandParameter(inputCommand, Direction.WEST);

            //assert
            Assert.AreEqual(Direction.WEST, result.Direction);
            Assert.AreEqual(2, result.Position.X);
            Assert.AreEqual(1, result.Position.Y);
        }

        [Test]
        public void ValidInputCommand()
        {
            //assign
            var inputParser = new InputParser();
            var inputCommand = "PLACE 2,1,WEST".Split(' ');

            //act
            bool result = inputParser.IsValidInput(inputCommand);

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void InValidInputCommand()
        {
            //assign
            var inputParser = new InputParser();
            var inputCommand = "PLACE 2".Split(' ');

            //act
            bool result = inputParser.IsValidInput(inputCommand);

            //assert
            Assert.IsFalse(result);
        }
    }
}
