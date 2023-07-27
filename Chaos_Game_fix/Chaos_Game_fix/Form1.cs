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
        private float x = 470;
        private float y = 400;
        Graphics g;
        Timer timer= new Timer();
        SolidBrush brush = new SolidBrush(Color.Black);
        Pen pen = new Pen(Color.Black);
        PointF[] outerpoints = new PointF[] {
                new PointF(85F, 400F),
                new PointF(470F, 400F),
                new PointF(277.5F, 66.580F)
            };

        PointF[] innerpoints = new PointF[] {
                new PointF(277.5F, 400F),
                new PointF(181.25F, 231.044F),
                new PointF(369.75F, 231.044F)
            };
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            x = xdistance(btn.Location.X);
            g.Clear(Color.White);
            y = ydistance(btn.Location.Y);
            timer.Start();

        }


        private float xdistance(float btnx)
        {
            float midpoint = (x - btnx) / 2;
            x = x - midpoint;
            //MessageBox.Show("new x coordinate: " + x);
            return x;
        }

        private float ydistance(float btny)
        {
            float midpoint = (y - btny) / 2;
            y = y - midpoint;
            //MessageBox.Show("new y coordinate: " + y);
            return y;
        }


        private float midx (float x1, float x2)
        {
            return 0;
        }

        private float midy(float y1, float y2)
        {
            return 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            g = this.CreateGraphics();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            int level = Levelselection();
            while (level == 0) {
                MessageBox.Show("level must be greater then 0");
                level = Levelselection();
            } ;
            timer.Start();
        }

        private int Levelselection()
        {
            string level = Interaction.InputBox("What Level Would you Like to play? level must be greater then 1", "level selection", "1");
            try
            {
                int levelnum = Int32.Parse(level);
                return levelnum;

            }
            catch 
            {
                
            }
            return 0;
        }
        /*private PointF Innertri()
        {

            return null;
        }*/

        private void Timer_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Rectangle r = new Rectangle((int)x, (int)y, 50, 50);
            g.DrawPolygon(pen, outerpoints);
            g.DrawPolygon(pen, innerpoints);
            g.FillEllipse(brush, r);
            timer.Stop();

        }


    }
}
