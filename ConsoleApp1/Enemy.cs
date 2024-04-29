using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class Enemy
    {
        public string enemyName { get; set; }
        public int enemyAttack { get; set; }
        public int enemyDefence { get; set; }
        public int enemyHealth { get; set; }

        public Enemy(string name, int attack, int defence, int health)
        {
            enemyName = name;
            enemyAttack = attack;
            enemyDefence = defence;
            enemyHealth = health;
        }

        public void TakeDamage(int damage)
        {
            enemyHealth -= damage;
            if (enemyHealth < 0)
            {
                enemyHealth = 0;
            }
        }
    }

    internal class EenemyStats
    {
        public Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>
        {
            {"일반 좀비", new Enemy("일반 좀비", 10, 0, 15) },
            {"굶주린 좀비", new Enemy("굶주린 좀비", 20, 0, 10) },
            {"뚱뚱한 좀비", new Enemy("뚱뚱한 좀비", 15, 0, 20) },
            {"숙주 좀비", new Enemy("숙주 좀비", 20, 5, 50) }
        };
    }    

}
