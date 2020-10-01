namespace HuffmanCoding {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.DisplayPic = new System.Windows.Forms.PictureBox();
            this.EncodeFileBtn = new System.Windows.Forms.Button();
            this.EncodeNewFileBtn = new System.Windows.Forms.Button();
            this.PreviousStepBtn = new System.Windows.Forms.Button();
            this.NextStepBtn = new System.Windows.Forms.Button();
            this.StepLbl = new System.Windows.Forms.Label();
            this.ASCIIChk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayPic)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayPic
            // 
            this.DisplayPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayPic.Location = new System.Drawing.Point(12, 12);
            this.DisplayPic.Name = "DisplayPic";
            this.DisplayPic.Size = new System.Drawing.Size(608, 402);
            this.DisplayPic.TabIndex = 0;
            this.DisplayPic.TabStop = false;
            this.DisplayPic.Click += new System.EventHandler(this.DisplayPic_Click);
            this.DisplayPic.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayPic_Paint);
            // 
            // EncodeFileBtn
            // 
            this.EncodeFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EncodeFileBtn.Location = new System.Drawing.Point(626, 12);
            this.EncodeFileBtn.Name = "EncodeFileBtn";
            this.EncodeFileBtn.Size = new System.Drawing.Size(111, 100);
            this.EncodeFileBtn.TabIndex = 1;
            this.EncodeFileBtn.Text = "Make a tree encode the file then decode it";
            this.EncodeFileBtn.UseVisualStyleBackColor = true;
            this.EncodeFileBtn.Click += new System.EventHandler(this.EncodeFileBtn_Click);
            // 
            // EncodeNewFileBtn
            // 
            this.EncodeNewFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EncodeNewFileBtn.Location = new System.Drawing.Point(626, 118);
            this.EncodeNewFileBtn.Name = "EncodeNewFileBtn";
            this.EncodeNewFileBtn.Size = new System.Drawing.Size(111, 115);
            this.EncodeNewFileBtn.TabIndex = 2;
            this.EncodeNewFileBtn.Text = "Encode then decode a new file using the tree";
            this.EncodeNewFileBtn.UseVisualStyleBackColor = true;
            this.EncodeNewFileBtn.Click += new System.EventHandler(this.EncodeNewFileBtn_Click);
            // 
            // PreviousStepBtn
            // 
            this.PreviousStepBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PreviousStepBtn.Location = new System.Drawing.Point(12, 420);
            this.PreviousStepBtn.Name = "PreviousStepBtn";
            this.PreviousStepBtn.Size = new System.Drawing.Size(111, 25);
            this.PreviousStepBtn.TabIndex = 3;
            this.PreviousStepBtn.Text = "Previous Step";
            this.PreviousStepBtn.UseVisualStyleBackColor = true;
            this.PreviousStepBtn.Click += new System.EventHandler(this.PreviousStepBtn_Click);
            // 
            // NextStepBtn
            // 
            this.NextStepBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextStepBtn.Location = new System.Drawing.Point(509, 420);
            this.NextStepBtn.Name = "NextStepBtn";
            this.NextStepBtn.Size = new System.Drawing.Size(111, 25);
            this.NextStepBtn.TabIndex = 4;
            this.NextStepBtn.Text = "Next Step";
            this.NextStepBtn.UseVisualStyleBackColor = true;
            this.NextStepBtn.Click += new System.EventHandler(this.NextStepBtn_Click);
            // 
            // StepLbl
            // 
            this.StepLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StepLbl.Location = new System.Drawing.Point(129, 424);
            this.StepLbl.Name = "StepLbl";
            this.StepLbl.Size = new System.Drawing.Size(374, 17);
            this.StepLbl.TabIndex = 5;
            this.StepLbl.Text = "Step: #/#";
            this.StepLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ASCIIChk
            // 
            this.ASCIIChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ASCIIChk.AutoSize = true;
            this.ASCIIChk.Location = new System.Drawing.Point(626, 239);
            this.ASCIIChk.Name = "ASCIIChk";
            this.ASCIIChk.Size = new System.Drawing.Size(99, 21);
            this.ASCIIChk.TabIndex = 7;
            this.ASCIIChk.Text = "Draw ASCII";
            this.ASCIIChk.UseVisualStyleBackColor = true;
            this.ASCIIChk.CheckedChanged += new System.EventHandler(this.ASCIIChk_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 452);
            this.Controls.Add(this.ASCIIChk);
            this.Controls.Add(this.StepLbl);
            this.Controls.Add(this.NextStepBtn);
            this.Controls.Add(this.PreviousStepBtn);
            this.Controls.Add(this.EncodeNewFileBtn);
            this.Controls.Add(this.EncodeFileBtn);
            this.Controls.Add(this.DisplayPic);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DisplayPic;
        private System.Windows.Forms.Button EncodeFileBtn;
        private System.Windows.Forms.Button EncodeNewFileBtn;
        private System.Windows.Forms.Button PreviousStepBtn;
        private System.Windows.Forms.Button NextStepBtn;
        private System.Windows.Forms.Label StepLbl;
        private System.Windows.Forms.CheckBox ASCIIChk;
    }
}

