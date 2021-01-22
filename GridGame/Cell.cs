using System;
using System.Linq;

namespace GridGame
{
	public class Cell
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int CurrentState { get; set; }
		public int NewState { get; set; }
		public int TimesPurple { get; set; }
		public Cell(int x, int y, int value)
		{
			this.X = x;
			this.Y = y;
			this.NewState = value;
			this.CurrentState = value;
			this.TimesPurple = value == 1 ? 1 : 0;
		}

		//Checks the surrounding cells' values
		public Tuple<int, int> CheckSurroundings(Grid grid, int cellCurrentState)
		{
			int sameColorSurrounding = 0;
			int oppositeColorSurrounding = 0;
			for (int y = this.Y - 1; y <= this.Y + 1; y++)
			{
				for (int x = this.X - 1; x <= this.X + 1; x++)
				{
					//Skips iteration because this would be comparison to itself				
					if (y == this.Y && x == this.X)
					{
						continue;
					}
					//Validates we are not out of index
					if (x < 0 || x > grid.Width - 1 || y < 0 || y > grid.Height - 1)
					{
						continue;
					}
					if (grid.State[y, x].CurrentState != cellCurrentState)
					{
						oppositeColorSurrounding++;
					}
					else
					{
						sameColorSurrounding++;
					}
				}
			}
			return Tuple.Create(sameColorSurrounding, oppositeColorSurrounding); ;
		}
		public void CalculateNewState(Grid grid)
		{
			Tuple<int, int> surroundings = this.CheckSurroundings(grid, this.CurrentState);
			int sameColorSurrounding = surroundings.Item1;
			int oppositeColorSurrounding = surroundings.Item2;
			if (this.CurrentState == 0)
			{
				int[] rule1 = new int[] { 3, 6 };
				int[] rule2 = new int[] { 0, 1, 2, 4, 5, 7, 8 };
				//Becomes Purple
				if (rule1.Contains(oppositeColorSurrounding))
				{
					this.NewState = 1;
					this.TimesPurple += 1;
				}
				//Becomes or stays Brown
				if (rule2.Contains(oppositeColorSurrounding))
				{
					this.NewState = 0;
				}
			}
			else
			{
				int[] rule3 = new int[] { 0, 1, 4, 5, 7, 8 };
				int[] rule4 = new int[] { 2, 3, 6 };
				//Becomes Brown
				if (rule3.Contains(sameColorSurrounding))
				{
					this.NewState = 0;
				}
				//Becomes or stays Purple
				if (rule4.Contains(sameColorSurrounding))
				{
					this.NewState = 1;
					this.TimesPurple += 1;
				}
			}
		}

		public void UpdateState()
		{
			this.CurrentState = this.NewState;
		}
	}
}

