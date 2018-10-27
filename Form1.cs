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
        Sintactico sin = new Sintactico();
        List<Lista> datos = new List<Lista>();
        MemoryStream userInput = new MemoryStream();

        String abrirR, guardarR, nombreA;

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
                abrirR = abrir.FileName;
                nombreA = abrir.Title;
                StreamReader leer = new StreamReader(abrir.FileName);
                richTextBox1.Text = leer.ReadToEnd();
                leer.Close();
               }
            Console.WriteLine(abrirR);
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // mejorar forma de guardar            
            if ( abrirR != guardarR)
            {
                StreamWriter escribir = new StreamWriter(abrirR);
                foreach (object item in richTextBox1.Lines)
                {
                    escribir.WriteLine(item);
                }
                escribir.Close();
            }
            else
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

        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = ".DSI|*.DIS";
            guardar.Title = "Guardar Como";
            guardar.FileName = "Sin Titulo";
            var dato = guardar.ShowDialog();
               if (dato == DialogResult.OK)
               {
                  guardarR = guardar.FileName;
                  StreamWriter escribir = new StreamWriter(guardar.FileName);
                  foreach (object item in richTextBox1.Lines)
                  {
                    escribir.WriteLine(item);
                  }
                escribir.Close();
               }
            Console.WriteLine("Ruta archivo guardado: "+ guardarR);
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
            datos.Clear();
            lexico.Analisis(richTextBox1.Text);
            sin.Parsear(lexico.getToken());
            lexico.Tablatkn();
            //lexico.TablaEtkn();
        }

        private void tableroDeJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lexico.Ejecutar();            
        }

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process temp = new System.Diagnostics.Process();
            temp.StartInfo.FileName = "E:\\Lenguajes\\segundo semestre 2018\\laboratorio\\Proyecto2\\[LFP]Proyecto2_201403541\\Manual Usuario.pdf";
            temp.Start();
            temp.Close();
        }

        private void manualTecnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process temp = new System.Diagnostics.Process();
            temp.StartInfo.FileName = "E:\\Lenguajes\\segundo semestre 2018\\laboratorio\\Proyecto2\\[LFP]Proyecto2_201403541\\Manual Técnico.pdf";
            temp.Start();
            temp.Close();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "LFP PROYECTO\n Uzzi Libni Aarón Pineda Solórzano\n carné:201403541 \n Sección: A-",
                "Acerca de...");
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
