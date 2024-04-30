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

        public UseItem(string name, String desc, bool isHave, int count, int hp, int ip, int price, int idx)
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
        public String Name { get; }
        public String Desc { get; }
        public bool IsHave { get; set; }
        public int Count { get; set; }
        public int Hp { get; }
        public int Ip { get; }
        public int Price { get; }
        public int IDX { get; set; }


        string[] useitemname = { "자유시간", "파워에이드", "백신시약품", "백신" };
        string[] useitemdesc = {
            "조금 녹았지만 맛있습니다.",
            "미지근하지만 마실만 합니다.",
            "아직 검증되진 않았지만, 바이러스 상대로는 좋습니다.",
            "감염율을 눈에 띄게 줄여줍니다." };

        bool[] useitemishave = { true, true, true, true };
        int[] useitemcount = { 1, 2, 1, 1 };

        int[] useitemhp = { 15, 25, 20, 50 };
        int[] useitemip = { 0, 0, 25, 50 };

        int[] useitemprice = { 800, 800, 1100, 1300 };
        int[] useitemidx = { 1, 2, 3, 4 };


        public void UseItemInShopList()
        {
            for (int i = 0; i < useitemname.Length; i++) // 사용 아이템 
            {
                UseItems.Add(new UseItem(useitemname[i], useitemdesc[i], useitemishave[i], useitemcount[i], useitemhp[i], useitemip[i], useitemprice[i], useitemidx[i]));
            }
        }
        public int UseItemInHaveScript() //  소유한 장비 아이템 스크립트 제작 
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
                        Item.ItemSort(item.Name.Length);  // 간격 맞춤용 함수
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

