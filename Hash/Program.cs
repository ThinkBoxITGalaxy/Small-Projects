using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{

    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})",
            this.X, this.Y, this.Z);
        }
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            Point3D other = obj as Point3D;
            if (other == null)
                return false;
            if (!this.X.Equals(other.X))
                return false;
            if (!this.Y.Equals(other.Y))
                return false;
            if (!this.Z.Equals(other.Z))
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            int prime = 83;
            int result = 1;
            unchecked
            {
                result = result * prime + X.GetHashCode();
                result = result * prime + Y.GetHashCode();
                result = result * prime + Z.GetHashCode();
            }
            return result;
        }
        public class Point3DEqualityComparer : IEqualityComparer<Point3D>
        {
            public bool Equals(Point3D point1, Point3D point2)
            {
                if (point1 == point2)
                    return true;
                if (point1 == null || point2 == null)
                    return false;
                if (!point1.X.Equals(point2.X))
                    return false;
                if (!point1.Y.Equals(point2.Y))
                    return false;
                if (!point1.Z.Equals(point2.Z))
                    return false;
                return true;
            }
            public int GetHashCode(Point3D obj)
            {
                Point3D point = obj as Point3D;
                if (point == null)
                {
                    return 0;
                }
                int prime = 83;
                int result = 1;
                unchecked
                {
                    result = result * prime + point.X.GetHashCode();
                    result = result * prime + point.Y.GetHashCode();
                    result = result * prime + point.Z.GetHashCode();
                }
                return result;
            }
        }
        static void Main()
        {
            IEqualityComparer<Point3D> comparer =
            new Point3DEqualityComparer();
            Dictionary<Point3D, int> dict =
            new Dictionary<Point3D, int>(comparer);
            dict[new Point3D(4, 2, 5)] = 5;
            dict[new Point3D(1, 2, 3)] = 1;
            dict[new Point3D(3, 1, -1)] = 3;
            dict[new Point3D(1, 2, 3)] = 10;
            foreach (var entry in dict)
            {
                Console.WriteLine("{0} --> {1}", entry.Key, entry.Value);
            }
            Console.Read();
        }
    }
   

}
