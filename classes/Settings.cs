using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Settings
    {
        public int Width { get; private set; }
        public int Heigth { get; private set; }
        public int Speed { get; set; }
        public int Score { get; set; }
        public int Points { get; set; }
        public bool GameOver { get; set; }
        public Direction Direction { get; set; }
        public int ObstacleCount { get; set; }
        public string User { get; set; }

        public Settings()
        {
            Width = 10;
            Heigth = 10;
            Speed = 15;
            Score = 0;
            Points = 100;
            GameOver = false;
            Direction = Direction.Down;
            ObstacleCount = 10;
        }
    }
}
