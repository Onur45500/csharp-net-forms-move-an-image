using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;

namespace csharp_net_forms_move_an_image
{
    public partial class Form1 : Form
    {
        Image logo;
        Point position = new Point(200, 200);
        bool dragging;
        Rectangle rect;
        int height = 200, width = 100;

        public Form1()
        {
            InitializeComponent();

            logo = Image.FromFile("images/LHS.png");
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
                position = e.Location;
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

        }

        private void FormTimerEvent(object sender, EventArgs e)
        {

        }
    }
}
