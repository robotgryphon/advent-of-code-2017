using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace day_6 {

    class Program {


        // Represents the previously-visited stacks
        static HashSet<int[]> hashes = new HashSet<int[]>();

        static int stackSize;

        static void Main(string[] args) {

            // Task<String> t = File.ReadAllTextAsync(Path.Combine(Environment.CurrentDirectory, "input.txt"));
            // String data = t.Result;

            // Get initial column set and hash code
            // int[] currentStacks = Array.ConvertAll(data.Split("\t"), x => int.Parse(x));
            int[] currentStacks = { 0, 2, 7, 0 };

            stackSize = currentStacks.Length - 1;
            hashes.Add(currentStacks);

            bool duplicate = false;
            while(!duplicate) {          
                int largestIndex = FindLargestStack(currentStacks);
                OutputStacks(largestIndex, currentStacks);

                int[] newStacks = RedistributeStack(largestIndex, currentStacks);

                // Overwrite old stacks
                currentStacks = newStacks;
                String currentHash = GenerateHash(currentStacks);
                duplicate = !hashes.Add(currentHash);
            }

            Console.WriteLine(hashes.Count);
        }

        static String GenerateHash(int[] stacks) {
            String hash = "";
            
            return hash;
        }
        
        static void OutputStacks(int highlightLargest, int[] stacks) {
            bool firstRun = true;
            foreach(int stack in stacks) {
                ConsoleColor oc = ConsoleColor.White;
                if(stacks[highlightLargest] == stack) oc = ConsoleColor.Green;
                Console.ForegroundColor = oc;
                Console.Write("{1}{0}", stack, firstRun ? "" : "\t");
                Console.ForegroundColor = ConsoleColor.White;
                if(firstRun) firstRun = false;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\t" + stacks.GetHashCode());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static int FindLargestStack(int[] stacks) {
            int index = 0;
            int largestIndex = 0;
            for(; index < stacks.Length; index++) {
                if(stacks[index] > stacks[largestIndex]) largestIndex = index;
            }

            return largestIndex;
        }

        static int GetNextStack(int currentStack) {
            return currentStack + 1 > stackSize ? 0 : currentStack + 1;
        }

        static int[] RedistributeStack(int stack, int[] stacks, int modifier = 1) {
            int currentStack = GetNextStack(stack);
            int remaining = stacks[stack];
            
            int[] newStacks = new int[stacks.Length];
            stacks.CopyTo(newStacks, 0);
            newStacks[stack] = 0;

            while(remaining > 0) {
                int deducted = remaining - modifier > 1 ? modifier : 1;
                newStacks[currentStack] += deducted;
                remaining -= deducted;

                currentStack = GetNextStack(currentStack);
            }

            return newStacks;
        }
    }
}
