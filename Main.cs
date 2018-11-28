﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Snake
{
    public partial class Main : Form
    {
        private List<Circle> Obstacles = new List<Circle>();
        private List<Circle> Snake = new List<Circle>();
        private Circle Food = new Circle(CircleType.food);
        private Settings CurSettings = new Settings();
        private Stopwatch Gametimer = new Stopwatch();
        private Score Score = new Score();
        public string username;

        public Main()
        {
            InitializeComponent();
            this.MinimumSize = new Size(pbCanvas.Width + 50, pbCanvas.Height + 70);

            CurSettings = new Settings();
            foreach (string path in Directory.GetFiles("./users"))
            {
                string[] spl = path.Split('\\');
                string user = spl[spl.Length - 1].Split('.')[0];
                SellectUser.Items.Add(user);
            }
        }

        private void Startbutton_Click(object sender, EventArgs e)
        {
            if (SellectUser.SelectedItem == null)
                return;

            username = SellectUser.SelectedItem.ToString();
            Score.LoadUser(username);
            HighScore.Text = $"#1: {Score.HighScore1}\n#2: {Score.HighScore2}\n#3: {Score.HighScore3}";

            AddUser.Dispose();
            SellectUser.Dispose();
            Startbutton.Dispose();
            
            GameTimer.Interval = 1000 / CurSettings.Speed;
            GameTimer.Start();

            StartGame();
        }

        private void StartGame()
        {
            lblGameOver.Visible = false;

            CurSettings = new Settings();

            Circle head = new Circle(CircleType.head) { X = 10, Y = 5 };
            Snake.Add(head);

            lblScore.Text = CurSettings.Score.ToString();
            GenerateFood();
        }

        private void GenerateObstacle()
        {
            int maxXPos = pbCanvas.Size.Width / CurSettings.Width - 3;
            int maxYPos = pbCanvas.Size.Height / CurSettings.Heigth - 3;

            Random rand = new Random();
            Circle obst = new Circle(CircleType.obstacle)
            {
                X = rand.Next(3, maxXPos),
                Y = rand.Next(3, maxYPos)
            };

            Obstacles.Add(obst);
        }

        private void GenerateFood()
        {
            int maxXPos = pbCanvas.Size.Width / CurSettings.Width - 3;
            int maxYPos = pbCanvas.Size.Height / CurSettings.Heigth - 3;

            Random rand = new Random();
            Food = new Circle(CircleType.food)
            {
                X = rand.Next(3, maxXPos),
                Y = rand.Next(3, maxYPos)
            };

            if (Obstacles.Count != 0)
            {
                bool corect = false;

                while (!corect)
                {
                    foreach (Circle obst in Obstacles)
                    {
                        if (obst.X == Food.X && obst.Y == Food.Y)
                        {
                            Food.X = rand.Next(3, maxXPos);
                            Food.Y = rand.Next(3, maxXPos);
                            corect = true;
                            break;
                        }
                    }
                    corect = true;
                }
            }
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            if (CurSettings.GameOver == true)
            {
                if (Input.KeyPressed(Keys.Enter))
                    StartGame();
            }
            else
            {
                if (Input.KeyPressed(Keys.Right) && CurSettings.Direction != Direction.Left)
                    CurSettings.Direction = Direction.Right;
                else if (Input.KeyPressed(Keys.Left) && CurSettings.Direction != Direction.Right)
                    CurSettings.Direction = Direction.Left;
                else if (Input.KeyPressed(Keys.Up) && CurSettings.Direction != Direction.Down)
                    CurSettings.Direction = Direction.Up;
                else if (Input.KeyPressed(Keys.Down) && CurSettings.Direction != Direction.Up)
                    CurSettings.Direction = Direction.Down;
                else if (Input.KeyPressed(Keys.Escape))
                    GameTimer.Stop();
                if (Input.KeyPressed(Keys.Enter))
                {
                    GameTimer.Dispose();
                    GameTimer.Interval = 1000 / CurSettings.Speed;
                    GameTimer.Start();
                }

                MovePlayer();
            }

            pbCanvas.Invalidate();
        }

        private void PbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;

            if (!CurSettings.GameOver)
            {
                Brush SnakeColor;
                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0)
                        SnakeColor = Brushes.Black;
                    else
                        SnakeColor = Brushes.DarkGreen;

                    Canvas.FillRectangle(SnakeColor, new Rectangle(Snake[i].X * CurSettings.Width, Snake[i].Y * CurSettings.Heigth, CurSettings.Width, CurSettings.Heigth));

                    Canvas.FillRectangle(Brushes.Red, new Rectangle(Food.X * CurSettings.Width, Food.Y * CurSettings.Heigth, CurSettings.Width, CurSettings.Heigth));
                }

                foreach(Circle circle in Obstacles)
                {
                    Canvas.FillRectangle(Brushes.Blue, new Rectangle(circle.X * CurSettings.Width, circle.Y * CurSettings.Heigth, CurSettings.Width, CurSettings.Heigth));
                }
            }
            else
            {
                string GameOver = "Game Over \nYour finale score is: " + CurSettings.Score + "\nPress Enter to try again";
                lblGameOver.Text = GameOver;
                lblGameOver.Visible = true;
            }
        }

        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (CurSettings.Direction)
                    {
                        case Direction.Down:
                            Snake[i].AddY();
                            break;
                        case Direction.Up:
                            Snake[i].MinY();
                            break;
                        case Direction.Left:
                            Snake[i].MinX();
                            break;
                        case Direction.Right:
                            Snake[i].AddX();
                            break;
                    }

                    int maxXPos = pbCanvas.Size.Width / CurSettings.Width;
                    int maxYPos = pbCanvas.Size.Height / CurSettings.Heigth;

                    if (Snake[i].X < 0 || Snake[i].X >= maxXPos || Snake[i].Y < 0 || Snake[i].Y >= maxYPos)
                    {
                        Die();
                        break;
                    }

                    for(int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            Die();
                            break; 
                        } 
                    }

                    foreach(Circle obst in Obstacles)
                    {
                        if (Snake[i].X == obst.X && Snake[i].Y == obst.Y)
                        {
                            Die();
                            break;
                        }
                    }

                    if (CurSettings.GameOver)
                        break;

                    if (Snake[i].X == Food.X && Snake[i].Y == Food.Y)
                    {
                        Eat();
                    }
                }
                else
                {
                    Snake[i].SetX(Snake[i - 1].X);
                    Snake[i].SetY(Snake[i - 1].Y);
                }
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);

            if(CurSettings.GameOver != true)
            {
                if (Input.KeyPressed(Keys.Enter))
                {
                    GameTimer.Interval = 1000 / CurSettings.Speed;
                    GameTimer.Start();
                }
            }
        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void Eat()
        {
            Circle food = new Circle(CircleType.body)
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };

            Snake.Add(food);

            CurSettings.Score += CurSettings.Points;
            lblScore.Text = CurSettings.Score.ToString();

            if(CurSettings.Score % 1000 == 0 && Obstacles.Count != CurSettings.ObstacleCount)
            {
                GenerateObstacle();
            }
            GenerateFood();
        }

        private void Die()
        {
            CurSettings.GameOver = true;
            if (int.Parse(Score.HighScore1) < CurSettings.Score || int.Parse(Score.HighScore2) < CurSettings.Score || int.Parse(Score.HighScore3) < CurSettings.Score)
            {
                Score.SaveScore(CurSettings.Score, username);
                Score.UpdateScore(username);
                HighScore.Text = $"#1: {Score.HighScore1}\n#2: {Score.HighScore2}\n#3: {Score.HighScore3}";
            }
            Snake.Clear();
            Obstacles.Clear();
        }

        private void SaveHighScore()
        {
            if (File.Exists($"./users/{username}.gsf"))
            {
                Score.LoadUser(username);
                HighScore.Text = $"#1: {Score.HighScore1}\n#2: {Score.HighScore2}\n#3: {Score.HighScore3}";
            }
            else
            {
                File.Create($"./users/{username}.gsf");
                HighScore.Text = $"#1: {Score.HighScore1}\n#2: {Score.HighScore2}\n#3: {Score.HighScore3}";
            }
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            CreateUser form = new CreateUser(this);
            form.Show();
        }
    }
}
