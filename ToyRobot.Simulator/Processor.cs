using System;
using ToyRobot.Simulator.Behaviour;
using ToyRobot.Simulator.Interface;

namespace ToyRobot.Simulator
{
    public class Processor
    {
        public readonly IRobot _robot;
        public readonly IBoard _board;
        public IInputParser _inputParser;

        public Processor(IRobot robot, IBoard board, IInputParser inputParser)
        {
            _robot = robot;
            _board = board;
            _inputParser = inputParser;
        }

        public string ProcessCommand(string[] input)
        {            
            var command = _inputParser.ParseCommand(input);
            if (command != Command.PLACE && _robot.Position == null) return string.Empty;

            switch (command)
            {
                case Command.PLACE:
                    if (_inputParser.IsValidInput(input))
                    {
                        var placeCommandParameter = _inputParser.ParseCommandParameter(input, _robot.Direction);
                        if (_board.IsValidPosition(placeCommandParameter.Position))
                            _robot.Place(placeCommandParameter.Position, placeCommandParameter.Direction);
                    }
                    break;
                case Command.MOVE:
                    var newPosition = _robot.GetNextPosition();
                    if (_board.IsValidPosition(newPosition))
                        _robot.Position = newPosition;
                    break;
                case Command.LEFT:
                    _robot.Rotate(-1);
                    break;
                case Command.RIGHT:
                    _robot.Rotate(1);
                    break;
                case Command.REPORT:
                    return GetReport();
            }
            return string.Empty;
        }

        public string GetReport()
        {
            return string.Format("Output: {0},{1},{2}", _robot.Position.X,
                _robot.Position.Y, _robot.Direction.ToString().ToUpper());
        }
    }
}
