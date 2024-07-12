using Microsoft.VisualBasic.ApplicationServices;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Windows.Forms.Design;

namespace YOKETORUcs
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        static int PlayerMax => 1;
        static int EnemyMax => 30;
        static int ItemMax => 30;

        static int PlayerIndex => 0;
        static int EnemyIndex => PlayerIndex + PlayerMax;//0+1=1
        static int ItemIndex => EnemyIndex + EnemyMax;//0+4=4
        static int LabelMax => ItemIndex + EnemyMax;//4+5=9

        Label[] labels = new Label[LabelMax];

        static Random random = new Random();

        int[] vx = new int[LabelMax];
        int[] vy = new int[LabelMax];

        static int SpeedMax => 10;

        int score;
        int highscore = 0;
        int timer;
        int itemget;

        //状態遷移、状態定義
        enum State
        {
            None = -1,
            Title,
            Game,
            Gameover,
            Clear,
        }

        //<summary>
        //次に切り替えたい状態
        //<summary>
        State nextState = State.Title;

        //<summary>
        //現在の状態
        //<summary>
        State currentState = State.None;

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < LabelMax; i++)
            {
                labels[i] = new Label();
                labels[i].AutoSize = true;
                labels[i].Visible = false;
                Controls.Add(labels[i]);

                labelPlayer.Visible = false;
                labelEnemy.Visible = false;
                labelItem.Visible = false;

                //Text,Font,ForeColorを種類ごとに設定
                //プレイヤーラベルの生成
                if (i >= PlayerIndex && i < PlayerMax)
                {
                    labels[i].Text = labelPlayer.Text;
                    labels[i].Font = labelPlayer.Font;
                    labels[i].ForeColor = labelPlayer.ForeColor;
                }
                //敵ラベルの生成
                if (i >= EnemyIndex && i <= EnemyMax)
                {
                    labels[i].Text = labelEnemy.Text;
                    labels[i].Font = labelEnemy.Font;
                    labels[i].ForeColor = labelEnemy.ForeColor;
                }
                //アイテムラベルの生成
                if (i >= ItemIndex && i < LabelMax)
                {
                    labels[i].Text = labelItem.Text;
                    labels[i].Font = labelItem.Font;
                    labels[i].ForeColor = labelItem.ForeColor;
                }

                if (i >= EnemyIndex)
                {
                    labels[i].Left = labels[i - 1].Left + labels[i - 1].Width;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            InitState();
            UpdateState();
        }

        void InitState()
        {   //番人
            if (nextState == State.None)
            {
                return;
            }
            currentState = nextState;
            nextState = State.None;

            //初期化処理
            switch (currentState)
            {
                case State.Title:
                    labelTitle.Visible = true;
                    buttonStart.Visible = true;
                    labelHighScore.Visible = true;

                    labelClear.Visible = false;
                    labelGameover.Visible = false;
                    buttonToTitle.Visible = false;

                    //ハイスコア判定
                    if (score > highscore)
                    {
                        highscore = score;
                    }
                    labelHighScore.Text = $"ハイスコア:{highscore}";
                    break;

                case State.Game:
                    labelTitle.Visible = false;
                    buttonStart.Visible = false;

                    for (int i = 0; i < LabelMax; i++)
                    {
                        labels[i].Visible = true;

                        vx[i] = random.Next(-SpeedMax, SpeedMax + 1);
                        vy[i] = random.Next(-SpeedMax, SpeedMax + 1);
                        labels[i].Left = random.Next(0, ClientSize.Width - labels[i].Width);
                        labels[i].Top = random.Next(0, ClientSize.Height - labels[i].Height);
                    }

                    score = 0;
                    timer = 200;
                    itemget = 0;
                    break;


                case State.Gameover:
                    labelGameover.Visible = true;
                    buttonToTitle.Visible = true;
                    break;

                case State.Clear:
                    labelClear.Visible = true;
                    buttonToTitle.Visible = true;
                    break;
            }
        }

        //状態の更新メソッド
        void UpdateState()
        {
            switch (currentState)
            {
                case State.Game:
                    UpdateGame();
                    break;
            }
        }
        //ゲーム状態の更新用メソッド
        void UpdateGame()
        {
            if (GetAsyncKeyState((int)Keys.O) < 0)
            {
                nextState = State.Gameover;
            }

            if (GetAsyncKeyState((int)Keys.C) < 0)
            {
                nextState = State.Clear;
            }

            //プレイヤーの移動
            var fpos = PointToClient(MousePosition);
            labels[PlayerIndex].Left = fpos.X - (labels[PlayerIndex].Width / 2);
            labels[PlayerIndex].Top = fpos.Y - (labels[PlayerIndex].Height / 2);

            //キャラクターの更新
            UpdateChrs();

            //時間とスコアの更新
            timer--;
            labelTime.Text = $"{timer}";
            labelScore.Text = $"{score}";

            if (timer <= 0)
                nextState = State.Gameover;
        }

        void UpdateChrs()
        {
            var fpos = PointToClient(MousePosition);

            //敵とアイテムの移動と跳ね返り処理
            for (int i = EnemyIndex; i < LabelMax; i++)
            {
                labels[i].Left += vx[i];
                labels[i].Top += vy[i];

                if (labels[i].Left < 0)
                {
                    vx[i] = Math.Abs(vx[i]);
                }
                else if (labels[i].Left > (ClientSize.Width - labels[i].Width))
                {
                    vx[i] = -Math.Abs(vx[i]);
                }
                else if (labels[i].Top < 0)
                {
                    vy[i] = Math.Abs(vy[i]);
                }
                else if (labels[i].Top > (ClientSize.Height - labels[i].Height))
                {
                    vy[i] = -Math.Abs(vy[i]);
                }

                //fposがラベルと重なっている
                if ((fpos.X > labels[i].Left) && (fpos.X < labels[i].Right) && (fpos.Y > labels[i].Top) && (fpos.Y < labels[i].Bottom))
                {
                    if (!labels[i].Visible)
                    {
                        continue;
                    }


                    //敵に当たった時
                    if (i < ItemIndex)
                    {
                        nextState = State.Gameover;
                    }
                    //アイテムをとった時
                    else
                    {
                        score += timer * 100;
                        labels[i].Visible = false;
                        itemget++;
                    }


                    if (itemget >= ItemMax)
                    {
                        nextState = State.Clear;
                    }
                }
            }

        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            nextState = State.Game;
        }

        private void buttonToTitle_Click(object sender, EventArgs e)
        {
            nextState = State.Title;
        }

        private void labelItem_Click(object sender, EventArgs e)
        {

        }

        private void labelEnemy_Click(object sender, EventArgs e)
        {

        }
    }
}