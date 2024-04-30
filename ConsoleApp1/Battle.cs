using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class Battle
    {
        private Player player;
        private Enemy enemy;
        

        public Battle(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
            
        }

        public void StartBattle()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" Battle");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            Console.WriteLine("근처를 둘러보다 좀비들에게 발각되었습니다!!\n");
            Console.WriteLine("좀비와의 전투에 돌입합니다.\n");

            // 플레이어 정보 출력
            Console.WriteLine();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" [ 플레이어 정보 ]\n");
            Console.WriteLine($" 이름 :  {player.playerName}");
            Console.WriteLine($" 레벨 : {player.level}");
            Console.WriteLine($" 현재 체력 : {player.currenthealth} / {player.maxhealth}");
            Console.WriteLine($" 공격력 : {player.attack}");
            Console.WriteLine($" 방어력 : {player.defense}");
            Console.WriteLine("---------------------------------------");

            // 적 정보 출력
            Console.WriteLine();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" [ 적 정보 ]\n");
            Console.WriteLine($"{enemy.EnemyName} 체력: {enemy.CurrentenemytHealth} / {enemy.MaxenemyHealth} 공격력: {enemy.EnemyAttack} 방어력: {enemy.EnemyDefence}");
            Console.WriteLine();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1.공격 하기");
            Console.WriteLine("2.아이템 사용");

            Console.WriteLine();
            Console.WriteLine("\n---------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" 원하시는 행동을 입력해주세요.");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("---------------------------------------");

            string userInput = Console.ReadLine();
            int choice;
                        
            if (int.TryParse(userInput, out choice))
            {                
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n---------------------------------------");
                        Console.WriteLine("대상을 선택하십시오.");
                        Console.WriteLine("---------------------------------------");

                        string targetInput = Console.ReadLine();
                        int target;

                        if (int.TryParse(targetInput, out target))
                        {                            
                            AttackEnemy(target);
                        }
                        else
                        {
                            Console.WriteLine("\n---------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" 올바른 값을 입력해주십시오.");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("---------------------------------------");
                        }
                        break;
                    case 2:
                        //UseItem();
                        break;
                    default:
                        Console.WriteLine("\n---------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" 올바른 값을 입력해주십시오.");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("---------------------------------------");
                        break;

                }
            }

        }

        public void AttackEnemy(int target)
        {
            if (target >= 0 && target < EnemyStats.Enemies.Count)
            {                
                Enemy selectedEnemy = EnemyStats.Enemies[target];
                                
                int damageDealt = Math.Max(0, player.attack - selectedEnemy.EnemyDefence);
                                
                selectedEnemy.CurrentenemytHealth -= damageDealt;
                                
                if (selectedEnemy.CurrentenemytHealth <= 0)
                {
                    Console.WriteLine("\n---------------------------------------");
                    Console.WriteLine($"{selectedEnemy.EnemyName}을(를) 물리쳤습니다!");
                    Console.WriteLine("---------------------------------------");                    
                }
                else
                {                    
                    Console.WriteLine("\n---------------------------------------");
                    Console.WriteLine($"{selectedEnemy.EnemyName} 남은 체력: {selectedEnemy.CurrentenemytHealth} / {selectedEnemy.MaxenemyHealth}");
                    Console.WriteLine("---------------------------------------");
                }
            }
            else
            {                
                Console.WriteLine("\n---------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" 선택된 적이 존재하지 않습니다.");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("---------------------------------------");
            }
        }
    }
}
