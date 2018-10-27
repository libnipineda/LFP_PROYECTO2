using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto2
{
    class Sintactico
    {
        /* Correlativo y lexema
         * 1->principal, 2->numero ,3->intervalo ,4->nivel ,5->dimension ,6->inicio_personaje ,7->ubicacion_salida ,8->pared ,9->casilla ,10->varias_casillas,
         * 11->enemigo ,12->caminata ,13->personaje ,14->paso ,15->variable ,16->[ ,17->] ,18->( ,19->) ,20->: ,21->; ,22->, 23->.. ,24->+ ,25->- ,
         * 26->* ,27->/ ,28->{ ,29->} ,30->cadena ,31->=
         */

        // variables
        int numpre;
        Lista Preanalisis;
        List<Lista> listatokens;

        public void Parsear(List<Lista> lista)
        {
            listatokens = lista;

            Lista aux = new Lista();
            aux.numero = "";
            aux.fila = "";
            aux.columna = "";
            aux.idtkn = "Ultimo Token";
            aux.tkn = "";
            aux.lexema = "";
            listatokens.Add(aux); // agregar como ultimo parametro ultimo token

            Preanalisis = lista.ElementAt(0); // primer elemento de la lista
            numpre = 0; // siguiente elemento
            Inicio(); // primera produccion
        }

        public void Inicio()
        {
            MessageBox.Show("Inicio de la Gramatica", "Información");
            try
            {
                Parea("16"); // [
                Parea("1"); // principal
                Parea("17"); // ]
                Parea("20"); // :
                Parea("28"); // {
                J();
                Parea("29"); // }
            }
            catch (Exception)
            {
                // Encuentra error lo obvia y sigue con el analisis
                throw;
            }
        }

        public void J()
        {
            try
            {
                Parea("16"); // [
                if (Preanalisis.getidtkn().Equals("3")) // intervalo
                {
                    A(); // Produccion <A>
                    Parea("21"); // ;                
                    B(); // Produccion <B>
                }
                else
                {
                    B(); // produccion <B>     
                    Parea("16"); // [
                    A(); // produccion <A>
                    Parea("21"); // ;
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public void A()
        {
            try
            {
                Parea("3"); // Intervalo
                Parea("17"); // ]
                Parea("20"); // :
                Parea("18"); //(
                Parea("2"); // num
                Parea("19"); // )       
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void B()
        {
            try
            {
                if (Preanalisis.getidtkn().Equals("16"))
                {
                    Parea("16"); // [
                    BPRI();
                }
                else
                {

                }                                
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void BPRI()
        {
            try
            {
                if (Preanalisis.getidtkn().Equals("4")) // nivel
                {
                    Parea("17"); // ]
                    Parea("20"); // :
                    Parea("28"); // {
                    C();
                    Parea("29"); // }
                    B();
                }
                else if (Preanalisis.getidtkn().Equals("11")) // Enemigo
                {
                    Parea("17"); // ]
                    Parea("20"); // :
                    Parea("28"); // {
                    H();
                    Parea("29"); // }
                    B();
                }
                else if (Preanalisis.getidtkn().Equals("13")) // personaje
                {
                    Parea("17"); // ]
                    Parea("20"); // :
                    Parea("28"); // {
                    I();
                    Parea("29"); // }
                    B();
                }
                else
                {

                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void C()
        {
            try
            {
                Parea("16"); // [
                CPRI();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void CPRI()
        {
            try
            {
                if (Preanalisis.getidtkn().Equals("5")) // dimensiones
                {
                    Parea("17"); // ]
                    Parea("20"); // :
                    Parea("18"); //(
                    Parea("2"); // num
                    Parea("22"); // ,
                    Parea("2"); // num
                    Parea("19"); // )
                    Parea("21"); // ;
                    C();
                }
                else if (Preanalisis.getidtkn().Equals("6")) // inicio_personaje
                {
                    Parea("17"); // ]
                    Parea("20"); // :
                    Parea("18"); //(
                    Parea("2"); // num
                    Parea("22"); // ,
                    Parea("2"); // num
                    Parea("19"); // )
                    Parea("21"); // ;
                    C();
                }
                else if (Preanalisis.getidtkn().Equals("7")) // ubicacion_salida
                {
                    Parea("17"); // ]
                    Parea("20"); // :
                    Parea("18"); //(
                    Parea("2"); // num
                    Parea("22"); // ,
                    Parea("2"); // num
                    Parea("19"); // )
                    Parea("21"); // ;
                    C();
                }
                else if (Preanalisis.getidtkn().Equals("8")) // pared
                {
                    Parea("17"); // ]
                    Parea("20"); // :
                    Parea("28"); // {
                    E();                    
                    C();
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public void E()
        {
            try
            {
                if (Preanalisis.getidtkn().Equals("16")) // [
                {
                    EPRI();
                }
                else if (Preanalisis.getidtkn().Equals("30")) // cadena
                {
                    Parea("20"); // :
                    Parea("31"); // =
                    F();
                    Parea("21"); // ;
                    E();
                }
                else
                {
                    Parea("29"); // }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EPRI()
        {
            try
            {
                if (Preanalisis.getidtkn().Equals("9")) // casilla
                {
                    Parea("17"); // ]
                    Parea("20"); // :
                    Parea("18"); // (
                    F();
                    Parea("22"); // ,
                    F();
                    Parea("19"); // )
                    Parea("21"); // ;
                    E();
                }
                else if (Preanalisis.getidtkn().Equals("10")) // varias_casillas
                {
                    Parea("17"); // ]
                    Parea("20"); // :
                    Parea("18"); // (
                    D();
                    Parea("22"); // ,
                    D();
                    Parea("19"); // )
                    Parea("21"); // ;
                    E();
                }
                else if (Preanalisis.getidtkn().Equals("15")) // variable
                {
                    Parea("17"); // ]
                    Parea("20"); // :
                    Parea("30"); // cadena
                    VPRI();
                    E();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void VPRI()
        {
            try
            {
                if (Preanalisis.getidtkn().Equals("22")) // ,
                {
                    Parea("30"); // cadena
                    VPRI();
                }
                else
                {
                    Parea("21"); // ;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void F()
        {
            try
            {
                G();
                FPRI();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void FPRI()
        {
            try
            {
                if (Preanalisis.getidtkn().Equals("24")) // +
                {
                    G();
                    FPRI();
                }
                else if (Preanalisis.getidtkn().Equals("25")) // -
                {
                    G();
                    FPRI();
                }
                else if (Preanalisis.getidtkn().Equals("26")) // *
                {
                    G();
                    FPRI();
                }
                else if (Preanalisis.getidtkn().Equals("27")) // /
                {
                    G();
                    FPRI();
                }
                else
                {
                    G();
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public void G()
        {
            try
            {
                if (Preanalisis.getidtkn().Equals("30")) // cadena
                {

                }
                else
                {
                    Parea("2"); // num
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void H()
        {
            try
            {
                Parea("16"); // [
                Parea("12"); // caminata
                Parea("17"); // ]
                Parea("20"); // :
                Parea("18"); // (
                D();
                Parea("19"); // )
                Parea("21"); // ;
                H();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public void I()
        {
            try
            {
                if (Preanalisis.getidtkn().Equals("16")) // [
                {
                    IPRI();
                }
                else if (Preanalisis.getidtkn().Equals("30")) // cadena
                {
                    Parea("20"); // :
                    Parea("31"); // =
                    F();
                    Parea("21"); // ;
                    I();
                }
                else
                {

                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public void IPRI()
        {
            try
            {
                if (Preanalisis.getidtkn().Equals("14")) // paso
                {
                    Parea("17"); // ]
                    Parea("20"); // :
                    Parea("18"); // (
                    G();
                    Parea("22"); // ,
                    G();
                    Parea("19"); // )
                    Parea("21"); // ;
                    I();
                }
                else if (Preanalisis.getidtkn().Equals("12")) // caminata
                {
                    Parea("17"); // ]
                    Parea("20"); // :
                    Parea("18"); // (
                    D();
                    Parea("19"); // )
                    Parea("21"); // ;
                    I();
                }
                else if (Preanalisis.getidtkn().Equals("15")) // variable
                {
                    Parea("17"); // ]
                    Parea("20"); // :
                    Parea("30"); // id
                    VPRI();
                    I();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void D()
        {
            try
            {
                if (Preanalisis.getidtkn().Equals("30")) // id
                {
                    G();
                    D();
                }
                else if (Preanalisis.getidtkn().Equals("2")) // numero
                {
                    G();
                    D();
                }
                else if (Preanalisis.getidtkn().Equals("23")) // .
                {
                    Parea("23"); //.
                    D();
                }
                else
                {

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Parea(String valor)
        {
            if (!valor.Equals(Preanalisis.getidtkn())) // lo que viene no es lo que se esperaba
            {
                //MessageBox.Show("Error sintactico se esperaba " + valor + ",en la fila: " + Preanalisis.fila);
                return;
            }
            if (!Preanalisis.getidtkn().Equals("Ultimo Token")) // saber si ya llego al tope de la lista
            {
                numpre++; // incrementa
                Preanalisis = listatokens.ElementAt(numpre); // ya esta en la siguiente posicion de la lista
            }
        }
    }    
}
