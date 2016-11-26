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

        public EResultGeneration(EGrid grid)
        {
            generation = grid.generation;
        }



    }
}
