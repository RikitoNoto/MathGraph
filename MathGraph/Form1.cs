using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathGraph
{
    public partial class Form1 : Form
    {
        private Graphics g;
        public Form1()
        {
            InitializeComponent();

            g = Graphics.FromHwnd(this.Handle);
            this.Shown += new EventHandler(MakeGraph);

            //Matrix mat = new Matrix();
            //mat.Translate(ClientSize.Width / 2, ClientSize.Height / 2);
            //mat.Scale(1, -1);                  // X,Y座標を反転
            //g.Transform = mat;
            g.ScaleTransform(1, -1);
            g.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2,MatrixOrder.Append);
            this.MaximumSizeChanged += new EventHandler(MakeGraph);
            this.Click += new EventHandler(Action1);
        }

        private void MakeGraph(object sender, EventArgs e)
        {
            int x0 = ClientSize.Width / 2;
            int y0 = ClientSize.Height / 2;
            float x0f = ClientSize.Width / 2;
            float y0f = ClientSize.Height / 2;
            int graphSize = 300;
            using (Graphics g = Graphics.FromHwnd(this.Handle))
            using (Pen p = new Pen(Color.Black, 1))
            using (Font f=new Font(this.Font,FontStyle.Regular))
            using (SolidBrush br=new SolidBrush(Color.Black))
            {
                g.Clear(this.BackColor);

                p.StartCap = LineCap.ArrowAnchor;
                p.EndCap = LineCap.Round;

                g.DrawLine(p, new Point(x0+graphSize, y0), new Point(x0-graphSize, y0));
                g.DrawLine(p, new Point(x0, y0-graphSize), new Point(x0, y0+graphSize));
                p.StartCap = LineCap.Round;
                p.Width = 2;
                g.DrawLine(p, new Point(x0, y0), new Point(x0, y0));
                g.DrawString("O",f,br,new PointF(x0f,y0f));
                g.DrawString("X", f, br, new PointF(x0f+graphSize, y0f));
                g.DrawString("Y", f, br, new PointF(x0f, y0f-graphSize));
            }
        }

        private void Action1(object sender,EventArgs e)
        {

        }

        private void DrawBit(int x,int y)
        {
            using (Bitmap bit = new Bitmap(1, 1))
            {
                bit.SetPixel(0, 0, Color.Red);
                g.DrawImageUnscaled(bit, x, y);
            }
        }
    }

    
}
