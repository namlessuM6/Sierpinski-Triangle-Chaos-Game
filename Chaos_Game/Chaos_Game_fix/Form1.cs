using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        readonly Pen pen = new Pen(Color.Black);
        //brush object for filling
        readonly SolidBrush brush = new SolidBrush(Color.Green);
        //brush object for erasing 
        readonly SolidBrush brushErase = new SolidBrush(Color.White);
        //array of points to draw goal triangle
        Point[] fillTriangle;
        //random number for selection of addresses 
        readonly Random r = new Random();


        /// <summary>
        /// method for corner button button actions
        /// </summary>
        /// <param name="sender"> tells the method which button was clicked</param>
        /// <param name="e"> allows method to be called on button click</param>
        private void Btnclick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //calls mid method to find new points for controller
            x = Mid(x, btn.Location.X);
            y = Mid(y, btn.Location.Y);
            Point p = new Point((int)x, (int)y);
            //applies new points to controller
            controler.Location = p;
            

        }


        /// <summary>
        /// method to calculate the midpoint of two coordinate values
        /// method needs to be called twice for midpoints of points
        /// once for x-coordinate once for y-coordinate
        /// </summary>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns>calculated coordinate value</returns>
        private float Mid(float y1, float y2)
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
        /// <param name="n">counter that keps track of  the ammount of times method gets called</param>
        /// <param name="x1">blue corner x point</param>
        /// <param name="y1">blue corner y point</param>
        /// <param name="x2">red corner x point</param>
        /// <param name="y2">red corner y point</param>
        /// <param name="x3">green corner x point</param>
        /// <param name="y3">green corner y point</param>
        /// <returns></returns>
        private PointF[] Innertri(int n, float x1, float y1, float x2, float y2, float x3, float y3)
        {
            //finds the midpoint of between eached passed point
            float a = Mid(x1, x2);
            float b = Mid(y1, y2);
            float c = Mid(x2, x3);
            float d = Mid(y2, y3);
            float e = Mid(x1, x3);
            float f = Mid(y1, y3); 
            //creats an array of the mid points
            PointF[] tripoints = new PointF[3];
            tripoints[0] = new PointF(a, b);
            tripoints[1] = new PointF(c, d);
            tripoints[2] = new PointF(e, f);
            //if the level inputed is higher then the ammount of times the method has been called STOP
            if(level > n)
            {
                //increase counter
                n++;
                //recursive call to draw more blue triangles
                g.DrawPolygon(pen, Innertri(n, x1, y1, a, b, e, f));
                //recursive call to draw more red triangles
                g.DrawPolygon(pen, Innertri(n, a, b, x2, y2, c, d));
                //recursive call to draw more green triangles
                g.DrawPolygon(pen, Innertri(n, e, f, c, d, x3, y3));

            }
            //returns created array of points to allow drawing 
            return tripoints;
        }
        /// <summary>
        /// starts the game
        /// </summary>
        /// <param name="sender">tells the method which button was clicked</param>
        /// <param name="e">allows method to be called on button click</param>
        private void Startbtnclick(object sender, EventArgs e)
        {
            //refreshes application and starts graphics
            Refreshform();
            //makes sure button are in right place might remove
            startbtn.Location = new Point(redbtn.Location.X + 300, redbtn.Location.Y);
            goalbtn.Location = new Point(startbtn.Location.X, startbtn.Location.Y + 80);
            //clears the form of any drawings
            g.Clear(Color.White);
            //makes an array of points to draw the large outer triangle
            PointF[] outerpoints = new PointF[] {
                new PointF(bluebtn.Location.X, bluebtn.Location.Y),
                new PointF(greenbtn.Location.X, greenbtn.Location.Y),
                new PointF(redbtn.Location.X, redbtn.Location.Y)
            };
            //draws the outer triangle
            g.DrawPolygon(pen, outerpoints);
            //selects the level
            level = Levelselection();
            //sets the x and y values of the controller
            x = greenbtn.Location.X;
            y = greenbtn.Location.Y;
            controler.Location = new Point((int)x, (int)y);
            //if the user inputed a bad level reselect level
            while (level == 0)
            {
                MessageBox.Show("level must be greater then 0");
                level = Levelselection();
            };
            //start counter for drawing 
            int n = 1;
            //timer for drawing should remove before final release
            var watch = System.Diagnostics.Stopwatch.StartNew();
            //draw inner triangles
            g.DrawPolygon(pen, Innertri(n, bluebtn.Location.X, bluebtn.Location.Y, redbtn.Location.X, redbtn.Location.Y, greenbtn.Location.X, greenbtn.Location.Y));
            //stop and display time
            watch.Stop();
            var mils = watch.ElapsedMilliseconds;
            MessageBox.Show("That took " + (float)mils/1000 + " seconds");
            //change start button text to reflect new game 
            startbtn.Text = "New Level";
            //create goal triangle
            Goalfill(0);
        }
        /// <summary>
        /// old method used for resizing the game
        /// </summary>
        /*private Point Btnloc (float scale, Button btn)
        {
            
            int x = (int)btn.Location.X * (int)scale;
            int y = (int)btn.Location.Y * (int)scale;
            System.Drawing.Point cor = new System.Drawing.Point(x, y);
            return cor;

            
        }*/
        
        /// <summary>
        /// refreshes the application and starts the graphics 
        /// </summary>
        private void Refreshform ()
        {
            this.Refresh();
            g = this.CreateGraphics();
        }

        /// <summary>
        /// used to resize the game now sets the goal triangle
        /// </summary>
        /// <param name="sender">tells the method which button was clicked</param>
        /// <param name="e">allows method to be called form a button click</param>
        private void Goalbtnclick(object sender, EventArgs e)
        {
            /*
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
            redbtn.Location = new Point((System.Drawing.Size)Btnloc(scale, redbtn));
            greenbtn.Location = new Point((System.Drawing.Size)Btnloc(scale, greenbtn));
            bluebtn.Location = new Point((System.Drawing.Size)Btnloc(scale, bluebtn));
            redbtn.Location = new Point(redbtn.Location.X - (int)(300 * scale), redbtn.Location.Y);
            greenbtn.Location = new Point(greenbtn.Location.X - (int)(300 * scale), greenbtn.Location.Y);
            bluebtn.Location = new Point(bluebtn.Location.X - (int)(300* scale), bluebtn.Location.Y);*/

            //try to erase and set goal triangle if game is not started this will cause an error
            try
            {
                Goalfill(1);
                //reset controller position
                x = greenbtn.Location.X;
                y = greenbtn.Location.Y;
                controler.Location = new Point((int)x, (int)y);
            }
            //on error starts game
            catch 
            {
                MessageBox.Show("Error You Must hit the Start Button First. You lost your privileges, Starting the game");
                startbtn.PerformClick();
            }
            
        }
        /// <summary>
        /// sets goal triangle or erases goal triangle
        /// </summary>
        /// <param name="erase">erase or set switch</param>
        private void Goalfill(int erase)
        {
            //if we are setting a goal
            if (erase == 0)
            {
                //vector from green button to blue button
                Vector2 blue = new Vector2(bluebtn.Location.X - greenbtn.Location.X, bluebtn.Location.Y - greenbtn.Location.Y);
                // vector from green button to red button
                Vector2 red = new Vector2(redbtn.Location.X - greenbtn.Location.X, redbtn.Location.Y - greenbtn.Location.Y);
                //list to store address of random triangle
                List<int> address = new List<int>();
                //list to store vector to get to random triangle
                List<Vector2> selctor = new List<Vector2>();
                //for each level of construction choose a random number between 0 and 2 and add it to the adress list
                for (int x = 0; x < level; x++)
                {
                    int ad = r.Next(3);
                    address.Add(ad);
                }
                //for each number in the address depending on which number it is assign a vector with a scalor based on position
                for (int i = 0; i < address.Count; i++)
                {
                    if (address[i] == 0)
                    {
                        //do nothing 
                    }
                    else if (address[i] == 1)
                    {
                        //add blue vector
                        selctor.Add(Vector2.Multiply((float)Math.Pow(0.5, (i + 1)), blue));
                    }
                    else if (address[i] == 2)
                    {
                        //add red vector
                        selctor.Add(Vector2.Multiply((float)Math.Pow(0.5, (i + 1)), red));
                    }
                }

                //use vector to find right corner of goal triangle
                Point rightCorner = new Point(greenbtn.Location.X, greenbtn.Location.Y);
                Point topCorner;
                Point leftCorner;
                for (int x = 0; x < selctor.Count; x++)
                {
                    rightCorner = new Point(rightCorner.X + (int)selctor[x].X, rightCorner.Y + (int)selctor[x].Y);
                }
                //use smallest scaler, ie the ammount of digits in the address, to find top and left points
                int smallestScaler = address.Count;
                leftCorner = new Point(rightCorner.X + (int)(Math.Pow(0.5, smallestScaler) * blue.X), rightCorner.Y + (int)(Math.Pow(0.5, smallestScaler) * blue.Y));
                topCorner = new Point(rightCorner.X + (int)(Math.Pow(0.5, smallestScaler) * red.X), rightCorner.Y + (int)(Math.Pow(0.5, smallestScaler) * red.Y));
                //array with the goal triangles points
                fillTriangle = new Point[3]
                {
                topCorner, leftCorner, rightCorner
                };
            
                //use brush to highlight triangle
                g.FillPolygon(brush, fillTriangle);
            //if we are eraseing a goal
            }else
            {
                //fill in goal triangle white
                g.FillPolygon(brushErase, fillTriangle);
                //redraw goal triangle lines, as they my have been erased
                g.DrawPolygon(pen, fillTriangle);
                //call method to select goal triangle
                Goalfill(0);
            }
        }
    }
}
