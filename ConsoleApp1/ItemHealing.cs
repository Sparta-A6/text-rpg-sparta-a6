using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class ItemHealing
    {
        UseItem useItem = new UseItem("-", "-", false, 0, 0, 0, 0, 0);
        public void UsedItem()
        {
            Console.WriteLine("-----------------------------------------------------\n");
            int scriptCount = useItem.UseItemInHaveScript();

            while(true)
            {
                if(scriptCount == 0)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    ColorChange.ColorWriteLine(12, " 소모할 아이템이 없습니다.");
                    Console.WriteLine("-----------------------------------------------------");
                    Console.ReadLine();
                    break;
                }
                Console.WriteLine("-----------------------------------------------------");
                ColorChange.ColorWriteLine(9, " 사용할 아이템을 선택해주세요.");
                Console.WriteLine("-----------------------------------------------------");

                int choice;
                bool isCan = int.TryParse(Console.ReadLine(), out choice);

                if ((isCan)&& (choice <= scriptCount))
                {
                    UseItem.UseItemHaveCount(choice);

                    if (DefaultScript.IsUsed == true)
                    {
                        Player.PlusHp(DefaultScript.ItemHP);
                        Console.WriteLine("-----------------------------------------------------\n");
                        ColorChange.ColorWriteLine(10, $" {DefaultScript.ItemName}을(를) 사용했습니다. ");
                        ColorChange.ColorWriteLine(10, $"현재 체력 {Player.currenthealth} / 100 \n");
                        Console.WriteLine("-----------------------------------------------------");
                        DefaultScript.IsUsed = false;
                        Console.ReadLine();
                        break;
                    }
                }
                else if (choice > scriptCount)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    ColorChange.ColorWriteLine(12, " 올바른 값을 입력해주십시오.");
                    Console.WriteLine("-----------------------------------------------------");
                    Console.ReadLine();
                }

            }


        }
    }
}
