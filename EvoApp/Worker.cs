using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace EvoApp
{
    public class Worker
    {
        public event Action<int> ProcessChanged;

        /*
        private bool _cancelled;

        public void Cancel()
        {

            _cancelled = true;
        }
        */

        public int Work(CancellationToken token)
        {
            for (int i = 0; i <= 99; i++)
            {
                /*
                if (_cancelled)
                {
                    break;
                }
                */

                //if (token.IsCancellationRequested) { break; } // неправильно (не будет статус у таска установлен в Cancelled)

                token.ThrowIfCancellationRequested();

                Thread.Sleep(75);

                if (i == 20)
                {
                    //throw new Exception("My exception 20");
                }


                OnProcessChanged(i);
            }

            return 5;
        }


        

        public void OnProcessChanged(int i)
        {
            if (ProcessChanged != null)
            {
                ProcessChanged(i);
            }
        }
    }
}
