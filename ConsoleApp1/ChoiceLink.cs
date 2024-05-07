using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
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

                case 6:
                    map6Choice(mapNumber, isCan, playerChoice, ScriptCount);
                    break;
                case 16:
                    map16Choice(mapNumber, isCan, playerChoice, ScriptCount);
                    break;
                case 26:
                    map26Choice(mapNumber, isCan, playerChoice, ScriptCount);
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

                    case 6:
                        //주변 탐색
                        MainGame.mapNum = 6;
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
                    case 0 :
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
                    case 0 :
                        MainGame.mapNum = 0;
                        break;

                    case  1 :
                        MainGame.mapNum = 12;
                        break;

                    case 2 :
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
                    case 9:
                        if (Map.itemKategorie == ItemKategorie.Weapon) Map.itemKategorie = ItemKategorie.Armor;
                        else if (Map.itemKategorie == ItemKategorie.Armor) Map.itemKategorie = ItemKategorie.Weapon;
                        break;

                    case 0:
                        //플레이어 인포
                        MainGame.mapNum = 2;
                        break;


                    default:
                        if (ScriptCount >= playerChoice)
                        {
                            switch (Map.itemKategorie)
                            {
                                case ItemKategorie.Weapon:
                                    WeaponItem.ItemTakeInTrue(playerChoice);
                                    break;
                                case ItemKategorie.Armor:
                                    DefenseItem.ItemTakeInTrue(playerChoice);
                                    break;
                            }
                        }
                        else MainGame.instructionNum = 1;
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

                    default:
                        if (ScriptCount >= playerChoice)
                            UseItem.UseItemHaveCount(playerChoice);
                        else MainGame.instructionNum = 1;
                        break;// 지시 : 올바른 값 입력
                        
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
                    case 0: //돌아가기
                        MainGame.mapNum = 0;
                        break;

                    case 1:
                        MainGame.mapNum = 13;
                        break;

                    case 2:
                        MainGame.mapNum = 23;
                        break;

                    case 9:
                        if (Map.itemKategorie == ItemKategorie.Weapon) Map.itemKategorie = ItemKategorie.Armor;
                        else if (Map.itemKategorie == ItemKategorie.Armor) Map.itemKategorie = ItemKategorie.Used;
                        else if (Map.itemKategorie == ItemKategorie.Used) Map.itemKategorie = ItemKategorie.Weapon;
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

                    default:
                        if (ScriptCount >= playerChoice)
                            switch (Map.itemKategorie) //만약 아이템 카테고리가 ~~이라면
                            {
                                case ItemKategorie.Weapon:
                                    WeaponItem.ItemHaveInTrue(playerChoice, mapNum);
                                    break;
                                case ItemKategorie.Armor:
                                    DefenseItem.ItemHaveInTrue(playerChoice, mapNum);
                                    break;
                                case ItemKategorie.Used:
                                    UseItem.ItemHaveInTrue(playerChoice, mapNum);
                                    break;
                            }
                        else MainGame.instructionNum = 1;
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

                    default:
                        if (ScriptCount >= playerChoice)
                            switch (Map.itemKategorie) //만약 아이템 카테고리가 ~~이라면
                            {
                                case ItemKategorie.Weapon:
                                    WeaponItem.ItemHaveInTrue(playerChoice, mapNum);
                                    break;
                                case ItemKategorie.Armor:
                                    DefenseItem.ItemHaveInTrue(playerChoice, mapNum);
                                    break;
                                case ItemKategorie.Used:
                                    UseItem.ItemHaveInTrue(playerChoice, mapNum);
                                    break;
                            }
                        else MainGame.instructionNum = 1;
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
                    case 0:
                        //플레이어 인포
                        MainGame.mapNum = 0;
                        break;

                    case 1:
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
                    case 0:
                        //플레이어 인포
                        MainGame.mapNum = 0;
                        break;

                    case 1:
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
        void map6Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {
            if (isCan)
            {               
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 1:
                        MainGame.mapNum = 0;
                        break;

                    case 2:
                        Random random = new Random();
                        int randomChoice = random.Next(1, 3);
                        switch (randomChoice)
                        {
                            case 1:
                                MainGame.mapNum = 16;
                                break;
                            case 2:
                                MainGame.mapNum = 26;
                                break;
                        }
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
        void map16Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {
            //if (isCan)
            //{
            //    MainGame.instructionNum = 0;
            //    switch (playerChoice)
            //    {
            //        case 1:
            //            MainGame.mapNum = 0;
            //            break;
                    
            //        default:
            //            MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            //            break;
            //    }
            //}
            //else
            //{
            //    MainGame.instructionNum = 1; // 지시 : 올바른 값 입력
            //}
        }
        void map26Choice(int mapNum, bool isCan, int playerChoice, int ScriptCount)
        {
            if (isCan)
            {
                MainGame.instructionNum = 0;
                switch (playerChoice)
                {
                    case 1:
                        MainGame.mapNum = 0;
                        break;

                    case 2:
                        Random random = new Random();
                        int randomChoice = random.Next(1, 3);
                        switch (randomChoice)
                        {
                            case 1:
                                MainGame.mapNum = 16;
                                break;
                            case 2:
                                MainGame.mapNum = 26;
                                break;
                        }
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
