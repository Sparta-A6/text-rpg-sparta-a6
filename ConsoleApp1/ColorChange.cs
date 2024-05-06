using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class ColorChange // 글자 색상 변경 함수
    {
        public static void ColorWriteLine(int color, string word) // 사용방법 - 함수 호출 + 1, 색상 코드  1~15 | 2, 글자 (string)
        {
            // Black = 0, DarkBlack = 1, DarkGreen = 2, DarkCyan = 3, DarkRed = 4, DarkMagenta = 5, DarkYellow = 6
            // Gray = 7, DarkGray = 8, Blue = 9, Green = 10, Cyan = 11, Red = 12, Magenta = 13, Yellow = 14, White  = 15

            Console.ForegroundColor = (ConsoleColor)color;
            Console.WriteLine(word);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void ColorWrite(int color, string word)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            Console.Write(word);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        // 오버로딩용 함수
        public static void ColorWriteLine(int color, int word) // 사용방법 - 함수 호출 + 1, 색상 코드  1~15 | 2, 글자 (string)
        {
            // Black = 0, DarkBlack = 1, DarkGreen = 2, DarkCyan = 3, DarkRed = 4, DarkMagenta = 5, DarkYellow = 6
            // Gray = 7, DarkGray = 8, Blue = 9, Green = 10, Cyan = 11, Red = 12, Magenta = 13, Yellow = 14, White  = 15

            Console.ForegroundColor = (ConsoleColor)color;
            Console.WriteLine(word);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        //오버로딩용 함수
        public static void ColorWrite(int color, int word)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            Console.Write(word);
            Console.ForegroundColor = ConsoleColor.Black;
        }

    }
}
