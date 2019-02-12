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
        protected List<Rectangle> circles = new List<Rectangle>();
        protected List<Rectangle> rectangles = new List<Rectangle>();
        List<int> dotsX = new List<int>();
        List<int> dotsY = new List<int>();
       // bool draw = false;
        int pX = -1;
        int pY = -1;
        Bitmap drawingPlace;

        public FigurCircel(string t)
        {
            this.type = t;
            this.BackColor = Color.Azure;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 800;
            this.Height = 600;
            drawingPlace = new Bitmap(this.Width, this.Height, this.CreateGraphics());
        }
        public void setFigureType(string typ)
        {
            type = typ;
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
            pX = e.X;
            pY = e.Y;
            drawing = true;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            currentPos = e.Location;
            if (drawing) this.Invalidate();
            if (type == "pen")
                penMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (drawing)
            {
                if (type == "circle")
                {
                    drawing = false;
                    var rc = getRectangle();
                    if (rc.Width > 0 && rc.Height > 0) circles.Add(rc);
                    this.Invalidate();
                }
                if (type == "rectangle")
                {
                    drawing = false;
                    var rc = getRectangle();
                    if (rc.Width > 0 && rc.Height > 0) rectangles.Add(rc);
                    this.Invalidate();
                }
                if (type == "pen")
                {
                    drawing = false;
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (type == "circle")
            {
                if (circles.Count > 0)
                {
                    foreach (Rectangle r in circles)
                        e.Graphics.DrawEllipse(Pens.Red, r);
                }
                if (drawing) e.Graphics.DrawEllipse(Pens.Black, getRectangle());
            }
            if (type == "rectangle")
            {
                if (rectangles.Count > 0) e.Graphics.DrawRectangles(Pens.Black, rectangles.ToArray());
                if (drawing) e.Graphics.DrawRectangle(Pens.Red, getRectangle());
            }
            if(type== "pen")
            {
                Pen pen = new Pen(Color.Black, 8);
                pen.EndCap = LineCap.Round;
                pen.StartCap = LineCap.Round;
                int i = 0;
                foreach (int x in dotsX)
                {
                    
                      e.Graphics.DrawLine(pen, pX, pY, x, dotsY[i]);
                }
                i++;
                    // e.Graphics.DrawImageUnscaled(drawingPlace, new Point(0, 0));
            }
        }
        void penMouseMove(MouseEventArgs e)
        {
            if (drawing)
            {
                dotsX.Add(e.X);
                dotsY.Add(e.Y);
                //Graphics panel = Graphics.FromImage(drawingPlace);

                //Pen pen = new Pen(Color.Black, 8);

                //pen.EndCap = LineCap.Round;
                //pen.StartCap = LineCap.Round;

                //this.CreateGraphics().DrawLine(pen, pX, pY, e.X, e.Y);

                //this.CreateGraphics().DrawImageUnscaled(drawingPlace, new Point(0, 0));
            }

           

            pX = e.X;
            pY = e.Y;

        }
    }
}