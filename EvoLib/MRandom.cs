using System;
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
            random = new Random();
        }


        public static int Next(int min, int max)
        {
            return random.Next(min, max);
        }

        public static int Next(int size)
        {
            return MRandom.Next(0, size - 1);
        }
    }
}
