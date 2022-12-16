using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _8Queen
{
    public partial class Form1 : Form
    {
        private int[] chess = new int[8];
        private Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                chess[0] = i;
                queens(0);
                for (int f = 0; f < 8; f++)
                    chess[f] = 0;
            }            
        }

        private void queens(int index)
        {
            if (check(index))
                if (index == 7)
                {
                    string str = string.Empty;
                    for (int i = 0; i < 8; i++)
                        str += chess[i] + "-";                    
                    listBox1.Items.Add(str);
                        
                }
                else
                {
                    for (int j = 0; j < 8; j++)
                    {
                        chess[index + 1] = j;
                        queens(index + 1);

                    }
                }

        }

        private bool check(int index)
        {
            int k=0;
            bool switchs=true;

            while(k<index && switchs)
            {
                if (chess[index]==chess[k] || Math.Abs(chess[index]-chess[k])==index-k)
                    switchs=false;
                k++;
            }
            return switchs;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
                chess[i] = 0;

            #region chess Ground

            drawChessGround();
            
            #endregion
        }

        private void Show_Click(object sender, EventArgs e)
        {
            string select = string.Empty;
            int x = 0;
            int y = 0;

            select = listBox1.SelectedItem.ToString();
            drawChessGround();
            for (int i=0;i<8;i++)
            {
                x = Convert.ToInt32(select.Substring(0,1))*74;
                y = i*74;
                select = select.Remove(0, 2);
                g.DrawImage(_8Queen.Properties.Resources.vc, x, y, 74, 74);               
            }                       
        }

        private void drawChessGround()
        {
            int x = 0;
            int y = 0;
            int color = 1;

            this.BackColor = Color.LightGray;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (color % 2 == 0)
                        g.FillRectangle(Brushes.Black, x, y, 74, 74);
                    else
                        g.FillRectangle(Brushes.White, x, y, 74, 74);
                    x += 74;
                    color++;
                }
                y += 74;
                x = 0;
                color++;
            }
        }
    }
}
