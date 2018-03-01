using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeepToo_Points
{
    /// <summary>
    /// Author : KeepToo
    /// Date   : 1/3/2018
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Creates the triangle.
        /// </summary>
        /// <param name="paintEventArgs">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="fill">if set to <c>true</c> [fill].</param>
        private void CreateTriangle(PaintEventArgs paintEventArgs, bool fill)
        {
            Point p0 = Point.Empty;
            Point p1 = Point.Empty;
            Point p2 = Point.Empty;
            
            
            Rectangle rectangle = new Rectangle(0,0, 100, 100);

            p0 = new Point(rectangle.Left + (rectangle.Width / 2), rectangle.Bottom);
            p1 = new Point(rectangle.Left, rectangle.Top);
            p2 = new Point(rectangle.Right, rectangle.Top);

            Graphics graphics = paintEventArgs.Graphics;
            // for smooth edges use :
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
           
            SolidBrush solidbrush = new SolidBrush(Color.Black);
            Pen pen = new Pen(solidbrush);

            if (fill == false)
            {
                // v shaped polygon
                // graphics.DrawPolygon(pen, new Point[] { p0, p2, p0, p1 });
               
                //full triangle
                graphics.DrawPolygon(pen, new Point[] { p0, p1, p2 });
            }
            else
                //fill polygon
                graphics.FillPolygon(solidbrush, new Point[] { p0, p1, p2 });


            //dispose your GDI Objects
            graphics.Dispose();
            pen.Dispose();
            solidbrush.Dispose();

        }

        /// <summary>
        /// Handles the Paint event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            CreateTriangle(e, false);
        }
    }
}
