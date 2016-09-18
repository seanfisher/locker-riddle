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
            var lockers = InitializeLockers(numLockers);
            Console.WriteLine($"Initialized lockers: [{sw.Elapsed}]");
			Console.WriteLine("Starting locker state:");
            PrintLockerStates(lockers);

            sw.Restart();
            TransformLockers(numHeirs, lockers);
            Console.WriteLine($"Transforming lockers: [{sw.Elapsed}]");
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

        public static Locker[] InitializeLockers(uint numLockers)
        {
            var lockers = new Locker[numLockers];
            for (var i = 0; i < numLockers; i++)
            {
                lockers[i] = new Locker { Open = false };
            }
            return lockers;
        }

        public static void TransformLockers(uint numHeirs, Locker[] lockers)
        {
            var runningModulo = 1;
            for (var heir = 1; heir <= numHeirs; heir++)
            {
                for (var i = 1; i <= lockers.Length; i++)
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
        }
    }
}
