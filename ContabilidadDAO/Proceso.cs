using ContabilidadDTO;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDAO
{
    public class Proceso
    {

        DocumentoDAO objDocumentoDAO = new DocumentoDAO();


        public const string ruta = "https://www.nubefact.com/api/v1/94167341-b260-417d-8de7-4cf50dbdf29d";


        public const string token = "11eaac9483c141259114cdebad6cb4827e2421800bbb497b8c74ee4becb56f9f";
        string rutaCompleta = @"N:\TXT\20300166611-";
        public string sendTxt(String txtruta)
        {

            StreamReader sr = new StreamReader(txtruta); ///AQUI VA TU ARCHIVO TXT
            string txt_sin_codificar = sr.ReadToEnd();
            byte[] txt_bytes = Encoding.Default.GetBytes(txt_sin_codificar);
            string txt_en_utf_8 = Encoding.UTF8.GetString(txt_bytes);
            sr.Close();

            string json_de_respuesta = SendJson(ruta, txt_en_utf_8, token);


            return json_de_respuesta;
        }
        public string generarAnulacion(DocumentoElectronicoCab objCabecera, string motivo)
        {
            string root = @"N:\TXT";
            rutaCompleta = @"N:\TXT\20300166611-";
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string t1, t2;
            rutaCompleta = rutaCompleta + "RA-"+objCabecera.Serie + "-" + objCabecera.NumeroString+".txt";

            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }
            t1 = "operacion|generar_anulacion|\n" + "tipo_de_comprobante|" + objCabecera.TipoDocumento +
                "|\n" + "serie|" + objCabecera.Serie + "|\n" + "numero|" + objCabecera.Numero + "|\n" +
                "motivo|" + motivo + "|\n"   + "codigo_unico|" + objCabecera.Serie + "-" + objCabecera.NumeroString + "|" ;
            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {

                mylogs.WriteLine(t1);
               

                mylogs.Close();
            }
            return rutaCompleta;
        }
        public string generarConsulta(DocumentoElectronicoCab objCabecera)
        {
            string root = @"N:\TXT";
            rutaCompleta = @"N:\TXT\20300166611-";
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string t1, t2;
            rutaCompleta = rutaCompleta + "CONSULTA-" + objCabecera.Serie + "-" + objCabecera.NumeroString + ".txt";

            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }
            t1 = "operacion|consultar_comprobante|\n" + "tipo_de_comprobante|" + objCabecera.TipoDocumento +
                "|\n" + "serie|" + objCabecera.Serie + "|\n" + "numero|" + objCabecera.Numero + "|";
            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {

                mylogs.WriteLine(t1);


                mylogs.Close();
            }
            return rutaCompleta;
        }
        public string generarConsultaAnulacion(DocumentoElectronicoCab objCabecera)
        {
            string root = @"N:\TXT";
            rutaCompleta = @"N:\TXT\20300166611-";
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string t1, t2;
            rutaCompleta = rutaCompleta + "CONSULTA-ANULACION-" + objCabecera.Serie + "-" + objCabecera.NumeroString + ".txt";

            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }
            t1 = "operacion|consultar_anulacion|\n" + "tipo_de_comprobante|" + objCabecera.TipoDocumento +
                "|\n" + "serie|" + objCabecera.Serie + "|\n" + "numero|" + objCabecera.Numero + "|";
            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {

                mylogs.WriteLine(t1);
                mylogs.Close();
            }
            return rutaCompleta;
        }

        public string generarText(DocumentoElectronicoCab objCabecera, List<DocumentoElectronicoDet> objListDetalle)
        {
            string root = @"N:\TXT";
            rutaCompleta = @"N:\TXT\20300166611-";
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string t1, t2;
            rutaCompleta = rutaCompleta + objCabecera.Serie + "-" + objCabecera.NumeroString+".txt";

            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }
            t1 = "operacion|generar_comprobante|\n" + "tipo_de_comprobante|" + objCabecera.TipoDocumento +
                "|\n" + "serie|" + objCabecera.Serie + "|\n" + "numero|" + objCabecera.Numero + "|\n" +
                "sunat_transaction|" + objCabecera.Operacion + "|\n" + "cliente_tipo_de_documento|" +
               objCabecera.TipoDocumentoCliente + "|\n" + "cliente_numero_de_documento|" + objCabecera.NroDocCliente +
               "|\n" + "cliente_denominacion|" + objCabecera.RazonSocialCliente + "|\n" + "cliente_direccion|"
               + objCabecera.DireccionCliente + "|\n" + "cliente_email|"  + "|\n" +
               "cliente_email_1||\n" + "cliente_email_2||\n" + "fecha_de_emision|" + objCabecera.FechaEmision +
               "|\n" + "fecha_de_vencimiento|" + objCabecera.FechaVencimiento + "|\n" + "moneda|" +
               objCabecera.Moneda + "|\n" + "tipo_de_cambio|" + objCabecera.TipoCambio + "|\n" + "porcentaje_de_igv|"
               + objCabecera.Igv + "|\n" + "descuento_global|" + objCabecera.DescuentoGlobal + "|\n" +
               "total_descuento|" + objCabecera.TotalDescuento + "|\n" + "total_anticipo|" + objCabecera.TotalAnticipo
               + "|\n" + "total_gravada|" + objCabecera.TotalGravada  + "|\n" + "total_inafecta|" +
               objCabecera.TotalInafecta + "|\n" + "total_exonerada|" + objCabecera.TotalExonerada + "|\n" + "total_igv|"
               + objCabecera.TotalIgv + "|\n" + "total_gratuita|" + objCabecera.TotalGratuita + "|\n" + "total_otros_cargos|" +
               objCabecera.TotalOtrosCargos + "|\n" + "total|" + objCabecera.Total + "|\n" + "percepcion_tipo|" +
               objCabecera.TipoPercepcion + "|\n" + "percepcion_base_imponible|" + objCabecera.BaseImponiblePercepcion
               + "|\n" + "total_percepcion|" + objCabecera.TotalPercepcion + "|\n" + "total_incluido_percepcion|"
               + objCabecera.TotalIncluidoPercepcion + "|\n" + "detraccion|" + objCabecera.Detraccion + "|\n" +
               "observaciones|" + objCabecera.Observacion + "|\n" + "documento_que_se_modifica_tipo|" +
               objCabecera.TipoDocumentoRef + "|\n" + "documento_que_se_modifica_serie|" + objCabecera.SerieRef + "|\n"
               + "documento_que_se_modifica_numero|" + objCabecera.NumeroRef + "|\n" + "tipo_de_nota_de_credito|" +
               objCabecera.TipoNotaCredito + "|\n" + "tipo_de_nota_de_debito|" + objCabecera.TipoNotaDebito + "|\n" +
               "enviar_automaticamente_a_la_sunat|" + "true" + "|\n" + "enviar_automaticamente_al_cliente|" + "false"
               + "|\n" + "codigo_unico|" + objCabecera.Serie + "-" + objCabecera.NumeroString + "|\n" +
               "condiciones_de_pago|" + objCabecera.FormaPago + "|\n" + "medio_de_pago|" + objCabecera.MedioPago
               + "|\n" + "placa_vehiculo|" + objCabecera.PlacaVehiculo + "|\n" + "orden_compra_servicio|" +
              objCabecera.OrdenServicio + "|\n" + "tabla_personalizada_codigo||\n" + "formato_de_pdf||";
            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {

                mylogs.WriteLine(t1);
                for (int i = 0; i < objListDetalle.Count; i++)
                {
                    t2 = "item|" + objListDetalle[i].UnidadMedida + "|" + objListDetalle[i].ProductoCodigo + "|" + objListDetalle[i].ProductoDescripcion
                   + "|" + objListDetalle[i].Cantidad + "|" + objListDetalle[i].ValorUnitario + "|" + objListDetalle[i].PrecioUnitario
                   + "||" + objListDetalle[i].Subtotal + "|" + objListDetalle[i].TipoIgv + "|" + objListDetalle[i].TotalIgvLinea + "|" +
                    objListDetalle[i].TotalLinea + "|" + objListDetalle[i].Anticipo + "|||";
                    if (objListDetalle[i].UnidadMedida =="ZZ")
                    {
                        t2 = t2 + "73150000|";
                    }else
                    {
                        t2 = t2 + "43222903|";
                      
                    }
                    mylogs.WriteLine(t2);
                }

                mylogs.Close();
            }
            return rutaCompleta;
        }

        public static string SendJson(string ruta, string json, string token)
        {
            try
            {
                using (var client = new WebClient())
                {
                    /// ESPECIFICAMOS EL TIPO DE DOCUMENTO EN EL ENCABEZADO
                    client.Headers[HttpRequestHeader.ContentType] = "text/plain";
                    /// ASI COMO EL TOKEN UNICO
                    client.Headers[HttpRequestHeader.Authorization] = "Token token=" + token;
                    /// OBTENEMOS LA RESPUESTA
                    string respuesta = client.UploadString(ruta, "POST", json);
                    /// Y LA 'RETORNAMOS'
                    return respuesta;
                }
            }
            catch (WebException ex)
            {
                /// EN CASO EXISTA ALGUN ERROR, LO TOMAMOS
                var respuesta = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                /// Y LO 'RETORNAMOS'
                return respuesta;
            }
        }

        public String genearQr(String nombre, String codigo)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(codigo, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            string path = @"N:\QR\"+nombre+".jpg";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
           
            qrCodeImage.Save(path);
           //qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return path;
        }
    }
}
