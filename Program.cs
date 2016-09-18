using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LockerRiddle
{
	public class Program
	{
		public static void Main(string[] args)
		{
			const int numLockers = 100;
			const int numHeirs = 100;

			var sw = Stopwatch.StartNew();
			var lockers = new Locker[numLockers];
			for (var i = 0; i < numLockers; i++)
			{
				lockers[i] = new Locker { Open = false };
			}
			Console.WriteLine($"Populating lockers: [{sw.Elapsed}]");
			// PrintLockerStates(lockers);

			sw.Restart();
			var runningModulo = 1;
			for (var heir = 1; heir <= numHeirs; heir++)
			{
				for (var i = 1; i <= numLockers; i++)
				{
					if ((i % runningModulo) == 0)
					{
						var locker = lockers[i - 1];
						locker.Toggle();
					}
				}
				runningModulo++;
				// Console.WriteLine($"\n\nAfter heir {heir}:");
				// PrintLockerStates(lockers);
			}
			Console.WriteLine($"Calculating lockers: [{sw.Elapsed}]");
			Console.WriteLine("Final results:");
			PrintLockerStates(lockers);
		}

		public static void PrintLockerStates(IEnumerable<Locker> lockers)
		{
			var count = 1;
			foreach (var locker in lockers)
			{
				Console.WriteLine($"Locker number {count++}:\t{locker}");
			}
		}
	}
}
