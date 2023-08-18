using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
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
        private int level;
        //Graphics object to render drawings
        private Graphics g;
        //pen Object for drawing
        private readonly Pen pen = new Pen(Color.Black);
        //brush object for filling
        private readonly SolidBrush brush = new SolidBrush(Color.Green);
        //brush object for erasing 
        private readonly SolidBrush brushErase = new SolidBrush(Color.White);
        //array of points to draw goal triangle
        PointF[] fillTriangle;
        //random number for selection of addresses 
        private readonly Random r = new Random();
        //private double area;
        private int win;
        private List<int> address;
        PointF rightCorner;
        Vector2 red;
        Vector2 blue;
        PointF topCorner;
        PointF leftCorner;
        int click;


        /// <summary>
        /// method for corner button button actions
        /// </summary>
        /// <param name="sender"> tells the method which button was clicked</param>
        /// <param name="e"> allows method to be called on button click</param>
        private void Btnclick(object sender, EventArgs e)
        {
            if (win == 0)
            {
                Button btn = (Button)sender;
                //calls mid method to find new points for controller
                x = Mid(x, btn.Location.X);
                y = Mid(y, btn.Location.Y);
                //applies new points to controller
                controler.Location = new Point((int)x, (int)y);
                buttonOutput.Text += btn.Text + ", ";
                if (Didyouwin())
                {
                    winOutput.Text = "You win!!! \nthe address of the goal triangle is " + Listaddress(address);
                    win = 1;
                    return;
                }
                click++;
                if (click > level + 2)
                {
                    winOutput.Text = "You should be able to beat this level in " + (level + 2) + " moves.";
                    if (click > level + 10)
                    {
                        win = -1;
                    }
                }
            }
            else if (win > 0)
            {
                MessageBox.Show("You Won, Stop Hitting the buttons");
            }
            else
            {
                winOutput.Text = "You lose, you need to hit the goal in " + (level + 10) + " moves.";
                click++;
                if (click > (level + 12))
                {
                    MessageBox.Show("You lost start a new game");
                }
            }
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
                if(levelnum < 0)
                {
                    levelnum = 0;
                }
                if(levelnum > 6) 
                {

                }
                return levelnum;
            }
            catch 
            {
                //upon error of conversion above no converson is done and 0 is returned
                return 0;
            }
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
            //vector from green button to blue button
            blue = new Vector2(bluebtn.Location.X - greenbtn.Location.X, bluebtn.Location.Y - greenbtn.Location.Y);
            // vector from green button to red button
            red = new Vector2(redbtn.Location.X - greenbtn.Location.X, redbtn.Location.Y - greenbtn.Location.Y);
            //refreshes application and starts graphics
            Refreshform();
            //clears the form of any drawings
            g.Clear(Color.White);
            
            //selects the level
            level = Levelselection();
            //sets the x and y values of the controller
            x = greenbtn.Location.X;
            y = greenbtn.Location.Y;
            controler.Location = new Point((int)x, (int)y);
            //if the user inputed a bad level reselect level
            while (level == 0)
            {
                MessageBox.Show("level must be a whole number greater then 0");
                level = Levelselection();
            };
            //makes an array of points to draw the large outer triangle
            PointF[] outerpoints = new PointF[]
            {
                new PointF(bluebtn.Location.X, bluebtn.Location.Y),
                new PointF(greenbtn.Location.X, greenbtn.Location.Y),
                new PointF(redbtn.Location.X, redbtn.Location.Y)
            };
            //draws the outer triangle
            g.DrawPolygon(pen, outerpoints);
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
            win = 0;
            click = 0;
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
            click = 0;
            winOutput.Text = string.Empty;
            buttonOutput.Text = string.Empty;
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
                winOutput.Text = string.Empty;
                buttonOutput.Text = string.Empty;

                //reset controller position
                x = greenbtn.Location.X;
                y = greenbtn.Location.Y;
                controler.Location = new Point((int)x, (int)y);
                win = 0;
                click = 0;
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
                
                //list to store address of random triangle
                address = new List<int>();
                //list to store vector to get to random triangle
                List<Vector2> selctor = new List<Vector2>();
                //for each level of construction choose a random number between 0 and 2 and add it to the adress list
                for (int x = 0; x < level; x++)
                {
                    int ad = r.Next(3);
                    address.Add(ad);
                }
                //for each number in the address depending on which number it is assign a vector with a scalor based on position
                for (int i = address.Count - 1; i >= 0; i--)
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
                rightCorner = new PointF(greenbtn.Location.X, greenbtn.Location.Y);
                for (int x = 0; x < selctor.Count; x++)
                {
                    rightCorner = new PointF(rightCorner.X + (float)selctor[x].X, rightCorner.Y + (float)selctor[x].Y);
                }
                //use smallest scaler, ie the ammount of digits in the address, to find top and left points
                int smallestScaler = address.Count;
                leftCorner = new PointF(rightCorner.X + (float)(Math.Pow(0.5, smallestScaler) * blue.X), rightCorner.Y + (float)(Math.Pow(0.5, smallestScaler) * blue.Y));
                topCorner = new PointF(rightCorner.X + (float)(Math.Pow(0.5, smallestScaler) * red.X), rightCorner.Y + (float)(Math.Pow(0.5, smallestScaler) * red.Y));
                //array with the goal triangles points
                fillTriangle = new PointF[3]
                {
                topCorner, leftCorner, rightCorner
                };
            
                //use brush to highlight triangle
                g.FillPolygon(brush, fillTriangle);
               /* double side1 = Distace(fillTriangle[0].X, fillTriangle[1].X, fillTriangle[0].Y, fillTriangle[1].Y);
                double side2 = Distace(fillTriangle[0].X, fillTriangle[2].X, fillTriangle[0].Y, fillTriangle[2].Y);
                double side3 = Distace(fillTriangle[1].X, fillTriangle[2].X, fillTriangle[1].Y, fillTriangle[2].Y);
                area = Heron(side1, side2, side3);*/

                //if we are eraseing a goal
            }
            else
            {
                //fill in goal triangle white
                g.FillPolygon(brushErase, fillTriangle);
                //redraw goal triangle lines, as they my have been erased
                g.DrawPolygon(pen, fillTriangle);
                //call method to select goal triangle
                Goalfill(0);
            }
        }

