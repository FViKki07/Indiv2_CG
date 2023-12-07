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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(182, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(606, 473);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // cube_trans
            // 
            cube_trans.AutoSize = true;
            cube_trans.Location = new Point(12, 27);
            cube_trans.Name = "cube_trans";
            cube_trans.Size = new Size(133, 19);
            cube_trans.TabIndex = 1;
            cube_trans.Text = "Прозрачность куба";
            cube_trans.UseVisualStyleBackColor = true;
            // 
            // shere_trans
            // 
            shere_trans.AutoSize = true;
            shere_trans.Location = new Point(12, 52);
            shere_trans.Name = "shere_trans";
            shere_trans.Size = new Size(138, 19);
            shere_trans.TabIndex = 2;
            shere_trans.Text = "Прозрачность шара";
            shere_trans.UseVisualStyleBackColor = true;
            // 
            // cube_mirror
            // 
            cube_mirror.AutoSize = true;
            cube_mirror.Location = new Point(12, 77);
            cube_mirror.Name = "cube_mirror";
            cube_mirror.Size = new Size(130, 19);
            cube_mirror.TabIndex = 3;
            cube_mirror.Text = "Зеркальность куба";
            cube_mirror.UseVisualStyleBackColor = true;
            // 
            // shere_mirror
            // 
            shere_mirror.AutoSize = true;
            shere_mirror.Location = new Point(12, 102);
            shere_mirror.Name = "shere_mirror";
            shere_mirror.Size = new Size(135, 19);
            shere_mirror.TabIndex = 4;
            shere_mirror.Text = "Зеркальность шара";
            shere_mirror.UseVisualStyleBackColor = true;
            // 
            // Light_add
            // 
            Light_add.AutoSize = true;
            Light_add.Location = new Point(12, 146);
            Light_add.Name = "Light_add";
            Light_add.Size = new Size(150, 19);
            Light_add.TabIndex = 9;
            Light_add.Text = "Дополнительный цвет";
            Light_add.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(44, 196);
            button1.Name = "button1";
            button1.Size = new Size(98, 23);
            button1.TabIndex = 11;
            button1.Text = "Применить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 497);
            Controls.Add(button1);
            Controls.Add(Light_add);
            Controls.Add(shere_mirror);
            Controls.Add(cube_mirror);
            Controls.Add(shere_trans);
            Controls.Add(cube_trans);
            Controls.Add(pictureBox1);
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
    }
}