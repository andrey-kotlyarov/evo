using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EvoLib
{
    public class Bot
    {
        private Grid grid;

        private MPoint point;
        //private MPoint course;
        private int courseIndex;

        private byte[] program;
        private byte address;


        public Bot(Grid _grid, int x, int y)
        {
            grid = _grid;

            point = new MPoint(x, y);
            //course = Const.COURSES[MRandom.Next(Const.COURSES.Length)];
            courseIndex = MRandom.Next(Const.COURSES.Length);

            program = new byte[64];
            address = 0;


        }

        public void DoProgram()
        {

        }



        public override string ToString()
        {
            string desc = base.ToString();

            //desc += " - x: " + point.x + "; y: " + point.y + "; cx: " + course.x + "; cy: " + course.y;
            desc += " - x: " + point.x + "; y: " + point.y + "; ci: " + courseIndex;

            return desc;
        }
    }
}
