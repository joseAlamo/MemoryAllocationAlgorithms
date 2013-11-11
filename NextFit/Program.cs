using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextFit
{
    class Program
    {
        static int previousFit = 0;
        static void Main(string[] args)
        {
            Block[] pool = new Block[5];
            pool[0] = new Block(9);
            pool[1] = new Block(20);
            pool[2] = new Block(30);
            pool[3] = new Block(20);
            pool[4] = new Block(20);
            while (true)
            {
                Console.WriteLine("Enter the amount of memory needed: ");
                int amount = int.Parse(Console.ReadLine());
                Search(amount, pool);
            }
        }

        static void Search(int memoryNeeded, Block[] pool)
        {
            if(previousFit==pool.Length-1)
                previousFit=0;
            for (int i = previousFit; i < pool.Length; i++)
            {
                if (pool[i].Size >= memoryNeeded && pool[i].Available)
                {
                    pool[i].Available = false;
                    Console.WriteLine("Found empty size {0} space at {1} position, wasted memory: {2}", pool[i].Size, i, (pool[i].Size - memoryNeeded));
                    previousFit = i;
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
