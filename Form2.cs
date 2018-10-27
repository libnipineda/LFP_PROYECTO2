using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto2
{
    public partial class Form2 : Form
    {
        int cX, cY;

        public Form2( int x, int y)
        {
            InitializeComponent();
            // paso coordenas tablero
            cX = x; cY = y;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Label[,] tablero = new Label[cX,cY]; // matriz de label
            int[,] tableroL = new int[cX,cY];
            int PosX=0, PosY=0;

            // recorrer el tablero
            for (int i = 0; i < cX; i++)
            {
                for (int j = 0; j < cY; j++)
                {
                    tablero[i, j] = new Label();
                    tablero[i, j].AutoSize = false;
                    tablero[i, j].SetBounds(PosX, PosY, 30, 30);
                    tablero[i, j].BackColor = Color.BlueViolet;
                    tablero[i, j].Text = "";
                    tablero[i, j].BorderStyle = BorderStyle.FixedSingle;

                    panel1.Controls.Add(tablero[i, j]);                                        
                    PosX += 30;

                }
                PosX = 0;
                PosY += 30;
            }

        }
    }
}
