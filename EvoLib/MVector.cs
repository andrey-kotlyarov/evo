using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EvoLib
{
    /*
    public struct MVector
    {
        public MPoint p0 { get; private set; }
        public MPoint p1 { get; private set; }


        //public MVector r { get { return new MVector()} }

        public MVector(MPoint _p0, MPoint _p1)
        {
            p0 = _p0;
            p1 = _p1;
        }
        public MVector(MPoint _p1)
        {
            p0 = new MPoint(0, 0);
            p1 = _p1;
        }

        public MVector(int x, int y)
        {
            p0 = new MPoint(0, 0);
            p1 = new MPoint(x, y);
        }
    }
    */

    /*
    public struct MVector
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int z { get; private set; }

        public MVector(int _x, int _y, int _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public MVector(int _x, int _y) : this (_x, _y, 0)
        {

        }

        public static MVector operator +(MVector v1, MVector v2)
        {
            return new MVector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        public static MVector operator -(MVector v1, MVector v2)
        {
            return new MVector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static MVector operator *(MVector v1, MVector v2)
        {
            return new MVector(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.x);
        }
        
    }
    */
}
