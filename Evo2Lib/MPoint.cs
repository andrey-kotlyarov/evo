using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Evo2Lib
{
    public struct MPoint
    {
        public int x;
        public int y;

        public MPoint(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public static MPoint operator +(MPoint p1, MPoint p2)
        {
            return new MPoint(p1.x + p2.x, p1.y + p2.y);
        }
        public static MPoint operator -(MPoint p1, MPoint p2)
        {
            return new MPoint(p1.x - p2.x, p1.y - p2.y);
        }

        public static bool operator ==(MPoint p1, MPoint p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(MPoint p1, MPoint p2)
        {
            return !p1.Equals(p2);
        }

        public override bool Equals(object obj)
        {
            MPoint p = (MPoint)obj;
            return (p.x == x && p.y == y);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
