using System;

namespace MarsRoverChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
        private static (Position, List<(Position, List<RoverInstruction>)>) parseData(string data)
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
