using ToyRobot.Simulator.Interface;

namespace ToyRobot.Simulator.Behaviour
{
    public class Board :IBoard
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Board(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        public bool IsValidPosition(Position position)
        {
            if (position == null) return false; 
            return position.X < Columns && position.X >= 0 &&
                   position.Y < Rows && position.Y >= 0;
        }
    }
}
