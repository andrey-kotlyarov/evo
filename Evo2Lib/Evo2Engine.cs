using System;
using System.Threading;



namespace Evo2Lib
{
    public class Evo2Engine
    {
        private EGrid _eGrid;

        private int _doDelay = 40;
        private int _doEventVia = 0;
        private bool _doPause = false;


        public void SetDelay(int delay)
        {
            _doDelay = delay;
        }
        public void SetEventVia(int eventVia)
        {
            _doEventVia = eventVia;
        }
        public void SetPause(bool pause)
        {
            _doPause = pause;
        }


        public event Action<int> OnGeneration_Started;
        public event Action<int, int, EGrid> OnGeneration_Completed;
        public event Action<int, int, EGrid> OnIteration_Completed;


        public Evo2Engine()
        {
            _eGrid = new EGrid();
        }

        public EGrid Work(CancellationToken token)
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();

                if (_doPause) continue;


                bool needEventForIteration = (_doEventVia == 0);
                bool needEventForGeneration = ((_doEventVia == 0) || (_doEventVia > 0 && _eGrid.generation % _doEventVia == 0));
                bool needDelay = false;
                
                if (_eGrid.iteration == 0 && needEventForGeneration)
                {
                    if (OnGeneration_Started != null) OnGeneration_Started(_eGrid.generation);
                    needDelay = true;
                }

                bool generation_completed = _eGrid.DoNextIteration();
                bool evo_completed = false;
                if (needEventForIteration)
                {
                    if (OnIteration_Completed != null) OnIteration_Completed(_eGrid.generation, _eGrid.iteration, _eGrid);
                    needDelay = true;
                }


                if (generation_completed)
                {
                    if (needEventForGeneration)
                    {
                        if (OnGeneration_Completed != null) OnGeneration_Completed(_eGrid.generation, _eGrid.iteration, _eGrid);
                        needDelay = true;
                    }

                    evo_completed = _eGrid.DoNextGeneration();
                }

                
                if (needDelay && _doDelay > 0)
                {
                    Thread.Sleep(_doDelay);
                }

                if (evo_completed)
                {
                    break;
                }
            }

            return _eGrid;
        }



    }
}
