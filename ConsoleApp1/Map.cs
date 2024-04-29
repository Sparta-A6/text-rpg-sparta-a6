using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestRpgGame
{
    public enum mapNum
    {
        Village = 0,
        PlayerInfo = 1,
        Inventory = 2,
        Shop = 3,
        Inn = 4,
        Dungeon = 5,
        InvenItem = 12,
        ItemUse = 22,
        ShopBuy = 13,
        ShopSell = 23,
        InnRest = 14,
        DungeonIn = 15,
        DungeonOut = 25,
    }

    

    internal class Map
    {
        DefaultScript defaultScript = new DefaultScript();
        ChoiceScript choiceScript = new ChoiceScript();
        Item item = new Item("-", "-", false, false, 0, 0, 0, 0);

        public int ScriptCount; //선택지 개수 줄이는 용도

        public void makeMapScript(int choice)
        {
            Console.Clear();

            mapNum choiceMap = (mapNum)choice;

            if (choice > 10) // ConsoleColor 맞추는 코드
            {
                choice -= 10;
                if(choice > 10) choice -= 10;
            }
            
            Console.WriteLine("---------------------------------------");
            Console.ForegroundColor = (ConsoleColor)choice+3;
            Console.WriteLine(" "+choiceMap);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("---------------------------------------\n");

        }

        
        public void mapInfoScript(int choice) // 플레이어에게 세부 정보 제공 (맵 및 이벤트)
        {
            

            switch (choice)
            {
                case 0: // 마을
                    defaultScript.VillageScript();
                    LimitLine();
                    choiceScript.VillageScript();
                    break;

                case 1: // 플레이어 정보
                    defaultScript.PlayerInfoScript();
                    defaultScript.PlayerInfoValse();
                    LimitLine();
                    choiceScript.PlayerInfoScript();
                    break;

                case 2: // 인벤토리
                    defaultScript.InventoryScript();
                    item.AllItemInHaveScript(choice); // 소유한 아이템
                    LimitLine();
                    choiceScript.InventoryScript();
                    break;

                case 12: // 아이템 장착
                    defaultScript.InvenItemScript(); // 소유한 아이템
                    ScriptCount = item.AllItemInHaveScript(choice); // 값 반환 (Case Break용)
                    LimitLine();
                    choiceScript.InvenItemScript();
                    break;

                case 22: // 아이템 사용
                    defaultScript.ItemUseScript(); // 사용할 아이템
                    ScriptCount = item.AllItemInHaveScript(choice); // 값 반환 (Case Break용)
                    LimitLine();
                    choiceScript.InvenItemScript();
                    break;

                case 3: // 상점
                    defaultScript.ShopScript();
                    item.AllItemInShopScript(choice); // 상점 아이템
                    LimitLine();
                    choiceScript.ShopScript();
                    break;

                case 13: // 상점 구매
                    defaultScript.ShopBuyScript();
                    ScriptCount = item.AllItemInShopScript(choice); // 값 반환 (Case Break용)
                    LimitLine();
                    choiceScript.ShopBuyScript();
                    break;

                case 23: // 상점 판매
                    defaultScript.ShopSellScript();
                    ScriptCount = item.AllItemInHaveScript(choice); // 값 반환 (Case Break용)
                    LimitLine();
                    choiceScript.ShopSellScript();
                    break;

                case 4: // 여관
                    defaultScript.InnScript();
                    LimitLine();
                    choiceScript.InnScript();
                    break;

                case 14: // 휴식완료
                    defaultScript.InnRestScript();
                    LimitLine();
                    choiceScript.InnRestScript();
                    break;

                case 5: // 던전
                    defaultScript.DungeonScript();
                    LimitLine();
                    choiceScript.DungeonScript();
                    break;

                case 15: // 던전 진입
                    defaultScript.DungeonInScript();
                    LimitLine();
                    choiceScript.DungeonInScript();
                    break;

                case 25: // 던전 밖으로
                    defaultScript.DungeonOutScript();
                    LimitLine();
                    choiceScript.DungeonOutScript();
                    break;
            }
        }

        public void instruction(int number) // 플레이어에게 지시 (원하는 행동 입력, 올바른 값 입력 등)
        {
            switch (number)
            {
                case 0:
                    Console.WriteLine("\n---------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(" 원하시는 행동을 입력해주세요.");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("---------------------------------------");
                    break;
                case 1:
                    Console.WriteLine("\n---------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" 올바른 값을 입력해주십시오.");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("---------------------------------------");
                    break;
                default:
                    break;
            }
        }
        void LimitLine()
        {
            Console.WriteLine("---------------------------------------");
        } // 가름줄

        public void ItemInList()
        {
            item.AllItemInShopList();
        }

        //public void Count()
        //{
        //    ChoiceLink.MakeScriptCount = (char)ScriptCount;
        //}
     
    }

}

