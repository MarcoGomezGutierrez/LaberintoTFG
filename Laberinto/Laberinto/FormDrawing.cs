using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laberinto
{
    public partial class FormDrawing : Form
    {
        private int startPoint = 1;
        private int sizeMap = 80;
        private int steps = 50;
        private List<List<Pixel>> list;
        private Random random = new Random();
        private Pixel player;

        public FormDrawing()
        {
            InitializeComponent();
            player = new Pixel(new Point(startPoint * steps, startPoint * steps), new Size(steps, steps), Color.FromArgb(0, 255, 0));
            list = getMap();
        }

        private List<List<Pixel>> getMap()
        {
            List<List<Pixel>> list = new List<List<Pixel>>();

            for (int i = startPoint; i <= (startPoint + sizeMap); i++)
            {
                List<Pixel> listPixel = new List<Pixel>();
                for (int y = startPoint; y <= (startPoint + sizeMap); y++)
                {
                    listPixel.Add(new Pixel(new Point(i * steps, y * steps), new Size(steps, steps), getColor()));
                }
                list.Add(listPixel);
            }
            return list;
        }

        private Color getColor()
        {
            if (random.Next() > (Int32.MaxValue / 2))
            {
                return Color.FromArgb(0, 0, 0);
            } else
            {
                return Color.FromArgb(90, 90, 90);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (List<Pixel> listPixel in list)
            {
                foreach (Pixel pixel in listPixel)
                {
                    e.Graphics.FillRectangle(pixel.getColor(), pixel.getPixel());
                }
            }
            e.Graphics.FillRectangle(player.getColor(), player.getPixel());
        }
    }

    public class Pixel
    {
        private Point point;
        private Size size;
        private Color color;

        public Pixel(Point point, Size size, Color color)
        {
            this.point = point;
            this.size = size;
            this.color = color;
        }

        public Rectangle getPixel()
        {
            return new Rectangle(point, size);
        }

        public SolidBrush getColor()
        {
            return new SolidBrush(color);
        }

    }
}
