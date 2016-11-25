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



        public int generation { get { return _generation; } }
        public int iteration { get { return _iteration; } }

        public ECell[,] cells { get { return _cells; } }
        public EBot[] bots { get { return _bots; } }

        public EHistory history { get { return _history; } }



        public EGrid()
        {
            createWalls();
            createBots();
            createFoodToxin(ESetting.FOOD_TOXIN_COUNT);
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

        private void createFoodToxin(int count)
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
                bots[i] = new EBot();
            }
        }

        private void recoveryBots()
        {

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
                    bot.DoRun();

                    if (!bot.alive)
                    {
                        cells[bot.point.x, bot.point.y].Clear();
                        createFoodToxin(1);
                    }
                }

                if (isGenerationComplete())
                {
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

            if (_generation == 100000 || false)
            {
                return true;
            }


            _generation += 1;
            _iteration = 0;

            clear();
            recoveryBots();
            createFoodToxin(ESetting.FOOD_TOXIN_COUNT);



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


        /*        
        
        public string ToMonoString()
        {
            string desc = "";

            desc += "GENERATION: " + generation.num;
            desc += "; ITERATION: " + generation.iteration;

            for (int y = 0; y < Const.GRID_SIZE_Y; y++)
            {
                desc += "\r\n";
                for (int x = 0; x < Const.GRID_SIZE_X; x++)
                {
                    if (cells[x, y].content == CellContentType.EMPTY)
                    {
                        desc += " ";
                    }
                    if (cells[x, y].content == CellContentType.WALL)
                    {
                        desc += "X";
                    }
                    if (cells[x, y].content == CellContentType.FOOD)
                    {
                        desc += "F";
                    }
                    if (cells[x, y].content == CellContentType.TOXIN)
                    {
                        desc += "T";
                    }
                    if (cells[x, y].content == CellContentType.BOT)
                    {
                        desc += "B";
                    }
                }
            }

            return desc;
        }

        public Bot GetBot(Cell cell)
        {
            Bot bot = null;

            if (generation != null)
            {
                foreach (Bot b in generation.bots)
                {
                    if (b.point == cell.point)
                    {
                        bot = b;
                        break;
                    }
                }
            }

            return bot;
        }

        public override string ToString()
        {
            string desc = base.ToString();

            desc += "GENERATION: " + generation.num;
            desc += "; ITERATION: " + generation.iteration;

            for (int y = 0; y < Const.GRID_SIZE_Y; y++)
            {
                desc += "\r\n";
                for (int x = 0; x < Const.GRID_SIZE_X; x++)
                {
                    if (cells[x, y].content == CellContentType.EMPTY)
                    {
                        desc += " ";
                    }
                    if (cells[x, y].content == CellContentType.WALL)
                    {
                        desc += "X";
                    }
                    if (cells[x, y].content == CellContentType.FOOD)
                    {
                        desc += "F";
                    }
                    if (cells[x, y].content == CellContentType.TOXIN)
                    {
                        desc += "T";
                    }
                    if (cells[x, y].content == CellContentType.BOT)
                    {
                        desc += "B";
                    }
                }
            }
            
            //desc += "\r\n\r\nCELLS";
            //for (int x = 0; x < Const.GRID_SIZE_X; x++)
            //{
            //    for (int y = 0; y < Const.GRID_SIZE_Y; y++)
            //    {
            //        desc += "\r\n";
            //        desc += cells[x, y].ToString();
            //    }
            //}
            

            desc += "\r\n\r\nBOTS";
            foreach (Bot bot in generation.bots)
            {
                desc += "\r\n";
                desc += bot.ToString();
            }

            return desc;
        }
        */

    }
}
