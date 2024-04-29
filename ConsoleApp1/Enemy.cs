using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class Enemy
    {
        public string enemyName;
        public int enemyAttack;
        public int enemyDefence;
        public int enemyHealth;

        public Enemy(string name, int attack, int defence, int health)
        {
            enemyName = name;
            enemyAttack = attack;
            enemyDefence = defence;
            enemyHealth = health;
        }              

    }
}
