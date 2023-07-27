namespace Chaos_Game_fix
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
            this.redbtn = new System.Windows.Forms.Button();
            this.bluebtn = new System.Windows.Forms.Button();
            this.greenbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // redbtn
            // 
            this.redbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.redbtn.Location = new System.Drawing.Point(241, 44);
            this.redbtn.Name = "redbtn";
            this.redbtn.Size = new System.Drawing.Size(75, 23);
            this.redbtn.TabIndex = 0;
            this.redbtn.Text = "Red";
            this.redbtn.UseVisualStyleBackColor = true;
            this.redbtn.Click += new System.EventHandler(this.btn_Click);
            // 
            // bluebtn
            // 
            this.bluebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.bluebtn.Location = new System.Drawing.Point(10, 400);
            this.bluebtn.Name = "bluebtn";
            this.bluebtn.Size = new System.Drawing.Size(75, 23);
            this.bluebtn.TabIndex = 1;
            this.bluebtn.Text = "Blue";
            this.bluebtn.UseVisualStyleBackColor = true;
            this.bluebtn.Click += new System.EventHandler(this.btn_Click);
            // 
            // greenbtn
            // 
            this.greenbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.greenbtn.Location = new System.Drawing.Point(470, 400);
            this.greenbtn.Name = "greenbtn";
            this.greenbtn.Size = new System.Drawing.Size(75, 23);
            this.greenbtn.TabIndex = 2;
            this.greenbtn.Text = "Green";
            this.greenbtn.UseVisualStyleBackColor = true;
            this.greenbtn.Click += new System.EventHandler(this.btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.greenbtn);
            this.Controls.Add(this.bluebtn);
            this.Controls.Add(this.redbtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button redbtn;
        private System.Windows.Forms.Button bluebtn;
        private System.Windows.Forms.Button greenbtn;
    }
}