/*
            double side0C = Distace(fillTriangle[0].X, controler.Location.X, fillTriangle[0].Y, controler.Location.Y);
            double side01 = Distace(fillTriangle[0].X, fillTriangle[1].X, fillTriangle[0].Y, fillTriangle[1].Y);
            double side02 = Distace(fillTriangle[0].X, fillTriangle[2].X, fillTriangle[0].Y, fillTriangle[2].Y);
            double side1C = Distace(fillTriangle[1].X, controler.Location.X, fillTriangle[1].Y, controler.Location.Y);
            double side12 = Distace(fillTriangle[1].X, fillTriangle[2].X, fillTriangle[1].Y, fillTriangle[2].Y);
            double side2C = Distace(fillTriangle[2].X, controler.Location.X, fillTriangle[2].Y, controler.Location.Y);
            double area1 = Heron(side0C, side01, side1C);
            double area2 = Heron(side0C, side02, side2C);
            double area3 = Heron(side1C, side2C, side12);
            double areaControler = area1 + area2 + area3;
            MessageBox.Show("area: " + area + "controller: " + areaControler);
            if (Epsilon(area1, 0) || Epsilon(area2, 0) || Epsilon(area3, 0))
            {
                return false;
            }
            if (Epsilon(areaControler,  area))
            {
                win++;
                return true;
            }
            else
                return false;
        }

        private double Heron(double side1, double side2, double side3)
        {

            double s = 0.5 * (side1 + side2 + side3);
            return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
        }
        /// <summary>
        /// calculates the distance between 2 points
        /// </summary>
        /// <param name="x1">x value of point 1</param>
        /// <param name="x2">x value of point 2</param>
        /// <param name="y1">y value of point 1</param>
        /// <param name="y2">y value of point 2</param>
        /// <returns>distance beween two points given the coordinates</returns>
        private double Distace(int x1, int x2, int y1, int y2)
        {
            return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
        }

        private bool Epsilon(double one, double two) {
            return Math.Abs(one - two) < Math.Pow(1, -1000);
        }

            */

        /// <summary>
        /// takes a string and makes it printable
        /// </summary>
        /// <param name="list">The list to be printed</param>
        /// <returns>The list contents as a string</returns>
        private string Listaddress(List<int> list)
        {
            string r = string.Empty;
            for(int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] == 0)
                {
                    r += 3;
                }else
                r += list[i]; 
            }
            return r;
        }

        private void Trybutton_Click(object sender, EventArgs e)
        {
            try
            {
                winOutput.Text = string.Empty;
                buttonOutput.Text = string.Empty;

                //reset controller position
                x = greenbtn.Location.X;
                y = greenbtn.Location.Y;
                controler.Location = new Point((int)x, (int)y);
                g.FillPolygon(brush, fillTriangle);
                win = 0;
                click = 0;
            }
            catch
            {
                MessageBox.Show("Error game must be started");
            }
        }

        private void Addressbutton_Click(object sender, EventArgs e)
        {
            try
            {
                winOutput.Text = "there's too many triangles to see the goal, here's the address of the goal: " + Listaddress(address);
            }
            catch
            {
                MessageBox.Show("Error no game started");
            }
        }
        private bool Didyouwin() 
        {
            if(controler.Location.X > leftCorner.X)
            {
                if(controler.Location.X < rightCorner.X)
                {
                    if(controler.Location.Y > topCorner.Y)
                    {
                        if(controler.Location.Y < leftCorner.Y)
                        {
                            win++;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }else
                    {
                        return false;
                    }
                }else 
                { 
                    return false; 
                }
            }else
            {
                return false;
            }
        }


    }
}
