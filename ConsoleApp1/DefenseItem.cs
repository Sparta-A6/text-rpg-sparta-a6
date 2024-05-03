using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class DefenseItem
    {
        public List<DefenseItem> DpItem = new List<DefenseItem>();  // 방어 아이템
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

        public void MakeItemScript()
        {
            Console.WriteLine("제작함수 진입");
            int count = 1;
            foreach (DefenseItem DpItem in DpItem)
            {
                Console.WriteLine($"for문 진입 {count}");
                DpItem.IDX = count;
                Console.Write(" " + count + ". ");  // 번호
                Console.Write(DpItem.Name);  // 이름
                Console.Write(DpItem.Desc + "\n\t       | 공격력 + " + DpItem.ADStat + "  | 방어력 + " + DpItem.DPStat + " | " + DpItem.Price + "G\n");  // 상세 정보
                count++;
            }
        }

        // 초기설정 : 무기 아이템 상점 리스트에 집어넣기
        public void DpItemInShopList(string name, int ad, int dp, string set, int price, string desc, int num)
        {
            DpItem.Add(new DefenseItem(name, desc, itemishave[num], itemistake[num], ad, dp, price, set, itemidx[num]));

        }



    }
}
