using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class UseItem
    {

        public static List <UseItem> UseItems = new List<UseItem>();  // 사용 아이템

        public UseItem(string name, string desc, bool isHave, int count, int hp, int ip, int price, int idx)
        {
            Name = name; // 아이템 이름
            Desc = desc; // 아이템 설명
            IsHave = isHave; // 변동되는 변수 : 가지고 있는가?
            Count = count;
            Hp = hp;
            Ip = ip;
            Price = price;
            IDX = idx; // 공개 X 아이템 인덱스
        }
        public string Name { get; }
        public string Desc { get; }
        public bool IsHave { get; set; }
        public int Count { get; set; }
        public int Hp { get; }
        public int Ip { get; }
        public int Price { get; }
        public int IDX { get; set; }


        bool[] itemishave;
        bool[] itemistake;

        int[] itemidx;
        int[] itemcount;

        // 배열 사이즈 제작 (초기에 한번만 실행)
        public void ArrSizeMake(int size)
        {
            itemishave = new bool[size];
            itemistake = new bool[size];
            itemidx = new int[size];
            itemcount = new int[size];

            for (int i = 0; i < size; i++)
            {
                itemishave[i] = true;
                itemistake[i] = false;
                itemidx[i] = i + 1;
                itemcount[i] = 1;
            }
        }


        public void UseItemInShopList(string name, int hp, int ip, int price, string desc, int num) // 리스트에 추가 (초기함수)
        {
            UseItems.Add(new UseItem(name, desc, itemishave[num], itemcount[num], hp, ip, price, itemidx[num]));

        }

        public static void ItemHaveInTrue(int choice, int mapNum) // 아이템을 구매 할 경우 True로 바꿔주는 함수
        {
            foreach (UseItem item in UseItems)
            {
                if ((choice == item.IDX) && (Player.gold >= item.Price) && (mapNum == 13)) // 구매할 경우
                {
                    if(item.IsHave == false) item.IsHave = !item.IsHave; //없다면 넣기
                    Player.gold -= item.Price;

                    DefaultScript.IsCanBuy = true;
                    DefaultScript.IsBuy = true;
                    DefaultScript.ItemName = item.Name;
                    DefaultScript.ItemPrice = item.Price;

                    item.Count += 1;
                }
                else if ((choice == item.IDX) && (Player.gold < item.Price) && (mapNum == 13)) // 구매할 때 돈이 부족한 경우
                {
                    DefaultScript.IsCanBuy = false;
                }
                
            }
        }

        public int UseItemInShopScript(int mapNum) // 상점 소비 아이템 스크립트 제작
        {
            
            if (mapNum == 13) // 아이템 구매 페이지
            {

                int count = 1;
                foreach (UseItem item in UseItems)
                {
                    item.IDX = count;
                    Console.Write(" " + count + ". ");  // 번호
                    Console.Write(item.Name);  // 이름
                    ItemSortScript.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                    Console.Write(item.Desc + "\n\t       | 체력 + " + item.Hp + "  | 감염도 - " + item.Ip + " | "); // 상세 정보
                    ColorChange.ColorWrite(12, (item.Count + "개 보유 | ")); // 가격 + 색상 함수
                    ColorChange.ColorWriteLine(6, item.Price + "G\n"); // 가격 + 색상 함수
                    count++;

                }
                return count - 1;
            }

            else  // 상점 페이지
            {
                ColorChange.ColorWriteLine(8, "  ◀   [ 소비류 ]   ▶      \n");

                int count = 1;
                foreach (UseItem item in UseItems)
                {
                    item.IDX = count;
                    Console.Write("  - " + item.Name);  // 이름
                    ItemSortScript.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                    Console.Write(item.Desc + "\n\t       | 체력 + " + item.Hp + "  | 감염도 - " + item.Ip + " | ");  // 상세 정보
                    if (item.IsHave == true)
                    {
                        Console.Write( item.Count + "개 보유 | "); // 가격 + 색상 함수
                    }
                    ColorChange.ColorWriteLine(6, item.Price + "G\n"); // 가격 + 색상 함수
                    count++;
                }
                return 0;
            }


        }

        public int UseItemInHaveScript() //  소유한 소모 아이템 스크립트 제작 
        {
            Console.WriteLine(" [ 소모 아이템 ]\n");

                int count = 1;
                foreach (UseItem item in UseItems)
                {
                    item.IDX = count;
                    if (item.IsHave == true) // 가지고 있는 아이템만 나오도록
                    {
                        item.IDX = count;
                        Console.Write(" " + count + ". ");  // 번호
                        Console.Write(item.Name);  // 이름
                        ItemSortScript.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                        Console.Write(item.Desc + "\n\t       | 체력 + " + item.Hp + "  | 감염도 - " + item.Ip + " | ");  // 상세 정보
                        ColorChange.ColorWriteLine(12, (item.Count + "개 보유 \n")); // 가격 + 색상 함수
                        count++;
                    }
                    else item.IDX = 0;
                }
                return count - 1;
            }

        public static void UseItemHaveCount(int choice) //  아이템 사용 -1 아이템을 다 사용했을 경우 list에서 삭제하는 함수
        {
            foreach (UseItem item in UseItems)
            {
                if ((choice == item.IDX) && (item.IsHave == true))
                {
                    DefaultScript.IsUsed = true;
                    DefaultScript.ItemName = item.Name;
                    DefaultScript.ItemHP = item.Hp;
                    DefaultScript.ItemIP = item.Ip;
                    item.Count--;
                    if(item.Count == 0)
                    {
                        item.IsHave = false;
                    }
                }
            }
        }
    }
}

