using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    public class DefaultScript
    {
        Player player = new Player();
        Dia_School dia_School = new Dia_School();

        public static bool IsCanBuy = true;

        public static bool IsBuy = false;
        public static bool IsSell = false;
        public static bool IsUsed = false;

        public static string ItemName = "";
        public static int ItemHP = 0;
        public static int ItemIP = 0;
        public static int ItemPrice = 0;

        public void VillageScript()
        {
            dia_School.SchoolRandomScript();
        }
        public void ShopScript()
        {
            Console.WriteLine(" 암시장 안에 들어왔습니다.");
            Console.WriteLine(" 암시장 건물 안은 상당히 어둡습니다 .");
            Console.WriteLine(" 충분한 돈만 있다면 물건을 살 수 있습니다. \n");
        }
        public void InnScript()
        {
            Console.WriteLine(" 보건실 안은 조용합니다.");
            Console.WriteLine(" 원한다면 이곳에서 쉬어도 될 것 같습니다. (체력 전부 회복)\n");

        }
        public void InventoryScript()
        {
            Console.WriteLine(" 자리에 앉아 장비를 점검하기 위해 가방을 열었습니다.");
            Console.WriteLine(" 보유중인 아이템을 관리할 수 있습니다.\n");
        }
        public void DungeonScript()
        {
            Console.WriteLine(" 사람은 때론 지치기 마련입니다.");
            Console.WriteLine(" 휴식을 즐기는 것에는 역시 산책이 최고입니다. \n");
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
        public void ItemUseScript()
        {
            Console.WriteLine(" 사용할 아이템을 선택해주십시오.\n");

            if (IsUsed == true)
            {
                Player.PlusHp(ItemHP);
                ColorChange.ColorWriteLine(10, $" {ItemName}을(를) 사용했습니다. ");
                ColorChange.ColorWriteLine(10, $"현재 체력 {Player.currenthealth} / 100 \n");
                IsUsed = false;
            }
        }
        public void ShopBuyScript()
        {
            if (IsCanBuy == true)
            {
                Console.WriteLine(" 이 세상에서 물건을 구할 수 있는 곳은 한정되어 있습니다.");
                Console.WriteLine(" 당신은 학교 뒤에 있는 개구멍을 통해 밖으로 나왔습니다.\n");

                Console.WriteLine(" 개구멍과 이어진 지하철 통로를 통해서 들어온 곳은 암시장입니다.");
                Console.WriteLine(" 어두운 지하철 통로에는 부랑자들과 사람들, 상인들이 있습니다.");
                Console.WriteLine(" 한 상인은 여러가지 물건을 바닥에 늘어놓고 있습니다.\n");

                if (IsBuy == true)
                {
                    ColorChange.ColorWriteLine(12, $" {ItemName} 를 {ItemPrice} G 에 구매했습니다.\n");

                    IsBuy = false;
                }
            }
            else
            {
                Console.WriteLine(" \"이봐! 돈이 없잖아. 제대로 된 돈으로 들고 오라고.\" ");
                Console.WriteLine(" 상인은 거지새끼를 보는 것 마냥 당신을 보고 있습니다.\n");

                ColorChange.ColorWriteLine(12, " 돈이 없습니다.\n");
            }

            // 타 함수로 나중에 옮기기
            Console.WriteLine(" [ 보유골드 ]");
            ColorChange.ColorWriteLine(6, $" {Player.gold} G\n");
        }
        public void ShopSellScript()
        {
            Console.WriteLine(" 상인은 의심쩍은 눈은 그대로인 채로 당신을 바라보며 말합니다.\n");
            Console.WriteLine(" \"그래. 뭘 파시겠다고?\"");
            Console.WriteLine(" \"잘 쳐줄테니까 한번 보여줘 봐.\"\n");

            if (IsSell == true)
            {
                ColorChange.ColorWriteLine(10, $" {ItemName} 를 {ItemPrice} G 에 팔았습니다.\n");

                IsSell = false;
            }

            Console.WriteLine(" [ 보유골드 ]");
            ColorChange.ColorWriteLine(6, $" {Player.gold} G\n");

            Console.WriteLine(" [ 아이템 판매 모드 ]\n");
        }
        public void InnRestScript()
        {
            Console.WriteLine(" 보건실 안에 들어가자마자 침대 위에 쓰러진 당신은 그대로 편히 잠을 잡니다.");
            Console.WriteLine(" 아침이 밝아오는 소리에 눈을 뜹니다.");
            Console.WriteLine(" 잘 쉬었던 것 같습니다.\n");

            ColorChange.ColorWriteLine(10, " + 체력 최대치 회복, 감염도 일부 치유\n");

            Player.PlusHp(100);

        }
        public void DungeonInScript()
        {
            Console.WriteLine(" 간단하게 산책을 즐겨봅니다.\n");
        }
        public void DungeonOutScript()
        {
            Console.WriteLine(" 시간이 많이 지났으니 돌아갑니다. \n");
        }

        public void BattleStartScript()
        {
            Console.WriteLine("근처를 둘러보다 좀비들에게 발각되었습니다!!");
            Console.WriteLine("좀비와의 전투에 돌입합니다.\n");
        }


        //플레이어 정보 공개
        public void PlayerInfoValse()
        {
            Console.WriteLine(" 이름 : " + player.playerName);
            Console.WriteLine(" 레벨 : " + player.level);

            Console.WriteLine();

            Player.PlayerHpGauge(); // 플레이어 체력게이지

            Console.Write(" 현재 체력 : ");
            if (Player.currenthealth >= 90)
            {
                ColorChange.ColorWrite(11, Player.currenthealth);
            }
            else if ((Player.currenthealth < 90) && (Player.currenthealth >= 50))
            {
                ColorChange.ColorWrite(10, Player.currenthealth);
            }
            else if (Player.currenthealth < 50)
            {
                ColorChange.ColorWrite(12, Player.currenthealth);
            }
            Console.Write(" / 100\n");

            Console.WriteLine();

            Player.PlayerIpGauge(); // 플레이어 감염도 게이지

            Console.Write(" 현재 감염도 : ");
            if (Player.infection >= 70)
            {
                ColorChange.ColorWrite(12, Player.infection + "%");
            }
            else if ((Player.infection < 70) && (Player.infection >= 30))
            {
                ColorChange.ColorWrite(9, Player.infection + "%");
            }
            else if (Player.infection < 30)
            {
                ColorChange.ColorWrite(11, Player.infection + "%");
            }
            Console.Write(" / 100%\n");

            Console.WriteLine();


            Console.Write(" 공격력 : " + player.attack);
            ColorChange.ColorWriteLine(11, $" + {Player.ItemAttack} ");
            Console.Write(" 방어력 : " + player.defense);
            ColorChange.ColorWriteLine(11, $" + {Player.ItemDefense} \n");

            Console.WriteLine(" 소지금 : " + Player.gold + " G \n");
        }

        public void LookAroundScript()
        {
            Console.WriteLine("앞에 무언가 보이는 것 같습니다");
            Console.WriteLine("가까이 가서 확인해 보겠습니까?\n");

        }

        public void FarmingStartScript()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 3);

            switch (randomNumber)
            {
                case 1:
                    Console.WriteLine("근처를 둘러 보았지만 아무것도 찾지 못했습니다..");
                    ColorChange.ColorWriteLine(2, "약간의 경험치를 획득했습니다.\n");
                    player.GainExperience(10);

                    ColorChange.ColorWriteLine(12, "아직은 괜찮습니다. 시간이 해결해 줄 것입니다.");
                    ColorChange.ColorWriteLine(12, $"현재 감염도 {Player.infection} / 100 \n");
                    player.GainInfection(10);
                    break;

                case 2:
                    int foundGold = random.Next(0, 201);
                    Console.WriteLine($"부패한 좀비의 시체 밑에서 무언가 반짝이고 있습니다.");
                    Console.WriteLine($"{foundGold}G를 발견했습니다!");
                    Player.gold += foundGold;

                    ColorChange.ColorWriteLine(12, "조금 몸이 무거워진 느낌입니다.");
                    ColorChange.ColorWriteLine(12, $"현재 감염도 {Player.infection} / 100 \n");
                    player.GainInfection(10);
                    break;


            }


        }
    }

}
