using System;
using System.Windows;

namespace UwizardWPF.Entities
{
    public class Point3D
    {
        public float X, Y, Z;
        
        private Point Rotate(float v1, float v2, float radians)
        {
            var cos = Math.Cos(radians);
            var sin = Math.Sin(radians);
            var RotationMatrix = new[] { cos, -sin, sin, cos };
            var PointMatrix = new[] { v1, v2 };
            return new Point(PointMatrix[0]*RotationMatrix[0] + PointMatrix[1]*RotationMatrix[1],
                             PointMatrix[0]*RotationMatrix[2] + PointMatrix[1]*RotationMatrix[3]);
        }

        [Flags]
        public enum rotAxis
        {
            X = 0,
            Y = 1,
            Z = 2,
        }

        private float deg2rad(float deg)
        {
            return (float)(deg * Math.PI / 180.0D);
        }

        public Point3D Rotate(float degrees, rotAxis axis)
        {
            Point pt;
            Point3D ptout = this;
            degrees = deg2rad(degrees);
            switch (axis)
            {
                case rotAxis.X:
                    pt = Rotate(ptout.Y, ptout.Z, degrees);
                    ptout.Y = (float) pt.X;
                    ptout.Z = (float) pt.Y;
                    break;
                case rotAxis.Y:
                    pt = Rotate(ptout.X, ptout.Z, degrees);
                    ptout.X = (float) pt.X;
                    ptout.Z = (float) pt.Y;
                    break;
                case rotAxis.Z:
                    pt = Rotate(ptout.X, ptout.Y, degrees);
                    ptout.X = (float) pt.X;
                    ptout.Y = (float) pt.Y;
                    break;
            }
            return ptout;
        }

        public Point Project(float fov, float sx, float sy)
        {
            float z1 = (1 / (Z + fov)) + (1 - (1 / fov));
            return new Point(X * z1 * sx, Y * z1 * sy);
        }

        public Point ToPoint()
        {
            return new Point(X, Y);
        }

        public void Translate(float x, float y, float z)
        {
            X += x;
            Y += y;
            Z += z;
        }

        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
