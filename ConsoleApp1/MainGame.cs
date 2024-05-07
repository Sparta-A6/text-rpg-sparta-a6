using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class MainGame
    {
        Map map = new Map();
        Excelitem excelitem = new Excelitem();
        ChoiceLink choiceLink = new ChoiceLink();
        IfDied ifDied = new IfDied();


        public int playerChoice;
        bool isGamePlay = true;
        bool isCan = true;
                
        public static int mapNum = 0; // 현재 있는 맵 enum번호
        public static int instructionNum = 0; // 입력 오류 확인 변수  0=입력값 정상 / 1=오류

        public void Start()
        {
            // 콘솔 기본 설정 세팅 : 타이틀/배경색/글씨색
            Console.Title = "텍스트 알피지 게임 : 지원빌리지에서 살아남기";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            
            excelitem.start();

            Console.WriteLine("\n     로딩 완료! ");
            Console.WriteLine("플레이를 위해 아무키나 눌러주세요.");
            Console.ReadKey();

            while (isGamePlay) // 게임 플레이중이라면 반복할 부분 
            {
                if(Player.infection >= 100) 
                {
                    ifDied.IsDied();
                }
                map.makeMapScript(mapNum); // 맵 이름스크립트 출력
                map.mapInfoScript(mapNum); // 맵 정보 (기본 스크립트, 선택지) 출력
                
                map.instruction(instructionNum); // 입력하세요 - 입력오류입니다 출력

                int scriptCount = map.ScriptCount;
                isCan = int.TryParse(Console.ReadLine(), out playerChoice);  // 플레이어 값 받기

                choiceLink.choice(mapNum, isCan, playerChoice, scriptCount); // 플레이어의 값을 기반으로 맵 이동

            } // 반복
        }

    }
}

