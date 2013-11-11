using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFit
{
    class Program
    {
        static void Main(string[] args)
        {
            Block[] pool = new Block[5];
            pool[0] = new Block(9);
            pool[1] = new Block(20);
            pool[2] = new Block(20);
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
            for (int i = 0; i < pool.Length; i++)
            {
                if (memoryNeeded <= pool[i].Size && pool[i].Available)
                {
                    pool[i].Available = false;
                    Console.WriteLine("Found empty size {0} space at {1} position, wasted memory: {2}", pool[i].Size, i, (pool[i].Size - memoryNeeded));
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
