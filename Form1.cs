using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoteriaMexicana
{
    public partial class Form1 : Form
    {
        private PictureBox[] Tabla;
        const int Cantidad_cartas = 54;
        Random rnd = new Random();
        int r = 0, c = 0;
        int a, aux;
        int[] cartas = new int[54];
        SoundPlayer carta = new SoundPlayer();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inicializarTabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = rnd.Next(1, 54);
            pictureBox1.Image = Image.FromFile(@"Grande\" + num + ".jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            carta.SoundLocation = @"sonidos\" + num + ".wav";
            carta.Play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }
        private void inicializarTabla()
        {
            Tabla = new PictureBox[25];

            for (int i = 0; i < cartas.Length; i++)
            {
                cartas[i] = i + 1;
            }
            for (int i = 0; i < cartas.Length; i++)
            {
                a = rnd.Next(cartas.Length);
                aux = cartas[i];
                cartas[i] = cartas[a];
                cartas[a] = aux;
            }
            for (int i = 0; i < Tabla.Length; i++)
            {
                Tabla[i] = new PictureBox();
                Tabla[i].Location = new System.Drawing.Point(100 + (c * 90), 25 + (r * 120));
                Tabla[i].Name = "picTabla" + i;
                Tabla[i].Size = new System.Drawing.Size(85, 110);
                Tabla[i].TabIndex = 0 + i;
                Tabla[i].SizeMode = PictureBoxSizeMode.StretchImage;
                Tabla[i].TabStop = false;
                Tabla[i].Image = Image.FromFile(@"Grande\" + cartas[i] + ".jpg");
                this.Controls.Add(Tabla[i]);
                c++;
                if (c == 5)
                {
                    r++;
                    c = 0;
                }
            }
        }


    }
}
