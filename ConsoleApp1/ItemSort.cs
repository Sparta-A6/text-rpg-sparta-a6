using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class ItemSortScript
    {
        public static void ItemSort(int i)
        {
            switch (i)
            {
                case 1:
                    Console.Write("          | ");
                    break;
                case 2:
                    Console.Write("         | ");
                    break;
                case 3:
                    Console.Write("       | ");
                    break;
                case 4:
                    Console.Write("     | ");
                    break;
                case 5:
                    Console.Write("   | ");
                    break;
                case 6:
                    Console.Write(" | ");
                    break;
                case 7:
                    Console.Write("| ");
                    break;
            }
        }
    }
}
