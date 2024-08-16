using SharpDX.MediaFoundation;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TD2
{
    partial class TowerMenu : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TowerMenu));
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            colorDialog1 = new ColorDialog();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(327, 247);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(112, 47);
            button1.TabIndex = 0;
            button1.Text = "buy";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(58, 247);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(117, 47);
            button2.TabIndex = 1;
            button2.Text = "buy";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(306, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(163, 177);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(40, 29);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(169, 177);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(175, 44);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(0, 25);
            label1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(215, 44);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(77, 25);
            label2.TabIndex = 5;
            label2.Text = "Workers";
            // 
            // colorDialog1
            // 
            colorDialog1.Color = System.Drawing.Color.Blue;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(336, 212);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(93, 31);
            textBox1.TabIndex = 6;
            textBox1.Text = "Cost: 100";
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(71, 212);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(93, 31);
            textBox2.TabIndex = 7;
            textBox2.Text = "Cost: 200";
            // 
            // TowerMenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.LightGray;
            ClientSize = new System.Drawing.Size(481, 308);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "TowerMenu";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private ColorDialog colorDialog1;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}