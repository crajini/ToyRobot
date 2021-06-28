using System;
using ToyRobot.Simulator.Behaviour;

namespace ToyRobot.Simulator.CommandReceiver
{
    public class PlaceCommandParameter
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        public PlaceCommandParameter(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }
    }

    public class CommandParameter
    {
        private const int ParameterCount = 3;

        private const int CommandInputCount = 2;

        public PlaceCommandParameter ParseParameters(string[] input, Direction currentDirection)
        {
            Direction direction;
            Position position = null;
            if (input.Length >= 2)
            {
                var commandParams = input[1].Split(',');
                if (commandParams.Length == 2)
                    direction = currentDirection;
                else
                    Enum.TryParse(commandParams[commandParams.Length - 1], true, out direction);

                var x = Convert.ToInt32(commandParams[0]);
                var y = Convert.ToInt32(commandParams[1]);
                position = new Position(x, y);
                return new PlaceCommandParameter(position, direction);
            }
            return new PlaceCommandParameter(position, currentDirection);
        }
    }
}
