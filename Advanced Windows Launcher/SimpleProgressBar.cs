using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Windows_Launcher
{
    public partial class SimpleProgressBar : UserControl
    {
        public SimpleProgressBar()
        {
            InitializeComponent();
        }

        int min = 0;
        int max = 100;
        int val = 0;    
        Color BarColor = Color.RosyBrown;

        public int Minimum
        {
            get { return min; }
            set
            {
                if (value < 0)
                    min = 0;
                else if (value > max)
                    min = max;
                else
                    min = value;

                if (val < min)
                    val = min;

                this.Invalidate();
            }
        }

        public int Maximum
        {
            get { return max; }
            set
            {
                if (value < min)
                    max = min;
                else
                    max = value;

                if (val > max)
                    val = max;

                this.Invalidate();
            }
        }

        public int Value
        {
            get { return val; }
            set
            {
                int previousValue = val;

                if (value < min)
                    val = min;
                else if (value > max)
                    val = max;
                else
                    val = value;

                float percentage;

                float rectWidth = this.ClientRectangle.Width;

                //Get new width
                percentage = (float)(val - min) / (float)(max - min);
                int newWidth = (int)(((float)rectWidth * percentage));

                //Get old width
                percentage = (float)(previousValue - min) / (float)(max - min);
                int oldWidth = (int)((float)rectWidth * percentage);


                //Rect that needs to be redrawn
                Rectangle updateRect = new Rectangle();
                if (newWidth > oldWidth)
                {
                    updateRect.X = oldWidth;
                    updateRect.Width = newWidth - oldWidth;
                }
                else
                {
                    updateRect.X = newWidth;
                    updateRect.Width = oldWidth - newWidth;
                }
                updateRect.Height = this.Height;

                this.Invalidate(updateRect);
            }
        }
        
        public Color ProgressBarColor
        {
            get { return BarColor; }
            set { BarColor = value; this.Invalidate(); }
        }

        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics g = e.Graphics )
            {
                Rectangle rect = this.ClientRectangle;

                //Rect to draw
                float percent = (float)(val - min) / (float)(max - min);
                rect.Width = (int)((float)rect.Width * percent);

                //Fill rect
                using (Brush brush = new SolidBrush(BarColor))
                    g.FillRectangle(brush, rect);

                //Draw border
                Draw3DBorder(g);
            }
        }

        void Draw3DBorder(Graphics g)
        {
            int PenWidth = (int)Pens.White.Width;

            g.DrawLine(Pens.DarkGray,
            new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),
            new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top));
            g.DrawLine(Pens.DarkGray,
            new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),
            new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth));
            g.DrawLine(Pens.White,
            new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth),
            new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth));
            g.DrawLine(Pens.White,
            new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top),
            new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth));
        }
    }
}
