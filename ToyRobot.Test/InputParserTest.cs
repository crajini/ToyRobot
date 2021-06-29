using NUnit.Framework;
using ToyRobot.Simulator.Behaviour;
using ToyRobot.Simulator.CommandReceiver;

namespace ToyRobot.Simulator.Test
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

        [TestCase("PLACE 2,3,NORTH", ExpectedResult =true, Description ="")]
        [TestCase("PLACE 2", ExpectedResult = false, Description = "")]
        public bool ValidateInputCommand(string command)
        {
            //assign
            var inputParser = new InputParser();
            var inputCommand = command.Split(' ');

            //act
            return inputParser.IsValidInput(inputCommand);

            //assert
        }
    }
}
