using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EvoLib
{

    public struct MPoint
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public MPoint(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public static MPoint operator +(MPoint p1, MPoint p2)
        {
            return new MPoint(p1.x + p2.x, p1.y + p2.y);
        }

        public static bool operator ==(MPoint p1, MPoint p2)
        {
            return (p1.x == p2.x && p1.y == p2.y);
        }

        public static bool operator !=(MPoint p1, MPoint p2)
        {
            return (p1.x != p2.x || p1.y != p2.y);
        }

    }
    
}
