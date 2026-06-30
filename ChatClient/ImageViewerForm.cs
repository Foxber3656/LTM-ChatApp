using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class ImageViewerForm : Form
    {
        private readonly string imagePath;
        public ImageViewerForm(string filePath)
        {
            InitializeComponent();
            this.imagePath = filePath;
        }
        private void ImageViewerForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(imagePath))
            {
                MessageBox.Show("Image not found.");
                Close();
                return;
            }

            pictureBox1.Image = Image.FromFile(imagePath);

            lblFileName.Text = Path.GetFileName(imagePath);
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dialog = new();

            dialog.FileName = Path.GetFileName(imagePath);

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            File.Copy(imagePath, dialog.FileName, true);

            MessageBox.Show("Downloaded successfully.");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ImageViewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pictureBox1.Image?.Dispose();
        }
    }
}
