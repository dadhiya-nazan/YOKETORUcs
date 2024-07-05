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
        static int EnemyMax => 4;
        static int ItemMax => 4;

        static int PlayerIndex => 0;
        static int EnemyIndex => PlayerIndex + PlayerMax;//0+1=1
        static int ItemIndex => EnemyIndex + EnemyMax;//0+4=4
        static int LabelMax => ItemIndex + EnemyMax;//4+5=9

        Label[] labels = new Label[LabelMax];

        static Random random = new Random();

        int[] vx = new int[LabelMax];
        int[] vy = new int[LabelMax];

        static int SpeedMax => 10;

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

            for (int i = 0; i < LabelMax; i++)
            {
                labels[i] = new Label();
                labels[i].AutoSize = true;
                labels[i].Visible = false;
                Controls.Add(labels[i]);

                vx[i] = random.Next(-SpeedMax , SpeedMax+1);
                vy[i] = random.Next(-SpeedMax , SpeedMax+1);

                labelPlayer.Visible = false;
                labelEnemy.Visible = false;
                labelItem.Visible = false;

                //Text,Font,ForeColor����ނ��Ƃɐݒ�
                //�v���C���[���x���̐���
                if (i >= PlayerIndex && i < PlayerMax)
                {
                    labels[i].Text = labelPlayer.Text;
                    labels[i].Font = labelPlayer.Font;
                    labels[i].ForeColor = labelPlayer.ForeColor;
                }
                //�G���x���̐���
                if (i >= EnemyIndex && i <= EnemyMax)
                {
                    labels[i].Text = labelEnemy.Text;
                    labels[i].Font = labelEnemy.Font;
                    labels[i].ForeColor = labelEnemy.ForeColor;
                }
                //�A�C�e�����x���̐���
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
            UpdateChrs();
        }

        void InitState()
        {   //�Ԑl
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
                    labelTitle.Visible = true;
                    buttonStart.Visible = true;

                    labelClear.Visible = false;
                    labelGameover.Visible = false;
                    buttonToTitle.Visible = false;
                    break;

                case State.Game:
                    labelTitle.Visible = false;
                    buttonStart.Visible = false;
                    
                    for (int i = 0; i < LabelMax; i++)
                    {
                        labels[i].Visible = true;
                    }
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
            if (GetAsyncKeyState((int)Keys.O) < 0)
            {
                nextState = State.Gameover;
            }

            if (GetAsyncKeyState((int)Keys.C) < 0)
            {
                nextState = State.Clear;
            }

            //�v���C���[�̈ړ�
            var fpos = PointToClient(MousePosition);
            labels[PlayerIndex].Left = fpos.X - (labels[PlayerIndex].Width / 2);
            labels[PlayerIndex].Top = fpos.Y - (labels[PlayerIndex].Height / 2);

            //�L�����N�^�[�̍X�V
            UpdateChrs();
        }

        void UpdateChrs()
        {
            //�G�ƃA�C�e���̈ړ��ƒ��˕Ԃ菈��
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