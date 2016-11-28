using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Evo2Lib;



namespace Evo2App
{
    public partial class FormDebug : Form
    {
        private  Evo2Engine _evoEngine;
        private BufferedGraphics _pbProgramBufferGraphics;


        public FormDebug(Evo2Engine evoEngine)
        {
            InitializeComponent();
            _evoEngine = evoEngine;
        }

        private void FormDebug_Load(object sender, EventArgs e)
        {
            _pbProgramBufferGraphics = BufferedGraphicsManager.Current.Allocate(pbProgram.CreateGraphics(), pbProgram.DisplayRectangle);

            if (_evoEngine != null)
            {
                _evoEngine.OnGeneration_Started += evoEngine_OnGenerationStarted;
                _evoEngine.OnGeneration_Completed += evoEngine_OnGenerationCompleted;
                _evoEngine.OnIteration_Completed += evoEngine_OnIterationCompleted;


                slblEvent.Text = "On Load";
                slblGenIter.Text = String.Format("GEN:{0} ITER:{1}", _evoEngine.eGrid.generation, _evoEngine.eGrid.iteration);
            }
        }

        private void FormDebug_Paint(object sender, PaintEventArgs e)
        {
            drawPrograms();
        }

        private void FormDebug_FormClosed(object sender, FormClosedEventArgs e)
        {
            _pbProgramBufferGraphics.Dispose();
        }






        private void drawPrograms()
        {
            try
            {
                Graphics g = _pbProgramBufferGraphics.Graphics;

                g.Clear(SystemColors.Control);
                //g.Clear(Color.Red);




                EBot[] traceBots = new EBot[ESetting.BOT_COUNT_MIN];
                foreach (EBot bot in _evoEngine.eGrid.bots)
                {
                    for (int i = 0; i < ESetting.BOT_COUNT_MIN; i++)
                    {
                        if (bot.traceIndex == i)
                        {
                            traceBots[i] = bot;
                        }
                    }
                }

                

                int size = 280;
                int paddingX = 40;
                int paddingY = 64;


                for (int i = 0; i < 8; i++)
                {
                    int x = 1 + (i % 4) * (size + paddingX);
                    int y = 1 + paddingY + (i / 4) * (size + paddingY);



                    drawProgram(g, x, y, size, traceBots[i], ESetting.TRACE_COLOR[i]);

                    
                }




                //_pbProgramBufferGraphics.Render();
                _pbProgramBufferGraphics.Render(pbProgram.CreateGraphics());

            }
            catch { }
        }


        private void drawProgram(Graphics g, int x, int y, int size, EBot bot, Color traceColor)
        {
            if (bot == null) return;

            int iteration = _evoEngine.eGrid.iteration;






            Brush brushBG = new SolidBrush(traceColor);
            //Brush brushCMD = Brushes.White;
            Brush brushCMD_ADDR = new SolidBrush(traceColor);

            Font fontBot = new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Bold);
            Font fontBotP = new Font(FontFamily.GenericSansSerif, 5.0F, FontStyle.Regular);
            Font fontBotC = new Font(FontFamily.GenericSansSerif, 4.0F, FontStyle.Regular);


            Font fontBotTitle = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            Font fontBotCoord = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Regular);

            Brush brushFontTitle = Brushes.Gray;
            Brush brushFontCoord = Brushes.Black;



            Brush brushFontW = Brushes.White;
            Brush brushFontB = Brushes.Black;


            Rectangle recBG = new Rectangle(x - 1, y - 1, size + 2, size + 2);
            Rectangle recCMD;
            Rectangle recCMD_ADDR;

            g.FillRectangle(brushBG, recBG);



            int csize = size / 8;
            int cx;
            int cy;


            int calls_max = 0;
            for (int i = 0; i < ESetting.BOT_PROGRAM_SIZE; i++)
            {
                if (bot.calls[i] > calls_max) calls_max = bot.calls[i];
            }

            for (int i = 0; i < ESetting.BOT_PROGRAM_SIZE; i++)
            {
                int calls = bot.calls[i];


                int callIndex = 0;

                if (bot.calls[i] > 0)
                {
                    callIndex = 25 + 205 * bot.calls[i] / calls_max;
                }





                cx = x + (i % 8) * csize;
                cy = y + (i / 8) * csize;

                
                Brush bCMD = new SolidBrush(ESetting.GRAY_COLOR[callIndex]);

                recCMD = new Rectangle(cx + 1, cy + 1, csize - 2, csize - 2);
                recCMD_ADDR = new Rectangle(cx + 5, cy + 5, csize - 10, csize - 10);

                //g.FillRectangle((i == bot.address ? brushCMD_ADDR : bCMD), recCMD);
                g.FillRectangle(bCMD, (i == bot.address ? recCMD_ADDR : recCMD));



                g.DrawString(bot.program[i].ToString(), fontBot, brushFontW, cx + csize / 4, cy + csize / 3);
                g.DrawString(bot.program[i].ToString(), fontBotP, (callIndex > 127 ? brushFontW : brushFontB), cx + 3, cy + 5);

                g.DrawString(bot.calls[i].ToString(), fontBotC, (callIndex > 127 ? brushFontW : brushFontB), cx + 3, cy + 25);
            }


            cx = x + 2;
            cy = y - 48;
            string title = String.Format("CS: {0}; G: {1}; H: {2}", bot.checkSum.Substring(0, 4), bot.generation, bot.health);
            g.DrawString(title, fontBotTitle, brushFontTitle, cx, cy);

            cx = x + 2;
            cy = y - 28;
            string coord = String.Format("(x,y) = ({0},{1}); course = {2}", bot.point.x, bot.point.y, bot.course.ToString());
            g.DrawString(coord, fontBotCoord, brushFontCoord, cx, cy);

            return;
        }





        private void evoEngine_OnIterationCompleted(int generation, int iteration, EResultIteration resultIteration)
        {
            this.InvokeEx(
                () =>
                {
                    slblEvent.Text = "On Iteration Completed";
                    slblGenIter.Text = String.Format("GEN:{0}        ITER:{1}", generation, iteration);
                    
                    drawPrograms();
                }
            );
        }

        private void evoEngine_OnGenerationStarted(int generation)
        {
            this.InvokeEx(
                () =>
                {
                    slblEvent.Text = "On Generation Started";
                    slblGenIter.Text = String.Format("GEN:{0}        ITER:{1}", generation, "0");

                    drawPrograms();
                }
            );
        }

        private void evoEngine_OnGenerationCompleted(int generation, int iteration, EResultGeneration resultGeneration)
        {
            this.InvokeEx(
                () =>
                {
                    slblEvent.Text = "On Generation Completed";
                    slblGenIter.Text = String.Format("GEN:{0}        ITER:{1}", generation, iteration);
                    
                    drawPrograms();
                }
            );
        }

        
    }
}
