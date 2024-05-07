using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class IfDied
    {
        public void IsDied()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
            ColorChange.ColorWrite(12, "\n 몸에서 이상한 변화가 느껴집니다...");
            Console.ReadKey();
            ColorChange.ColorWrite(12, "\n 모르는 사이에 감염이 된 모양입니다.");
            Console.ReadKey();
            ColorChange.ColorWrite(12, "\n 조금씩 눈이 감기고...");
            Console.ReadKey();
            ColorChange.ColorWrite(12, "\n 아무런 생각도 나지 않습니다...");
            Console.ReadKey();
            Console.WriteLine("\n-----------------------------------------------------");
            ColorChange.ColorWriteLine(12, " 좀비가 되었습니다.");
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
            ColorChange.ColorWriteLine(12, " 게임이 종료됩니다.");
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
