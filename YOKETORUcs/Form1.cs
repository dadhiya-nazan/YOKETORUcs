using Microsoft.VisualBasic.ApplicationServices;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace YOKETORUcs
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        static int PlayerMax => 1;
        static int EnemyMax => 4;
        static int ItemMax => 4;

        static int PlayerIndex => 0;
        static int EnemyIndex => PlayerIndex + PlayerMax;//0+1=1
        static int ItemIndex => EnemyIndex + EnemyMax;//0+4=4
        static int LabelMax => ItemIndex + EnemyMax;//4+5=9

        Label[] labels = new Label[LabelMax];

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
                Controls.Add(labels[i]);
                labels[i].Left += i * 60 + 50;

                //Text,Font,ForeColorを種類ごとに設定
                if (i >= PlayerIndex && i < PlayerMax)
                {
                    labels[i].Text = labelPlayer.Text;
                    labels[i].Font = labelPlayer.Font;
                    labels[i].ForeColor = labelPlayer.ForeColor;
                }
                if (i >= EnemyIndex && i <= EnemyMax)
                {
                    labels[i].Text = labelEnemy.Text;
                    labels[i].Font = labelEnemy.Font;
                    labels[i].ForeColor = labelEnemy.ForeColor;
                }
                if (i >= ItemIndex && i < LabelMax)
                {
                    labels[i].Text = labelItem.Text;
                    labels[i].Font = labelItem.Font;
                    labels[i].ForeColor = labelItem.ForeColor;
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

                    labelClear.Visible = false;
                    labelGameover.Visible = false;
                    buttonToTitle.Visible = false;
                    break;

                case State.Game:
                    labelTitle.Visible = false;
                    buttonStart.Visible = false;
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
    }
}