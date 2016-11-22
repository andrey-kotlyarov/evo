using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EvoLib
{
    public class Bot
    {
        private MPoint point;
        //private MPoint course;
        private OrientationType courseOrientation;

        private byte[] program;
        private byte address;


        public Bot(int x, int y)
        {
            point = new MPoint(x, y);
            //course = Const.COURSES[MRandom.Next(Const.COURSES.Length)];
            courseOrientation = (OrientationType)MRandom.Next(Enum.GetValues(typeof(OrientationType)).Length);
            
            generateProgram();


        }

        private void generateProgram()
        {
            address = 0;
            program = new byte[Const.BOT_PROGRAM_SIZE];


            program[0] = 1;
            program[1] = 1;
            program[2] = 1;
            program[3] = 1;
            program[4] = 1;
            program[5] = 1;
            program[6] = 1;
            program[7] = 1;
            //TODO
        }

        public void DoProgram()
        {

        }



        public override string ToString()
        {
            string desc = base.ToString();

            //desc += " - x: " + point.x + "; y: " + point.y + "; cx: " + course.x + "; cy: " + course.y;
            //desc += " - x: " + point.x + "; y: " + point.y + "; ci: " + courseOrientation.ToString();
            desc += " - (" + point.x + ", " + point.y + ", " + courseOrientation.ToString() + ")";


            desc += "; prog: ";
            for (int i = 0; i < Const.BOT_PROGRAM_SIZE; i++)
            {
                
                if (i == address)
                {
                    desc += "[" + program[i] + "] ";
                }
                else
                {
                    desc += program[i] + " ";
                }
            }

            return desc;
        }
    }
}
