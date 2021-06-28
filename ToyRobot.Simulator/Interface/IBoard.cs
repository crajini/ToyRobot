using ToyRobot.Simulator.Behaviour;

namespace ToyRobot.Simulator.Interface
{
    public interface IBoard
    {
        /// <summary>
        /// to validate place command and position of toy on the table 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        bool IsValidPosition(Position position);
    }
}
