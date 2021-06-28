using NUnit.Framework;
using ToyRobot.Simulator;
using ToyRobot.Simulator.Behaviour;
using ToyRobot.Simulator.CommandReceiver;
using ToyRobot.Simulator.Interface;

namespace ToyRobot.Test
{
    [TestFixture]
    public class ProcessorTest
    {
        private IBoard _board;
        private IInputParser _inputParser;
        private IRobot _robot;

        [SetUp]
        public void SetUp()
        {
            _board = new Board(6, 6);
            _inputParser = new InputParser();
            _robot = new Robot();
        }

        [Test]
        public void ProcessValidPlaceCommand()
        {
            //assign
            var processor = new Processor(_robot, _board, _inputParser);
            var inputCommand = "PLACE 2,1,WEST".Split(' ');

            //act
            processor.ProcessCommand(inputCommand);

            //assert
            Assert.AreEqual(2, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.WEST, _robot.Direction);
        }

        [Test]
        public void ProcessValidMoveCommand()
        {
            //assign
            var processor = new Processor(_robot, _board, _inputParser);
            var inputCommand = "MOVE".Split(' ');
            var inputPlaceCommand = "PLACE 2,1,WEST".Split(' ');

            //act
            processor.ProcessCommand(inputPlaceCommand);
            processor.ProcessCommand(inputCommand);

            //assert
            Assert.AreEqual(1, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.WEST, _robot.Direction);
        }

        [Test]
        public void ProcessValidRightCommand()
        {
            //assign
            var processor = new Processor(_robot, _board, _inputParser);
            var inputCommand = "RIGHT".Split(' ');
            var inputPlaceCommand = "PLACE 2,1,WEST".Split(' ');

            //act
            processor.ProcessCommand(inputPlaceCommand);
            processor.ProcessCommand(inputCommand);

            //assert
            Assert.AreEqual(2, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.NORTH, _robot.Direction);
        }

        [Test]
        public void ProcessValidLeftCommand()
        {
            //assign
            var processor = new Processor(_robot, _board, _inputParser);
            var inputCommand = "LEFT".Split(' ');
            var inputPlaceCommand = "PLACE 2,1,WEST".Split(' ');

            //act
            processor.ProcessCommand(inputPlaceCommand);
            processor.ProcessCommand(inputCommand);

            //assert
            Assert.AreEqual(2, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.SOUTH, _robot.Direction);
        }

        [Test]
        public void ProcessValidReportCommand()
        {
            //assign
            var processor = new Processor(_robot, _board, _inputParser);
            var inputPlaceCommand = "PLACE 2,1,WEST".Split(' ');

            //act
            processor.ProcessCommand(inputPlaceCommand);
            var report = processor.GetReport();

            //assert
            Assert.AreEqual("Output: 2,1,WEST", report);
        }
    }
}
