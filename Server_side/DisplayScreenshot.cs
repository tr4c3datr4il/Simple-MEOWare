using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_side
{
    public partial class DisplayScreenshot : Form
    {
        private bool isDragging = false;
        private Point clickOffset;
        private float zoomFactor = 1.0f;
        private const float ZoomStep = 0.1f;
        public DisplayScreenshot(Image image)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Size = new Size(image.Width + 50, image.Height + 100);
            screenshotBox.Image = image;
            screenshotBox.SizeMode = PictureBoxSizeMode.StretchImage;
            screenshotBox.Width = image.Width;
            screenshotBox.Height = image.Height;

            screenshotBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            screenshotBox.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
            screenshotBox.MouseUp += new MouseEventHandler(PictureBox_MouseUp);
            screenshotBox.MouseWheel += new MouseEventHandler(PictureBox_MouseWheel);
            this.MouseWheel += new MouseEventHandler(PictureBox_MouseWheel);
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                clickOffset = new Point(e.X, e.Y);
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentScreenPos = screenshotBox.PointToScreen(e.Location);
                screenshotBox.Location = this.PointToClient(new Point(currentScreenPos.X - clickOffset.X, currentScreenPos.Y - clickOffset.Y));
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoomFactor += ZoomStep;
            }
            else if (e.Delta < 0)
            {
                zoomFactor -= ZoomStep;
                if (zoomFactor < ZoomStep) zoomFactor = ZoomStep;
            }

            ZoomPictureBox();
        }

        private void ZoomPictureBox()
        {
            screenshotBox.Width = (int)(screenshotBox.Image.Width * zoomFactor);
            screenshotBox.Height = (int)(screenshotBox.Image.Height * zoomFactor);
            screenshotBox.Left = (this.ClientSize.Width - screenshotBox.Width) / 2;
            screenshotBox.Top = (this.ClientSize.Height - screenshotBox.Height) / 2;
        }
    }
}
