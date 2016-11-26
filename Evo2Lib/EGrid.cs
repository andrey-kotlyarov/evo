using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Evo2Lib
{
    public class EGrid
    {
        private int _generation = 0;
        private int _iteration = 0;

        private ECell[,] _cells = new ECell[ESetting.GRID_SIZE_X, ESetting.GRID_SIZE_Y];
        private EBot[] _bots = new EBot[ESetting.BOT_COUNT_MAX];

        private EHistory _history = new EHistory();

        private int[] _recoveryIndex = new int[ESetting.BOT_COUNT_MIN];



        public int generation { get { return _generation; } }
        public int iteration { get { return _iteration; } }

        public ECell[,] cells { get { return _cells; } }
        public EBot[] bots { get { return _bots; } }

        public EHistory history { get { return _history; } }



        public EGrid()
        {
            createWalls();
            createBots();
            CreateFoodToxin(ESetting.FOOD_TOXIN_COUNT);
        }

        

        private void createWalls()
        {
            for (int x = 0; x < ESetting.GRID_SIZE_X; x++)
            {
                for (int y = 0; y < ESetting.GRID_SIZE_Y; y++)
                {
                    cells[x, y] = new ECell(x, y);

                    if (x == 0 || x == (ESetting.GRID_SIZE_X - 1) || y == 0 || y == (ESetting.GRID_SIZE_Y - 1))
                    {
                        cells[x, y].SetType(ECellType.WALL);
                    }

                    if (x == 9 && y >= 1 && y <= 7)
                    {
                        cells[x, y].SetType(ECellType.WALL);
                    }

                    if (x == 20 && y >= 8 && y <= 14)
                    {
                        cells[x, y].SetType(ECellType.WALL);
                    }
                }
            }
        }

        public void CreateFoodToxin(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ECell cell = selectEmptyCell();

                bool isFood = MRandom.Probability(ESetting.FOOD_PROBABILITY);
                cell.SetType(isFood ? ECellType.FOOD : ECellType.TOXIN);
            }
        }

        private void createBots()
        {
            for (int i = 0; i < bots.Length; i++)
            {
                ECell cell = selectEmptyCell();
                bots[i] = new EBot(cell);
            }
        }

        private void recoveryBots()
        {
            
            int j = 0;
            //for (int i = 0; i < ESetting.BOT_COUNT_MAX; i++)
            for (int i = 0; i < bots.Length; i++)
            {
                if (bots[i].alive)
                {
                    bots[i].DoRecovery(selectEmptyCell());

                    _recoveryIndex[j] = i;
                    j++;
                }
            }
            
            int k = 0;
            for (int i = 0; i < bots.Length; i++)
            {
                if (!bots[i].alive)
                {
                    bots[i].DoRecovery(selectEmptyCell(), bots[_recoveryIndex[k % ESetting.BOT_COUNT_MIN]]);
                    
                    if (k >= 0 && k < 8) { }
                    if (k >= 8 && k < 16) { bots[i].DoMutation(1); }
                    if (k >= 16 && k < 24) { }
                    if (k >= 24 && k < 32) { bots[i].DoMutation(1); }
                    if (k >= 32 && k < 40) { }
                    if (k >= 40 && k < 48) { bots[i].DoMutation(1); }
                    
                    k += 1;
                }
            }

            for (int i = 0; i < bots.Length; i++)
            {
                bots[i].DoClearCalls();
            }

            return;
        }


        private ECell selectEmptyCell()
        {
            ECell cell;
            
            do
            {
                cell = cells[MRandom.Next(1, ESetting.GRID_SIZE_X - 2), MRandom.Next(1, ESetting.GRID_SIZE_Y - 2)];
            }
            while (cell.type != ECellType.EMPTY);

            return cell;
        }


        private void clear()
        {
            for (int x = 0; x < ESetting.GRID_SIZE_X; x++)
            {
                for (int y = 0; y < ESetting.GRID_SIZE_Y; y++)
                {
                    cells[x, y].Clear();
                }
            }
        }





        public bool DoNextIteration()
        {
            /*
            //DEBUG
            return (++_iteration == 1000);
            */


            _iteration++;


            for (int i = 0; i < bots.Length; i++)
            {
                EBot bot = bots[i];

                if (bot.alive)
                {
                    bot.DoRun(this);

                    if (!bot.alive) { cells[bot.point.x, bot.point.y].Clear(); }
                }

                if (isGenerationComplete())
                {
                    _history.Add(this);
                    return true;
                }
            }
            
            return false;
        }

        public bool DoNextGeneration()
        {

            /*
            //DEBUG
            if (_generation == 1000)
            {
                return true;
            }

            _generation += 1;
            _iteration = 0;
            
            return false;
            */

            if (_generation == 100000 && false)
            {
                return true;
            }


            _generation += 1;
            _iteration = 0;

            clear();
            recoveryBots();
            CreateFoodToxin(ESetting.FOOD_TOXIN_COUNT);



            return false;
        }







        private bool isGenerationComplete()
        {
            return (CalcBots() <= ESetting.BOT_COUNT_MIN);
        }



        public int CalcBots()
        {
            int count = 0;

            for (int i = 0; i < bots.Length; i++)
            {
                count += (bots[i].alive ? 1 : 0);
            }

            return count;
        }


        public Tuple<int, int> CalcFoodToxin()
        {
            int countF = 0;
            int countT = 0;

            for (int x = 0; x < ESetting.GRID_SIZE_X; x++)
            {
                for (int y = 0; y < ESetting.GRID_SIZE_Y; y++)
                {
                    countF += (cells[x, y].type == ECellType.FOOD ? 1 : 0);
                    countT += (cells[x, y].type == ECellType.TOXIN ? 1 : 0);
                }
            }

            return new Tuple<int, int>(countF, countT);
        }
        
        public int CalcDieByToxin()
        {
            int count = 0;

            for (int i = 0; i<bots.Length; i++)
            {
                count += (bots[i].dieByToxin ? 1 : 0);
            }

            return count;
        }

        public float AverageHealth()
        {
            int sum = 0;
            int count = 0;

            for (int i = 0; i < bots.Length; i++)
            {
                if (bots[i].alive)
                {
                    count += 1;
                    sum += bots[i].health;
                }
            }

            return (float)(1F * sum / count);
        }


    }
}
