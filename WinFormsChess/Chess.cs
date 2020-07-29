using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsChess
{
    public partial class Chess : Form
    {
        public Chess()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            int width = MainCanvas.Width;
            int height = MainCanvas.Height;
            Image MainBitmap = new Bitmap(MainCanvas.Width, MainCanvas.Height);

            using (Graphics transformer = Graphics.FromImage(MainBitmap))
                for(int i = 0; i < 8; i++)
                    for(int j = 0; j < 8; j++)
                    {
                        if((i+j)%2 == 0)
                            transformer.FillRectangle(Brushes.White, new Rectangle(width/8 * i, height/8 * j, width/8, height/8));
                        else
                            transformer.FillRectangle(Brushes.SandyBrown, new Rectangle(width/8 * i, height/8 * j, width / 8, height / 8));

                    }                

            MainCanvas.Image = MainBitmap;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Chess_Load(object sender, EventArgs e)
        {

        }
    }
}
