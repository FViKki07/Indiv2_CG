namespace Indiv
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
            pictureBox1 = new PictureBox();
            cube_trans = new CheckBox();
            shere_trans = new CheckBox();
            cube_mirror = new CheckBox();
            shere_mirror = new CheckBox();
            Light_add = new CheckBox();
            button1 = new Button();
            DownWall = new CheckBox();
            LeftWall = new CheckBox();
            UpWall = new CheckBox();
            RightWall = new CheckBox();
            label1 = new Label();
            BackWall = new CheckBox();
            FaceWall = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(208, 16);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(693, 631);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // cube_trans
            // 
            cube_trans.AutoSize = true;
            cube_trans.Location = new Point(14, 36);
            cube_trans.Margin = new Padding(3, 4, 3, 4);
            cube_trans.Name = "cube_trans";
            cube_trans.Size = new Size(166, 24);
            cube_trans.TabIndex = 1;
            cube_trans.Text = "Прозрачность куба";
            cube_trans.UseVisualStyleBackColor = true;
            // 
            // shere_trans
            // 
            shere_trans.AutoSize = true;
            shere_trans.Location = new Point(14, 69);
            shere_trans.Margin = new Padding(3, 4, 3, 4);
            shere_trans.Name = "shere_trans";
            shere_trans.Size = new Size(172, 24);
            shere_trans.TabIndex = 2;
            shere_trans.Text = "Прозрачность шара";
            shere_trans.UseVisualStyleBackColor = true;
            // 
            // cube_mirror
            // 
            cube_mirror.AutoSize = true;
            cube_mirror.Location = new Point(14, 103);
            cube_mirror.Margin = new Padding(3, 4, 3, 4);
            cube_mirror.Name = "cube_mirror";
            cube_mirror.Size = new Size(161, 24);
            cube_mirror.TabIndex = 3;
            cube_mirror.Text = "Зеркальность куба";
            cube_mirror.UseVisualStyleBackColor = true;
            // 
            // shere_mirror
            // 
            shere_mirror.AutoSize = true;
            shere_mirror.Location = new Point(14, 136);
            shere_mirror.Margin = new Padding(3, 4, 3, 4);
            shere_mirror.Name = "shere_mirror";
            shere_mirror.Size = new Size(167, 24);
            shere_mirror.TabIndex = 4;
            shere_mirror.Text = "Зеркальность шара";
            shere_mirror.UseVisualStyleBackColor = true;
            // 
            // Light_add
            // 
            Light_add.AutoSize = true;
            Light_add.Location = new Point(14, 195);
            Light_add.Margin = new Padding(3, 4, 3, 4);
            Light_add.Name = "Light_add";
            Light_add.Size = new Size(188, 24);
            Light_add.TabIndex = 9;
            Light_add.Text = "Дополнительный цвет";
            Light_add.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(50, 441);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(112, 31);
            button1.TabIndex = 11;
            button1.Text = "Применить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DownWall
            // 
            DownWall.AutoSize = true;
            DownWall.Location = new Point(24, 322);
            DownWall.Margin = new Padding(3, 4, 3, 4);
            DownWall.Name = "DownWall";
            DownWall.Size = new Size(59, 24);
            DownWall.TabIndex = 12;
            DownWall.Text = "Пол";
            DownWall.UseVisualStyleBackColor = true;
            // 
            // LeftWall
            // 
            LeftWall.AutoSize = true;
            LeftWall.Location = new Point(24, 299);
            LeftWall.Margin = new Padding(3, 4, 3, 4);
            LeftWall.Name = "LeftWall";
            LeftWall.Size = new Size(73, 24);
            LeftWall.TabIndex = 13;
            LeftWall.Text = "Левая";
            LeftWall.UseVisualStyleBackColor = true;
            // 
            // UpWall
            // 
            UpWall.AutoSize = true;
            UpWall.Location = new Point(24, 343);
            UpWall.Margin = new Padding(3, 4, 3, 4);
            UpWall.Name = "UpWall";
            UpWall.Size = new Size(90, 24);
            UpWall.TabIndex = 14;
            UpWall.Text = "Потолок";
            UpWall.UseVisualStyleBackColor = true;
            // 
            // RightWall
            // 
            RightWall.AutoSize = true;
            RightWall.Location = new Point(24, 276);
            RightWall.Margin = new Padding(3, 4, 3, 4);
            RightWall.Name = "RightWall";
            RightWall.Size = new Size(83, 24);
            RightWall.TabIndex = 15;
            RightWall.Text = "Правая";
            RightWall.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 252);
            label1.Name = "label1";
            label1.Size = new Size(138, 20);
            label1.TabIndex = 16;
            label1.Text = "Зеркальность стен";
            // 
            // BackWall
            // 
            BackWall.AutoSize = true;
            BackWall.Location = new Point(24, 388);
            BackWall.Margin = new Padding(3, 4, 3, 4);
            BackWall.Name = "BackWall";
            BackWall.Size = new Size(80, 24);
            BackWall.TabIndex = 17;
            BackWall.Text = "Задняя";
            BackWall.UseVisualStyleBackColor = true;
            // 
            // FaceWall
            // 
            FaceWall.AutoSize = true;
            FaceWall.Location = new Point(24, 366);
            FaceWall.Margin = new Padding(3, 4, 3, 4);
            FaceWall.Name = "FaceWall";
            FaceWall.Size = new Size(100, 24);
            FaceWall.TabIndex = 18;
            FaceWall.Text = "Передняя";
            FaceWall.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 663);
            Controls.Add(FaceWall);
            Controls.Add(BackWall);
            Controls.Add(label1);
            Controls.Add(RightWall);
            Controls.Add(UpWall);
            Controls.Add(LeftWall);
            Controls.Add(DownWall);
            Controls.Add(button1);
            Controls.Add(Light_add);
            Controls.Add(shere_mirror);
            Controls.Add(cube_mirror);
            Controls.Add(shere_trans);
            Controls.Add(cube_trans);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private CheckBox cube_trans;
        private CheckBox shere_trans;
        private CheckBox cube_mirror;
        private CheckBox shere_mirror;
        private CheckBox Light_add;
        private Button button1;
        private CheckBox DownWall;
        private CheckBox LeftWall;
        private CheckBox UpWall;
        private CheckBox RightWall;
        private Label label1;
        private CheckBox BackWall;
        private CheckBox FaceWall;
    }
}