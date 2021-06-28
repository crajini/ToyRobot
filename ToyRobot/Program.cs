using System;
using ToyRobot.Simulator;
using ToyRobot.Simulator.Behaviour;
using ToyRobot.Simulator.CommandReceiver;
using ToyRobot.Simulator.Interface;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ToyRobot!");
            IBoard squareBoard = new Board(6, 6);
            IInputParser inputParser = new InputParser();
            IRobot robot = new Robot();
            var simulator = new Processor(robot, squareBoard, inputParser);

            var stopApplication = false;
            do
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.Equals("EXIT"))
                    stopApplication = true;
                else
                {
                    try
                    {
                        var output = simulator.ProcessCommand(command.Split(' '));
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!stopApplication);
        }
    }
}
