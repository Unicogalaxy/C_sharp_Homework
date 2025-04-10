namespace WebContentScraper
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
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.scrapeButton = new System.Windows.Forms.Button();
            this.phoneListBox = new System.Windows.Forms.ListBox();
            this.emailListBox = new System.Windows.Forms.ListBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlTextBox
            // 
            this.urlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.urlTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.urlTextBox.Location = new System.Drawing.Point(20, 50);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(500, 41);
            this.urlTextBox.TabIndex = 0;
            // 
            // scrapeButton
            // 
            this.scrapeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.scrapeButton.FlatAppearance.BorderSize = 0;
            this.scrapeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scrapeButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scrapeButton.ForeColor = System.Drawing.Color.White;
            this.scrapeButton.Location = new System.Drawing.Point(526, 50);
            this.scrapeButton.Name = "scrapeButton";
            this.scrapeButton.Size = new System.Drawing.Size(160, 55);
            this.scrapeButton.TabIndex = 1;
            this.scrapeButton.Text = "开始抓取";
            this.scrapeButton.UseVisualStyleBackColor = false;
            this.scrapeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // phoneListBox
            // 
            this.phoneListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phoneListBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.phoneListBox.FormattingEnabled = true;
            this.phoneListBox.ItemHeight = 35;
            this.phoneListBox.Location = new System.Drawing.Point(20, 150);
            this.phoneListBox.Name = "phoneListBox";
            this.phoneListBox.Size = new System.Drawing.Size(300, 212);
            this.phoneListBox.TabIndex = 2;
            // 
            // emailListBox
            // 
            this.emailListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailListBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emailListBox.FormattingEnabled = true;
            this.emailListBox.ItemHeight = 35;
            this.emailListBox.Location = new System.Drawing.Point(346, 150);
            this.emailListBox.Name = "emailListBox";
            this.emailListBox.Size = new System.Drawing.Size(300, 212);
            this.emailListBox.TabIndex = 3;
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.urlLabel.Location = new System.Drawing.Point(20, 20);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(148, 35);
            this.urlLabel.TabIndex = 4;
            this.urlLabel.Text = "网页URL：";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.phoneLabel.Location = new System.Drawing.Point(20, 120);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(150, 35);
            this.phoneLabel.TabIndex = 5;
            this.phoneLabel.Text = "手机号码：";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emailLabel.Location = new System.Drawing.Point(346, 120);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(150, 35);
            this.emailLabel.TabIndex = 6;
            this.emailLabel.Text = "电子邮箱：";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(20, 467);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(815, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 12);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(855, 509);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.emailListBox);
            this.Controls.Add(this.phoneListBox);
            this.Controls.Add(this.scrapeButton);
            this.Controls.Add(this.urlTextBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网页内容抓取工具";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button scrapeButton;
        private System.Windows.Forms.ListBox phoneListBox;
        private System.Windows.Forms.ListBox emailListBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}