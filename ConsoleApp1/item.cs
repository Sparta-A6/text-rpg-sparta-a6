using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class Item
    {
        public static List<Item> items = new List<Item>();  // 기본 무기 아이템
        public static List<Item> DpItem = new List<Item>();  // 방어 아이템


        public Item(string name, String desc, bool isHave, bool isTake, int adstat, int dpstat, int price, int idx)
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

        string[] itemname = { "장갑", "목검", "후라이팬", "야구배트", "빠루", "식칼", "나이프", "소방도끼" };
        string[] itemdesc = {
            "맨주먹보단 낫습니다.",
            "무언가를 썰기보단 때리는 용도입니다.",
            "단단합니다.",
            "깡!",
            "어디서든 사용할 수 있습니다.",
            "무언가를 토막내기에는 이만한 것이 없습니다.",
            "가볍고, 날카로우며, 빠릅니다.",
            "빨간 날 위로 끈적한 것이 묻어있습니다." };

        bool[] itemishave = { true, false, false, false, false, false, false, false };
        bool[] itemistake = { true, false, false, false, false, false, false, false };

        int[] itemadstat = { 10, 15, 15, 15, 20, 25, 25, 30 };
        int[] itemdpstat = { 0, 0, 0, 0, 0, 0, 0, 0 };

        int[] itemprice = { 500, 1000, 1200, 1000, 1500, 2000, 2000, 2500 };
        int[] itemidx = { 1, 2, 3, 4, 5, 6, 7, 8 };

    


        public static void ItemHaveInTrue(int choice, int mapNum) // 아이템을 구매 할 경우 True로 바꿔주는 함수
        {
            foreach (Item item in items)
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
            foreach (Item item in items)
            {
                if (choice == item.IDX)
                {
                    item.IsTake = !item.IsTake;
                }
            }
        }
        public int AllItemInShopScript(int mapNum) // 상점 장비 아이템 스크립트 제작
        {
            if (mapNum == 23) // 아이템 판매 페이지
            {
                AllItemInHaveScript(mapNum);
                return 0;
            }

            if (mapNum == 13) // 아이템 구매 페이지
            {

                int count = 1;
                foreach (Item item in items)
                {
                    if (item.IsHave == false)
                    {
                        item.IDX = count;
                        Console.Write(" " + count + ". ");  // 번호
                        Console.Write(item.Name);  // 이름
                        ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                        Console.Write(item.Desc + "\n\t       | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat + " | ");  // 상세 정보
                        ColorChange.ColorWriteLine(6, item.Price + "G\n"); // 가격 + 색상 함수
                        count++;
                    }
                    else item.IDX = 0;
                }
                return count - 1;
            }
            else  // 상점 페이지
            {
                int count = 1;
                foreach (Item item in items)
                {
                    item.IDX = count;
                    Console.Write("  - " + item.Name);  // 이름
                    ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                    Console.Write(item.Desc + "\n\t       | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat + " | ");  // 상세 정보
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

        public int AllItemInHaveScript(int mapNum) //  소유한 장비 아이템 스크립트 제작
        {
            Console.WriteLine(" [ 무기 아이템 ]\n");

            if (mapNum == 2) // 인벤토리 페이지
            {
                int count = 1;
                foreach (Item item in items)
                {
                    item.IDX = count;
                    // 가지고 있는 아이템만 생성
                    if (item.IsHave == true) 
                    {
                        Console.Write("  - " + item.Name);  // 이름
                        ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                        Console.WriteLine(item.Desc + "\n\t       | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat + " | \n");  // 상세 정보
                    }
                    count++;
                }
                return 0;
            }
            else if (mapNum == 12) // 인벤토리 장착 페이지
            {
                int count = 1;
                foreach (Item item in items)
                {
                    if (item.IsHave == true) // 가지고 있는 아이템만 나오도록
                    {
                        item.IDX = count;

                        Console.Write(" " + count + ". ");

                        if (item.IsTake == true) // 아이템을 착용하고 있다면 E 표시
                        {
                            ColorChange.ColorWrite(10, item.Name);  // 이름
                            ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                            Console.Write(item.Desc);
                            ColorChange.ColorWrite(10, " [E] ");
                        }
                        else
                        {
                            Console.Write(item.Name);  // 이름
                            ItemSort(item.Name.Length);  // 간격 맞춤용 함수
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
                int count = 1;
                foreach (Item item in items)
                {
                    item.IDX = count;
                    if (item.IsHave == true) // 가지고 있는 아이템만 나오도록
                    {
                        item.IDX = count;
                        Console.Write(" " + count + ". ");  // 번호
                        Console.Write(item.Name);  // 이름
                        ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                        Console.Write(item.Desc + "\n\t       | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat + " | ");  // 상세 정보
                        ColorChange.ColorWriteLine(12, (item.Price / 100 * 85) + "G (85%)\n"); // 가격 + 색상 함수
                        count++;
                    }
                    else item.IDX = 0;
                }
                return count - 1;
            }
        }
        public static void ItemSort(int i)
        {
            switch (i)
            {
                case 1:
                    Console.Write("        | ");
                    break;
                case 2:
                    Console.Write("       | ");
                    break;
                case 3:
                    Console.Write("     | ");
                    break;
                case 4:
                    Console.Write("   | ");
                    break;
                case 5:
                    Console.Write(" | ");
                    break;
                case 6:
                    Console.Write("| ");
                    break;
            }
        }


        public void AllItemInShopList()
        {
            for (int i = 0; i < itemname.Length; i++) // 무기 아이템
            {
                items.Add(new Item(itemname[i], itemdesc[i], itemishave[i], itemistake[i], itemadstat[i], itemdpstat[i], itemprice[i], itemidx[i]));
            }

        } // 초기설정 : 모든 아이템 상점 리스트에 집어넣기
    }
}
