using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
   
    // 맵 기본 정보 스크립트
    

    // 맵 선택지 정보 스크립트
    public class ChoiceScript
    {
        string[] VillageChoice = { "플레이어 정보 (PlayerInfo)", "인벤토리 (Inventory)", "상점 (Shop)", "여관 (Inn)", "던전 (Dungeon)" };
        string[] ShopChoice = { "상점에서 나가기 (Village)", "아이템 구매", "아이템 판매" };
        string[] InnChoice = { "여관에서 나가기 (Village)", "휴식하기" };
        string[] InventoryChoice = { "인벤토리 닫기 (Close)", "아이템 장착관리" };
        string[] DungeonChoice = { "마을로 돌아가기 (Village)", "던전으로 진입" };
        string[] PlayerInfoChoice = { "정보 그만보기 (Close)" };

        string[] InvenItemChoice = { "아이템 장착관리 취소" };
        string[] ShopBuyChoice = { "아이템 구매 취소" };
        string[] ShopSellChoice = { "아이템 판매 취소" };
        string[] InnRestChoice = { "마을로 돌아가기 ( Village )" };
        string[] DungeonInChoice = { " 던전 안으로 들어간다... " };
        string[] DungeonOutChoice = { " 던전 밖으로 나간다... " };

        string[] BattleSceneChoice = { "공격하기", "아이템 사용하기" };

        public void VillageScript()
        {
            for (int i = 0; i < VillageChoice.Length; i++)
            {
                Console.Write("\n " + (i + 1) + ". ");
                Console.WriteLine($"{VillageChoice[i]}");
            }
        }
        public void ShopScript()
        {
            for (int i = 0; i < ShopChoice.Length; i++)
            {
                Console.Write("\n " + (i + 1) + ". ");
                Console.WriteLine($"{ShopChoice[i]}");
            }
        }
        public void InnScript()
        {
            for (int i = 0; i < InnChoice.Length; i++)
            {
                Console.Write("\n " + (i + 1) + ". ");
                Console.WriteLine($"{InnChoice[i]}");
            }
        }
        public void InventoryScript()
        {
            for (int i = 0; i < InventoryChoice.Length; i++)
            {
                Console.Write("\n " + (i + 1) + ". ");
                Console.WriteLine($"{InventoryChoice[i]}");
            }
        }
        public void DungeonScript()
        {
            for (int i = 0; i < DungeonChoice.Length; i++)
            {
                Console.Write("\n " + (i + 1) + ". ");
                Console.WriteLine($"{DungeonChoice[i]}");
            }
        }
        public void PlayerInfoScript()
        {
            for (int i = 0; i < PlayerInfoChoice.Length; i++)
            {
                Console.Write("\n " + (i + 1) + ". ");
                Console.WriteLine($"{PlayerInfoChoice[i]}");
            }
        }

        public void InvenItemScript()
        {
            for (int i = 0; i < InvenItemChoice.Length; i++)
            {
                Console.Write("\n " + (i) + ". ");
                Console.WriteLine($"{InvenItemChoice[i]}");
            }
        }
        public void ShopBuyScript()
        {
            for (int i = 0; i < ShopBuyChoice.Length; i++)
            {
                Console.Write("\n " + (i) + ". ");
                Console.WriteLine($"{ShopBuyChoice[i]}");
            }
        }
        public void ShopSellScript()
        {
            for (int i = 0; i < ShopSellChoice.Length; i++)
            {
                Console.Write("\n " + (i) + ". ");
                Console.WriteLine($"{ShopSellChoice[i]}");
            }
        }
        public void InnRestScript()
        {
            for (int i = 0; i < InnRestChoice.Length; i++)
            {
                Console.Write("\n " + (i + 1) + ". ");
                Console.WriteLine($"{InnRestChoice[i]}");
            }
        }
        public void DungeonInScript()
        {
            for (int i = 0; i < DungeonInChoice.Length; i++)
            {
                Console.Write("\n " + (i + 1) + ". ");
                Console.WriteLine($"{DungeonInChoice[i]}");
            }
        }
        public void DungeonOutScript()
        {
            for (int i = 0; i < DungeonOutChoice.Length; i++)
            {
                Console.Write("\n " + (i + 1) + ". ");
                Console.WriteLine($"{DungeonOutChoice[i]}");
            }
        }
        public void BattleSceneScript()
        {
            for(int i = 0;i < BattleSceneChoice.Length; i++)
            {
                Console.Write("\n " + (i + 1) + ". ");
                Console.WriteLine($"{BattleSceneChoice[i]}");
            }
        }
    }
}
