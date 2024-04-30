using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class Enemy
    {
        public string EnemyName { get; set; }
        public int EnemyAttack { get; set; }
        public int EnemyDefence { get; set; }
        public int CurrentenemytHealth { get; set; }
        public int MaxenemyHealth { get; set; }

        public Enemy(string name, int maxhealth, int attack, int defence)
        {
            EnemyName = name;
            EnemyAttack = attack;
            EnemyDefence = defence;
            MaxenemyHealth = maxhealth;
            CurrentenemytHealth = maxhealth;

        }

        
    }

    internal class EnemyStats
    {
        public static List<Enemy> Enemies { get; set; } = new List<Enemy>
        {
            new Enemy("일반 좀비", 25, 15, 0),
            new Enemy("뚱뚱한 좀비", 50, 10, 5),
            new Enemy("굶주린 좀비", 40, 20, 0),
            new Enemy("숙주 좀비", 200, 35, 10)
        };
    }

}
