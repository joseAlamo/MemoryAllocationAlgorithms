using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFit
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<Block>> Pool = new List<List<Block>>();
            List<Block> Zeroes = new List<Block>();
            Zeroes.Add(new Block(10));
            Zeroes.Add(new Block(19));
            List<Block> Twenties = new List<Block>();
            Twenties.Add(new Block(20));
            Twenties.Add(new Block(25));
            Twenties.Add(new Block(30));
            List<Block> Forties = new List<Block>();
            Forties.Add(new Block(40));
            Forties.Add(new Block(50));
            Forties.Add(new Block(55));
            List<Block> Sixties = new List<Block>();
            Sixties.Add(new Block(60));
            Sixties.Add(new Block(70));
            List<Block> Eighties = new List<Block>();
            Eighties.Add(new Block(90));
            Pool.Add(Zeroes);
            Pool.Add(Twenties);
            Pool.Add(Forties);
            Pool.Add(Sixties);
            Pool.Add(Eighties);

            while (true)
            {
                Console.WriteLine("Enter the amount of memory needed: ");
                int amount = int.Parse(Console.ReadLine());
                Search(amount, Pool);
            }
        }

        public static void Search(int memoryNeeded, List<List<Block>> pool)
        {
            List<Block> currentQueue = new List<Block>();
            if(memoryNeeded>=80)
            {
                currentQueue = pool[4];
            }
            else if(memoryNeeded>=60)
            {
                currentQueue = pool[3];
            }
            else if(memoryNeeded>=40)
            {
                currentQueue = pool[2];
            }
            else if(memoryNeeded>=20)
            {
                currentQueue = pool[1];
            }
            else if(memoryNeeded>=0)
            {
                currentQueue = pool[0];
            }

            for (int i = 0; i < currentQueue.Count; i++)
            {
                if (memoryNeeded <= currentQueue[i].Size && currentQueue[i].Available)
                {
                    currentQueue[i].Available = false;
                    Console.WriteLine("Found empty size {0} space at {1} position, wasted memory: {2}", currentQueue[i].Size, i, (currentQueue[i].Size - memoryNeeded));
                    break;
                }
            }
        }
    }

    class Block
    {
        public bool Available { get; set; }
        public int Size { get; set; }

        public Block(int size)
        {
            Size = size;
            Available = true;
        }
    }
}
