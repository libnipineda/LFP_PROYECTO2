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

        public void Principal(List<Lista> listas)
        {            
            
        }

        public void Nivel(List<Lista> listas)
        {
            Boolean num = false, numx = false, num2= false, numy=false;
            foreach (var item in listas)
            {
                if (item.numero.Equals("5"))
                {
                    num = true;
                }
                if (num) // encontro la palabra reservada
                {
                    if (item.numero.Equals("18"))
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
                            DimensionForm();
                            numx = false;
                        }                        
                   }
                   catch (Exception)
                   {
                        DimensionForm();
                        throw;
                   }
                }// Hasta aqui se acepta la coordenada x
                 //---------------------------------------------------------------------------------------------------------------------------------------------------------------
                if (item.numero.Equals("2"))
                {
                    num2 = true;
                }
                if (num2) // encontro la palabra reservada
                {
                    if (item.numero.Equals("22"))
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
                            DimensionForm();
                            numy = false;
                        }
                    }
                    catch (Exception)
                    {
                        DimensionForm();
                        throw;
                    }
                }// Hasta aqui se acepta la coordenada y
            } 
//---------------------------------------------------------------------------------------------------------------------------------------------------------------
        }

        public void Enemigo(List<Lista> listas)
        {

        }

        public void Personaje(List<Lista> listas)
        {

        }

        public void DimensionForm()
        {
            if (DimX > 3 & DimX <21 || DimY > 3 & DimY <16)
            {
                MessageBox.Show("Valores en x: " + DimX + "," + DimY);
            }
            else
            {
                MessageBox.Show("3 < x <= 20"  + "," + "3 < y <= 15");
            }            
        }
    }
}
