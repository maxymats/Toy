using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toy
{
    public partial class Form1 : Form
    {
        private const int MaxPenalty = 100;
        private const int CircleRadius = 30;
        private const int CircleLifetime = 2000; 

        private int score;
        private int penalty;
        private Random random;
        private List<Circle> circles;
        private DateTime startTime;
        private List<PlayerScore> playerScores;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            score = 0;
            penalty = 0;
            random = new Random();
            circles = new List<Circle>();
            startTime = DateTime.Now;
            playerScores = new List<PlayerScore>();
            UpdateScoreLabel();
            timer1.Start();
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = $"Очки: {score}";
            penaltyLabel.Text = $"Штраф: {penalty}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isGameStarted)
            {
                GenerateCircle();

                if (penalty >= MaxPenalty)
                {
                    GameOver();
                    return;
                }

                if ((DateTime.Now - startTime).TotalMilliseconds >= CircleLifetime)
                {
                    GenerateCircle();
                    startTime = DateTime.Now;
                }

                for (int i = circles.Count - 1; i >= 0; i--)
                {
                    Circle circle = circles[i];
                    circle.Lifetime -= timer1.Interval;

                    if (circle.Lifetime <= 0)
                    {
                        circles.RemoveAt(i);
                        penalty += GetCirclePenalty(circle.Color);
                        UpdateScoreLabel();
                    }
                }
                Invalidate();
            }
        }

        private void GenerateCircle()
        {
            Random random = new Random();
            int x = random.Next(CircleRadius, Width - CircleRadius);
            int y = random.Next(CircleRadius, Height - CircleRadius);

            Color color = GetRandomColor();
            int lifetime = 2000;

            Circle circle = new Circle(x, y, color, lifetime);
            circles.Add(circle);
            Invalidate();
        }

        private Color GetRandomColor()
        {
            Random random = new Random();
            int colorIndex = random.Next(3);

            switch (colorIndex)
            {
                case 0:
                    return Color.Red;
                case 1:
                    return Color.Yellow;
                case 2:
                    return Color.Green;
                default:
                    return Color.Red;
            }
        }


        private int GetCirclePenalty(Color color)
        {
            if (color == Color.Red)
                return 10;
            if (color == Color.Green)
                return 20;
            if (color == Color.Yellow)
                return 15;

            return 0;
        }

        private void StartGame()
        {
            playerNameTextBox.Enabled = false;
            score = 0;
            penalty = 0;
            circles.Clear();
            timer1.Start();
            isGameStarted = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void GameOver()
        {
            timer1.Stop();
            SavePlayerScore();
            ShowPlayerScores();
            MessageBox.Show("Гра закінчена! Ваш рахунок: " + score);
            Close();
        }

        private void SavePlayerScore()
        {
            string playerName = playerNameTextBox.Text;
            PlayerScore playerScore = new PlayerScore(playerName, score, DateTime.Now);
            playerScores.Add(playerScore);
            playerScores = playerScores.OrderByDescending(ps => ps.Score).ToList();
        }

        private void ShowPlayerScores()
        {
            string leaderboard = "Рейтинг учасників:\n\n";
            int count = Math.Min(playerScores.Count, 10);
            for (int i = 0; i < count; i++)
            {
                PlayerScore playerScore = playerScores[i];
                leaderboard += $"{i + 1}. {playerScore.Name} - {playerScore.Score} очків ({playerScore.DateTime})\n";
            }
            MessageBox.Show(leaderboard);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = circles.Count - 1; i >= 0; i--)
            {
                Circle circle = circles[i];
                if (IsInsideCircle(circle, e.Location))
                {
                    circles.RemoveAt(i);
                    int circleScore = GetCircleScore(circle.Color);
                    score += circleScore;
                    penalty += 0;
                    UpdateScoreLabel();
                    break;
                }
            }
        }

        private bool IsInsideCircle(Circle circle, Point location)
        {
            int distance = (int)Math.Sqrt(
                Math.Pow(location.X - circle.X, 2) + Math.Pow(location.Y - circle.Y, 2)
            );
            return distance <= CircleRadius;
        }

        private int GetCircleScore(Color color)
        {
            if (color == Color.Red)
                return 10;
            if (color == Color.Green)
                return 20;
            if (color == Color.Yellow)
                return 15;
            return 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (Circle circle in circles)
            {
                using (Brush brush = new SolidBrush(circle.Color))
                {
                    e.Graphics.FillEllipse(brush,
                        circle.X - CircleRadius, circle.Y - CircleRadius,
                        CircleRadius * 2, CircleRadius * 2);
                }
            }
        }

        private void playerNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
        public int Lifetime { get; set; }

        public Circle(int x, int y, Color color, int lifetime)
        {
            X = x;
            Y = y;
            Color = color;
            Lifetime = lifetime;
        }
    }

    public class PlayerScore
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime DateTime { get; set; }

        public PlayerScore(string name, int score, DateTime dateTime)
        {
            Name = name;
            Score = score;
            DateTime = dateTime;
        }
    }
}