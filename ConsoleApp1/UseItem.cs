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

        public UseItem(string name, String desc, bool isHave, bool isTake, int adstat, int dpstat, int price, int idx)
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


        string[] useitemname = { "자유시간", "파워에이드", "백신시약품", "백신" };
        string[] useitemdesc = {
            "조금 녹았지만 맛있습니다.",
            "미지근하지만 마실만 합니다.",
            "아직 검증되진 않았지만, 바이러스 상대로는 좋습니다.",
            "감염율을 눈에 띄게 줄여줍니다." };

        bool[] useitemishave = { false, false, false, false };
        bool[] useitemistake = { false, false, false, false };

        int[] useitemhp = { 15, 25, 20, 50 };
        int[] useitemip = { 0, 0, 25, 50 };

        int[] useitemprice = { 800, 800, 1100, 1300 };
        int[] useitemidx = { 1, 2, 3, 4 };


        public void UseItemInShopList()
        {
            for (int i = 0; i < useitemname.Length; i++) // 사용 아이템
            {
                UseItems.Add(new UseItem(useitemname[i], useitemdesc[i], useitemishave[i], useitemistake[i], useitemhp[i], useitemip[i], useitemprice[i], useitemidx[i]));
            }
        }

       
        public static void ItemHaveCount(int choice, int mapNum) //  아이템을 다 사용했을 경우 list에서 삭제하는 함수
        {

        }

    }
}
