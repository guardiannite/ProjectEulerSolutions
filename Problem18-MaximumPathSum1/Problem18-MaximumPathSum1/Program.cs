using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Problem18_MaximumPathSum1
{
    class Program
    {
        static void Main(string[] args)
        {
            string error;
            string file;
            int solution;

            Console.WriteLine("Choose a problem to solve.");
            Console.WriteLine("  18 - Problem 18");
            Console.WriteLine("  67 - Problem 67");
            var input = Console.ReadLine();

            if (String.Equals("18", input, StringComparison.InvariantCultureIgnoreCase))
            {
                file = "problem18_triangle.txt";
            }
            else if (String.Equals("67", input, StringComparison.InvariantCultureIgnoreCase))
            {
                file = "problem67_triangle.txt";
            }
            else
            {
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Calculating the maximum path total for this file:");
            Console.WriteLine(file);

            var sw = Stopwatch.StartNew();
            if (!ExecuteSolution(file, out error, out solution))
            {
                Console.WriteLine(error);
            }
            sw.Stop();

            Console.WriteLine("Solution is: {0}", solution);
            Console.WriteLine("Took {0} ms to execute", sw.ElapsedMilliseconds);
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

        static public bool ExecuteSolution(string filename, out string errorMessage, out int solution)
        {
            errorMessage = "";
            solution = 0;
            string currentDir = Directory.GetCurrentDirectory();
            string path = Path.Combine(currentDir, filename);

            while(!File.Exists(path))
            {
                errorMessage += "Unable to find file at " + path + Environment.NewLine;
                var parent = Directory.GetParent(currentDir);
                if(parent == null)
                {
                    break;
                }
                currentDir = parent.FullName;
                
                path = Path.Combine(currentDir, filename);
            }
            if(!File.Exists(path))
            {
                errorMessage += "Unable to find file at " + path;
                return false;
            }
            var lines = File.ReadAllLines(path);
            int[] maximumPathSum = new int[lines.Length+1];
            for (int lineNum = lines.Length-1; lineNum >= 0; lineNum-- )
            {
                var line = lines[lineNum];
                var numbersInLine = line.Split(' ');
                var numbers = Array.ConvertAll<string, int>(numbersInLine, int.Parse);
                maximumPathSum = FindRowDecision(maximumPathSum, numbers);
            }
            errorMessage = "";
            solution = maximumPathSum[0];
            return true;
        }

        /// <summary>
        /// Finds the maximum path of of the current row
        /// </summary>
        /// <param name="currRowSum">Sum of the best path at the current node and below</param>
        /// <param name="nextRow">Row of numbers directly above the current row.</param>
        /// <returns>Sum of the maximum paths below the current row, but also includes this row</returns>
        /// Example:
        ///      currRowSum   =   35    9    22    66   42
        ///      nextRow      =      17   29    73    32
        /// The result:
        ///      higherRowSum = (35+17) (22+29) (66+73) (66+32)
        static public int[] FindRowDecision(int[] currRowSum, int[] nextRow)
        {
            //This is the row directly above the one we're looking at
            var nextRowSum = new int[nextRow.Length];

            for (int i = 0; i < currRowSum.Length - 1; i++)
            {
                if (currRowSum[i] > currRowSum[i + 1])
                {
                    //Number on left is greater than right
                    nextRowSum[i] = currRowSum[i] + nextRow[i];
                }
                else
                {
                    //Number on right is greater than the left
                    nextRowSum[i] = currRowSum[i + 1] + nextRow[i];
                }
            }
            return nextRowSum;
        }
    }
}
