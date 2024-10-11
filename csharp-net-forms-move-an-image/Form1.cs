using Microsoft.VisualBasic.Logging;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Drawing.Drawing2D;

namespace csharp_net_forms_move_an_image
{
    public partial class Form1 : Form
    {
        Image logo;
        Point position = new Point(200, 200);
        bool dragging;
        Rectangle rect;
        int width, height;

        public Form1()
        {
            InitializeComponent();

            logo = Image.FromFile("images/LHS.png");
            width = logo.Width / 4;
            height = logo.Height / 4;

            rect = new Rectangle(position.X, position.Y, width, height);
        }

        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            Point mousePosition = new Point(e.X, e.Y);
            if(rect.Contains(mousePosition))
            {
                dragging = true;
                label1.Text = "Dragging the image";
            }
        }

        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            if(dragging)
            {
                position.X = e.X - (width / 2);
                position.Y = e.Y - (height / 2);
            }
        }

        private void FormMouseUp(object sender, MouseEventArgs e)
        {
            if(dragging)
            {
                dragging = false;
                rect.Location = new Point(e.X, e.Y);
                label1.Text = "Image dropped @ " + rect.Location.ToString();
            }
        }

        private void FormPaint(object sender, PaintEventArgs e)
        {
            Pen outline;

            if(dragging)
            {
                outline = new Pen(Color.Yellow, 6);
            }
            else
            {
                outline = new Pen(Color.Plum, 6);
            }

            e.Graphics.DrawRectangle(outline, rect);
            e.Graphics.DrawImage(logo, position.X, position.Y, width, height);
        }

        private void FormTimerEvent(object sender, EventArgs e)
        {
            rect.X = position.X;
            rect.Y = position.Y;

            this.Invalidate();
        }
    }
}
