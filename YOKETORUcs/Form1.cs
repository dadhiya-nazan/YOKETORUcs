namespace YOKETORUcs
{
    public partial class Form1 : Form
    {
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            InitState();
            UpdateState();
        }

        void InitState()
        {
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
                    labelGameover.Visible = false;
                    buttonToTitle.Visible = false;
                    break;

                case State.Game:
                    labelTitle.Visible = false;
                    buttonStart.Visible = false;
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

        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            nextState = State.Game;
        }
    }
}