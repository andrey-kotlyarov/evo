using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Evo2Lib
{
    public struct EResultGenerationBot
    {
        public int generation;
        public int health;
        public string checkSum;

        public EResultGenerationBot(EBot bot)
        {
            generation = bot.generation;
            health = bot.health;
            checkSum = bot.checkSum;
        }
    }
}
