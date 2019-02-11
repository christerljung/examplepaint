using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace examplePaint
{
    class FigurRektangel : Figur
    {
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(drawing)
            {
                drawing = false;
                var rc = getRectangle();
                if (rc.Width > 0 && rc.Height > 0) figures.Add(rc);
                this.Invalidate(); //rita om fönstret
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (figures.Count > 0) e.Graphics.DrawRectangles(Pens.Black, figures.ToArray());
            if (drawing) e.Graphics.DrawRectangle(Pens.Red, getRectangle());
        }
    }
}
