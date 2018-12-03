using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
        public CircleType Type { get; }
        public Brush Color { get; set; }
        public int Points { get; set; }

        public Circle(CircleType type, Brush circlecolor)
        {
            this.X = 0;
            this.Y = 0;
            this.Type = type;
            this.Color = circlecolor;
            this.Points = 100;
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
