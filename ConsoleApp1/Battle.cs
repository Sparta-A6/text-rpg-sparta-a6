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
        private List<Enemy> enemies;
        private Random random = new Random();
                 
        Map map = new Map();


        public Battle(Player player, List<Enemy> enemies)
        {
            this.player = player;
            this.enemies = enemies;

        }
                
        public void StartBattle()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" Battle");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            Console.WriteLine("근처를 둘러보다 좀비들에게 발각되었습니다!!\n");
            Console.WriteLine("좀비와의 전투에 돌입합니다.\n");

            int enemyCount = random.Next(1, 4);

            for (int i = 0; i < enemyCount; i++)
            {
                int randomEnemyIndex;
                if (player.level >= 3)
                {
                    randomEnemyIndex = random.Next(3);
                }
                else
                {
                    randomEnemyIndex = random.Next(2);
                }

                Enemy randomEnemy = EnemyStats.Enemies[randomEnemyIndex];

                Enemy newEnemy = new Enemy(randomEnemy.EnemyName, randomEnemy.MaxenemyHealth,
                               randomEnemy.EnemyAttack, randomEnemy.EnemyDefence);

                Console.WriteLine($"{i + 1}. {newEnemy.EnemyName} 체력: {newEnemy.CurrentenemytHealth}/{newEnemy.MaxenemyHealth} 공격력: {newEnemy.EnemyAttack} 방어력: {newEnemy.EnemyDefence}");
                enemies.Add(newEnemy);
            }


            while (!IsBattleOver())
            {
                PlayerTurn();
                if (IsBattleOver())
                {
                    break;
                }

                EnemyTurn();
                if (IsBattleOver())
                {
                    break;
                }
            }

        }

        private void PlayerTurn()
        {
            Console.Clear();

            Console.WriteLine(" [ 플레이어 정보 ]\n");
            Console.WriteLine($" 이름 :  {player.playerName}");
            Console.WriteLine($" 레벨 : {player.level}");
            Console.WriteLine($" 현재 체력 : {player.currenthealth} / {player.maxhealth}");
            Console.WriteLine($" 공격력 : {player.attack}");
            Console.WriteLine($" 방어력 : {player.defense}");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine(" [ 적 정보 ]\n");

            PrintEnemyInfo();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1.공격 하기");
            Console.WriteLine("2.아이템 사용");

            Console.WriteLine("---------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" 원하시는 행동을 입력해주세요.");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("---------------------------------------");


            int choice;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("---------------------------------------");
                            Console.WriteLine("대상을 선택하십시오.");
                            Console.WriteLine("---------------------------------------");

                            int target;

                            if (int.TryParse(Console.ReadLine(), out target) && target > 0 && target <= enemies.Count)
                            {
                                Enemy selectedEnemy = enemies[target - 1];

                                // 체력이 0 이상인 경우에만 공격 가능
                                if (selectedEnemy.CurrentenemytHealth > 0)
                                {
                                    int playerAttackPower = player.attack;
                                    int enemyDefensePower = selectedEnemy.EnemyDefence;
                                    int damage = playerAttackPower - enemyDefensePower;

                                    bool isHit = CheckHit(player.Accuracy);

                                    if (isHit)
                                    {
                                        // 치명타 여부 판단
                                        bool isCritical = CheckCritical(player.Critical);

                                        if (isCritical)
                                        {
                                            // 치명타 발생 시 공격력을 150% 증가
                                            damage = (int)(damage * 1.5);
                                            Console.WriteLine($"좀비의 머리를 명중시켜 {damage}의 피해를 입혔습니다!!");
                                            selectedEnemy.CurrentenemytHealth -= damage;
                                            Console.WriteLine("---------------------------------------");
                                            Console.WriteLine("계속 진행하시려면 엔터키를 입력해주세요");
                                            Console.ReadLine();
                                        }
                                        else
                                        {   //일반 공격
                                            selectedEnemy.CurrentenemytHealth -= damage;
                                            Console.WriteLine($"좀비를 공격해 {damage}의 피해를 주었습니다!");
                                            Console.WriteLine("---------------------------------------");
                                            Console.WriteLine("계속 진행하시려면 엔터키를 입력해주세요");
                                            Console.ReadLine();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("공격이 빗나갔습니다...");
                                        Console.WriteLine("---------------------------------------");
                                        Console.WriteLine("계속 진행하시려면 엔터키를 입력해주세요");
                                        Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("이미 죽은 적입니다!");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("---------------------------------------");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" 올바른 값을 입력해주십시오.");
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("---------------------------------------");
                                continue;
                            }
                            break;
                        case 2:
                            //UseItem()                        
                            return;
                        default:
                            Console.WriteLine("\n---------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" 올바른 값을 입력해주십시오.");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("---------------------------------------");
                            continue;
                    }
                    break;
                }
            }
        }

        private void EnemyTurn()
        {
            Console.Clear();

            Console.WriteLine(" [ 플레이어 정보 ]\n");
            Console.WriteLine($" 이름 :  {player.playerName}");
            Console.WriteLine($" 레벨 : {player.level}");
            Console.WriteLine($" 현재 체력 : {player.currenthealth} / {player.maxhealth}");
            Console.WriteLine($" 공격력 : {player.attack}");
            Console.WriteLine($" 방어력 : {player.defense}");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine(" [ 적 정보 ]\n");
            PrintEnemyInfo();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("적의 차례입니다.");
            Console.WriteLine("---------------------------------------");

            foreach (var newEnemy in enemies)
            {
                if (newEnemy.CurrentenemytHealth > 0)
                {                    
                    int enemyDamage = newEnemy.EnemyAttack - player.defense;
                    player.currenthealth -= Math.Max(0, enemyDamage);
                    player.currenthealth = Math.Max(0, player.currenthealth);

                    Console.Clear();                                        

                    Console.WriteLine(" [ 플레이어 정보 ]\n");
                    Console.WriteLine($" 이름 :  {player.playerName}");
                    Console.WriteLine($" 레벨 : {player.level}");
                    Console.WriteLine($" 현재 체력 : {player.currenthealth} / {player.maxhealth}");
                    Console.WriteLine($" 공격력 : {player.attack}");
                    Console.WriteLine($" 방어력 : {player.defense}");
                    Console.WriteLine("---------------------------------------");

                    PrintEnemyInfo();
                    Console.WriteLine("---------------------------------------");

                    Console.WriteLine($"{enemies.IndexOf(newEnemy) + 1}.{newEnemy.EnemyName}가 당신을 공격했습니다!");
                    Console.WriteLine($"{enemyDamage}의 피해를 입었습니다!");

                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("계속 진행하시려면 엔터키를 입력해주세요");
                    Console.ReadLine();

                    if (player.currenthealth == 0)
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("좀비에게 물려 사망하였습니다...");
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("게임이 종료됩니다.");                        
                        Console.WriteLine("---------------------------------------");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }    
                }
            }
        }


        public bool CheckHit(float accuracy)
        {
            int randomNumber = random.Next(0, 101);
            return randomNumber <= accuracy * 100;
        }

        public bool CheckCritical(float critical)
        {
            int randomNumber = random.Next(0, 101);
            return randomNumber <= critical * 100;
        }

        public bool CheckAvoid(float avoidance)
        {
            int randomNumber = random.Next(0, 101);
            return randomNumber <= avoidance * 100;
        }

        private bool IsBattleOver()
        {
            if (player.currenthealth == 0)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("좀비에게 물려 사망하였습니다...");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("게임이 종료됩니다.");
                Console.WriteLine("---------------------------------------");
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (enemies.All(newEnemy => newEnemy.CurrentenemytHealth <= 0))
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("주위의 좀비를 모두 물리쳤습니다!");
                Console.WriteLine();
                int totalnewEnemyAttack = enemies.Sum(newEnemy => newEnemy.EnemyAttack);
                player.GainExperience(totalnewEnemyAttack);
                Console.ReadLine();
                int foundGold = random.Next(0, 401);
                Console.WriteLine($"죽은 좀비의 품에서 {foundGold}G를 발견했습니다!");
                Player.gold += foundGold;
                Console.WriteLine();
                Console.ReadLine();
                Console.WriteLine("마을로 돌아갑니다.");
                Console.ReadLine();
                Console.Clear();
                MainGame.mapNum = 0;
                map.makeMapScript(0);
                map.mapInfoScript(0);                
            }

            return player.currenthealth <= 0 || enemies.All(newEnemy => newEnemy.CurrentenemytHealth <= 0);

        }

        private void PrintEnemyInfo()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                var newEnemy = enemies[i];
                Console.WriteLine($"{i + 1}. {newEnemy.EnemyName} 체력: {Math.Max(0, newEnemy.CurrentenemytHealth)}/{newEnemy.MaxenemyHealth} 공격력: {newEnemy.EnemyAttack} 방어력: {newEnemy.EnemyDefence}");
            }
        }        
    }
}
