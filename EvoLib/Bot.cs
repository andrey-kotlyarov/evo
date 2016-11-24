using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EvoLib
{
    public class Bot
    {
        public MPoint point { get; private set; }
        
        public OrientationType courseOrientation { get; private set; }

        public int health { get; private set; }

        public int iteration { get; private set; }
        public int age { get; private set; }

        public byte[] program { get; private set; }
        public int[] cmd_calls { get; private set; }
        public byte address { get; private set; }



        public bool dieByToxin { get; private set; }


        public Bot(int x, int y) : this(x, y, null) { }

        public Bot(int x, int y, Bot parentBot)
        {
            point = new MPoint(x, y);

            //DEBUG
            //courseOrientation = OrientationType.TOP;
            courseOrientation = (OrientationType)MRandom.Next(Enum.GetValues(typeof(OrientationType)).Length);

            health = Const.BOT_HEALTH_BIRTH;
            iteration = 0;
            age = (parentBot != null ? parentBot.age + 1 : 1);

            generateProgram(parentBot);

            dieByToxin = false;

            return;
        }

        


        private void generateProgram(Bot parentBot)
        {
            address = 0;
            program = new byte[Const.BOT_PROGRAM_SIZE];
            cmd_calls = new int[Const.BOT_PROGRAM_SIZE];


            for (int i = 0; i < Const.BOT_PROGRAM_SIZE; i++) cmd_calls[i] = 0;
            if (parentBot != null)
            {
                for (int i = 0; i < Const.BOT_PROGRAM_SIZE; i++) program[i] = parentBot.program[i];
            }
            else
            {
                //DEBUG
                //for (int i = 0; i < Const.BOT_PROGRAM_SIZE; i++) program[i] = (byte)MRandom.Next(24);
                for (int i = 0; i < Const.BOT_PROGRAM_SIZE; i++) program[i] = (byte)MRandom.Next(Const.BOT_COMMAND_SIZE);
            }

            return;
        }


        public void DoMutation(int count, Bot parentBot)
        {
            for (int i = 0; i < count; i++)
            {
                byte addr;
                byte cmd = (byte)MRandom.Next(Const.BOT_COMMAND_SIZE);

                do
                {
                    addr = (byte)MRandom.Next(Const.BOT_PROGRAM_SIZE);
                }
                while (parentBot.cmd_calls[addr] == 0);

                //cmd = (byte)((program[addr] + cmd) % Const.BOT_COMMAND_SIZE);
                program[addr] = cmd;
            }

            address = 0;
            age = 1;
        }


        public void DoRun()
        {
            int step = 0;

            health -= 1;

            while (step < Const.BOT_PROGRAM_STEP_MAX)
            {
                step += doCommand();
            }

            iteration += 1;
        }

        private int doCommand()
        {
            int step = 1;
            byte command = program[address];

            cmd_calls[address] = cmd_calls[address] + 1;

            if (command < 24)
            {
                Cell currentCell = Grid.CurrentGrid.cells[point.x, point.y];

                MPoint targetPoint = point + Const.ORIENTATIONS[((int)courseOrientation + (command % 8)) % 8];
                Cell targetCell = Grid.CurrentGrid.cells[targetPoint.x, targetPoint.y];

                address += (byte)targetCell.content;

                if (command < 8)
                {
                    //
                    // ШАГНУТЬ
                    //
                    /*
                    if (targetCell.content == CellContentType.BOT) { }
                    if (targetCell.content == CellContentType.EMPTY) { }
                    if (targetCell.content == CellContentType.FOOD) { }
                    if (targetCell.content == CellContentType.TOXIN) { }
                    if (targetCell.content == CellContentType.WALL) { }
                    */


                    if (targetCell.content == CellContentType.EMPTY)
                    {
                        point = targetPoint;
                        currentCell.Clear();
                        targetCell.Clear();
                        targetCell.SetContent(CellContentType.BOT);
                    }
                    else if (targetCell.content == CellContentType.FOOD)
                    {
                        health = Math.Min(health + Const.BOT_HEALTH_FOOD, Const.BOT_HEALTH_MAX);
                        Grid.CurrentGrid.generation.CreateFoodToxin(1);

                        point = targetPoint;
                        currentCell.Clear();
                        targetCell.Clear();
                        targetCell.SetContent(CellContentType.BOT);
                    }
                    else if (targetCell.content == CellContentType.TOXIN)
                    {
                        health = 0;
                        dieByToxin = true;
                        Grid.CurrentGrid.generation.CreateFoodToxin(1);

                        point = targetPoint;
                        currentCell.Clear();
                        targetCell.Clear();
                        targetCell.SetContent(CellContentType.BOT);
                    }
                    

                    step = Const.BOT_PROGRAM_STEP_MAX;
                }
                else if (command < 16)
                {
                    //
                    // ВЗЯТЬ ЕДУ / ПРЕОБРАЗОВАТЬ ЯД
                    //
                    /*
                    if (targetCell.content == CellContentType.BOT) { }
                    if (targetCell.content == CellContentType.EMPTY) { }
                    if (targetCell.content == CellContentType.FOOD) { }
                    if (targetCell.content == CellContentType.TOXIN) { }
                    if (targetCell.content == CellContentType.WALL) { }
                    */

                    if (targetCell.content == CellContentType.FOOD)
                    {
                        health = (health + Const.BOT_HEALTH_FOOD) % (Const.BOT_HEALTH_MAX + 1);
                        targetCell.Clear();
                        Grid.CurrentGrid.generation.CreateFoodToxin(1);
                    }
                    else if (targetCell.content == CellContentType.TOXIN)
                    {
                        targetCell.Clear();
                        targetCell.SetContent(CellContentType.FOOD);
                    }

                    step = Const.BOT_PROGRAM_STEP_MAX;
                }
                else if (command < 24)
                {
                    //
                    // ПОСМОТРЕТЬ
                    //
                    /*
                    if (targetCell.content == CellContentType.BOT) { }
                    if (targetCell.content == CellContentType.EMPTY) { }
                    if (targetCell.content == CellContentType.FOOD) { }
                    if (targetCell.content == CellContentType.TOXIN) { }
                    if (targetCell.content == CellContentType.WALL) { }
                    */
                }


                
            }
            else if (command < 32)
            {
                //
                // ПОВЕРНУТЬСЯ
                //

                address += 1;
                
                /*
                if (targetCell.content == CellContentType.BOT) { }
                if (targetCell.content == CellContentType.EMPTY) { }
                if (targetCell.content == CellContentType.FOOD) { }
                if (targetCell.content == CellContentType.TOXIN) { }
                if (targetCell.content == CellContentType.WALL) { }
                */
                courseOrientation = (OrientationType)(((int)courseOrientation + (command % 8)) % 8);


                
            }
            else
            {
                //
                // БЕЗУСЛОВНЫЙ ПЕРЕХОД в ПРОГРАММЕ
                //

                address += command;
                //address += (byte)(command - 31);
                //address += (byte)(command - 31 + 6);
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


        public string ToStringMultiLine()
        {
            string desc = "Bot";

            desc += " - (" + point.x + "," + point.y + "," + courseOrientation.ToString() + ")";
            desc += "; a: " + age +  "; h:" + health;

            desc += "\r\nprog: ";
            for (int i = 0; i < Const.BOT_PROGRAM_SIZE; i++)
            {

                if (i == address)
                {
                    desc += "[" + program[i].ToString("D3") + "] ";
                }
                else
                {
                    desc += program[i].ToString("D3") + " ";
                }
            }

            desc += "\r\ncmd:  ";
            for (int i = 0; i < Const.BOT_PROGRAM_SIZE; i++)
            {

                if (i == address)
                {
                    desc += "[" + cmd_calls[i].ToString("D3") + "] ";
                }
                else
                {
                    desc += cmd_calls[i].ToString("D3") + " ";
                }
            }

            return desc;
        }

    }
}
