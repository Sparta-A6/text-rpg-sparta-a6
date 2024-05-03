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

        public Enemy(Enemy other)
        {
            this.EnemyName = other.EnemyName;
            this.EnemyAttack = other.EnemyAttack;
            this.EnemyDefence = other.EnemyDefence;
            this.CurrentenemytHealth = other.CurrentenemytHealth;
            this.MaxenemyHealth = other.MaxenemyHealth;
        }
    }

    internal class EnemyStats
    {
        public static List<Enemy> Enemies { get; set; } = new List<Enemy>
        {
            new Enemy("일반 좀비", 25, 20, 0),
            new Enemy("뚱뚱한 좀비", 40, 15, 5),
            new Enemy("굶주린 좀비", 20, 25, 0),
            new Enemy("숙주 좀비", 200, 40, 10)
        };
    }    

}
