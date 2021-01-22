using System;
using System.Collections.Generic;

namespace BFlowTasks
{
	public class Program
	{
		public static string FindDuplicates(string word)
		{
			IDictionary<char, int> duplicates = new Dictionary<char, int>();

			foreach (char letter in word)
			{
				//Checks if the dictionary already contains the character
				if (duplicates.ContainsKey(letter))
				{
					//Increments the count of the repeated character
					duplicates[letter] += 1;
				}
				else
				{
					//Adds a character that is not in the dictionary yet and has been repeated
					duplicates.Add(letter, 1);
				}
			}

			string result = "";

			foreach (KeyValuePair<char, int> kvp in duplicates)
			{
				if (kvp.Value > 1)
				{
					result += string.Format("'{0}' occurs {1} times,\n", kvp.Key, kvp.Value);
				}
			}

			if (result.Length > 0)
			{
				//Removes "," in last line of the result
				return result.ToString().Remove(result.Length - 2);
			}
			else
			{
				return "No duplicates";
			}
		}
		public static void Main()
		{
			Console.WriteLine("Enter word: ");

			//Converts input to lowercase and removes whitespeces
			string word = Console.ReadLine().ToLower().Replace(" ", string.Empty);

			string result = FindDuplicates(word);

			Console.WriteLine(result);
		}
	}
}
