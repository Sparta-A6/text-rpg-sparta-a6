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
        public int currenthealth { get; set; }
        public int maxhealth { get; set; }
        public static int gold = 15000;

        
    }

}
