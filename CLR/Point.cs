using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CLR
{
    public struct Point : IChangable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Change(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"x={X}, y={Y}";
        }
    }

    public interface IChangable
    {
        void Change(int x, int y);
    }
}
