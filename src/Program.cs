using System;
using System.Collections.Generic;
using turtle_mine.Entities;

namespace turtle_mine
{
    class Program
    {
        static void Main(string[] args)
        {
            //I'm not using interfaces here because an abstraction is not neccessary
            //Even on tests, i want to test the implementation, not the contract
            var (board, turtle, movements) = ParseInput(args);
            var game = new Game(board, turtle, movements);

            Console.WriteLine(game.Run().ToString());
        }

        static (Board board, Turtle turtle, IEnumerable<Movement> movements) ParseInput(string[] args)
        {
            if (args.Length < 5)
                throw new ArgumentException("The amount of arguments provided is less than 5.");

            var boardSize = args[0].ParseToIntTuple();
            var minePoints = args[1].ParseMinePoints();
            var exitPoint = args[2].ParseToIntTuple(separator: ' ').ToPoint();
            var turtle = args[3].ParseTurtle();
            var movements = args.ParseMovements();

            var board = new Board(boardSize.first, boardSize.second, exitPoint, minePoints);

            return (board, turtle, movements);
        }
    }
}
