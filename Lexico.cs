using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto2
{
    class Lexico
    {
        List<Lista> datos = new List<Lista>();
        List<Elista> Edatos = new List<Elista>();        
        int idtkn;
        int nutken = 0;        
        int fila =0 , columna = 0;
        string token = "";
        string concatenar = "";
        string Etoken = "";

        public void Analisis(String cadena)
        {
            int estado = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                switch (estado)
                {
                    case 0:                        
                        if (((char)09).Equals(cadena[i]) | ((char)10).Equals(cadena[i]) | ((char)32).Equals(cadena[i])) // tecla tab, salto de linea , espacio
                        {
                            estado = 0; fila++; columna++;
                        }
                        else if (((char)40).Equals(cadena[i])|((char)41).Equals(cadena[i])|((char)42).Equals(cadena[i])|((char)43).Equals(cadena[i])|((char)44).Equals(cadena[i])|((char)45).Equals(cadena[i]) | ((char)46).Equals(cadena[i]) | ((char)47).Equals(cadena[i]) |((char)58).Equals(cadena[i]) |((char)59).Equals(cadena[i])|((char)61).Equals(cadena[i]) |((char)91).Equals(cadena[i]) | ((char)93).Equals(cadena[i]) | ((char)123).Equals(cadena[i]) | ((char)125).Equals(cadena[i])) // caracter * + - , :  ;  = [ ] { }  ( ) .
                        {                            
                            estado = 1; concatenar += cadena[i]; columna++;                            
                        }
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 2; concatenar += cadena[i]; columna++;
                        }
                        else if (char.IsLetter(cadena[i]))
                        {
                            estado = 3; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            Etoken += cadena[i];
                            Elista aux = new Elista();
                            aux.Enum = "" + nutken;
                            aux.Efi = "" + fila;
                            aux.Ecol = "" + columna;
                            aux.Eidtkn = "" + idtkn;
                            aux.Etkn = "Valor Desconocido";
                            aux.Elex = Etoken;
                            //Console.WriteLine("errores: " + tokenerror);
                            Edatos.Add(aux); nutken++; concatenar = ""; Etoken = "";
                        }
                        break;
                    case 1:
                        //MessageBox.Show(concatenar + i.ToString() + cadena[i]);
                        string a = concatenar + cadena[i];
                        if (a == "..")
                        {                            
                            concatenar = concatenar + ".";
                            Analizartkn(concatenar); estado = estado - 1; estado = 0;
                            Lista temp1 = new Lista();
                            temp1.numero = "" + nutken;
                            temp1.fila = "" + fila;
                            temp1.columna = "" + columna;
                            temp1.idtkn = "" + idtkn;
                            temp1.tkn = token;
                            temp1.lexema = concatenar;
                            datos.Add(temp1); nutken++; concatenar = "";
                        }
                        else
                        {
                            Analizartkn(concatenar); i--; estado = estado - 1; estado = 0;
                            Lista temp1 = new Lista();
                            temp1.numero = "" + nutken;
                            temp1.fila = "" + fila;
                            temp1.columna = "" + columna;
                            temp1.idtkn = "" + idtkn;
                            temp1.tkn = token;
                            temp1.lexema = concatenar;
                            datos.Add(temp1); nutken++; concatenar = "";
                        }
                        //Console.WriteLine("dato: " + concatenar);
                        break;
                    case 2:
                        if (char.IsNumber(cadena[i]))
                        {
                            estado = 2; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            i--; estado = estado - 1; estado = 0;
                            Lista temp = new Lista();
                            temp.numero = "" + nutken;
                            temp.fila = "" + fila;
                            temp.columna = "" + columna;
                            temp.idtkn = "2";
                            temp.tkn = "Numero";
                            temp.lexema = concatenar;
                            //Console.WriteLine("dato: " + concatenar);
                            datos.Add(temp); nutken++; concatenar = "";
                        }
                        break;
                    case 3:
                        if (char.IsLetter(cadena[i]))
                        {
                            estado = 3; concatenar += cadena[i]; columna++;
                        }
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 3; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)95).Equals(cadena[i])) // caracter '_'
                        {
                            estado = 3; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            Analizartkn(concatenar); i--; estado = estado - 1; estado = 0;
                            Lista temp = new Lista();
                            temp.numero = "" + nutken;
                            temp.fila = "" + fila;
                            temp.columna = "" + columna;
                            temp.idtkn = "" + idtkn;
                            temp.tkn = token;
                            temp.lexema = concatenar;
                            //Console.WriteLine("dato: " + concatenar);
                            datos.Add(temp); nutken++; concatenar = "";
                        }
                        break;
                    default:
                        Etoken += cadena[i];
                        Elista aux1 = new Elista();
                        aux1.Enum = "" + nutken;
                        aux1.Efi = "" + fila;
                        aux1.Ecol = "" + columna;
                        aux1.Eidtkn = "" + idtkn;
                        aux1.Etkn = "Valor Desconocido";
                        aux1.Elex = Etoken;
                        //Console.WriteLine("errores: " + tokenerror);
                        Edatos.Add(aux1); nutken++; concatenar = ""; Etoken = "";
                        break;
                }
            }
        }

        public void Analizartkn(String tkn)
        {
            //tkn.ToLower();
            tkn.Trim();            
            switch (tkn)
            {
                case "PRINCIPAL":
                    token = "palabra reservada"; idtkn = 1;
                    break;
                case "Principal":
                    token = "palabra reservada"; idtkn = 1;
                    break;
                case "principal":
                    token = "palabra reservada"; idtkn = 1;
                    break;             
                case "intervalo":
                    token = "palabra reservada"; idtkn = 3;
                    break;
                case "Intervalo":
                    token = "palabra reservada"; idtkn = 3;
                    break;
                case "INTERVALO":
                    token = "palabra reservada"; idtkn = 3;
                    break;
                case "Nivel":
                    token = "palabra reservada"; idtkn = 4;
                    break;
                case "NIVEL":
                    token = "palabra reservada"; idtkn = 4;
                    break;
                case "nivel":
                    token = "palabra reservada"; idtkn = 4;
                    break;                
                case "dimensiones":
                    token = "palabra reservada"; idtkn = 5;
                    break;
                case "Dimensiones":
                    token = "palabra reservada"; idtkn = 5;
                    break;
                case "inicio_personaje":
                    token = "palabra reservada"; idtkn = 6;
                    break;
                case "Inicio_personaje":
                    token = "palabra reservada"; idtkn = 6;
                    break;
                case "ubicacion_salida":
                    token = "palabra reservada"; idtkn = 7;
                    break;
                case "Ubicación_Salida":
                    token = "palabra reservada"; idtkn = 7;
                    break;
                case "pared":
                    token = "palabra reservada"; idtkn = 8;
                    break;
                case "Pared":
                    token = "palabra reservada"; idtkn = 8;
                    break;
                case "casilla":
                    token = "palabra reservada"; idtkn = 9;
                    break;
                case "Casilla":
                    token = "palabra reservada"; idtkn = 9;
                    break;
                case "varias_casillas":
                    token = "palabra reservada"; idtkn = 10;
                    break;
                case "Varias_Casillas":
                    token = "palabra reservada"; idtkn = 10;
                    break;
                case "enemigo":
                    token = "palabra reservada"; idtkn = 11;
                    break;
                case "Enemigo":
                    token = "palabra reservada"; idtkn = 11;
                    break;
                case "ENEMIGO":
                    token = "palabra reservada"; idtkn = 11;
                    break;
                case "caminata":
                    token = "palabra reservada"; idtkn = 12;
                    break;
                case "Caminata":
                    token = "palabra reservada"; idtkn = 12;
                    break;
                case "personaje":
                    token = "palabra reservada"; idtkn = 13;
                    break;
                case "Personaje":
                    token = "palabra reservada"; idtkn = 13;
                    break;
                case "PERSONAJE":
                    token = "palabra reservada"; idtkn = 13;
                    break;
                case "paso":
                    token = "palabra reservada"; idtkn = 14;
                    break;
                case "Paso":
                    token = "palabra reservada"; idtkn = 14;
                    break;
                case "variable":
                    token = "palabra reservada"; idtkn = 15;
                    break;
                case "Variable":
                    token = "palabra reservada"; idtkn = 15;
                    break;
                case "[":
                    token = "Signo corchete abierto"; idtkn = 16;
                    break;
                case "]":
                    token = "Signo corchete cerrado"; idtkn = 17;
                    break;
                case "(":
                    token = "Signo parentesis abierto"; idtkn = 18;
                    break;
                case ")":
                    token = "Signo parentesis cerrado"; idtkn = 19;
                    break;
                case ":":
                    token = "Signo dos puntos"; idtkn = 20;
                    break;
                case ";":
                    token = "Signo punto y coma"; idtkn = 21;
                    break;
                case ",":
                    token = "Signo coma"; idtkn = 22;
                    break;
                case "..":
                    token = "Signo de rango"; idtkn = 23;
                    break;
                case "+":
                    token = "signo mas"; idtkn = 24;
                    break;
                case "-":
                    token = "signo menos"; idtkn = 25;
                    break;
                case "*":
                    token = "Signo por"; idtkn = 26;
                    break;
                case "/":
                    token = "Signo div"; idtkn = 27;
                    break;
                case "{":
                    token = "Signo corchete abierto"; idtkn = 28;
                    break;
                case "}":
                    token = "Signo corchete cerrado"; idtkn = 29;
                    break;
                case "=":
                    token = "Signo igual"; idtkn = 31;
                   break;                    
                default:
                    token = "cadena"; idtkn = 30;
                    break;
            }
        }

        public void Tablatkn()
        {
            if (MessageBox.Show("Espere en un momento se abrira el archivo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                ReporteHTML item = new ReporteHTML();
                item.ReporteTKN(datos);
                Process.Start(@"C:\Users\libni\Desktop\ReporteToken.html");
            }
        }

        public void TablaEtkn()
        {            
                ReporteHTML item1 = new ReporteHTML();
                item1.ReporteETKN(Edatos);
                Process.Start(@"C:\Users\libni\Desktop\ReporteErrores.html");            
        }

        public void Ejecutar()
        {
            Funcionalidad fun = new Funcionalidad();                                                            
            fun.FunNivel(datos); // se utiliza para obtener el tamaño del formulario                   
        }

        public List<Lista> getToken()
        {
            return this.datos;
        }
    }
}
