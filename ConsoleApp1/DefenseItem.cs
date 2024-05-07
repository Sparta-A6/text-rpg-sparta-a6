using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class DefenseItem
    {
        public static List<DefenseItem> DpItem = new List<DefenseItem>();  // 방어 아이템
        public DefenseItem(string name, string desc, bool isHave, bool isTake, int adstat, int dpstat, int price, string set, int idx)
        {
            Name = name; // 아이템 이름
            Desc = desc; // 아이템 설명
            Set = set; // 아이템 종류
            IsHave = isHave; // 변동되는 변수 : 가지고 있는가?
            IsTake = isTake;
            ADStat = adstat;
            DPStat = dpstat;
            Price = price;
            IDX = idx; // 공개 X 아이템 인덱스
        }

        public string Name { get; }
        public string Desc { get; }
        public string Set { get; }
        public bool IsHave { get; set; }
        public bool IsTake { get; set; }
        public int ADStat { get; }
        public int DPStat { get; }
        public int Price { get; }
        public int IDX { get; set; }

        // 방어구 아이템

        bool[] itemishave;
        bool[] itemistake;

        int[] itemidx;
        public static string itemSet;

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
            foreach (DefenseItem item in DpItem)
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
            foreach (DefenseItem item in DpItem) // 장착할 아이템 찾아서 장착
            {
                if (choice == item.IDX)
                {
                    if (item.IsTake == true) Player.ItemDefense -= item.DPStat;
                    if (item.IsTake == false) Player.ItemDefense += item.DPStat;
                    item.IsTake = !item.IsTake;
                    itemSet = item.Set;
                }
            }

            foreach (DefenseItem item in DpItem) // 장착했던 아이템 찾아서 장착해제
            {
                if ((choice != item.IDX) && (itemSet == item.Set) && (item.IsTake == true))
                {
                    item.IsTake = !item.IsTake;
                    Player.ItemDefense -= item.DPStat;
                }
            }
        }

        public int DpItemInShopScript(int mapNum) // 상점 장비 아이템 스크립트 제작
        {
            if (mapNum == 23) // 아이템 판매 페이지
            {
                DpItemInHaveScript(mapNum);
                return 0;
            }

            if (mapNum == 13) // 아이템 구매 페이지
            {

                int count = 1;
                foreach (DefenseItem item in DpItem)
                {
                    if (item.IsHave == false)
                    {
                        item.IDX = count;
                        Console.Write(" " + count + ". ");  // 번호
                        Console.Write(item.Name);  // 이름
                        ItemSortScript.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                        Console.Write($"{item.Desc}\n  부위 [{item.Set}]  | 공격력 + {item.ADStat}  | 방어력 + {item.DPStat} | ");  // 상세 정보
                        ColorChange.ColorWriteLine(6, item.Price + "G\n"); // 가격 + 색상 함수
                        count++;
                    }
                    else item.IDX = 0;
                }
                return count - 1;
            }

            else  // 상점 페이지
            {
                ColorChange.ColorWriteLine(8, "  ◀   [ 방어구 ]   ▶      \n");

                int count = 1;
                foreach (DefenseItem item in DpItem)
                {
                    item.IDX = count;
                    Console.Write("  - " + item.Name);  // 이름
                    ItemSortScript.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                    Console.Write($"{item.Desc}\n  부위 [{item.Set}]  | 공격력 + {item.ADStat}  | 방어력 + {item.DPStat} | ");  // 상세 정보
                    if (item.IsHave == true)
                    {
                        ColorChange.ColorWriteLine(8, "구매완료\n"); // 구매완료
                    }
                    else
                    {
                        ColorChange.ColorWriteLine(6, item.Price + "G\n"); // 가격 + 색상 함수
                    }
                    count++;
                }
                return 0;
            }


        }

        public void DpItemIsTakeScript() // 인벤토리 -  장착한 방어구 아이템 스크립트 제작
        {
            Console.WriteLine(" [ 방어구 ] \n");
            int count = 1;
            foreach (DefenseItem item in DpItem)
            {
                item.IDX = count;
                // 가지고 있는 아이템만 생성
                if ((item.IsHave == true) && (item.IsTake == true))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write($"  - {item.Name}");  // 이름
                    ItemSortScript.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                    Console.WriteLine($"{item.Desc}\n  부위 [{item.Set}]  | 공격력 + {item.ADStat}  | 방어력 + {item.DPStat} | \n");  // 상세 정보
                    Console.ForegroundColor = ConsoleColor.Black;
                    count++;
                }
            }
        }
        public int DpItemInHaveScript(int mapNum) //  아이템 장착, 상점 판매 - 소유한 장비 아이템 스크립트 제작
        {
            Console.WriteLine(" [ 방어구 아이템 ]\n");

            if (mapNum == 12) // 인벤토리 장착 페이지
            {
                int count = 1;
                foreach (DefenseItem item in DpItem)
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
                            ColorChange.ColorWrite(10, $" [장착중 : {item.Set}] ");
                        }
                        else
                        {
                            Console.Write(item.Name);  // 이름
                            ItemSortScript.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                            Console.Write(item.Desc);
                            Console.Write("     ");
                        }

                        Console.WriteLine($"\n  부위 [{item.Set}]  | 공격력 + {item.ADStat}  | 방어력 + {item.DPStat} | \n");  // 상세 정보
                        count++;
                    }
                    else item.IDX = 0;
                }
                return count - 1;
            }
            else // 상점 판매 페이지
            {
                int count = 1;
                foreach (DefenseItem item in DpItem)
                {
                    item.IDX = count;
                    if (item.IsHave == true) // 가지고 있는 아이템만 나오도록
                    {
                        item.IDX = count;
                        Console.Write(" " + count + ". ");  // 번호
                        Console.Write(item.Name);  // 이름
                        ItemSortScript.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                        Console.Write($"{item.Desc}\n  부위 [{item.Set}]  | 공격력 + {item.ADStat}  | 방어력 + {item.DPStat} | ");  // 상세 정보
                        ColorChange.ColorWriteLine(12, (item.Price / 100 * 85) + "G (85%)\n"); // 가격 + 색상 함수
                        count++;
                    }
                    else item.IDX = 0;
                }
                return count - 1;
            }
        }

        // 초기설정 : 장비 아이템 상점 리스트에 집어넣기
        public void DpItemInShopList(string name, int ad, int dp, string set, int price, string desc, int num)
        {
            DpItem.Add(new DefenseItem(name, desc, itemishave[num], itemistake[num], ad, dp, price, set, itemidx[num]));

        }



    }
}
