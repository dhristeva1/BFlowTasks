using System;
using System.Linq;

namespace GridGame
{
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Enter grid width and height according to this format \"x,y\". \n Example: \n 3,3");
			Console.WriteLine("   ----------------");
			int[] size = Console.ReadLine().Split(',').Select(num => int.Parse(num)).ToArray();
			int x = size[0];
			int y = size[1];

			Grid grid = new Grid(x, y);

			Console.WriteLine("   ----------------");
			Console.WriteLine("Enter 0(represents Brown) or 1(represents Purple) for values of cells in the grid\n Example: \n 000\n 111\n 000");
			Console.WriteLine("   ----------------");

			grid.BuildState();

			Console.WriteLine("   ----------------");
			Console.WriteLine("Enter X, Y coordinates of cell and number of generations: \n Example: \n 1,0,10");
			Console.WriteLine("   ----------------");
			int[] args = Console.ReadLine().Split(',').Select(num => int.Parse(num)).ToArray();
			int coordinatesX = args[0];
			int coordinatesY = args[1];
			int n = args[2];

			for (int generation = 1; generation <= n; generation++)
			{
				grid.UpdateState();
			}

			Cell cell = grid.State[coordinatesY, coordinatesX];
			Console.WriteLine("   ----------------");
			Console.WriteLine();
			Console.WriteLine("Result: \n Cell({0}, {1}) has turned Purple: {2} times", coordinatesX, coordinatesY, cell.TimesPurple);
		}
	}
}
