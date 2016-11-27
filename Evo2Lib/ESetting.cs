using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;


namespace Evo2Lib
{
    public static class ESetting
    {
        /*
        MAX_BIOS_COUNT=64 //  максимальное количество живности
END_BIOS_LIVE=8   // кол-во живых, что бы начинать новый цикл
BIO_SIZE=72
MIND_SIZE=64
MUTANT=2          // мутантов на 8 ботов
CHILD= (MAX_BIOS_COUNT / END_BIOS_LIVE)- MUTANT - 1
HEALTH_PLUS=10    // здоровья прибавляется от еды
HEALTH_MAX=90     // максимальное количество здоровья
FOOD=60           // количество еды на старте
YAD =60           // количество яда на старте
FOODYAD=2
grafTOP= 100000   // максимальная продолжительность жизни поколения
                  // при которой моделирование завершается
DELAY=0


// 0..63 мозг
    ADR= MIND_SIZE+0 // адрес команды
X_COORD= MIND_SIZE+1 // Х-координата
Y_COORD= MIND_SIZE+2 // У-координата
 HEALTH= MIND_SIZE+3 // здоровье
  GENER= MIND_SIZE+4 // пройденно поколений
 C_BLUE= MIND_SIZE+5 // цвет
C_GREEN= MIND_SIZE+6 // цвет
 TRANSF= MIND_SIZE+7 // направление
   
   
// out - 4 если пусто
//       3 если еда
//       2 если сородич
//       1 если стена
//       0 если яд    
        */

        public const int GRID_SIZE_X = 45;
        public const int GRID_SIZE_Y = 24;

        public const int BOT_COUNT_MAX = 64;
        public const int BOT_COUNT_MIN = 8;

        public const byte BOT_PROGRAM_SIZE = 64;
        public const byte BOT_COMMAND_SIZE = 64;
        public const int BOT_PROGRAM_STEP_MAX = 10;

        public const int BOT_HEALTH_MAX = 90;
        public const int BOT_HEALTH_FOOD = 10;
        public const int BOT_HEALTH_BIRTH = 35;


        //public const int FOOD_COUNT = 60;
        //public const int TOXIN_COUNT = 60;
        public const int FOOD_TOXIN_COUNT = 120;
        public const int FOOD_PROBABILITY = 50;





        public static MPoint[] ORIENTATIONS = new MPoint[Enum.GetValues(typeof(MOrientation)).Length];
        public static Color[] TRACE_COLOR = new Color[BOT_COUNT_MIN];

        public static Color[] GRAY_COLOR = new Color[256];



        static ESetting()
        {
            ORIENTATIONS[(int)MOrientation.TOP] = new MPoint(0, -1);
            ORIENTATIONS[(int)MOrientation.TOP_RIGHT] = new MPoint(1, -1);
            ORIENTATIONS[(int)MOrientation.RIGHT] = new MPoint(1, 0);
            ORIENTATIONS[(int)MOrientation.BOTTOM_RIGHT] = new MPoint(1, 1);
            ORIENTATIONS[(int)MOrientation.BOTTOM] = new MPoint(0, 1);
            ORIENTATIONS[(int)MOrientation.BOTTOM_LEFT] = new MPoint(-1, 1);
            ORIENTATIONS[(int)MOrientation.LEFT] = new MPoint(-1, 0);
            ORIENTATIONS[(int)MOrientation.TOP_LEFT] = new MPoint(-1, -1);

            TRACE_COLOR[0] = Color.Gold;
            TRACE_COLOR[1] = Color.Coral;
            TRACE_COLOR[2] = Color.Firebrick;
            TRACE_COLOR[3] = Color.GreenYellow;
            TRACE_COLOR[4] = Color.DeepSkyBlue;
            TRACE_COLOR[5] = Color.SaddleBrown;
            TRACE_COLOR[6] = Color.SeaGreen;
            TRACE_COLOR[7] = Color.Purple;


            for (int i = 0; i < 256; i++)
            {
                GRAY_COLOR[i] = Color.FromArgb(255, 255 - i, 255 - i, 255 - i);
            }


            return;
        }



    }
}
