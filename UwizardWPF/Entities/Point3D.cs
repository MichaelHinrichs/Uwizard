using System;

namespace UwizardWPF.Entities
{
    public class Point3D
    {
        public float X, Y, Z;
        
        private PointF Rotate(float v1, float v2, float radians)
        {
            var cos = Math.Cos(radians);
            var sin = Math.Sin(radians);
            var RotationMatrix = new[] { cos, -sin, sin, cos };
            var PointMatrix = new[] { v1, v2 };
            return new PointF((float)(PointMatrix[0] * RotationMatrix[0] + PointMatrix[1] * RotationMatrix[1]), (float)(PointMatrix[0] * RotationMatrix[2] + PointMatrix[1] * RotationMatrix[3]));
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
            PointF pt;
            Point3D ptout = this;
            degrees = deg2rad(degrees);
            switch (axis)
            {
                case rotAxis.X:
                    pt = Rotate(ptout.Y, ptout.Z, degrees);
                    ptout.Y = pt.X;
                    ptout.Z = pt.Y;
                    break;
                case rotAxis.Y:
                    pt = Rotate(ptout.X, ptout.Z, degrees);
                    ptout.X = pt.X;
                    ptout.Z = pt.Y;
                    break;
                case rotAxis.Z:
                    pt = Rotate(ptout.X, ptout.Y, degrees);
                    ptout.X = pt.X;
                    ptout.Y = pt.Y;
                    break;
            }
            return ptout;
        }

        public PointF Project(float fov, float sx, float sy)
        {
            float z1 = (1 / (this.Z + fov)) + (1 - (1 / fov));
            return new PointF(this.X * z1 * sx, this.Y * z1 * sy);
        }

        public PointF toPointF()
        {
            return new PointF(this.X, this.Y);
        }

        public void Translate(float x, float y, float z)
        {
            this.X += x;
            this.Y += y;
            this.Z += z;
        }

        public Point3D(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}
