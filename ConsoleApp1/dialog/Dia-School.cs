using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRpgGame
{
    internal class Dia_School
    {
        public void SchoolRandomScript()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 4);

            switch (randomNumber)
            {
                case 0:
                    Console.WriteLine(" 어두운 세상, 밝지 않은 하늘." +
                        "\r\n 더이상 밝은 미래와 일상은 없습니다." +
                        "\r\n 남아있는 것은 비명소리와 알 수 없는 것들의 울음소리 뿐." +
                        "\r\n 당신은 이곳의 생존자입니다." +
                        "\r\n\r\n 학교 내부는 이미 여러번의 전투를 치뤘습니다." +
                        "\r\n 여러가지 물품 또한 구비되어 있지만, 충분하지 않습니다." +
                        "\r\n 이곳에서 전투를 대비하기 위한 행동을 할 수 있습니다." +
                        "\r\n\r\n 살아남기 위해서라면 무엇이든지 하십시오.\n");
                    break; 
                case 1:
                    Console.WriteLine(" 학교 안에 있는 학생들은 여전히 어수선합니다." +
                        "\r\n 당신도 그들과 같은 학생이지만, 그들 모두가 스스로 목숨을 유지할 수 있는 것은 아닙니다." +
                        "\r\n 모든 것은 당신의 생존을 위해 존재합니다." +
                        "\r\n 동정심을 가지지 마십시오.\n");
                    break;
                case 2:
                    Console.WriteLine("옆 건물에서 큰 소리가 울려퍼집니다. 당신은 급하게 몸을 일으킵니다." +
                        "\r\n복도 바깥은 소리지르는 학생, 도망치는 학생들은 무언가에게서 도망치고 있습니다." +
                        "\r\n당신은 불안한 마음을 감추지 못한 채 두 주먹을 꽉 쥐었습니다." +
                        "\r\n\r\n도망치는 학생들 사이를 가로질러 도착한 곳은." +
                        "\r\n흥건해진 복도와 말을 잇지 못하는 학생들," +
                        "\r\n무엇인가가 터진 듯이 벽면에 튀긴 자국," +
                        "\r\n우는 소리와 곡소리, 고통에 찬 신음소리가 뒤섞입니다." +
                        "\r\n\"어째서 우리에게만 이러한 일이 일어나는거야!!\"" +
                        "\r\n한 학생이 소리를 질러도 그 누구도 대답해주지 못합니다." +
                        "\r\n당신은 기다립니다." +
                        "\r\n\r\n둘러싸여 구경하거나 두려워하던 군중들이 하나 둘 사라져 아무도 남지 않았을 때," +
                        "\r\n당신은 축 늘어진 시체를 들어 창문 바깥으로 던집니다." +
                        "\r\n급격하게 밀려오는 어지럼증에 더욱 피곤함을 느낍니다.\n");
                    break;
                case 3:
                    Console.WriteLine("아직 아무 일도 일어나지 않았습니다.\r\n무소식이 희소식.\n");
                    break;
            }
        }
    }
}
