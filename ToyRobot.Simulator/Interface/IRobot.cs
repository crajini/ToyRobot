using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Simulator.Behaviour;

namespace ToyRobot.Simulator.Interface
{
    public interface IRobot
    {
        Direction Direction { get; set; }
        Position Position { get; set; }

        /// <summary>
        /// to process the place command
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        void Place(Position position, Direction direction);
        /// <summary>
        /// to get next position of move
        /// </summary>
        /// <returns></returns>
        Position GetNextPosition();     
        /// <summary>
        /// rotate the toy left or right
        /// </summary>
        /// <param name="rotationNumber"></param>
        void Rotate(int rotationNumber);
    }
}
