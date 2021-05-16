namespace ProgramGUI
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.invalidStateButton = new System.Windows.Forms.Button();
            this.gradientButton = new System.Windows.Forms.Button();
            this.transparentGradientButton = new System.Windows.Forms.Button();
            this.disabledButton = new System.Windows.Forms.Button();
            this.blurButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.invalidStateButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gradientButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.transparentGradientButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.disabledButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.blurButton, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(415, 235);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // invalidStateButton
            // 
            this.invalidStateButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invalidStateButton.Location = new System.Drawing.Point(3, 3);
            this.invalidStateButton.Name = "invalidStateButton";
            this.invalidStateButton.Size = new System.Drawing.Size(201, 52);
            this.invalidStateButton.TabIndex = 0;
            this.invalidStateButton.Text = "Invalid State";
            this.invalidStateButton.UseVisualStyleBackColor = true;
            this.invalidStateButton.Click += new System.EventHandler(this.enableTransparencyButton_Click);
            // 
            // gradientButton
            // 
            this.gradientButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientButton.Location = new System.Drawing.Point(210, 3);
            this.gradientButton.Name = "gradientButton";
            this.gradientButton.Size = new System.Drawing.Size(202, 52);
            this.gradientButton.TabIndex = 1;
            this.gradientButton.Text = "Gradient";
            this.gradientButton.UseVisualStyleBackColor = true;
            this.gradientButton.Click += new System.EventHandler(this.gradientButton_Click);
            // 
            // transparentGradientButton
            // 
            this.transparentGradientButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transparentGradientButton.Location = new System.Drawing.Point(3, 61);
            this.transparentGradientButton.Name = "transparentGradientButton";
            this.transparentGradientButton.Size = new System.Drawing.Size(201, 52);
            this.transparentGradientButton.TabIndex = 2;
            this.transparentGradientButton.Text = "Transparent Gradient";
            this.transparentGradientButton.UseVisualStyleBackColor = true;
            this.transparentGradientButton.Click += new System.EventHandler(this.transparentGradientButton_Click);
            // 
            // disabledButton
            // 
            this.disabledButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.disabledButton.Location = new System.Drawing.Point(210, 61);
            this.disabledButton.Name = "disabledButton";
            this.disabledButton.Size = new System.Drawing.Size(202, 52);
            this.disabledButton.TabIndex = 3;
            this.disabledButton.Text = "Disabled";
            this.disabledButton.UseVisualStyleBackColor = true;
            this.disabledButton.Click += new System.EventHandler(this.disabledButton_Click);
            // 
            // blurButton
            // 
            this.blurButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blurButton.Location = new System.Drawing.Point(3, 119);
            this.blurButton.Name = "blurButton";
            this.blurButton.Size = new System.Drawing.Size(201, 52);
            this.blurButton.TabIndex = 4;
            this.blurButton.Text = "Blur";
            this.blurButton.UseVisualStyleBackColor = true;
            this.blurButton.Click += new System.EventHandler(this.blurButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 237);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(7, 2, 7, 0);
            this.Text = "Taskbar Modifier v0.1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button invalidStateButton;
        private System.Windows.Forms.Button gradientButton;
        private System.Windows.Forms.Button transparentGradientButton;
        private System.Windows.Forms.Button disabledButton;
        private System.Windows.Forms.Button blurButton;
    }
}

