namespace QuestionPaper_Genration
{
    partial class GenrateQuestionPaper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenrateQuestionPaper));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NoOFQuestionSet = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtNoOfQuestionSet = new System.Windows.Forms.TextBox();
            this.txtsec4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Btnsubmit = new System.Windows.Forms.Button();
            this.txtsec3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtsec1 = new System.Windows.Forms.TextBox();
            this.cmblevel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbsubject = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.groupBox1.Controls.Add(this.NoOFQuestionSet);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.TxtNoOfQuestionSet);
            this.groupBox1.Controls.Add(this.txtsec4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Btnsubmit);
            this.groupBox1.Controls.Add(this.txtsec3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtsec1);
            this.groupBox1.Controls.Add(this.cmblevel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbsubject);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 470);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Question Paper Genration";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // NoOFQuestionSet
            // 
            this.NoOFQuestionSet.FormattingEnabled = true;
            this.NoOFQuestionSet.Location = new System.Drawing.Point(287, 411);
            this.NoOFQuestionSet.Name = "NoOFQuestionSet";
            this.NoOFQuestionSet.Size = new System.Drawing.Size(130, 28);
            this.NoOFQuestionSet.TabIndex = 22;
            this.NoOFQuestionSet.SelectedIndexChanged += new System.EventHandler(this.NoOFQuestionSet_SelectedIndexChanged);
            this.NoOFQuestionSet.SelectionChangeCommitted += new System.EventHandler(this.NoOFQuestionSet_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(69, 411);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Genrate Paper:";
            // 
            // TxtNoOfQuestionSet
            // 
            this.TxtNoOfQuestionSet.Location = new System.Drawing.Point(287, 140);
            this.TxtNoOfQuestionSet.Name = "TxtNoOfQuestionSet";
            this.TxtNoOfQuestionSet.Size = new System.Drawing.Size(216, 26);
            this.TxtNoOfQuestionSet.TabIndex = 18;
            this.TxtNoOfQuestionSet.Text = "3";
            this.TxtNoOfQuestionSet.Visible = false;
            this.TxtNoOfQuestionSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNoOfQuestionSet_KeyPress_1);
            // 
            // txtsec4
            // 
            this.txtsec4.Location = new System.Drawing.Point(287, 296);
            this.txtsec4.Name = "txtsec4";
            this.txtsec4.Size = new System.Drawing.Size(112, 26);
            this.txtsec4.TabIndex = 17;
            this.txtsec4.Visible = false;
            this.txtsec4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsec4_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(69, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "10 Mark :";
            this.label7.Visible = false;
            // 
            // Btnsubmit
            // 
            this.Btnsubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Btnsubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnsubmit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Btnsubmit.Location = new System.Drawing.Point(287, 337);
            this.Btnsubmit.Name = "Btnsubmit";
            this.Btnsubmit.Size = new System.Drawing.Size(112, 28);
            this.Btnsubmit.TabIndex = 15;
            this.Btnsubmit.Text = "Generate";
            this.Btnsubmit.UseVisualStyleBackColor = false;
            this.Btnsubmit.Click += new System.EventHandler(this.Btnsubmit_Click);
            // 
            // txtsec3
            // 
            this.txtsec3.Location = new System.Drawing.Point(287, 241);
            this.txtsec3.Name = "txtsec3";
            this.txtsec3.Size = new System.Drawing.Size(112, 26);
            this.txtsec3.TabIndex = 13;
            this.txtsec3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsec3_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(69, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "5 Mark :";
            // 
            // txtsec1
            // 
            this.txtsec1.Location = new System.Drawing.Point(287, 189);
            this.txtsec1.Name = "txtsec1";
            this.txtsec1.Size = new System.Drawing.Size(112, 26);
            this.txtsec1.TabIndex = 8;
            this.txtsec1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsec1_KeyPress);
            // 
            // cmblevel
            // 
            this.cmblevel.FormattingEnabled = true;
            this.cmblevel.Location = new System.Drawing.Point(287, 94);
            this.cmblevel.Name = "cmblevel";
            this.cmblevel.Size = new System.Drawing.Size(216, 28);
            this.cmblevel.TabIndex = 6;
            this.cmblevel.SelectedIndexChanged += new System.EventHandler(this.cmblevel_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Enter No Sets:";
            this.label3.Visible = false;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmbsubject
            // 
            this.cmbsubject.FormattingEnabled = true;
            this.cmbsubject.Location = new System.Drawing.Point(287, 48);
            this.cmbsubject.Name = "cmbsubject";
            this.cmbsubject.Size = new System.Drawing.Size(216, 28);
            this.cmbsubject.TabIndex = 5;
            this.cmbsubject.SelectedIndexChanged += new System.EventHandler(this.cmbsubject_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "2 Mark :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter Level:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Subject:";
            // 
            // GenrateQuestionPaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(716, 500);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenrateQuestionPaper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GenrateQuestionPaper";
            this.Load += new System.EventHandler(this.GenrateQuestionPaper_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtsec1;
        private System.Windows.Forms.ComboBox cmblevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbsubject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsec3;
        private System.Windows.Forms.Button Btnsubmit;
        private System.Windows.Forms.TextBox txtsec4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtNoOfQuestionSet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox NoOFQuestionSet;
    }
}