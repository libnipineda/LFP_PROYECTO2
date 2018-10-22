using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto2
{
    public partial class Form1 : Form
    {
        Lexico lexico = new Lexico();        

        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Archivo|*.DIS";
            abrir.Title = "Abrir Archivo";
            abrir.FileName = "Sin titulo";
            var dato = abrir.ShowDialog();
               if (dato == DialogResult.OK)
               {
                StreamReader leer = new StreamReader(abrir.FileName);
                richTextBox1.Text = leer.ReadToEnd();
                leer.Close();
               }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // mejorar forma de guardar
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivo|*.DIS";
            guardar.Title = "Guardar Como";
            guardar.FileName = "Sin Titulo";
            var dato = guardar.ShowDialog();
            if (dato == DialogResult.OK)
            {
                StreamWriter escribir = new StreamWriter(guardar.FileName);
                foreach (object item in richTextBox1.Lines)
                {
                    escribir.WriteLine(item);
                }
                escribir.Close();
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivo|*.DIS";
            guardar.Title = "Guardar Como";
            guardar.FileName = "Sin Titulo";
            var dato = guardar.ShowDialog();
               if (dato == DialogResult.OK)
               {
                  StreamWriter escribir = new StreamWriter(guardar.FileName);
                  foreach (object item in richTextBox1.Lines)
                  {
                    escribir.WriteLine(item);
                  }
                escribir.Close();
               }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de la aplicación", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lexico.Analisis(richTextBox1.Text);
            //lexico.Tablatkn();
            //lexico.TablaEtkn();
        }

        private void tableroDeJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lexico.Ejecutar();
            //Form2 frm = new Form2();
            //frm.ShowDialog();
            //if (frm.DialogResult == DialogResult.Yes)
            //{

            //}
        }

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   Process.Start(@"C: \Users\Aarón\Documents\Lenguajes\Proyecto 2\[LFP]Proyecto2_201403541\Manual Tecnico.pdf");
        }

        private void manualTecnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   Process.Start(@"C: \Users\Aarón\Documents\Lenguajes\Proyecto 2\[LFP]Proyecto2_201403541\Manual de Usuario.pdf");
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "LFP PROYECTO\n Uzzi Libni Aarón Pineda Solórzano\n carné:201403541 \n Sección: A-",
                "Acerca de...");
        }
    }
}
