namespace YOKETORUcs
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            labelTitle = new Label();
            buttonStart = new Button();
            labelGameover = new Label();
            buttonToTitle = new Button();
            labelClear = new Label();
            labelScore = new Label();
            labelTime = new Label();
            labelItem = new Label();
            labelPlayer = new Label();
            labelEnemy = new Label();
            labelHighScore = new Label();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Swis721 Blk BT", 60F, FontStyle.Italic, GraphicsUnit.Point);
            labelTitle.ForeColor = Color.Cyan;
            labelTitle.Location = new Point(217, 162);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(511, 96);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "YOKETORU";
            labelTitle.Click += labelTitle_Click;
            // 
            // buttonStart
            // 
            buttonStart.BackColor = Color.MintCream;
            buttonStart.Font = new Font("UD デジタル 教科書体 NK-B", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            buttonStart.ForeColor = Color.RoyalBlue;
            buttonStart.Location = new Point(381, 373);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(154, 89);
            buttonStart.TabIndex = 1;
            buttonStart.Text = "スタート";
            buttonStart.UseVisualStyleBackColor = false;
            buttonStart.Click += buttonStart_Click;
            // 
            // labelGameover
            // 
            labelGameover.AutoSize = true;
            labelGameover.Font = new Font("Bauhaus 93", 48F, FontStyle.Bold, GraphicsUnit.Point);
            labelGameover.Location = new Point(256, 186);
            labelGameover.Name = "labelGameover";
            labelGameover.Size = new Size(441, 73);
            labelGameover.TabIndex = 2;
            labelGameover.Text = "GAME OVER…";
            // 
            // buttonToTitle
            // 
            buttonToTitle.BackColor = Color.LightCoral;
            buttonToTitle.Font = new Font("UD デジタル 教科書体 NK-B", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            buttonToTitle.ForeColor = SystemColors.ActiveCaptionText;
            buttonToTitle.Location = new Point(381, 373);
            buttonToTitle.Name = "buttonToTitle";
            buttonToTitle.Size = new Size(154, 89);
            buttonToTitle.TabIndex = 3;
            buttonToTitle.Text = "タイトルへ";
            buttonToTitle.UseVisualStyleBackColor = false;
            buttonToTitle.Click += buttonToTitle_Click;
            // 
            // labelClear
            // 
            labelClear.AutoSize = true;
            labelClear.Font = new Font("Bauhaus 93", 48F, FontStyle.Bold, GraphicsUnit.Point);
            labelClear.ForeColor = Color.FromArgb(233, 238, 11);
            labelClear.Location = new Point(323, 186);
            labelClear.Name = "labelClear";
            labelClear.Size = new Size(288, 73);
            labelClear.TabIndex = 4;
            labelClear.Text = "CREAR!!";
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Font = new Font("Swis721 BlkCn BT", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelScore.Location = new Point(424, 9);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(28, 32);
            labelScore.TabIndex = 5;
            labelScore.Text = "0";
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Font = new Font("Swis721 BlkCn BT", 25F, FontStyle.Regular, GraphicsUnit.Point);
            labelTime.Location = new Point(843, 481);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(72, 41);
            labelTime.TabIndex = 6;
            labelTime.Text = "200";
            labelTime.TextAlign = ContentAlignment.TopRight;
            // 
            // labelItem
            // 
            labelItem.AutoSize = true;
            labelItem.Font = new Font("メイリオ", 20F, FontStyle.Regular, GraphicsUnit.Point);
            labelItem.ForeColor = Color.FromArgb(255, 255, 128);
            labelItem.Location = new Point(299, 295);
            labelItem.Name = "labelItem";
            labelItem.Size = new Size(45, 41);
            labelItem.TabIndex = 7;
            labelItem.Text = "★";
            labelItem.Click += labelItem_Click;
            // 
            // labelPlayer
            // 
            labelPlayer.AutoSize = true;
            labelPlayer.Font = new Font("メイリオ", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelPlayer.Location = new Point(424, 310);
            labelPlayer.Name = "labelPlayer";
            labelPlayer.Size = new Size(67, 21);
            labelPlayer.TabIndex = 9;
            labelPlayer.Text = "( 。∀ ﾟ)";
            // 
            // labelEnemy
            // 
            labelEnemy.AutoSize = true;
            labelEnemy.BackColor = SystemColors.ControlDark;
            labelEnemy.Font = new Font("メイリオ", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelEnemy.Location = new Point(572, 310);
            labelEnemy.Name = "labelEnemy";
            labelEnemy.Size = new Size(52, 21);
            labelEnemy.TabIndex = 10;
            labelEnemy.Text = "◉▽◉";
            labelEnemy.Click += labelEnemy_Click;
            // 
            // labelHighScore
            // 
            labelHighScore.AutoSize = true;
            labelHighScore.Font = new Font("Swis721 BlkCn BT", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelHighScore.Location = new Point(721, 9);
            labelHighScore.Name = "labelHighScore";
            labelHighScore.Size = new Size(141, 32);
            labelHighScore.TabIndex = 11;
            labelHighScore.Text = "ハイスコア:0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 535);
            Controls.Add(labelHighScore);
            Controls.Add(labelEnemy);
            Controls.Add(labelPlayer);
            Controls.Add(labelItem);
            Controls.Add(labelTime);
            Controls.Add(labelScore);
            Controls.Add(buttonStart);
            Controls.Add(labelTitle);
            Controls.Add(labelGameover);
            Controls.Add(buttonToTitle);
            Controls.Add(labelClear);
            Font = new Font("游ゴシック", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Label labelTitle;
        private Button buttonStart;
        private Label labelGameover;
        private Button buttonToTitle;
        private Label labelClear;
        private Label labelScore;
        private Label labelTime;
        private Label labelItem;
        private Label labelPlayer;
        private Label labelEnemy;
        private Label labelHighScore;
    }
}