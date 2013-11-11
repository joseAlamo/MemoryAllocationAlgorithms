using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorstFit
{
    class Program
    {
        static void Main(string[] args)
        {
            Block[] pool = new Block[5];
            pool[0] = new Block(9);
            pool[1] = new Block(300);
            pool[2] = new Block(30);
            pool[3] = new Block(1000);
            pool[4] = new Block(10);
            while (true)
            {
                Console.WriteLine("Enter the amount of memory needed: ");
                uint amount = uint.Parse(Console.ReadLine());
                Search(amount, pool);
            }
        }

        static void Search(uint memoryNeeded, Block[] pool)
        {
            uint difference = (uint)pool[0].Size - memoryNeeded;
            uint position = 0;
            for (uint i = 0; i < pool.Length; i++)
            {
                if (pool[i].Size - memoryNeeded >= difference && pool[i].Available)
                {
                    difference = (uint)pool[i].Size - memoryNeeded;
                    position = i;
                }
            }
            pool[position].Available = false;
            Console.WriteLine("Found empty size {0} space at {1} position, wasted memory: {2}", pool[position].Size, position, difference);
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
