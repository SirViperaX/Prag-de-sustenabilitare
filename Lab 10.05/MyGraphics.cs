using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Lab_10._05
{
    public class MyGraphics
    {
        PictureBox display;
        Bitmap bmp;
        public Graphics grp;
        public Color backColor = Color.AliceBlue;
        public int resX { get { return display.Height; } }
        public int resY { get { return display.Width; } }

        public void InitGraph(PictureBox display)
        {
            this.display = display;
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);
            ClearGraph();
            RefreshGraph();
        }

        public void ClearGraph()
        {
            grp.Clear(backColor);
        }

        public void RefreshGraph()
        {
            this.display.Image = bmp;
        }

    }
}
