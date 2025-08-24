using System;
using System.Drawing;
using System.Windows.Forms;

namespace WhacAMole
{
    public partial class Form1 : Form
    {
        private Button[] holes;      // 地鼠洞口
        private System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();     // 遊戲倒數計時
        private System.Windows.Forms.Timer moleTimer = new System.Windows.Forms.Timer();     // 地鼠出現計時
        private int score = 0;
        private int timeLeft = 30;   // 遊戲時間30秒
        private Random rand = new Random();
        private int difficulty = 500; // 毫秒，地鼠出現頻率

        public Form1()
        {
            InitGame();
        }

        private void InitGame()
        {
            this.Text = "打地鼠遊戲";
            this.Size = new Size(400, 500);

            // 設定地鼠洞口
            holes = new Button[9];
            int index = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button b = new Button();
                    b.Size = new Size(80, 80);
                    b.Location = new Point(50 + j * 100, 50 + i * 100);
                    b.Tag = false; // 是否有地鼠
                    b.Click += Hole_Click;
                    holes[index++] = b;
                    this.Controls.Add(b);
                }
            }

            // 設定倒數計時
            Label lblTime = new Label();
            lblTime.Name = "lblTime";
            lblTime.Text = "時間: " + timeLeft;
            lblTime.Location = new Point(50, 10);
            lblTime.AutoSize = true;
            this.Controls.Add(lblTime);

            // 設定記分板
            Label lblScore = new Label();
            lblScore.Name = "lblScore";
            lblScore.Text = "分數: " + score;
            lblScore.Location = new Point(200, 10);
            lblScore.AutoSize = true;
            this.Controls.Add(lblScore);

            // 遊戲Timer
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000; // 1秒
            gameTimer.Tick += GameTimer_Tick;

            // 地鼠Timer
            moleTimer = new System.Windows.Forms.Timer();
            moleTimer.Interval = difficulty; // 難度
            moleTimer.Tick += MoleTimer_Tick;

            // 難度選擇
            ComboBox cmbDifficulty = new ComboBox();
            cmbDifficulty.Items.AddRange(new string[] { "簡單", "普通", "困難" });
            cmbDifficulty.SelectedIndex = 1; // 默認普通
            cmbDifficulty.Location = new Point(50, 360);
            cmbDifficulty.SelectedIndexChanged += CmbDifficulty_SelectedIndexChanged;
            this.Controls.Add(cmbDifficulty);

            // 開始按鈕
            Button btnStart = new Button();
            btnStart.Text = "開始遊戲";
            btnStart.Location = new Point(200, 360);
            btnStart.AutoSize = true;
            btnStart.Click += BtnStart_Click;
            this.Controls.Add(btnStart);
        }

        private void CmbDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            switch (cmb.SelectedItem.ToString())
            {
                case "簡單": difficulty = 1000; break;
                case "普通": difficulty = 700; break;
                case "困難": difficulty = 400; break;
            }
            moleTimer.Interval = difficulty;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            score = 0;
            timeLeft = 30;
            UpdateScore();
            UpdateTime();
            gameTimer.Start();
            moleTimer.Start();
        }

        private void Hole_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if ((bool)b.Tag)
            {
                // 正確打到地鼠
                score++;
                b.Tag = false;
                b.Text = "";
            }
            else
            {
                // 打錯扣分
                score--;
                if (score < 0) score = 0; // 分數不允許負數，可視情況移除
            }
            UpdateScore();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            UpdateTime();
            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                moleTimer.Stop();
                MessageBox.Show("遊戲結束! 分數: " + score);
            }
        }

        private void MoleTimer_Tick(object sender, EventArgs e)
        {
            // 清空所有洞
            foreach (var h in holes)
            {
                h.Tag = false;
                h.Text = "";
            }

            // 隨機出現地鼠
            int idx = rand.Next(holes.Length);
            holes[idx].Tag = true;
            holes[idx].Text = "🐹"; // 使用 emoji 當地鼠
        }

        private void UpdateScore()
        {
            Label lblScore = this.Controls["lblScore"] as Label;
            lblScore.Text = "分數: " + score;
        }

        private void UpdateTime()
        {
            Label lblTime = this.Controls["lblTime"] as Label;
            lblTime.Text = "時間: " + timeLeft;
        }
    }
}
