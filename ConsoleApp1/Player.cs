using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame 
{
    internal class Player
    {

        // 플레이어 정보        

        public string playerName = " 지원 ";
        public int level = 1;
        public int attack = 10 + ItemAttack;
        public int defense = 10 + ItemDefense;

        public static int ItemAttack;
        public static int ItemDefense;

        public static int currenthealth = 100;
        public int maxhealth = 100;
        public static int infection = 0;

        public static int gold = 15000;
        public float Accuracy = 0.8f; // 명중률
        public float Avoidance = 0.2f;  // 회피율
        public float Critical = 0.1f; // 치명타율
        public int experience = 0;
        public int experienceLevelUp = 100;

       


        public static Player GetPlayerStatInfo()
        {
            Player player = new Player();            
            return player;
        }

        public void GainExperience(int amount)
        {
            experience += amount;
            if (experience >= experienceLevelUp)
            {
                LevelUp();
                Console.WriteLine("레벨이 올랐습니다!");
                Console.WriteLine("최대 체력이 10 증가합니다");
            }
        }

        public void GainInfection(int Infection)
        {
            infection += Infection;
        }

        // Hp 게이지 UI 생성용 배열
        static int[,] HpGauge = new int[3, 12] // 다차원 배열 선언시 세로,가로 길이로 지정
            {
                {2,2,2,2,2,2,2,2,2,2,2,2},
                {3,0,0,0,0,0,0,0,0,0,0,4},
                {2,2,2,2,2,2,2,2,2,2,2,2}
            };

        // 감염도 게이지 UI 생성용 배열
        static int[,]  IpGauge = new int[3, 12] // 다차원 배열 선언시 세로,가로 길이로 지정
            {
                {2,2,2,2,2,2,2,2,2,2,2,2},
                {3,0,0,0,0,0,0,0,0,0,0,4},
                {2,2,2,2,2,2,2,2,2,2,2,2}
            };

        public static void PlusIp(int PlusIp)
        {
            infection -= PlusIp;
            if (infection < 0)
            {
                infection = 0;
            }
        }

        public static void PlusHp(int PlusHp)
        {
            currenthealth += PlusHp;
            if (currenthealth > 100) 
            {
                currenthealth = 100;
            }
        }

        //체력 게이지 제작
        public static void PlayerHpGauge()
        {
            // hp 게이지 채우는 함수
            for (int i = 10; i > 0; i--)
            {
                if (currenthealth >= 10 * i) // HP가 100보다 크거나 같다면
                {
                    HpGauge[1, i] = 1;
                }
                else HpGauge[1, i] = 0;
            }

            // 게이지 생성 함수
            for (int i = 0; i < 3; i++)
            {
                Console.Write(" ");
                for (int j = 0; j < 12; j++)
                {
                    switch (HpGauge[i, j])
                    {
                        case 0:
                            Console.Write("♡");
                            break;
                        case 1:
                            ColorChange.ColorWrite(12, "♥");
                            break;
                        case 2:
                            Console.Write("ㅡ");
                            break;
                        case 3:
                            Console.Write("| ");
                            break;
                        case 4:
                            Console.Write(" |");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        //감염도 게이지 제작
        public static void PlayerIpGauge()
        {
            // hp 게이지 채우는 함수
            for (int i = 10; i > 0; i--)
            {
                if (infection >= 10 * i) // HP가 100보다 크거나 같다면
                {
                    IpGauge[1, i] = 0;
                }
                else IpGauge[1, i] = 1;
            }

            // 게이지 생성 함수
            for (int i = 0; i < 3; i++)
            {
                Console.Write(" ");
                for (int j = 0; j < 12; j++)
                {
                    switch (IpGauge[i, j])
                    {
                        case 0:
                            ColorChange.ColorWrite(13, "■");
                            break;
                        case 1:
                            ColorChange.ColorWrite(11, "■");
                            break;
                        case 2:
                            Console.Write("ㅡ");
                            break;
                        case 3:
                            Console.Write("| ");
                            break;
                        case 4:
                            Console.Write(" |");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
        private void LevelUp()
        {
            experienceLevelUp = (int)(experienceLevelUp * 1.3f);
            level++;
            maxhealth += 10;
        }


    }


    
}


