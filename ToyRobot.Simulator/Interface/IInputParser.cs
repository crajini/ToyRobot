using ToyRobot.Simulator.Behaviour;
using ToyRobot.Simulator.CommandReceiver;

namespace ToyRobot.Simulator.Interface
{
    public interface IInputParser
    {
        /// <summary>
        /// to parse the input command
        /// </summary>
        /// <param name="rawInput"></param>
        /// <returns></returns>
        Command ParseCommand(string[] rawInput);
        /// <summary>
        /// to parse the input parameters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        PlaceCommandParameter ParseCommandParameter(string[] input, Direction currentDirection);
        /// <summary>
        /// to validate user's input format
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        bool IsValidInput(string[] input);
    }
}
