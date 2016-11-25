using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Evo2Lib
{
    public class ECell
    {
        private MPoint _point;
        private ECellType _type;

        public MPoint point { get { return _point; } }
        public ECellType type { get { return _type; } }


        public ECell(int x, int y)
        {
            _point = new MPoint(x, y);
            _type = ECellType.EMPTY;
        }


        public void SetType(ECellType type)
        {
            _type = type;
        }

        public void Clear()
        {
            if (_type != ECellType.WALL)
            {
                _type = ECellType.EMPTY;
            }
        }

        /*
        public bool SetContent(CellContentType newContent)
        {
            if (content == CellContentType.EMPTY)
            {
                content = newContent;
                return true;
            }

            return false;
        }

        public void Clear()
        {
            if (content != CellContentType.WALL)
            {
                content = CellContentType.EMPTY;
            }

            return;
        }



        public override string ToString()
        {
            string desc = base.ToString();

            desc += " - X: " + point.x + "; Y: " + point.y + "; C: " + content.ToString();

            return desc;
        }
        */
    }
}
