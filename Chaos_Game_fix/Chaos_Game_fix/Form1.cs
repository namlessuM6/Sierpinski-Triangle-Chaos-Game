using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Chaos_Game_fix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //calss variables
        //x coordinate of controller
        private float x;
        //y coordinate of controller
        private float y;
        //level selection variable
        int level;
        //Graphics object to render drawings
        Graphics g;
        //pen Object for drawing
        Pen pen = new Pen(Color.Black);


        /// <summary>
        /// method for corner button button actions
        /// </summary>
        /// <param name="sender"> tells the method which button was clicked</param>
        /// <param name="e"> allows method to be called on button click</param>
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //calls mid method to find new points for controller
            x = mid(x, btn.Location.X);
            y = mid(y, btn.Location.Y);
            //applies new points to controller
            controler.Location = new Point((int)x, (int)y);

        }


        /// <summary>
        /// method to calculate the midpoint of two coordinate values
        /// method needs to be called twice for midpoints of points
        /// once for x-coordinate once for y-coordinate
        /// </summary>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns>calculated coordinate value</returns>
        private float mid(float y1, float y2)
        {
            //absolute value of y1+y2 divided by 2
            return Math.Abs((y1+y2)/2);
        }


        /// <summary>
        /// allows user to select level to play
        /// </summary>
        /// <returns> selected level or 0 upon error</returns>
        private int Levelselection()
        {
            //message box asking user to input level default input is 1
            string level = Interaction.InputBox("What Level Would you Like to play? level must be greater then 1", "level selection", "1");
            try
            {
                //convert input string to int value
                int levelnum = Int32.Parse(level);
                return levelnum;
            }
            catch 
            {
                //upon error of conversion above no converson is done and 0 is returned
            }
            return 0;
        }

        /// <summary>
        /// method used to draw and calculate inner triangles
        /// </summary>
        /// <param name="n">counter that keps track of </param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <returns></returns>
        private PointF[] Innertri(int n, float x1, float y1, float x2, float y2, float x3, float y3)
        {
            int l = level;
            double ammount = Math.Pow(3, level);
            float a = mid(x1, x2);
            float b = mid(y1, y2);
            float c = mid(x2, x3);
            float d = mid(y2, y3);
            float e = mid(x1, x3);
            float f = mid(y1, y3); 
            PointF[] tripoints = new PointF[3];
            tripoints[0] = new PointF(a, b);
            tripoints[1] = new PointF(c, d);
            tripoints[2] = new PointF(e, f);
            if(l > n)
            {
                n++;
                g.DrawPolygon(pen, Innertri(n, x1, y1, a, b, e, f));
                g.DrawPolygon(pen, Innertri(n, a, b, x2, y2, c, d));
                g.DrawPolygon(pen, Innertri(n, e, f, c, d, x3, y3));

            }
            return tripoints;
        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            Refreshform();
            startbtn.Location = new Point(redbtn.Location.X + 300, redbtn.Location.Y);
            resizebtn.Location = new Point(startbtn.Location.X, startbtn.Location.Y + 80);
            g.Clear(Color.White);
            PointF[] outerpoints = new PointF[] {
                new PointF(bluebtn.Location.X, bluebtn.Location.Y),
                new PointF(greenbtn.Location.X, greenbtn.Location.Y),
                new PointF(redbtn.Location.X, redbtn.Location.Y)
            };
            g.DrawPolygon(pen, outerpoints);
            level = Levelselection();
            x = greenbtn.Location.X;
            y = greenbtn.Location.Y;
            controler.Location = new Point((int)x, (int)y);
            while (level == 0)
            {
                MessageBox.Show("level must be greater then 0");
                level = Levelselection();
            };
            int n = 1;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            g.DrawPolygon(pen, Innertri(n, bluebtn.Location.X, bluebtn.Location.Y, redbtn.Location.X, redbtn.Location.Y, greenbtn.Location.X, greenbtn.Location.Y));
            watch.Stop();
            var mils = watch.ElapsedMilliseconds;
            MessageBox.Show("That took " + (float)mils/1000 + " seconds");
        }

        private Point btnloc (float scale, Button btn)
        {
            
            int x = (int)btn.Location.X * (int)scale;
            int y = (int)btn.Location.Y * (int)scale;
            Point cor = new Point(x, y);
            return cor;

            
        }
        private void Refreshform ()
        {
            this.Refresh();
            g = this.CreateGraphics();
        }

        private void resizebtn_Click(object sender, EventArgs e)
        {
            float scale;
            string scalestr = Interaction.InputBox("how much larger do you want the triangle to be? scaler must be greater then 0", "Resize", "1");
            try
            {
                scale = float.Parse(scalestr);
                

            }
            catch
            {
                MessageBox.Show("Failure you must enter a valid number");
                scale = 1;
            }
            redbtn.Location = new Point((Size)btnloc(scale, redbtn));
            greenbtn.Location = new Point((Size)btnloc(scale, greenbtn));
            bluebtn.Location = new Point((Size)btnloc(scale, bluebtn));
            redbtn.Location = new Point(redbtn.Location.X - (int)(300 * scale), redbtn.Location.Y);
            greenbtn.Location = new Point(greenbtn.Location.X - (int)(300 * scale), greenbtn.Location.Y);
            bluebtn.Location = new Point(bluebtn.Location.X - (int)(300* scale), bluebtn.Location.Y);
            
        }
    }
}
