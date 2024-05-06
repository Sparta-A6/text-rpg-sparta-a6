using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class WeaponItem
    {
        public static List<WeaponItem> items = new List<WeaponItem>();  // 기본 무기 아이템

        public WeaponItem(string name, String desc, bool isHave, bool isTake, int adstat, int dpstat, int price, int idx)
        {
            Name = name; // 아이템 이름
            Desc = desc; // 아이템 설명
            IsHave = isHave; // 변동되는 변수 : 가지고 있는가?
            IsTake = isTake;
            ADStat = adstat;
            DPStat = dpstat;
            Price = price;
            IDX = idx; // 공개 X 아이템 인덱스
        }
        public String Name { get; }
        public String Desc { get; }
        public bool IsHave { get; set; }
        public bool IsTake { get; set; }
        public int ADStat { get; }
        public int DPStat { get; }
        public int Price { get; }
        public int IDX { get; set; }

        // 무기 아이템



        bool[] itemishave;
        bool[] itemistake;

        int[] itemidx;

        public int count = 1;
        public int savecount = 0;
        public int foreachcount = 0;

        // 배열 사이즈 제작
        public void ArrSizeMake(int size)
        {
            itemishave = new bool[size];
            itemistake = new bool[size];
            itemidx = new int[size];

            for (int i = 0; i < size; i++)
            {
                itemishave[i] = false;
                itemistake[i] = false;
                itemidx[i] = i + 1;
            }
        }


        public static void ItemHaveInTrue(int choice, int mapNum) // 아이템을 구매 할 경우 True로 바꿔주는 함수
        {
            foreach (WeaponItem item in items)
            {
                if ((choice == item.IDX) && (Player.gold >= item.Price) && (mapNum == 13)) // 구매할 경우
                {
                    item.IsHave = !item.IsHave;
                    Player.gold -= item.Price;

                    DefaultScript.IsCanBuy = true;
                    DefaultScript.IsBuy = true;
                    DefaultScript.ItemName = item.Name;
                    DefaultScript.ItemPrice = item.Price;
                }
                else if ((choice == item.IDX) && (Player.gold < item.Price) && (mapNum == 13)) // 구매할 때 돈이 부족한 경우
                {
                    DefaultScript.IsCanBuy = false;
                }
                else if ((choice == item.IDX) && (mapNum == 23)) // 아이템을 판매할 경우 
                {
                    item.IsHave = !item.IsHave;
                    Player.gold += item.Price / 100 * 85;

                    DefaultScript.IsSell = true;
                    DefaultScript.ItemName = item.Name;
                    DefaultScript.ItemPrice = item.Price / 100 * 85;
                }
            }
        }
        public static void ItemTakeInTrue(int choice) // 아이템을 착용 할 경우 True로 바꿔주는 함수
        {
            foreach (WeaponItem item in items)
            {
                if (choice == item.IDX)
                {
                    item.IsTake = !item.IsTake;
                }
            }
        }
        public int WpItemInShopScript(int mapNum) // 상점 무기 아이템 스크립트 제작
        {
            if (mapNum == 23) // 아이템 판매 페이지
            {
                WpItemInHaveScript(mapNum);
                return 0;
            }

            if (mapNum == 13) // 아이템 구매 페이지
            {

                count = 1;

                foreach (WeaponItem item in items)
                {
                    if (item.IsHave == false)
                    {
                        item.IDX = count + savecount;
                        Console.Write(" " + count + ". ");  // 번호
                        Console.Write(item.Name);  // 이름
                        ItemSortScript.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                        Console.Write(item.Desc + "\n\t       | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat + " | ");  // 상세 정보
                        ColorChange.ColorWriteLine(6, item.Price + "G\n"); // 가격 + 색상 함수

                        if (count < 8)
                        {
                            count++;
                        }
                        else
                        {
                            savecount = count;
                            break;
                        }
                    }
                    else item.IDX = 0;
                }
                return count - 1;
            }

            else  // 상점 페이지
            {
                ColorChange.ColorWriteLine(8, "  ◀   [ 무기류 ]   ▶      \n");
                ColorChange.ColorWriteLine(8, "              \n");

                count = 1; // 아이템 인덱스에 넣어줄 변수 (항상 초기화)
                foreachcount = 0; // 아이템 스크립트 8회만 나오도록 카운트 하는 변수 (항상 초기화)
                if (items.Count <= savecount) savecount = 0; //만약 나와야 할 아이템이 더 없다면 = 다시 1부터 꺼내게 하는 초기화

                foreach (WeaponItem item in items)
                {
                    if(count <= savecount) //만약 아이템을 이전에 열어본 적이 있다면, 스크립트를 그만큼 건너뛰게 만듬
                    {
                        count++;
                        continue; // 8/16/24회 지나갈 때까지 돌아감.
                    }

                    item.IDX = count;
                    Console.Write("  - " + item.Name);  // 이름
                    ItemSortScript.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                    Console.Write(item.Desc + "\n\t       | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat + " | ");  // 상세 정보

                    if (item.IsHave == true)
                    {
                        ColorChange.ColorWriteLine(8, "구매완료\n"); // 구매완료
                    }
                    else
                    {
                        ColorChange.ColorWriteLine(6, item.Price + "G\n"); // 가격 + 색상 함수
                    }

                    foreachcount++; // foreach 돈 횟수++

                    if (foreachcount < 8) // 만약 아직 8번을 돌지 못했다면?
                    {
                        count++; // 다음 인덱스 번호로 넘어가기
                    }
                    else // 만약 8번 돌았다면?
                    {
                        break; // foreach문 종료
                    }
                }
                savecount = count; // 지금까지 돈 횟수 저장
                return 0;
            }


        }

        public void WpItemIsTakeScript() // 인벤토리 -  장착한 무기 아이템 스크립트 제작
        {
            Console.WriteLine(" [ 장착한 아이템 ]\n");
            Console.WriteLine(" [ 무기 ]");
            count = 1;
            foreach (WeaponItem item in items)
            {
                item.IDX = count;
                // 가지고 있는 아이템만 생성
                if ((item.IsHave == true) && (item.IsTake == true))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("  - " + item.Name);  // 이름
                    ItemSortScript.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                    Console.WriteLine(item.Desc + "\n\t       | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat + " | \n");  // 상세 정보
                    Console.ForegroundColor = ConsoleColor.Black;
                    count++;
                }
            }
        }
        public int WpItemInHaveScript(int mapNum) //  아이템 장착, 상점 판매 - 소유한 장비 아이템 스크립트 제작
        {
            Console.WriteLine(" [ 무기 아이템 ]\n");
            
            if (mapNum == 12) // 인벤토리 장착 페이지
            {
                count = 1;
                foreach (WeaponItem item in items)
                {
                    if (item.IsHave == true) // 가지고 있는 아이템만 나오도록
                    {
                        item.IDX = count;

                        Console.Write(" " + count + ". ");

                        if (item.IsTake == true) // 아이템을 착용하고 있다면 E 표시
                        {
                            ColorChange.ColorWrite(10, item.Name);  // 이름
                            ItemSortScript.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                            Console.Write(item.Desc);
                            ColorChange.ColorWrite(10, " [장착중 : 무기] ");
                        }
                        else
                        {
                            Console.Write(item.Name);  // 이름
                            ItemSortScript.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                            Console.Write(item.Desc);
                            Console.Write("     ");
                        }

                        Console.WriteLine("\n\t       | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat + " | \n");  // 상세 정보
                        count++;
                    }
                }
                return count - 1;
            }
            else // 상점 판매 페이지
            {
                count = 1; 
                foreachcount = 0; 
                if (items.Count <= savecount) savecount = 0; 

                foreach (WeaponItem item in items)               
                {
                    if (count <= savecount) 
                    {
                        count++;
                        continue; 
                    }

                    if (item.IsHave == true) // 가지고 있는 아이템만 나오도록
                    {
                        item.IDX = count;
                        Console.Write(" " + count + ". ");  // 번호
                        Console.Write(item.Name);  // 이름
                        ItemSortScript.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                        Console.Write(item.Desc + "\n\t       | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat + " | ");  // 상세 정보
                        ColorChange.ColorWriteLine(12, (item.Price / 100 * 85) + "G (85%)\n"); // 가격 + 색상 함수
                        foreachcount++;
                    }
                    else item.IDX = 0;

                    if (foreachcount < 8) count++;
                    else break;
                   
                }
                savecount = count; // 지금까지 돈 횟수 저장
                return count - 1;
            }
        }

        


        // 초기설정 : 무기 아이템 상점 리스트에 집어넣기
        public void WpItemInShopList(string name, int ad, int dp, int price, string desc, int num)
        {
            items.Add(new WeaponItem(name, desc, itemishave[num], itemistake[num], ad, dp, price, itemidx[num]));

        } 
    }
}
