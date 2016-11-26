using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Evo2Lib
{
    public struct EResultIteration
    {
        public int iteration;
        public int countBot;
        public int countFood;
        public int countToxin;
        public int countDieByToxin;
        public float averageHealth;


        public EResultIteration(EGrid grid)
        {
            iteration = grid.iteration;
            countBot = grid.CalcBots();
            Tuple<int,int> ft = grid.CalcFoodToxin();
            countFood = ft.Item1;
            countToxin = ft.Item2;

            countDieByToxin = grid.CalcDieByToxin();
            averageHealth = grid.AverageHealth();
        }


        public string ToShortString()
        {
            string desc = "";

            desc = String.Format(
                "B: {0}  |  F: {1}  |  T: {2}  |  DT: {3}  |  AH: {4}",
                countBot,
                countFood,
                countToxin,
                countDieByToxin,
                averageHealth.ToString("F1")
            );

            return desc;
        }

    }
}
