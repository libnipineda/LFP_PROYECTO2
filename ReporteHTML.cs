using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LFP_Proyecto2
{
    class ReporteHTML
    {
        string datos = "";
        string Edatos = "";

        public void ReporteTKN(List<Lista> arreglo)
        {
            if (arreglo.Count != 0)
            {
                for (int i = 0; i < arreglo.Count; i++)
                {
                    datos = datos + "<tr>"
                    + "<td><strong>" + arreglo[i].numero +"</strong></td>"
                    + "<td><strong>" + arreglo[i].lexema + "</strong></td>"
                    + "<td><strong>" + arreglo[i].idtkn + "</strong></td>"
                    + "<td><strong>" + arreglo[i].tkn + "</strong></td>"
                    + "<td><strong>" + arreglo[i].columna +"</strong></td>"
                    + "<td><strong>" + arreglo[i].fila +"</strong></td>"                    
                    + "</tr>";
                }
            }

            string[] texto = { "<html>"
                 ,"<head>"
                        ,"<title> Listado de tokens </title>"
                        ,"</head>"
                ,"<body>"
                ,"<h1> LFP PROYECTO No.2 LISTADO DE TOKENS </h1>"
                ,"<table border>"
                ,"<tr>"
                ,"<td><strong>No</strong></td>"
                ,"<td><strong>Lexema</strong></td>"
                ,"<td><strong>ID Token</strong></td>"
                ,"<td><strong>Token</strong></td>"
                ,"<td><strong>Columna</strong></td>"
                ,"<td><strong>Fila</strong></td>"                                                
                ,"</tr>"
                ,datos
                ,"</table>"
                ,"</body>"
                ,"</html>"
            };

            System.IO.File.WriteAllLines(@"C:\Users\libni\Desktop\ReporteToken.html", texto);
        }

        public void ReporteETKN(List<Elista> cadena)
        {
            if (cadena.Count != 0)
            {
                for (int i = 0; i < cadena.Count; i++)
                {
                    Edatos = Edatos + "<tr>"
                    + "<td><strong>" + cadena[i].Enum + "</strong></td>"
                    + "<td><strong>" + cadena[i].Elex + "</strong></td>"
                    + "<td><strong>" + cadena[i].Etkn + "</strong></td>"
                    + "<td><strong>" + cadena[i].Ecol + "</strong></td>"
                    + "<td><strong>" + cadena[i].Efi + "</strong></td>"                                        
                    + "</tr>";
                }
            }

            string[] text = { "<html>"
                        ,"<head>"
                        ,"<title> Listado de Errores </title>"
                        ,"</head>"
                        ,"<body>"
                        ,"<h1> LFP PROYECTO No.2 Listado de Errores</h1>"
                        ,"<table border>"
                        ,"<tr>"
                        ,"<td><strong>No</strong></td>"
                        ,"<td><strong>Caracter</strong></td>"
                        ,"<td><strong>Descripcion</strong></td>"
                        ,"<td><strong>Columna</strong></td>"
                        ,"<td><strong>Fila</strong></td>"                        
                        ,"</tr>"
                        ,Edatos
                        ,"</table>"
                        ,"</body>"
                        ,"</html>"
            };

            System.IO.File.WriteAllLines(@"C:\Users\libni\Desktop\ReporteErrores.html", text);
        }
    }
}
