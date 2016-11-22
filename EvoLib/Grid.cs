using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EvoLib
{
    public class Grid
    {
        private static Grid instance = null;

        public static Grid CurrentGrid
        {
            get
            {
                if (instance == null)
                {
                    instance = new Grid();
                }

                return instance;
            }
        }



        public Cell[,] cells { get; private set; }
        private Dictionary<int, Generation> generations = new Dictionary<int, Generation>();
        private Generation generation = null;

        //private List<Bot> bots;

        
        private Grid() { }

        


        public void CreateGrid()
        {
            cells = new Cell[Const.GRID_SIZE_X, Const.GRID_SIZE_Y];

            for (int x = 0; x < Const.GRID_SIZE_X; x++)
            {
                for (int y = 0; y < Const.GRID_SIZE_Y; y++)
                {
                    cells[x, y] = new Cell(x, y);

                    if (x == 0 || x == (Const.GRID_SIZE_X - 1) || y == 0 || y == (Const.GRID_SIZE_Y - 1))
                    {
                        cells[x, y].SetContent(CellContentType.WALL);
                    }

                    if (x == 9 && y >= 1 && y <= 7)
                    {
                        cells[x, y].SetContent(CellContentType.WALL);
                    }

                    if (x == 20 && y >= 8 && y <= 14)
                    {
                        cells[x, y].SetContent(CellContentType.WALL);
                    }
                }
            }

            NextGeneration();
        }

        private void clearGrid()
        {
            for (int x = 0; x < Const.GRID_SIZE_X; x++)
            {
                for (int y = 0; y < Const.GRID_SIZE_Y; y++)
                {
                    cells[x, y].Clear();
                }
            }
        }

        public void NextGeneration()
        {
            clearGrid();

            /*
            int num = (generation == null ? 1 : generation.num + 1);
            generation = new Generation(num);
            generations.Add(num, generation);
            */
            generation = new Generation(generation);
            generations.Add(generation.num, generation);

            return;
        }

        public void NextIteration()
        {
            generation.NextIteration();
            return;
        }
        





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
            /*
            desc += "\r\n\r\nCELLS";
            for (int x = 0; x < Const.GRID_SIZE_X; x++)
            {
                for (int y = 0; y < Const.GRID_SIZE_Y; y++)
                {
                    desc += "\r\n";
                    desc += cells[x, y].ToString();
                }
            }
            */

            desc += "\r\n\r\nBOTS";
            foreach (Bot bot in generation.bots)
            {
                desc += "\r\n";
                desc += bot.ToString();
            }

            return desc;
        }
    }
}
