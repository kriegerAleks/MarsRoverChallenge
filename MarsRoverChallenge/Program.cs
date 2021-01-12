using MarsRoverChallenge.Rover;
using MarsRoverChallenge.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using static MarsRoverChallenge.Rover.RoverInstructions;

namespace MarsRoverChallenge
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Running Default Test For Simulation");
            var commandList = new string[] { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };
            var testInput = String.Join(Environment.NewLine, commandList);

            var (boundPosition, roverList) = parseData(testInput);

            runASimulation(boundPosition, roverList);
        }

        public static void runASimulation(Position boundPosition, List<(Position, List<RoverInstruction>)> roverList)
        {
            var sim = new DefaultSimulation(boundPosition);
            foreach (var rover in roverList)
            {
                var (startPosition, instructionList) = rover;
                sim.addRover(startPosition, instructionList.ToArray());
            }
            Console.WriteLine("Added rovers to simulation");
            var results = sim.runSimulation();
            Console.WriteLine("simulation successfully run. Results:");
            results.ForEach(resultantPosition => Console.WriteLine(resultantPosition));

            Console.WriteLine("Results Finished");
        }

        public static (Position, List<(Position, List<RoverInstruction>)>) parseData(string data)
        {
            var lines = data.Split(Environment.NewLine);

            var boundryLine = lines[0];

            var boundrySpec = boundryLine.Split(' ');

            var boundryPoint = new Position(int.Parse(boundrySpec[0]), int.Parse(boundrySpec[1]));

            var itemList = new List<(Position, List<RoverInstruction>)>();

            int offset = 1;
            for (var currentItemIndex = offset; currentItemIndex < lines.Length; currentItemIndex += 2)
            {
                var roverDetails = lines[currentItemIndex].Split(' ');
                var x = int.Parse(roverDetails[0]);
                var y = int.Parse(roverDetails[1]);
                var direction = Directions.convertToDirection(roverDetails[2][0]);

                var position = new Position(x, y, direction);

                var instructionList = lines[currentItemIndex + 1].Select(command => ConvertValueToInstruction(command)).ToList();

                itemList.Add((position, instructionList));
            }

            return (boundryPoint, itemList);
        }
    }
}