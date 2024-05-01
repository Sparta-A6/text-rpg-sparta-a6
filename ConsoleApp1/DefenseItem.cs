using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class DefenseItem
    {
        public static List<DefenseItem> DpItem = new List<DefenseItem>();  // 방어 아이템


        public DefenseItem(string name, String desc, bool isHave, bool isTake, int adstat, int dpstat, int price, int idx)
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
    }
}
