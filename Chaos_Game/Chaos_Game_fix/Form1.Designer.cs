namespace Chaos_Game_fix
{
    partial class Trianglegame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trianglegame));
            this.redbtn = new System.Windows.Forms.Button();
            this.bluebtn = new System.Windows.Forms.Button();
            this.greenbtn = new System.Windows.Forms.Button();
            this.startbtn = new System.Windows.Forms.Button();
            this.controler = new System.Windows.Forms.PictureBox();
            this.goalbtn = new System.Windows.Forms.Button();
            this.winOutput = new System.Windows.Forms.TextBox();
            this.buttonOutput = new System.Windows.Forms.TextBox();
            this.trybutton = new System.Windows.Forms.Button();
            this.addressbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.controler)).BeginInit();
            this.SuspendLayout();
            // 
            // redbtn
            // 
            this.redbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.redbtn.Location = new System.Drawing.Point(258, 38);
            this.redbtn.MaximumSize = new System.Drawing.Size(100, 30);
            this.redbtn.MinimumSize = new System.Drawing.Size(74, 30);
            this.redbtn.Name = "redbtn";
            this.redbtn.Size = new System.Drawing.Size(74, 30);
            this.redbtn.TabIndex = 0;
            this.redbtn.Text = "Red";
            this.redbtn.UseVisualStyleBackColor = true;
            this.redbtn.Click += new System.EventHandler(this.Btnclick);
            // 
            // bluebtn
            // 
            this.bluebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.bluebtn.Location = new System.Drawing.Point(27, 400);
            this.bluebtn.MaximumSize = new System.Drawing.Size(100, 30);
            this.bluebtn.MinimumSize = new System.Drawing.Size(74, 30);
            this.bluebtn.Name = "bluebtn";
            this.bluebtn.Size = new System.Drawing.Size(74, 30);
            this.bluebtn.TabIndex = 1;
            this.bluebtn.Text = "Blue";
            this.bluebtn.UseVisualStyleBackColor = true;
            this.bluebtn.Click += new System.EventHandler(this.Btnclick);
            // 
            // greenbtn
            // 
            this.greenbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.greenbtn.Location = new System.Drawing.Point(487, 400);
            this.greenbtn.MaximumSize = new System.Drawing.Size(100, 30);
            this.greenbtn.MinimumSize = new System.Drawing.Size(74, 30);
            this.greenbtn.Name = "greenbtn";
            this.greenbtn.Size = new System.Drawing.Size(74, 30);
            this.greenbtn.TabIndex = 2;
            this.greenbtn.Text = "Green";
            this.greenbtn.UseVisualStyleBackColor = true;
            this.greenbtn.Click += new System.EventHandler(this.Btnclick);
            // 
            // startbtn
            // 
            this.startbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.startbtn.Location = new System.Drawing.Point(620, 68);
            this.startbtn.MaximumSize = new System.Drawing.Size(100, 30);
            this.startbtn.MinimumSize = new System.Drawing.Size(75, 30);
            this.startbtn.Name = "startbtn";
            this.startbtn.Size = new System.Drawing.Size(75, 30);
            this.startbtn.TabIndex = 3;
            this.startbtn.Text = "Start";
            this.startbtn.UseVisualStyleBackColor = true;
            this.startbtn.Click += new System.EventHandler(this.Startbtnclick);
            // 
            // controler
            // 
            this.controler.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controler.BackgroundImage")));
            this.controler.Location = new System.Drawing.Point(511, 400);
            this.controler.Name = "controler";
            this.controler.Size = new System.Drawing.Size(5, 5);
            this.controler.TabIndex = 6;
            this.controler.TabStop = false;
            // 
            // goalbtn
            // 
            this.goalbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.goalbtn.Location = new System.Drawing.Point(620, 145);
            this.goalbtn.MaximumSize = new System.Drawing.Size(75, 35);
            this.goalbtn.MinimumSize = new System.Drawing.Size(75, 35);
            this.goalbtn.Name = "goalbtn";
            this.goalbtn.Size = new System.Drawing.Size(75, 35);
            this.goalbtn.TabIndex = 7;
            this.goalbtn.Text = "New Goal";
            this.goalbtn.UseVisualStyleBackColor = true;
            this.goalbtn.Click += new System.EventHandler(this.Goalbtnclick);
            // 
            // winOutput
            // 
            this.winOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.winOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.winOutput.Location = new System.Drawing.Point(620, 195);
            this.winOutput.MaximumSize = new System.Drawing.Size(1000, 75);
            this.winOutput.MinimumSize = new System.Drawing.Size(217, 50);
            this.winOutput.Multiline = true;
            this.winOutput.Name = "winOutput";
            this.winOutput.ReadOnly = true;
            this.winOutput.Size = new System.Drawing.Size(217, 50);
            this.winOutput.TabIndex = 8;
            this.winOutput.Text = "The goal of the game is to get the black square into the highlighted green triang" +
    "le by pushing the green, red, and blue buttons. Press Start to begin.";
            // 
            // buttonOutput
            // 
            this.buttonOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buttonOutput.Location = new System.Drawing.Point(620, 286);
            this.buttonOutput.MaximumSize = new System.Drawing.Size(1000, 75);
            this.buttonOutput.MinimumSize = new System.Drawing.Size(217, 50);
            this.buttonOutput.Multiline = true;
            this.buttonOutput.Name = "buttonOutput";
            this.buttonOutput.ReadOnly = true;
            this.buttonOutput.Size = new System.Drawing.Size(217, 50);
            this.buttonOutput.TabIndex = 9;
            // 
            // trybutton
            // 
            this.trybutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.trybutton.Location = new System.Drawing.Point(728, 145);
            this.trybutton.MaximumSize = new System.Drawing.Size(75, 35);
            this.trybutton.MinimumSize = new System.Drawing.Size(75, 35);
            this.trybutton.Name = "trybutton";
            this.trybutton.Size = new System.Drawing.Size(75, 35);
            this.trybutton.TabIndex = 10;
            this.trybutton.Text = "Try again";
            this.trybutton.UseVisualStyleBackColor = true;
            this.trybutton.Click += new System.EventHandler(this.Trybutton_Click);
            // 
            // addressbutton
            // 
            this.addressbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.addressbutton.Location = new System.Drawing.Point(728, 68);
            this.addressbutton.MaximumSize = new System.Drawing.Size(75, 35);
            this.addressbutton.MinimumSize = new System.Drawing.Size(75, 35);
            this.addressbutton.Name = "addressbutton";
            this.addressbutton.Size = new System.Drawing.Size(75, 35);
            this.addressbutton.TabIndex = 11;
            this.addressbutton.Text = "I can\'t see the goal";
            this.addressbutton.UseVisualStyleBackColor = true;
            this.addressbutton.Click += new System.EventHandler(this.Addressbutton_Click);
            // 
            // Trianglegame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.addressbutton);
            this.Controls.Add(this.trybutton);
            this.Controls.Add(this.buttonOutput);
            this.Controls.Add(this.winOutput);
            this.Controls.Add(this.goalbtn);
            this.Controls.Add(this.startbtn);
            this.Controls.Add(this.greenbtn);
            this.Controls.Add(this.bluebtn);
            this.Controls.Add(this.redbtn);
            this.Controls.Add(this.controler);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "Trianglegame";
            this.Text = "Form1";
            this.ResizeEnd += new System.EventHandler(this.Trianglegame_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.controler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button redbtn;
        private System.Windows.Forms.Button bluebtn;
        private System.Windows.Forms.Button greenbtn;
        private System.Windows.Forms.Button startbtn;
        private System.Windows.Forms.PictureBox controler;
        private System.Windows.Forms.Button goalbtn;
        private System.Windows.Forms.TextBox winOutput;
        private System.Windows.Forms.TextBox buttonOutput;
        private System.Windows.Forms.Button trybutton;
        private System.Windows.Forms.Button addressbutton;
    }
}

