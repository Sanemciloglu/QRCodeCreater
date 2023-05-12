using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRCodeCreater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string vcardData = "BEGIN:VCARD\n" +
            "VERSION:3.0\n" +
              "N:" + txtName.Text + "\n" +
            "FN:" + txtName.Text + "\n" +
            "ORG:" + txtSirket.Text + "\n" +
            "TITLE:" + txtTitle.Text + "\n" +
            "TEL;TYPE=CELL,VOICE:" + txtTelKisisel.Text + "\n" +
            "TEL;TYPE=WORK,VOICE:" + txtTel.Text + "\n" +
            "TEL;TYPE=WORK,VOICE:" + textBox2.Text + "\n" +
            
            "EMAIL:" + txtMail.Text + "\n" +
            "ADR:" + txtAddres.Text + "\n" +
               "URL:" + txtURL.Text + "\n" +

            "END:VCARD";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(vcardData, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(4);
            picQrCode.Image = qrCodeImage;
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void btnQrOlustur_Click(object sender, EventArgs e)
        {
            // Kaydetme dosya yolu ve türü
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PNG Image|*.png|JPEG Image|*.jpg|BMP Image|*.bmp";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // Dosya yolu null değilse ve resim yüklenmişse resmi kaydet
            if (saveFileDialog1.FileName != "" && picQrCode.Image != null)
            {
                picQrCode.Image.Save(saveFileDialog1.FileName);
            }
        }
    }
}
