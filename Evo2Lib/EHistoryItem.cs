﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo2Lib
{
    public struct EHistoryItem
    {
        public int generation;
        public int iteration;
        public int countDieByToxin;
        public float averageHealth;



        public EHistoryItem(EGrid grid)
        {
            generation = grid.generation;
            iteration = grid.iteration;

            countDieByToxin = grid.CalcDieByToxin();
            averageHealth = grid.AverageHealth();
        }

        public string ToShortString()
        {
            string desc = "";

            desc = String.Format(
                "{0}  /  T: {1}  :  AH: {2}",
                iteration,
                countDieByToxin,
                averageHealth.ToString("F1")
            );

            return desc;
        }
    }
}
