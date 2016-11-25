using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Evo2Lib
{
    public class EGrid
    {
        private int _generation;
        private int _iteration;

        public int generation { get { return _generation; } }
        public int iteration { get { return _iteration; } }



        public EGrid()
        {
            _generation = 0;
            _iteration = 0;
        }

        public bool DoNextIteration()
        {
            //DEBUG
            return (++_iteration == 1000);
        }

        public bool DoNextGeneration()
        {
            if (_generation == 1000)
            {
                return true;
            }

            _generation += 1;
            _iteration = 0;
            
            return false;
        }



        /*
        public bool IsComlpleted()
        {
            //DEBUG
            return _generation == 3;
        }
        */
        
    }
}
