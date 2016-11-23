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
            
            createBots((parentGeneration != null ? parentGeneration.bots : null));

            //createFood();
            //createToxin();
            CreateFoodToxin(Const.FOOD_TOXIN_COUNT);

            return;
        }

        private void createBots(List<Bot> parentBots)
        {
            bots = new List<Bot>();

            int x;
            int y;



            for (int i = 0; i < Const.BOT_COUNT_MAX; i++)
            {
                do
                {
                    x = MRandom.Next(1, Const.GRID_SIZE_X - 1);
                    y = MRandom.Next(1, Const.GRID_SIZE_Y - 1);

                } while (Grid.CurrentGrid.cells[x, y].content != CellContentType.EMPTY);



                Bot bot;
                if (parentBots != null)
                {
                    bot = new Bot(x, y, parentBots[i % Const.BOT_COUNT_MIN]);
                }
                else
                {
                    bot = new Bot(x, y);
                }

                //if (i >= 40 && i < 48) bot.DoMutation(1);
                if (i >= 48 && i < 56) bot.DoMutation(1);
                if (i >= 56 && i < 64) bot.DoMutation(1);


                bots.Add(bot);
                Grid.CurrentGrid.cells[x, y].SetContent(CellContentType.BOT);
            }

            
            return;
        }

        /*
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
        */

        public void CreateFoodToxin(int count)
        {
            int x;
            int y;

            for (int i = 0; i < count; i++)
            {
                do
                {
                    x = MRandom.Next(1, Const.GRID_SIZE_X - 2);
                    y = MRandom.Next(1, Const.GRID_SIZE_Y - 2);

                } while (Grid.CurrentGrid.cells[x, y].content != CellContentType.EMPTY);

                bool isFood = MRandom.Probability(50);
                Grid.CurrentGrid.cells[x, y].SetContent(isFood ? CellContentType.FOOD : CellContentType.TOXIN);
            }
        }




        public bool NextIteration()
        {
            iteration++;

            
            for (int i = 0; i < bots.Count; i++)
            {
                Bot bot = bots[i];
                bot.DoRun();

                if (bot.health <= 0)
                {
                    Cell currentCell = Grid.CurrentGrid.cells[bot.point.x, bot.point.y];
                    currentCell.Clear();

                    bots.Remove(bot);
                    i--;
                }

                if (!needContinue())
                {
                    return false;
                }
            }
            
            return true;
        }



        private bool needContinue()
        {
            return (bots.Count > Const.BOT_COUNT_MIN);
        }

        


    }
}
