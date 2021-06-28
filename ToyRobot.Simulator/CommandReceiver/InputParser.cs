using System;
using ToyRobot.Simulator.Behaviour;
using ToyRobot.Simulator.Interface;

namespace ToyRobot.Simulator.CommandReceiver
{
    public class InputParser : IInputParser
    {
        public Command ParseCommand(string[] rawInput)
        {
            Command command;
            if (!Enum.TryParse(rawInput[0], true, out command))
                return command;
            return command;
        }

        // Extracts the parameters from the user input and returns it       
        public PlaceCommandParameter ParseCommandParameter(string[] input, Direction currentDirection)
        {
            var thisPlaceCommandParameter = new CommandParameter();
            return thisPlaceCommandParameter.ParseParameters(input, currentDirection);
        }

        public bool IsValidInput(string[] input)
        {
            Direction direction;
            Command command;
            Enum.TryParse(input[0], true, out command);

            if (input.Length >= 2)
            {
                var commandParams = input[1].Split(',');
                //To ignore invalid commands
                if ((input.Length != 2 || commandParams.Length > 3 || commandParams.Length < 2) || (commandParams.Length == 3 && !Enum.TryParse(commandParams[commandParams.Length - 1], true, out direction)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
