﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoLib
{
    public static class MRandom
    {
        private static Random random;

        static MRandom()
        {
            random = new Random(1);
        }


        public static int Next(int min, int max)
        {
            return random.Next(min, max);
        }

        public static int Next(int size)
        {
            //return MRandom.Next(0, size - 1);
            return MRandom.Next(0, size);
        }

        public static bool Probability(int percent)
        {
            int p = MRandom.Next(100);
            return (p < percent);
        }
    }
}
