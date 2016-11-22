﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EvoLib
{
    public class Cell
    {
        private Grid grid;
        public MPoint point { get; private set; }
        public CellContentType content { get; private set; }
        //private Bot bot;


        public Cell(Grid _grid, int x, int y)
        {
            grid = _grid;
            point = new MPoint(x, y);
            content = CellContentType.EMPTY;
            //bot = null;
        }


        public bool SetContent(CellContentType newContent)
        {
            if (content == CellContentType.EMPTY)
            {
                content = newContent;
                return true;
            }
            
            return false;
        }



        public override string ToString()
        {
            string desc = base.ToString();

            desc += " - X: " + point.x + "; Y: " + point.y + "; C: " + content.ToString();

            return desc;
        }

    }
}
