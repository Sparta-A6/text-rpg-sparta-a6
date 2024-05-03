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
        public int currenthealth = 100;
        public int maxhealth = 100;
        public static int gold = 15000;
        public float Accuracy = 0.8f; // 명중률
        public float Avoidance = 0.2f;  // 회피율
        public float Critical = 0.1f; // 치명타율

        public static Player GetPlayerStatInfo()
        {
            Player player = new Player();            
            return player;
        }
    }

}
