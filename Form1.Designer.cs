namespace PastebinLib
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDevKey = new System.Windows.Forms.TextBox();
            this.txtUrlKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Developer Key";
            // 
            // txtDevKey
            // 
            this.txtDevKey.Location = new System.Drawing.Point(95, 6);
            this.txtDevKey.Name = "txtDevKey";
            this.txtDevKey.Size = new System.Drawing.Size(177, 20);
            this.txtDevKey.TabIndex = 1;
            // 
            // txtUrlKey
            // 
            this.txtUrlKey.Location = new System.Drawing.Point(95, 32);
            this.txtUrlKey.Name = "txtUrlKey";
            this.txtUrlKey.Size = new System.Drawing.Size(177, 20);
            this.txtUrlKey.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "File Url Key";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(12, 63);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(260, 148);
            this.textBox3.TabIndex = 4;
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGet.Location = new System.Drawing.Point(12, 217);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(100, 35);
            this.btnGet.TabIndex = 5;
            this.btnGet.Text = "Get Code";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnPost
            // 
            this.btnPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPost.Location = new System.Drawing.Point(172, 217);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(100, 35);
            this.btnPost.TabIndex = 6;
            this.btnPost.Text = "New Paste";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtUrlKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDevKey);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "PastebinLib";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDevKey;
        private System.Windows.Forms.TextBox txtUrlKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnPost;
    }
}
