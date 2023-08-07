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
        int level;
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
            y = ydistance(btn.Location.Y);
            timer.Start();

        }


        private float xdistance(float btnx)
        {
            float midpoint = (x - btnx) / 2;
            x = x - midpoint;
            return x;
        }

        private float ydistance(float btny)
        {
            float midpoint = (y - btny) / 2;
            y = y - midpoint;
            return y;
        }


        private float midx (float x1, float x2)
        {
            
            return Math.Abs((x1 + x2)/2) ;
        }

        private float midy(float y1, float y2)
        {
            return Math.Abs((y1+y2)/2);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
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
        private PointF[] Innertri(int n, float x1, float y1, float x2, float y2, float x3, float y3)
        {
            int l = level;
            float a = midx(x1, x2);
            float b = midy(y1, y2);
            float c = midy(x2, x3);
            float d = midy(y2, y3);
            float e = midy(x1, x3);
            float f = midy(y1, y3); 
            PointF[] tripoints = new PointF[3];
            tripoints[0] = new PointF(a, b);
            tripoints[1] = new PointF(c, d);
            tripoints[2] = new PointF(e, f);
            if (l > n)
            {
                n++;
                g.DrawPolygon(pen, Innertri(n, x1, y1, a, b, e, f));
                g.DrawPolygon(pen, Innertri(n, a, b, x2, y2, c, d));
                g.DrawPolygon(pen, Innertri(n, e, f, c, d, x3, y3));

            }
            return tripoints;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            controler.Location = new System.Drawing.Point((int)x, (int)y);
            timer.Stop();

        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            g.DrawPolygon(pen, outerpoints);

            level = Levelselection();
            x = 470;
            y = 400;
            controler.Location = new System.Drawing.Point((int)x, (int)y);
            while (level == 0)
            {
                MessageBox.Show("level must be greater then 0");
                level = Levelselection();
            };
            int n = 1;

            g.DrawPolygon(pen, Innertri(n, bluebtn.Location.X, bluebtn.Location.Y, redbtn.Location.X, redbtn.Location.Y, greenbtn.Location.X, greenbtn.Location.Y));

        }


    }
}
