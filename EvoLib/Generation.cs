using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EvoLib
{
    public class Generation
    {
        public int num { get; private set; }
        public int iteration { get; private set; }
        public List<Bot> bots { get; private set; }



        public Generation(Generation parentGeneration)
        {
            num = (parentGeneration != null ? parentGeneration.num + 1 : 0);

            iteration = 0;
            
            createBots();
            createFood();
            createToxin();

            return;
        }

        private void createBots()
        {
            bots = new List<Bot>();

            int x;
            int y;

            for (int i = 0; i < Const.BOT_COUNT_MAX; i++)
            {
                do
                {
                    x = MRandom.Next(1, Const.GRID_SIZE_X - 2);
                    y = MRandom.Next(1, Const.GRID_SIZE_Y - 2);

                } while (Grid.CurrentGrid.cells[x, y].content != CellContentType.EMPTY);

                Bot bot = new Bot(x, y, 1);
                bots.Add(bot);

                Grid.CurrentGrid.cells[x, y].SetContent(CellContentType.BOT);
            }

            return;
        }

        private void createFood()
        {
            int x;
            int y;

            for (int i = 0; i < Const.FOOD_COUNT; i++)
            {
                do
                {
                    x = MRandom.Next(1, Const.GRID_SIZE_X - 2);
                    y = MRandom.Next(1, Const.GRID_SIZE_Y - 2);

                } while (Grid.CurrentGrid.cells[x, y].content != CellContentType.EMPTY);

                Grid.CurrentGrid.cells[x, y].SetContent(CellContentType.FOOD);
            }
        }

        private void createToxin()
        {
            int x;
            int y;

            for (int i = 0; i < Const.TOXIN_COUNT; i++)
            {
                do
                {
                    x = MRandom.Next(1, Const.GRID_SIZE_X - 2);
                    y = MRandom.Next(1, Const.GRID_SIZE_Y - 2);

                } while (Grid.CurrentGrid.cells[x, y].content != CellContentType.EMPTY);

                Grid.CurrentGrid.cells[x, y].SetContent(CellContentType.TOXIN);
            }
        }




        public bool NeedNextIteration()
        {
            //DEBUG
            return iteration < 7;

            return (bots.Count > Const.BOT_COUNT_MIN);
        }


        public void NextIteration()
        {
            iteration++;
            //TODO
        }



    }
}
