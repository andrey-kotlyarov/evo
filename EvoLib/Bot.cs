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

        private int health;

        private byte[] program;
        private byte address;


        public Bot(int x, int y)
        {
            point = new MPoint(x, y);
            //course = Const.COURSES[MRandom.Next(Const.COURSES.Length)];
            courseOrientation = (OrientationType)MRandom.Next(Enum.GetValues(typeof(OrientationType)).Length);

            health = Const.BOT_HEALTH_BIRTH;

            generateProgram();


        }

        private void generateProgram()
        {
            address = 0;
            program = new byte[Const.BOT_PROGRAM_SIZE];



            program[0] = 1;
            program[1] = 1;
            program[2] = 1;
            program[3] = 2;
            program[4] = 2;
            program[5] = 2;
            program[6] = 3;
            program[7] = 4;
            //TODO
        }

        public void DoRun()
        {
            int step = 0;

            while (step < Const.BOT_PROGRAM_STEP_MAX)
            {
                doCommand();
            }

        }

        private int doCommand()
        {
            int step = 1;
            byte command = program[address];

            if (command < 24)
            {
                MPoint targetPoint = Const.ORIENTATIONS[((int)courseOrientation + (command % 8)) % 8];
                Cell targetCell = Grid.CurrentGrid.cells[targetPoint.x, targetPoint.y];

                if (command < 8)
                {
                    //ШАГНУТЬ
                    //TODO
                    step = Const.BOT_PROGRAM_STEP_MAX;
                }
                else if (command < 16)
                {
                    //ВЗЯТЬ ЕДУ / ПРЕОБРАЗОВАТЬ ЯД
                    //TODO
                    step = Const.BOT_PROGRAM_STEP_MAX;
                }
                else if (command < 24)
                {
                    //ПОСМОТРЕТЬ
                    //TODO
                }

                
                address += (byte)targetCell.content;
            }
            else if (command < 32)
            {
                //ПОВЕРНУТЬСЯ
                //TODO
                address += 1;
            }
            else
            {
                address += command;
            }

            address = (byte)(address % Const.BOT_PROGRAM_SIZE);

            return step;
        }



        public override string ToString()
        {
            string desc = base.ToString();

            //desc += " - x: " + point.x + "; y: " + point.y + "; cx: " + course.x + "; cy: " + course.y;
            //desc += " - x: " + point.x + "; y: " + point.y + "; ci: " + courseOrientation.ToString();
            desc += " - (" + point.x + "," + point.y + "," + courseOrientation.ToString() + ")";
            desc += "; h:" + health;

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
