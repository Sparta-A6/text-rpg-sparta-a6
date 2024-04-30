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
        public int attack = 10;
        public int defense = 10;
        public int health = 50;
        public int infection = 50;
        public static int gold = 15000;

        // Hp 게이지 UI 생성용 배열
        int[,] HpGauge = new int[3, 12] // 다차원 배열 선언시 세로,가로 길이로 지정
            {
                {2,2,2,2,2,2,2,2,2,2,2,2},
                {3,0,0,0,0,0,0,0,0,0,0,4},
                {2,2,2,2,2,2,2,2,2,2,2,2}
            };

        // 감염도 게이지 UI 생성용 배열
        int[,]  IpGauge = new int[3, 12] // 다차원 배열 선언시 세로,가로 길이로 지정
            {
                {2,2,2,2,2,2,2,2,2,2,2,2},
                {3,0,0,0,0,0,0,0,0,0,0,4},
                {2,2,2,2,2,2,2,2,2,2,2,2}
            };

        public void PlusHp(int PlusHp)
        {
            health += PlusHp;
            if (health > 100) 
            {
                health = 100;
            }
        }

        //체력 게이지 제작
        public void PlayerHpGauge()
        {
            // hp 게이지 채우는 함수
            for (int i = 10; i > 0; i--)
            {
                if (health >= 10 * i) // HP가 100보다 크거나 같다면
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
        public void PlayerIpGauge()
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

    }

}


