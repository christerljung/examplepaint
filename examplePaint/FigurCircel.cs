using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace examplePaint
{
   
    class FigurCircel :Panel
    {
        protected string type;
        protected Point startPos;
        protected Point currentPos;
        protected bool drawing;
        protected List<Rectangle> rectangles = new List<Rectangle>();

        public FigurCircel(string t)
        {
            this.type = t;
            this.BackColor = Color.Azure;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 800;
            this.Height = 600;
        }
        protected Rectangle getRectangle()
        {
            return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y));
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            currentPos = startPos = e.Location;
            drawing = true;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            currentPos = e.Location;
            if (drawing) this.Invalidate();            
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(drawing)
            {
                drawing = false;
                var rc = getRectangle();
                if (rc.Width > 0 && rc.Height > 0) rectangles.Add(rc);
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (type == "circle")
            {
                if (rectangles.Count > 0)
                {
                    foreach (Rectangle r in rectangles)
                        e.Graphics.DrawEllipse(Pens.Red, r);
                }
                if (drawing) e.Graphics.DrawEllipse(Pens.Black, getRectangle());
            }
            if (type == "rectangle")
            {
                if (figures.Count > 0) e.Graphics.DrawRectangles(Pens.Black, figures.ToArray());
                if (drawing) e.Graphics.DrawRectangle(Pens.Red, getRectangle());
            }

    }
}












