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
        public static List<Item> items = new List<Item>(); // 리스트 선언


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

        string[] itemname = { "롱소드", "천 갑옷", "열정의 검", "쇠사슬 조끼", "얼어붙은 심장", "정령의 형상", "마나무네", "고속 연사포" };
        string[] itemdesc = { 
            "기본에 충실한 무기입니다.", 
            "기본에 충실한 방어구입니다.", 
            "두개의 검이 위협적으로 빛납니다.", 
            "사슬로 만들어져 더욱 단단합니다.",
            "차가운 마나의 기운이 몸을 더 단단하게 만듭니다.",
            "갑옷 주위를 푸른 정령이 감싸고 있습니다.",
            "마나의 흐름이 느껴집니다.",
            "더 멀리 공격할 수 있습니다." };

        bool[] itemishave = { false, false, false, false, false, false, false, false };
        bool[] itemistake = { false, false, false, false, false, false, false, false };

        int[] itemadstat = { 10, 0, 15, 5, 15, 5, 30, 35 };
        int[] itemdpstat = { 0, 15, 5, 25, 35, 45, 10, 5 };

        int[] itemprice = { 800, 800, 1100, 1300, 2700, 2800, 2600, 2800 };
        int[] itemidx = { 1, 2, 3, 4, 5, 6, 7, 8 };



        public static void ItemHaveInTrue(int choice, int mapNum) // 아이템을 구매 할 경우 True로 바꿔주는 함수
        {
            foreach (Item item in items)
            {
                if ((choice == item.IDX) && (Player.gold>=item.Price) && (mapNum==13) ) // 구매할 경우
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
        public int AllItemInShopScript(int mapNum) // 상점 아이템 스크립트 제작
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
                        Console.WriteLine(" " + count + ". " + item.Name + "  | " + item.Desc + "\n\t\t | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat + "\t | " + item.Price + "G\n");
                        count++;
                    }
                    else item.IDX = 0;
                }
                return count-1;
            }
            else  // 상점 페이지
            {
                int count = 1;
                foreach (Item item in items)
                {
                    item.IDX = count;
                    if (item.IsHave == true)
                        Console.WriteLine(" - " + item.Name + "  | " + item.Desc + "\n\t\t | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat + "\t | " + "구매완료\n" );
                    else
                        Console.WriteLine(" - " + item.Name + "  | " + item.Desc + "\n\t\t | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat + "\t | " + item.Price + "G\n");
                    count++;
                }
                return 0;
            }


        }
        public void AllItemInShopList()
        {
            for (int i = 0; i < itemname.Length; i++)
            {
                items.Add(new Item(itemname[i], itemdesc[i], itemishave[i], itemistake[i], itemadstat[i], itemdpstat[i], itemprice[i], itemidx[i]));
            }
        } // 초기설정 : 모든 아이템 상점 리스트에 집어넣기
        public int AllItemInHaveScript(int mapNum) //  소유한 아이템 스크립트 제작
        {
            if (mapNum == 2) // 인벤토리 페이지
            {
                int count = 1;
                foreach (Item item in items) 
                {
                    item.IDX = count;
                    // 가지고 있는 아이템만 생성
                    if (item.IsHave == true) { Console.WriteLine(" - " + item.Name + "  | " + item.Desc + "\n\t\t | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat + "  | \n"); }
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
                        if (item.IsTake == true) // 아이템을 착용하고 있다면 E 표시
                            Console.WriteLine(count + ". " + " [E] " + item.Name + "  | " + item.Desc + "\n\t\t | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat +"\n");
                        else
                            Console.WriteLine(count + ". " + "     " + item.Name + "  | " + item.Desc + "\n\t\t | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat +"\n");
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
                        Console.WriteLine(count + ". " + item.Name + "  | " + item.Desc + "\n\t\t | 공격력 + " + item.ADStat + "  | 방어력 + " + item.DPStat +  "  | " + (item.Price/100*85) +"G (85%)\n" );
                        count++;
                    }
                    else item.IDX = 0;
                }
                return count - 1;
            }
        }
    }
}
