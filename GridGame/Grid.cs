using System;

namespace GridGame
{
	public class Grid
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public Cell[,] State { get; set; }

		public Grid(int width, int height)
		{
			this.Width = width;
			this.Height = height;
			this.State = new Cell[width, height];
		}
		public void BuildState()
		{
			for (int row = 0; row < this.Height; row++)
			{
				string line = Console.ReadLine();
				for (int col = 0; col < line.Length; col++)
				{
					this.State[row, col] = new Cell(col, row, int.Parse(line[col].ToString()));
				}
			}
		}

		// In order to avoid mixing states of cells, first every cell's NewState is calculated, based on the whole grid's
		// current state, after that is done for all of the cells we update their CurrentState to NewState
		public void UpdateState()
		{
			for (int row = 0; row < this.Height; row++)
			{
				for (int col = 0; col < this.Width; col++)
				{
					this.State[row, col].CalculateNewState(this);
				}
			}
			for (int row = 0; row < this.Height; row++)
			{
				for (int col = 0; col < this.Width; col++)
				{
					this.State[row, col].UpdateState();
				}
			}
		}
	}
}