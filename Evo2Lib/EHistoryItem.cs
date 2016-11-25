using System;
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

        public EHistoryItem(EGrid grid)
        {
            generation = grid.generation;
            iteration = grid.iteration;
        }
    }
}
