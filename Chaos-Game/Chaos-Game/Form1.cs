using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chaos_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private float x = 470;
        private float y = 400;
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            x = xdistance(btn.Location.X);
            y = xdistance(btn.Location.Y);
            
        }


        private float xdistance(float btnx)
        {
            float midpoint = (x - btnx) / 2;
            x = x - midpoint;
            return x;
        }

        private float ydistance (float btny)
        {
            float midpoint = (y - btny) / 2;
            y = y - midpoint;
            return y;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.panel1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 1);
            Brush brush = new SolidBrush(Color.Black);

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

            
            RectangleF rec =new RectangleF(2, 4, 5, 8);
            e.Graphics.DrawPolygon(pen, outerpoints);
            e.Graphics.DrawPolygon(pen, innerpoints);
            
        }


    }
}
