using System;
using ToyRobot.Simulator.Interface;

namespace ToyRobot.Simulator.Behaviour
{
    public class Robot : IRobot
    {
        public Direction Direction { get; set; }
        public Position Position { get; set; }

        public void Place(Position position, Direction direction)
        {
            this.Position = position;
            this.Direction = direction;
        }

        public Position GetNextPosition()
        {
            var newPosition = new Position(Position.X, Position.Y);
            switch (Direction)
            {
                case Direction.NORTH:
                    newPosition.Y = newPosition.Y + 1;
                    break;
                case Direction.EAST:
                    newPosition.X = newPosition.X + 1;
                    break;
                case Direction.SOUTH:
                    newPosition.Y = newPosition.Y - 1;
                    break;
                case Direction.WEST:
                    newPosition.X = newPosition.X - 1;
                    break;
            }
            return newPosition;
        }

        public void Rotate(int rotationNumber)
        {
            var directions = (Direction[])Enum.GetValues(typeof(Direction));
            Direction newDirection;
            if ((Direction + rotationNumber) < 0)
                newDirection = directions[directions.Length - 1];
            else
            {
                var index = ((int)(Direction + rotationNumber)) % directions.Length;
                newDirection = directions[index];
            }
            Direction = newDirection;
        }
    }
}
