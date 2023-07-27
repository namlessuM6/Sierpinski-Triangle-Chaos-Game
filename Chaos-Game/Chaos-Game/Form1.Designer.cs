namespace Chaos_Game
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
            this.greenbtn = new System.Windows.Forms.Button();
            this.redbtn = new System.Windows.Forms.Button();
            this.bluebtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // greenbtn
            // 
            this.greenbtn.Location = new System.Drawing.Point(470, 400);
            this.greenbtn.Name = "greenbtn";
            this.greenbtn.Size = new System.Drawing.Size(75, 23);
            this.greenbtn.TabIndex = 0;
            this.greenbtn.Text = "Green";
            this.greenbtn.UseVisualStyleBackColor = true;
            this.greenbtn.Click += new System.EventHandler(this.btn_Click);
            // 
            // redbtn
            // 
            this.redbtn.Location = new System.Drawing.Point(240, 43);
            this.redbtn.Name = "redbtn";
            this.redbtn.Size = new System.Drawing.Size(75, 23);
            this.redbtn.TabIndex = 1;
            this.redbtn.Text = "Red";
            this.redbtn.UseVisualStyleBackColor = true;
            this.redbtn.Click += new System.EventHandler(this.btn_Click);
            // 
            // bluebtn
            // 
            this.bluebtn.Location = new System.Drawing.Point(10, 400);
            this.bluebtn.Name = "bluebtn";
            this.bluebtn.Size = new System.Drawing.Size(75, 23);
            this.bluebtn.TabIndex = 2;
            this.bluebtn.Text = "Blue";
            this.bluebtn.UseVisualStyleBackColor = true;
            this.bluebtn.Click += new System.EventHandler(this.btn_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(120, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 320);
            this.panel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 733);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button greenbtn;
        private System.Windows.Forms.Button redbtn;
        private System.Windows.Forms.Button bluebtn;
        private System.Windows.Forms.Panel panel1;
    }


}

