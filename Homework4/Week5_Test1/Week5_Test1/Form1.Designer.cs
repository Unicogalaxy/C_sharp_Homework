namespace Week5_Test1
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
            this.txtFile1 = new System.Windows.Forms.TextBox();
            this.txtFile2 = new System.Windows.Forms.TextBox();
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.btnSelectFile1 = new System.Windows.Forms.Button();
            this.btnSelectFile2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFile1
            // 
            this.txtFile1.Location = new System.Drawing.Point(136, 86);
            this.txtFile1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFile1.Name = "txtFile1";
            this.txtFile1.Size = new System.Drawing.Size(475, 38);
            this.txtFile1.TabIndex = 0;
            this.txtFile1.Text = "点击select选择文件";
            this.txtFile1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtFile2
            // 
            this.txtFile2.Location = new System.Drawing.Point(136, 343);
            this.txtFile2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFile2.Name = "txtFile2";
            this.txtFile2.Size = new System.Drawing.Size(475, 38);
            this.txtFile2.TabIndex = 1;
            this.txtFile2.Text = "点击select选择文件";
            this.txtFile2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.BackColor = System.Drawing.SystemColors.Info;
            this.btnSelectFiles.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSelectFiles.Location = new System.Drawing.Point(1161, 210);
            this.btnSelectFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(189, 62);
            this.btnSelectFiles.TabIndex = 4;
            this.btnSelectFiles.Text = "合并文件";
            this.btnSelectFiles.UseVisualStyleBackColor = false;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // btnSelectFile1
            // 
            this.btnSelectFile1.BackColor = System.Drawing.SystemColors.Info;
            this.btnSelectFile1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFile1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSelectFile1.Location = new System.Drawing.Point(783, 86);
            this.btnSelectFile1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectFile1.Name = "btnSelectFile1";
            this.btnSelectFile1.Size = new System.Drawing.Size(189, 62);
            this.btnSelectFile1.TabIndex = 6;
            this.btnSelectFile1.Text = "select";
            this.btnSelectFile1.UseVisualStyleBackColor = false;
            this.btnSelectFile1.Click += new System.EventHandler(this.btnSelectFile1_Click);
            // 
            // btnSelectFile2
            // 
            this.btnSelectFile2.BackColor = System.Drawing.SystemColors.Info;
            this.btnSelectFile2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSelectFile2.Location = new System.Drawing.Point(783, 343);
            this.btnSelectFile2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectFile2.Name = "btnSelectFile2";
            this.btnSelectFile2.Size = new System.Drawing.Size(189, 62);
            this.btnSelectFile2.TabIndex = 7;
            this.btnSelectFile2.Text = "select";
            this.btnSelectFile2.UseVisualStyleBackColor = false;
            this.btnSelectFile2.Click += new System.EventHandler(this.btnSelectFile2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1393, 625);
            this.Controls.Add(this.btnSelectFile2);
            this.Controls.Add(this.btnSelectFile1);
            this.Controls.Add(this.btnSelectFiles);
            this.Controls.Add(this.txtFile2);
            this.Controls.Add(this.txtFile1);
            this.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile1;
        private System.Windows.Forms.TextBox txtFile2;
        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.Button btnSelectFile1;
        private System.Windows.Forms.Button btnSelectFile2;
    }
}