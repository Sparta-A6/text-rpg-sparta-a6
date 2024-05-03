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
                itemishave[i] = false;
                itemistake[i] = false;
                itemidx[i] = i + 1;
                itemcount[i] = 0;
            }
        }


        public void UseItemInShopList(string name, int hp, int ip, int price, string desc, int num)
        {
            UseItems.Add(new UseItem(name, desc, itemishave[num], itemcount[num], hp, ip, price, itemidx[num]));

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
                        WeaponItem.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
                        Console.Write(item.Desc + "\n\t       | 체력 + " + item.Hp + "  | 감염도 - " + item.Ip + " | ");  // 상세 정보
                        ColorChange.ColorWriteLine(12, (item.Count + "개 보유 \n")); // 가격 + 색상 함수
                        count++;
                    }
                    else item.IDX = 0;
                }
                return count - 1;
            }

        public static void UseItemHaveCount(int choice) //  아이템을 다 사용했을 경우 list에서 삭제하는 함수
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

