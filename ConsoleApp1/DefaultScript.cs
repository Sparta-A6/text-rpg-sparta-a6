using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    public class DefaultScript
    {
        Player Player = new Player();

        public static bool IsCanBuy = true;

        public static bool IsBuy = false;
        public static bool IsSell = false;

        public static string ItemName = "";
        public static int ItemPrice = 0;

        public void VillageScript()
        {
            Console.WriteLine(" 낡은 마을의 전경이 보입니다.");
            Console.WriteLine(" 사람이 많은 것은 아니나, 적지도 않습니다.");
            Console.WriteLine(" 이곳에서 던전으로 들어가기 위한 활동을 할 수 있습니다. \n");
        }
        public void ShopScript()
        {
            Console.WriteLine(" 상점 안에 들어왔습니다.");
            Console.WriteLine(" 낡은 상점 내부는 모험가에게 필요한 물품만 판매하고 있습니다.");
            Console.WriteLine(" 충분한 돈만 있다면 물건을 살 수 있습니다. \n");
        }
        public void InnScript()
        {
            Console.WriteLine(" 여관 안은 조용합니다.");
            Console.WriteLine(" 단돈 500G로 하룻밤 묵을 수 있습니다. (체력 전부 회복)\n");

            Console.WriteLine(" [ 보유골드 ]");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($" {Player.gold} G\n");
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public void InventoryScript()
        {
            Console.WriteLine(" 자리에 앉아 장비를 점검하기 위해 가방을 열었습니다.");
            Console.WriteLine(" 보유중인 아이템을 관리할 수 있습니다.\n");
        }
        public void DungeonScript()
        {
            Console.WriteLine(" 던전은 무서워보입니다...");
            Console.WriteLine(" 충분한 공격력과 방어력이 있어야 클리어 할 수 있을 것 같습니다. \n");
        }
        public void PlayerInfoScript()
        {
            Console.WriteLine(" [ 플레이어 정보 ] \n");
        }
        public void InvenItemScript()
        {
            Console.WriteLine(" 아이템을 선택해서 장착하거나 장착해제할 수 있습니다.\n");
            Console.WriteLine(" [ 아이템 관리 모드 ]\n");
        }
        public void ShopBuyScript()
        {
            if (IsCanBuy == true)
            {
                Console.WriteLine(" 주인장은 아무런 관심이 없지만 당신은 양심적으로 구매하려고 합니다.\n");

                if (IsBuy == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" {ItemName} 를 {ItemPrice} G 에 구매했습니다.\n");
                    Console.ForegroundColor = ConsoleColor.Black;

                    IsBuy = false;
                }
            }
            else
            {
                Console.WriteLine(" \"이봐! 돈이 없잖아. 제대로 된 돈으로 들고 오라고.\" ");
                Console.WriteLine(" 주인장은 거지새끼를 보는 것 마냥 당신을 보고 있습니다.\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" 돈이 없습니다.\n");
                Console.ForegroundColor = ConsoleColor.Black;
            }

            // 타 함수로 나중에 옮기기
            Console.WriteLine(" [ 보유골드 ]");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($" {Player.gold} G\n");
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public void ShopSellScript()
        {
            Console.WriteLine(" 주인장은 카운터에 늘어져있던 몸을 일으키면서 말합니다.\n");
            Console.WriteLine(" \"그래. 뭘 파시겠다고?\"");
            Console.WriteLine(" \"잘 쳐줄테니까 한번 보여줘 봐.\"\n");

            if (IsSell == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" {ItemName} 를 {ItemPrice} G 에 팔았습니다.\n");
                Console.ForegroundColor = ConsoleColor.Black;

                IsSell = false;
            }

            Console.WriteLine(" [ 보유골드 ]");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($" {Player.gold} G\n");
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine(" [ 아이템 판매 모드 ]\n");
        }
        public void InnRestScript()
        {
            Console.WriteLine(" 방 안에 들어가자마자 침대 위에 쓰러진 당신은 그대로 편히 잠을 잡니다.");
            Console.WriteLine(" 아침이 밝아오는 소리에 눈을 뜹니다.");
            Console.WriteLine(" 잘 쉬었던 것 같습니다.\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" + 체력 최대치 회복\n");
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public void DungeonInScript()
        {
            Console.WriteLine(" 던전에 입장했습니다!\n");
        }
        public void DungeonOutScript()
        {
            Console.WriteLine(" 던전 클리어! \n");
        }

        public void BattleStartScript()
        {
            Console.WriteLine("근처를 둘러보다 좀비들에게 발각되었습니다!!");
            Console.WriteLine("좀비와의 전투에 돌입합니다.");
        }


        //플레이어 정보 공개
        public void PlayerInfoValse()
        {
            Console.WriteLine(" 이름 : " + Player.playerName);
            Console.WriteLine(" 레벨 : " + Player.level);
            Console.WriteLine(" 현재 체력 : " + Player.currenthealth + " / 100\n");

            Console.WriteLine(" 공격력 : " + Player.attack);
            Console.WriteLine(" 방어력 : " + Player.defense + "\n");

            Console.WriteLine(" 소지금 : " + Player.gold + " G \n");
        }

        public void LookAroundScript()
        {
            Console.WriteLine("앞에 무언가 보이는 것 같습니다");
            Console.WriteLine("가까이 가서 확인해 보겠습니까?");

        }

        public void FarmingStartScript()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 3); 

            if (randomNumber == 1)
            {
                Console.WriteLine("근처를 둘러 보았지만 아무것도 찾지 못했습니다..");
                Console.WriteLine("약간의 경험치를 획득했다.");
                Player.GainExperience(10);
            }
            else if (randomNumber == 2)
            {
                int foundGold = random.Next(0, 201);
                Console.WriteLine($"부패한 좀비의 시체 밑에서 무언가 반짝이고 있습니다.");
                Console.WriteLine($"{foundGold}G를 발견했습니다!");
                Player.gold += foundGold;
            }          
            else
            {

            }
        }
    }


}
