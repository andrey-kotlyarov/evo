using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EvoLib
{
    public class Grid
    {
        private Cell[,] cells;
        private List<Bot> bots;


        public Grid()
        {
            createCells();
            createBots();
            createFood();
            createToxin();

            return;
        }

        private void createCells()
        {
            cells = new Cell[Const.GRID_SIZE_X, Const.GRID_SIZE_Y];

            for (int x = 0; x < Const.GRID_SIZE_X; x++)
            {
                for (int y = 0; y < Const.GRID_SIZE_Y; y++)
                {
                    cells[x, y] = new Cell(this, x, y);

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
                } while (cells[x, y].content != CellContentType.EMPTY);

                Bot bot = new Bot(this, x, y);
                bots.Add(bot);

                cells[x, y].SetContent(CellContentType.BOT);
            }
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
                } while (cells[x, y].content != CellContentType.EMPTY);

                cells[x, y].SetContent(CellContentType.FOOD);
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
                } while (cells[x, y].content != CellContentType.EMPTY);

                cells[x, y].SetContent(CellContentType.TOXIN);
            }
        }





        public string ToMonoString()
        {
            string desc = "";

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

            desc += "\r\n\r\nCELLS";
            for (int x = 0; x < Const.GRID_SIZE_X; x++)
            {
                for (int y = 0; y < Const.GRID_SIZE_Y; y++)
                {
                    desc += "\r\n";
                    desc += cells[x, y].ToString();
                }
            }

            desc += "\r\n\r\nBOTS";
            foreach (Bot bot in bots)
            {
                desc += "\r\n";
                desc += bot.ToString();
            }

            return desc;
        }
    }
}
