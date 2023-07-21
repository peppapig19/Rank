using System;
using System.Collections.Generic;
using System.Linq;

namespace Rank
{
	internal class Program
	{
		static double[] Rank(double[] arr)
		{
			var duplicates = new Dictionary<double, List<double>>();
			double[] ranks = new double[arr.Length];

			for (int i = 0; i < arr.Length; i++)
			{
				double rank = 1;

				for (int j = 0; j < arr.Length; j++)
				{
					if (arr[i] > arr[j]) rank++;
					else if (i > j && arr[i] == arr[j])
					{
						if (duplicates.ContainsKey(arr[i]) && duplicates[arr[i]].Contains(ranks[j]))
						{
							rank++;
							continue;
						}

						rank = ranks[j] + 1;

						duplicates.Add(arr[i], new List<double>());
						duplicates[arr[i]].Add(ranks[j]);
						break;
					}
				}

				ranks[i] = rank;
				if (duplicates.ContainsKey(arr[i])) duplicates[arr[i]].Add(rank);
			}

			for (int i = 0; i < arr.Length; i++)
			{
				if (duplicates.ContainsKey(arr[i])) ranks[i] = duplicates[arr[i]].Average();
			}

			return ranks;
		}

		static void Main(string[] args)
		{
			double[] arr = { 2, 3, 1, 3, 4, 5 };
			double[] ranks = Rank(arr);

			Console.WriteLine("Numbers: " + string.Join(", ", arr));
			Console.WriteLine("Ranks: " + string.Join(", ", ranks));
			Console.ReadKey();
		}
	}
}