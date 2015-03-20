using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Steganographie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap encode_wiki(Bitmap pIn, Bitmap pInSec)
        {
            Bitmap pOUT = new Bitmap(pIn.Width, pIn.Height);

            if(pInSec.Height <= pIn.Height && pInSec.Width <= pIn.Width)
            {
                for (int i = 0; i < pIn.Width; i++)
                {
                    for (int j = 0; j < pIn.Height; j++)
                    {
                        String tmp;
                        String tmp_sec;
                        int x = 0; // Length of Tmp
                        int y = 0; // R,G,B or A Value
                        Point pt = new Point();
                        pt.X = i;
                        pt.Y = j;

                        tmp = Convert.ToString(pIn.GetPixel(i, j).A, 2);
                        y = pInSec.GetPixel(i, j).A / 85;
                        x = tmp.Length;
                        if (x == 1)
                            tmp = "0" + tmp;
                        else
                            tmp = tmp.Substring(0, x - 2);
                        if(Convert.ToString(y,2).Length <2)
                            tmp = tmp + "0" + Convert.ToString(y,2);
                        else
                            tmp = tmp + Convert.ToString(y,2);
                        int cA = Convert.ToInt32(tmp, 2);

                        tmp = Convert.ToString(pIn.GetPixel(i, j).B, 2);
                        y = pInSec.GetPixel(i, j).B / 85;
                        x = tmp.Length;
                        if (x == 1)
                            tmp = "0" + tmp;
                        else
                            tmp = tmp.Substring(0, x - 2);
                        if (Convert.ToString(y, 2).Length < 2)
                            tmp = tmp + "0" + Convert.ToString(y, 2);
                        else
                            tmp = tmp + Convert.ToString(y,2);
                        int cB = Convert.ToInt32(tmp, 2);

                        tmp = Convert.ToString(pIn.GetPixel(i, j).G, 2);
                        y = pInSec.GetPixel(i, j).G / 85;
                        x = tmp.Length;
                        if (x == 1)
                            tmp = "0" + tmp;
                        else
                            tmp = tmp.Substring(0, x - 2);
                        if (Convert.ToString(y, 2).Length < 2)
                            tmp = tmp + "0" + Convert.ToString(y, 2);
                        else
                            tmp = tmp + Convert.ToString(y,2);
                        int cG = Convert.ToInt32(tmp, 2);

                        tmp = Convert.ToString(pIn.GetPixel(i, j).R, 2);
                        y = pInSec.GetPixel(i, j).R / 85;
                        x = tmp.Length;
                        if (x == 1)
                            tmp = "0" + tmp;
                        else
                            tmp = tmp.Substring(0, x - 2);
                        if (Convert.ToString(y, 2).Length < 2)
                            tmp = tmp + "0" + Convert.ToString(y, 2);
                        else
                            tmp = tmp + Convert.ToString(y,2);
                        int cR = Convert.ToInt32(tmp, 2);

                        pOUT.SetPixel(i, j, Color.FromArgb(cA, cR, cG, cB));
                    }
                }
            }

            return pOUT;
        }

        private Bitmap decode_wiki(Bitmap pIn)
        {
            Bitmap pOUT = new Bitmap(pIn.Width, pIn.Height);

            for (int i = 0; i < pIn.Width; i++)
            {
                for (int j = 0; j < pIn.Height; j++)
                {
                    String tmp;
                    int x = 0;

                    Point pt = new Point();
                    pt.X = i;
                    pt.Y = j;

                    tmp = Convert.ToString(pIn.GetPixel(i, j).A, 2);
                    x = tmp.Length;
                    if (x == 1)
                        tmp = "0" + tmp;
                    else
                        tmp = tmp.Substring(x-2, 2);
                    int cA = Convert.ToInt32(tmp, 2) * 85;

                    tmp = Convert.ToString(pIn.GetPixel(i, j).B, 2);
                    x = tmp.Length;
                    if (x == 1)
                        tmp = "0" + tmp;
                    else
                        tmp = tmp.Substring(x - 2, 2);
                    int cB = Convert.ToInt32(tmp, 2) * 85;

                    tmp = Convert.ToString(pIn.GetPixel(i, j).G, 2);
                    x = tmp.Length;
                    if (x == 1)
                        tmp = "0" + tmp;
                    else
                        tmp = tmp.Substring(x - 2, 2);
                    int cG = Convert.ToInt32(tmp, 2) * 85;

                    tmp = Convert.ToString(pIn.GetPixel(i, j).R, 2);
                    x = tmp.Length;
                    if (x == 1)
                        tmp = "0" + tmp;
                    else
                        tmp = tmp.Substring(x - 2, 2);
                    int cR = Convert.ToInt32(tmp, 2) * 85;

                    pOUT.SetPixel(i, j, Color.FromArgb(cA,cR,cG,cB));
                }
            }
            return pOUT;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.pictureBox2.Image = this.decode_wiki(pictureBox1.Image as Bitmap);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.pictureBox3.Image = this.encode_wiki(pictureBox1.Image as Bitmap, pictureBox2.Image as Bitmap);
            this.pictureBox2.Image = new Bitmap(this.pictureBox2.Image.Width, this.pictureBox2.Image.Height);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.pictureBox2.Image = this.decode_wiki(this.pictureBox3.Image  as Bitmap);
        }
            
    }
}
