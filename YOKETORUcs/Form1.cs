namespace YOKETORUcs
{
    public partial class Form1 : Form
    {
        //��ԑJ�ځA��Ԓ�`
        enum State
        {
            None = -1,
            Title,
            Game,
            Gameover,
            Clear,
        }

        //<summary>
        //���ɐ؂�ւ��������
        //<summary>
        State nextState = State.Title;

        //<summary>
        //���݂̏��
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

            //����������
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

        //��Ԃ̍X�V���\�b�h
        void UpdateState()
        {
            switch (currentState)
            {
                case State.Game:
                    UpdateGame();
                    break;
            }
        }
        //�Q�[����Ԃ̍X�V�p���\�b�h
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