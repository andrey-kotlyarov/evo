using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EvoLib
{
    public static class Const
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

        public const int FOOD_COUNT = 60;
        public const int TOXIN_COUNT = 60;

        public static MPoint[] COURSES = { new MPoint(0, 1), new MPoint(1, 1), new MPoint(1, 0), new MPoint(1, -1), new MPoint(0, -1), new MPoint(-1, -1), new MPoint(-1, 0), new MPoint(-1, 1) };






    }
}
