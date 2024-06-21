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
            labelTitle.Font = new Font("Yu Gothic UI", 72F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.ForeColor = Color.FromArgb(192, 255, 255);
            labelTitle.Location = new Point(191, 135);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(542, 128);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "YOKETORU";
            labelTitle.Click += labelTitle_Click;
            // 
            // buttonStart
            // 
            buttonStart.BackColor = Color.Cyan;
            buttonStart.Font = new Font("UD デジタル 教科書体 NK-B", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            buttonStart.ForeColor = SystemColors.ButtonFace;
            buttonStart.Location = new Point(401, 349);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(154, 84);
            buttonStart.TabIndex = 1;
            buttonStart.Text = "スタート";
            buttonStart.UseVisualStyleBackColor = false;
            buttonStart.Click += buttonStart_Click;
            // 
            // labelGameover
            // 
            labelGameover.AutoSize = true;
            labelGameover.Font = new Font("Bauhaus 93", 48F, FontStyle.Bold, GraphicsUnit.Point);
            labelGameover.Location = new Point(257, 180);
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
            buttonToTitle.Location = new Point(401, 349);
            buttonToTitle.Name = "buttonToTitle";
            buttonToTitle.Size = new Size(154, 84);
            buttonToTitle.TabIndex = 3;
            buttonToTitle.Text = "タイトルへ";
            buttonToTitle.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 501);
            Controls.Add(buttonStart);
            Controls.Add(labelTitle);
            Controls.Add(labelGameover);
            Controls.Add(buttonToTitle);
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
    }
}