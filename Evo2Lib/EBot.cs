using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace Evo2Lib
{
    public class EBot
    {
        private int _traceIndex;
        private MPoint _point;
        private MOrientation _course;

        public int _generation = 0;
        public int _health = ESetting.BOT_HEALTH_BIRTH;

        private byte[] _program = new byte[ESetting.BOT_PROGRAM_SIZE];
        private int[] _calls = new int[ESetting.BOT_PROGRAM_SIZE];
        private int _address = 0;

        private bool _dieByToxin = false;

        private string _checkSum = String.Empty;



        public int traceIndex { get { return _traceIndex; } set { _traceIndex = value; } }
        public MPoint point { get { return _point; } }
        public MOrientation course { get { return _course; } }

        public int generation { get { return _generation; } }
        public int health { get { return _health; } }


        public byte[] program { get { return _program; } }
        public int[] calls { get { return _calls; } }
        public int address { get { return _address; } }

        public bool dieByToxin { get { return _dieByToxin; } }

        public string checkSum {
            get
            {
                if (String.IsNullOrEmpty(_checkSum))
                {
                    _checkSum = calcCheckSum();
                }

                return _checkSum;
            }
        }

        private string calcCheckSum()
        {
            /*
            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            
            byte[] hash = md5.ComputeHash(program);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
            */

            int cs = 0;
            for (int i = 0; i < program.Length; i++) cs += program[i];

            return cs.ToString("X2");
        }


        //public void SetGenerationIndex(int gIndex)
        //{
        //    _generationIndex = gIndex;
        //}




        public bool alive
        {
            get
            {
                return _health > 0;
            }
        }


        /*
        public string checkSum
        {
            get
            {
                string pid = "";
                for (int i = 0; i < program.Length; i++)
                {
                    pid += program[i].ToString("D2");
                }

                return pid;

                
                //int cs = 0;
                //for (int i = 0; i < program.Length; i++) cs += program[i];

                //return cs;
                
            }
        }
        */

        /*
        public string programid
        {
            get
            {
                string pid = "";
                for (int i = 0; i < program.Length; i++)
                {
                    pid += program[i].ToString("D2");
                }

                return pid;
            }
        }

        public void SetHistoryProgram(EProgram program)
        {
            _historyProgram = program;
        }
        */
        /*
        public string uid
        {
            get
            {
                string u = "g" + generation.ToString() + "|p";
                for (int i = 0; i < program.Length; i++)
                {
                    u += program[i].ToString("D2");
                }

                return u;
            }
        }
        */

        public EBot(ECell cell)
        {
            //_genom = "";
            _point = cell.point;

            _course = (MOrientation)MRandom.Next(Enum.GetValues(typeof(MOrientation)).Length);
            _generation = 1;
            _health = ESetting.BOT_HEALTH_BIRTH;

            _dieByToxin = false;

            for (int i = 0; i < ESetting.BOT_PROGRAM_SIZE; i++) program[i] = (byte)MRandom.Next(ESetting.BOT_COMMAND_SIZE);
            for (int i = 0; i < ESetting.BOT_PROGRAM_SIZE; i++) calls[i] = 0;
            _address = 0;

            return;
        }



        public void DoRecovery(ECell cell)
        {
            //_genom = "";
            _point = cell.point;

            _course = (MOrientation)MRandom.Next(Enum.GetValues(typeof(MOrientation)).Length);
            _generation += 1;
            _health = ESetting.BOT_HEALTH_BIRTH;

            _dieByToxin = false;

            _address = 0;

            return;
        }



        public void DoRecovery(ECell cell, EBot sampleBot)
        {
            //_genom = "";
            _point = cell.point;

            _course = (MOrientation)MRandom.Next(Enum.GetValues(typeof(MOrientation)).Length);
            _generation = sampleBot.generation;
            _health = ESetting.BOT_HEALTH_BIRTH;

            _dieByToxin = false;

            for (int i = 0; i < ESetting.BOT_PROGRAM_SIZE; i++) program[i] = sampleBot.program[i];
            for (int i = 0; i < ESetting.BOT_PROGRAM_SIZE; i++) calls[i] = sampleBot.calls[i];
            _address = 0;

            return;
        }

        public void DoMutation(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int attempt = 0;
                byte addr;
                byte cmd = (byte)MRandom.Next(ESetting.BOT_COMMAND_SIZE);

                do
                {
                    attempt += 1;
                    addr = (byte)MRandom.Next(ESetting.BOT_PROGRAM_SIZE);
                }
                while (calls[addr] == 0 || attempt <= 8);

                if (program[addr] != cmd)
                {
                    program[addr] = cmd;
                    _generation = 1;
                }
            }

            return;
        }

        public void DoClearCalls()
        {
            for (int i = 0; i < ESetting.BOT_PROGRAM_SIZE; i++) calls[i] = 0;

            return;
        }




        public void DoRun(EGrid grid)
        {
            int steps = 0;

            _health -= 1;

            while (steps < ESetting.BOT_PROGRAM_STEP_MAX)
            {
                steps += doCommand(grid);
            }

            return;
        }

        
        private int doCommand(EGrid grid)
        {
            int step = 1;
            byte command = program[address];

            calls[address] = calls[address] + 1;

            if (command < 24)
            {
                ECell currentCell = grid.cells[point.x, point.y];

                MPoint targetPoint = point + ESetting.ORIENTATIONS[((int)_course + (command % 8)) % 8];
                ECell targetCell = grid.cells[targetPoint.x, targetPoint.y];

                _address += (byte)targetCell.type;

                if (command < 8)
                {
                    //
                    // ШАГНУТЬ
                    //
                    
                    //if (targetCell.content == CellContentType.BOT) { }
                    //if (targetCell.content == CellContentType.EMPTY) { }
                    //if (targetCell.content == CellContentType.FOOD) { }
                    //if (targetCell.content == CellContentType.TOXIN) { }
                    //if (targetCell.content == CellContentType.WALL) { }
                    


                    if (targetCell.type == ECellType.EMPTY)
                    {
                        _point = targetPoint;
                        currentCell.Clear();
                        targetCell.SetType(ECellType.BOT);
                    }
                    else if (targetCell.type == ECellType.FOOD)
                    {
                        _health = Math.Min(health + ESetting.BOT_HEALTH_FOOD, ESetting.BOT_HEALTH_MAX);
                        grid.CreateFoodToxin(1);

                        _point = targetPoint;
                        currentCell.Clear();
                        targetCell.SetType(ECellType.BOT);
                    }
                    else if (targetCell.type == ECellType.TOXIN)
                    {
                        _health = 0;
                        _dieByToxin = true;
                        grid.CreateFoodToxin(1);

                        _point = targetPoint;
                        currentCell.Clear();
                        targetCell.SetType(ECellType.BOT);
                    }
                    

                    step = ESetting.BOT_PROGRAM_STEP_MAX;
                }
                else if (command < 16)
                {
                    //
                    // ВЗЯТЬ ЕДУ / ПРЕОБРАЗОВАТЬ ЯД
                    //
                    
                    //if (targetCell.content == CellContentType.BOT) { }
                    //if (targetCell.content == CellContentType.EMPTY) { }
                    //if (targetCell.content == CellContentType.FOOD) { }
                    //if (targetCell.content == CellContentType.TOXIN) { }
                    //if (targetCell.content == CellContentType.WALL) { }
                    

                    if (targetCell.type == ECellType.FOOD)
                    {
                        _health = Math.Min(health + ESetting.BOT_HEALTH_FOOD, ESetting.BOT_HEALTH_MAX);
                        targetCell.Clear();
                        grid.CreateFoodToxin(1);
                    }
                    else if (targetCell.type == ECellType.TOXIN)
                    {
                        targetCell.SetType(ECellType.FOOD);
                    }

                    step = ESetting.BOT_PROGRAM_STEP_MAX;
                }
                else if (command< 24)
                {
                    //
                    // ПОСМОТРЕТЬ
                    //
                    
                    //if (targetCell.content == CellContentType.BOT) { }
                    //if (targetCell.content == CellContentType.EMPTY) { }
                    //if (targetCell.content == CellContentType.FOOD) { }
                    //if (targetCell.content == CellContentType.TOXIN) { }
                    //if (targetCell.content == CellContentType.WALL) { }
                }

            }
            else if (command< 32)
            {
                //
                // ПОВЕРНУТЬСЯ
                //

                _address += 1;
                
                //if (targetCell.content == CellContentType.BOT) { }
                //if (targetCell.content == CellContentType.EMPTY) { }
                //if (targetCell.content == CellContentType.FOOD) { }
                //if (targetCell.content == CellContentType.TOXIN) { }
                //if (targetCell.content == CellContentType.WALL) { }
                
                _course = (MOrientation)(((int)_course + (command % 8)) % 8);
            }
            else
            {
                //
                // БЕЗУСЛОВНЫЙ ПЕРЕХОД в ПРОГРАММЕ
                //

                _address += command;
                //address += (byte)(command - 31);
                //address += (byte)(command - 31 + 6);
            }

            _address = (byte)(address % ESetting.BOT_PROGRAM_SIZE);

            return step;
        }


        


        public override string ToString()
        {
            string desc = base.ToString();

            desc += " calls: ";
            for (int i = 0; i < ESetting.BOT_PROGRAM_SIZE; i++) desc += " " + calls[i];

            return desc;
        }


    }
}
