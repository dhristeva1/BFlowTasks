using System;
using System.Linq;

namespace SubsequentArray
{
	public class Program
	{
		public static bool IsValidSubsequence(int[] array, int[] sequence, bool adjacent)
		{
			int sequenceIndex = 0;

			for (int arrayIndex = 0; arrayIndex < array.Length; arrayIndex++)
			{
				if (sequence.Length > array.Length)
				{
					return false;
				}
				int curNum = array[arrayIndex];

				if (adjacent && sequence[sequenceIndex] == curNum)
				{
					for (sequenceIndex = 0; sequenceIndex < sequence.Length; sequenceIndex++)
					{
						//Checks if array index is out of range
						if (arrayIndex + sequenceIndex >= array.Length)
						{
							return false;
						}
						int arrayNum = array[arrayIndex + sequenceIndex];
						int sequenceNum = sequence[sequenceIndex];
						//Compares both values to determine if they are equal
						if (arrayNum != sequenceNum)
						{
							return false;
						}
					}
					return true;
				}

				if (sequence[sequenceIndex] == curNum)
				{
					sequenceIndex++;
				}
				if (sequenceIndex == sequence.Length)
				{
					return true;
				}
			}
			return false;
		}

		public static void Main()
		{
			Console.WriteLine("Enter array: \n Example:  5,1,22,25,6,-1,8,10 ");
			Console.WriteLine("   ----------------");

			int[] array = Console.ReadLine().Split(',').Select(num => int.Parse(num)).ToArray(); ;

			Console.WriteLine();
			Console.WriteLine("Enter sequence to check: \n Example: \n 1,6,-1,10 or 1,6,-1,10,adjacent ");
			Console.WriteLine("   ----------------");

			string[] sequenceInput = Console.ReadLine().Split(',').ToArray();
			int[] sequence = new int[] { };
			bool adjacent = sequenceInput[sequenceInput.Length - 1] == "adjacent" ? true : false;

			//Removes last element from sequence input if adjacent is provided
			if (adjacent)
			{
				sequenceInput = sequenceInput.Take(sequenceInput.Length - 1).ToArray();
			}
			sequence = sequenceInput.Select(num => int.Parse(num)).ToArray();

			Console.WriteLine(IsValidSubsequence(array, sequence, adjacent));
		}
	}
}
