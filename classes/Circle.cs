using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum CircleType
    {
        head,
        body,
        food,
        obstacle
    }

    public class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CircleType Type { get; set; }

        public Circle(CircleType type)
        {
            this.X = 0;
            this.Y = 0;
            this.Type = type;
        }

        public void AddX()
        {
            this.X += 1;
        }

        public void MinX()
        {
            this.X -= 1;
        }

        public void AddY()
        {
            this.Y += 1;
        }

        public void MinY()
        {
            this.Y -= 1;
        }

        public void SetX(int newx)
        {
            this.X = newx;
        }

        public void SetY(int newy)
        {
            this.Y = newy;
        }
    }
}
