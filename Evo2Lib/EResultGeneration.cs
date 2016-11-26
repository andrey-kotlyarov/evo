using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Evo2Lib
{
    public struct EResultGeneration
    {
        public int generation;
        public List<EResultGenerationBot> resultBots;


        public EResultGeneration(EGrid grid)
        {
            generation = grid.generation;
            resultBots = new List<EResultGenerationBot>();
            
            foreach (EBot bot in grid.bots)
            {
                if (bot.alive)
                {
                    resultBots.Add(new EResultGenerationBot(bot));
                }
            }

            resultBots.Sort(
                delegate (EResultGenerationBot b1, EResultGenerationBot b2)
                {
                    int compare = b2.generation.CompareTo(b1.generation);

                    if (compare == 0) compare = b2.health.CompareTo(b1.health);

                    return compare;
                }
            );
        }


        public string ToShortString()
        {
            string desc = "";

            foreach (EResultGenerationBot resultBot in resultBots)
            {
                desc += desc.Length == 0 ? "" : " | ";
                desc += "G: " + resultBot.generation + " H: " + resultBot.health;
            }

            return desc;
        }


    }
}
