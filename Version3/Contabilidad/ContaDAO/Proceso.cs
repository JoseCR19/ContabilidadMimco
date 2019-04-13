
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ContaDTO;

namespace ContaDAO
{
    public class Proceso
    {
        string rutaCompleta = "";
        public string generarTxtAsiento(String TipoAsiento, List<String> letras , String Fecha)
        {

            string root = @"G:\FACTURACION\TXT";
            rutaCompleta = @"G:\FACTURACION\TXT\" + "LE" + "20300166611" + DateTime.Now.ToString("yyyy") + Fecha + "00" + TipoAsiento + "00" + "11" + "1" + "1";
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            rutaCompleta = rutaCompleta + ".txt";

            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }

            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {
                for (int i = 0; i < letras.Count; i++)
                {
                    mylogs.WriteLine(letras[i]);
                }
                mylogs.Close();
            }
            return rutaCompleta;
        }
        //se crea funciones separadas para la exportación de los txt q se enviaran a sunat funcion para generar asiento soles 
        public string generarTxtAsientoSoles(String TipoAsiento, List<String> letras, String Fecha)
        {
            string root = @"G:\FACTURACION\TXT";
            rutaCompleta = @"G:\FACTURACION\TXT\" + "LE" + "20300166611" + DateTime.Now.ToString("yyyy") + Fecha + "00" + TipoAsiento + "00" + "11" + "1" + "1";
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            rutaCompleta = rutaCompleta + ".txt";

            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }

            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {
                for (int i = 0; i < letras.Count; i++)
                {
                    mylogs.WriteLine(letras[i]);
                }
                mylogs.Close();
            }
            return rutaCompleta;
        }
        //se crea funciones separadas para la exportación de los txt q se enviaran a sunat funcion para generar asiento dolares 
        public string generarTxtAsientoDolares(String TipoAsiento, List<String> letras, String Fecha)
        {
            string root = @"G:\FACTURACION\TXT";
            rutaCompleta = @"G:\FACTURACION\TXT\" + "LE" + "20300166611" + DateTime.Now.ToString("yyyy") + Fecha + "00" + TipoAsiento + "00" + "11" + "2" + "1";
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            rutaCompleta = rutaCompleta + ".txt";

            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }

            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {
                for (int i = 0; i < letras.Count; i++)
                {
                    mylogs.WriteLine(letras[i]);
                }
                mylogs.Close();
            }
            return rutaCompleta;
        }
        public string generarTxtAsientoCompraSoles(String TipoAsiento, List<String> letras, String Fecha)
        {
            string root = @"G:\FACTURACION\TXT";
            rutaCompleta = @"G:\FACTURACION\TXT\" + "LE" + "20300166611" + DateTime.Now.ToString("yyyy")+Fecha + "00" + TipoAsiento + "00" + "11" + "1" + "1";
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            rutaCompleta = rutaCompleta + ".txt";

            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }

            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {
                for (int i = 0; i < letras.Count; i++)
                {
                    mylogs.WriteLine(letras[i]);
                }
                mylogs.Close();
            }
            return rutaCompleta;

        }
        public string generarTxtAsientoCompraDolares(String TipoAsiento, List<String> letras,String Fecha)
        {
            string root = @"G:\FACTURACION\TXT";
            rutaCompleta = @"G:\FACTURACION\TXT\" + "LE" + "20300166611" + DateTime.Now.ToString("yyyy")+Fecha + "00" + TipoAsiento + "00" + "11" + "2" + "1";
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            rutaCompleta = rutaCompleta + ".txt";

            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }

            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {
                for (int i = 0; i < letras.Count; i++)
                {
                    mylogs.WriteLine(letras[i]);
                }
                mylogs.Close();
            }
            return rutaCompleta;

        }
    }
}
