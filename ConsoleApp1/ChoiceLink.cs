using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    public class ChoiceLink
    {
        Map map = new Map();

        public static char MakeScriptCount;
        
        //map(n)Choice를 Map번호에 맞춰 실행시켜주는 함수
        public void choice(int mapNumber, bool isCan, int playerChoice, int ScriptCount)
        {
            switch (mapNumber)
            {
                case 0:
                    map0Choice(mapNumber, isCan, playerChoice, ScriptCount); 
                    break;

                case 1:
                    map1Choice(mapNumber, isCan, playerChoice, ScriptCount);
                    break;

                case 2:
                    map2Choice(mapNumber, isCan, playerChoice, ScriptCount);
                    break;
                case 12:
                    map12Choice(mapNumber, isCan, playerChoice, ScriptCount);
                    break;
                case 22:
                    map22Choice(mapNumber, isCan, playerChoice, ScriptCount);
                    break;

                case 3:
                    map3Choice(mapNumber, isCan, playerChoice, ScriptCount);
                    break;
                case 13:
                    map13Choice(mapNumber, isCan, playerChoice, ScriptCount);
                    break;
                case 23:
                    map23Choice(mapNumber, isCan, playerChoice, ScriptCount);
                    break;

                case 4:
                    map4Choice(mapNumber, isCan, playerChoice, ScriptCount);
                    break;
                case 14:
                    map14Choice(mapNumber, isCan, playerChoice, ScriptCount);
                    break;

                case 5:
                    map5Choice(mapNumber, isCan, playerChoice, ScriptCount);
                    break;
                case 15:
                    map15Choice(mapNumber, isCan, playerChoice, ScriptCount);
                    break;
                case 25:
                    map25Choice(mapNumber, isCan, playerChoice, ScriptCount);
                    break;

            }
       
        }


        //맵마다 링크 연결
        void map0Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {
                        
            if (isCan)
            {
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 0:
                        //마을
                        MainGame.mapNum = 0;
                        break;

                    case 1:
                        //플레이어 인포
                        MainGame.mapNum = 1;
                        break;

                    case 2:
                        //인벤토리
                        MainGame.mapNum = 2;
                        break;

                    case 3:
                        //상점
                        MainGame.mapNum = 3;
                        break;

                    case 4:
                        //여관
                        MainGame.mapNum = 4;
                        break;

                    case 5:
                        //던전
                        MainGame.mapNum = 5;
                        break;

                    default:
                        MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
                        break;
                }
            }
            else
            {
                MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            }
        }
        void map1Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {
            if (isCan)
            {
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 1 :
                        //플레이어 인포
                        MainGame.mapNum = 0;
                        break;

                    default:
                        MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
                        break;
                }
            }
            else
            {
                MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            }
        }
        void map2Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {
            if (isCan)
            {
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 1 :
                        //플레이어 인포
                        MainGame.mapNum = 0;
                        break;

                    case  2 :
                        //플레이어 인포
                        MainGame.mapNum = 12;
                        break;

                    case 3:
                        //플레이어 인포
                        MainGame.mapNum = 22;
                        break;

                    default:
                        MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
                        break;
                }
            }
            else
            {
                MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            }
        }
        void map12Choice(int mapNum, bool isCan, int playerChoice, int  ScriptCount)
        {
            
            if (isCan)
            {
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 0:
                        //플레이어 인포
                        MainGame.mapNum = 2;
                        break;

                    case 1:
                        if (ScriptCount >= 1)
                            Item.ItemTakeInTrue(1);
                        else MainGame.instructionNum = 1;
                        break;

                    case 2:
                        if (ScriptCount >= 2)
                            Item.ItemTakeInTrue(2);
                        else MainGame.instructionNum = 1;
                        break;

                    case 3:
                        if (ScriptCount >= 3) 
                            Item.ItemTakeInTrue(3);
                        else MainGame.instructionNum = 1;
                        break;

                    case 4:
                        if (ScriptCount >= 4)
                            Item.ItemTakeInTrue(4);
                        else MainGame.instructionNum = 1;
                        break;

                    case 5:
                        if (ScriptCount >= 5)
                            Item.ItemTakeInTrue(5);
                        else MainGame.instructionNum = 1;
                        break;

                    case 6:
                        if (ScriptCount >= 6)
                            Item.ItemTakeInTrue(6);
                        else MainGame.instructionNum = 1;
                        break;

                    case 7:
                        if (ScriptCount >= 7)
                            Item.ItemTakeInTrue(7);
                        else MainGame.instructionNum = 1;
                        break;

                    case 8:
                        if (ScriptCount>=8)
                            Item.ItemTakeInTrue(8);
                        else MainGame.instructionNum = 1;
                        break;

                    default:
                        MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
                        break;
                }
            }
            else
            {
                MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            }
        }

        void map22Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {

            if (isCan)
            {
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 0:
                        //플레이어 인포
                        MainGame.mapNum = 2;
                        break;

                    case 1:
                        if (ScriptCount >= 1)
                            Item.ItemTakeInTrue(1);
                        else MainGame.instructionNum = 1;
                        break;

                    case 2:
                        if (ScriptCount >= 2)
                            Item.ItemTakeInTrue(2);
                        else MainGame.instructionNum = 1;
                        break;

                    case 3:
                        if (ScriptCount >= 3)
                            Item.ItemTakeInTrue(3);
                        else MainGame.instructionNum = 1;
                        break;

                    case 4:
                        if (ScriptCount >= 4)
                            Item.ItemTakeInTrue(4);
                        else MainGame.instructionNum = 1;
                        break;

                    case 5:
                        if (ScriptCount >= 5)
                            Item.ItemTakeInTrue(5);
                        else MainGame.instructionNum = 1;
                        break;

                    case 6:
                        if (ScriptCount >= 6)
                            Item.ItemTakeInTrue(6);
                        else MainGame.instructionNum = 1;
                        break;

                    case 7:
                        if (ScriptCount >= 7)
                            Item.ItemTakeInTrue(7);
                        else MainGame.instructionNum = 1;
                        break;

                    case 8:
                        if (ScriptCount >= 8)
                            Item.ItemTakeInTrue(8);
                        else MainGame.instructionNum = 1;
                        break;

                    default:
                        MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
                        break;
                }
            }
            else
            {
                MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            }
        }

        void map3Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {
            if (isCan)
            {
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 1:
                        //플레이어 인포
                        MainGame.mapNum = 0;
                        break;

                    case 2:
                        //플레이어 인포
                        MainGame.mapNum = 13;
                        break;

                    case 3:
                        //플레이어 인포
                        MainGame.mapNum = 23;
                        break;

                    default:
                        MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
                        break;
                }
            }
            else
            {
                MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            }
        }
        void map13Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {
            
            if (isCan)
            {
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 0:
                        //플레이어 인포
                        MainGame.mapNum = 3;
                        break;

                    case 1:
                        if(ScriptCount>=1)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    case 2:
                        if (ScriptCount>=2)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    case 3:
                        if (ScriptCount >= 3)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    case 4:
                        if (ScriptCount >= 4)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    case 5:
                        if (ScriptCount >= 5)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    case 6:
                        if (ScriptCount >= 6)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    case 7:
                        if (ScriptCount >= 7)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    case 8:
                        if (ScriptCount >= 8)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    default:
                        MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
                        break;
                }
            }
            else
            {
                MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            }
        }
        void map23Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {
            
            if (isCan)
            {
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 0:
                        //플레이어 인포
                        MainGame.mapNum = 3;
                        break;

                    case 1:
                        if ( ScriptCount >= 1)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    case 2:
                        if (ScriptCount >= 2)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    case 3:
                        if (ScriptCount >= 3)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    case 4:
                        if (ScriptCount >= 4)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    case 5:
                        if (ScriptCount >= 5)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    case 6:
                        if (ScriptCount >= 6)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    case 7:
                        if (ScriptCount >= 7)
                            Item.ItemHaveInTrue(playerChoice, mapNum );
                        else MainGame.instructionNum = 1;
                        break;

                    case 8:
                        if (ScriptCount >= 8)
                            Item.ItemHaveInTrue(playerChoice, mapNum);
                        else MainGame.instructionNum = 1;
                        break;

                    default:
                        MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
                        break;
                }
            }
            else
            {
                MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            }
        }

        void map4Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {
            if (isCan)
            {
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 1:
                        //플레이어 인포
                        MainGame.mapNum = 0;
                        break;

                    case 2:
                        //플레이어 인포
                        MainGame.mapNum = 14;
                        break;

                    default:
                        MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
                        break;
                }
            }
            else
            {
                MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            }
        }
        void map14Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {
            if (isCan)
            {
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 1:
                        //플레이어 인포
                        MainGame.mapNum = 0;
                        break;

                    default:
                        MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
                        break;
                }
            }
            else
            {
                MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            }
        }

        void map5Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {
            if (isCan)
            {
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 1:
                        //플레이어 인포
                        MainGame.mapNum = 0;
                        break;

                    case 2:
                        //플레이어 인포
                        MainGame.mapNum = 15;
                        break;

                    default:
                        MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
                        break;
                }
            }
            else
            {
                MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            }
        }
        void map15Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {
            if (isCan)
            {
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 1:
                        //플레이어 인포
                        MainGame.mapNum = 25;
                        break;

                    default:
                        MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
                        break;
                }
            }
            else
            {
                MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            }
        }
        void map25Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {
            if (isCan)
            {
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 1:
                        //플레이어 인포
                        MainGame.mapNum = 0;
                        break;

                    default:
                        MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
                        break;
                }
            }
            else
            {
                MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            }
        }

    }
}
