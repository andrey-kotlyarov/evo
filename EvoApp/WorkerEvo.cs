using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using EvoLib;



namespace EvoApp
{
    public class WorkerEvo
    {
        private int delay = 100;
        private bool enabledIteration = true;

        public void SetDelay(int _delay)
        {
            delay = _delay;
        }

        public void SetIterationEnabled(bool _enabledIteration)
        {
            enabledIteration = _enabledIteration;
        }


        public event Action<int> NextIteration;
        public event Action<int> NextGeneration;

        public void OnNextIteration(int i)
        {
            if (NextIteration != null) NextIteration(i);
        }
        public void OnNextGeneration(int i)
        {
            if (NextGeneration != null) NextGeneration(i);
        }





        public int Work(CancellationToken token)
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();

                if (enabledIteration)
                {
                    Grid.CurrentGrid.NextIteration();

                    OnNextIteration(1);
                    
                    if (Grid.CurrentGrid.generation.iteration == 0)
                    {
                        OnNextGeneration(1);
                    }
                }
                else
                {
                    Grid.CurrentGrid.NextGeneration();
                    OnNextGeneration(1);
                }

                if (Grid.CurrentGrid.IsFinished)
                {
                    break;
                }

                Thread.Sleep(delay);
            }

            return 0;
        }

    }
}
