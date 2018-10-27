using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto2
{    
    class Funcionalidad
    {
        int DimX = 0, DimY = 0;
      
        public void FunNivel(List<Lista> listas)
        {
            Boolean num = false, numx = false, num2= false, numy=false;
            foreach (var item in listas)
            {
                if (item.numero.Equals("5")) // busca palabra dimension
                {
                    num = true;
                    num2 = true;    
                }               
                if (num) // encontro la palabra reservada
                {
                    if (item.numero.Equals("18")) // busca caracter '('
                    {
                        numx = true;
                        num = false;
                    }
                }
                if (numx)
                {
                    try
                    {
                        if (item.tkn.Equals("Numero"))
                        {
                            DimX = Convert.ToInt32(item.lexema);                            
                            numx = false;
                        }
                    }
                    catch (Exception)
                    {
                        DimensionForm();
                        throw;
                    }
                } // fin coordenada x
                if (num2)
                {
                    if (item.lexema.Equals(",")) // busca caracter ','
                    {
                        numy = true;
                        num2 = false;
                    }
                }                
                if (numy)
                {
                    try
                    {
                        if (item.tkn.Equals("Numero"))
                        {
                            DimY = Convert.ToInt32(item.lexema);
                            numy = false;
                            DimensionForm();
                        }
                    }
                    catch (Exception)
                    {
                        DimensionForm();
                        throw;
                    }
                }
                //---------------------------------------------------------------------------------------------------------------------------------------------------------------                
            }// cierre del foreach
        }        

        public void DimensionForm()
        {
            //MessageBox.Show("Tamaño del formulario " + "(" + DimX + "," + DimY + ")");
            if (DimX > 3 & DimX <21 || DimY > 3 & DimY <16)
            {
                MessageBox.Show("Tamaño del formulario " + "(" + DimX + "," + DimY + ")");
                Form2 frm = new Form2(DimX, DimY);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Intervalo no respetado debe estar entre 3 < x <= 20"  + "," + "3 < y <= 15");
            }            
        }        
    }
}
