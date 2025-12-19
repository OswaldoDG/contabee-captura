using ContabeeApi.Modelos.Captura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TinyMessenger;

namespace ContabeeComunes.Fachada
{
    public class MensajeEjemplo: ITinyMessage
    {
        public string Dato { get; set; }
        public object Sender { get; set; }
    }

    public class DatosFiscalesMensaje : ITinyMessage
    {
        public PaginaTrabajoCapturaCloud Datos { get; set; }
        public object Sender { get; set; }
    }

    public class ImagenBlobMensaje : ITinyMessage
    {
        public byte[] Imagen { get; set; }
        public object Sender { get; set; }
    }

    public class OCRMensaje : ITinyMessage
    {
        public string TextoDetectado { get; set; }
        public object Sender { get; set; }
    }

    public class NombreBlobMensaje : ITinyMessage
    {
        public string NombreBlob { get; set; }
        public object Sender { get; set; }
    }

    public class DescargaDetectadaMensaje : ITinyMessage
    {
        public string RutaTemp {  get; set; }
        public string NombreArchivo { get; set; }
        public string Extension { get; set; }
        public object Sender {  get; set; }

    }

    public class SolicitarCompletarCapturaMensaje : ITinyMessage
    {
        public object Sender { get; set; }
    }

    public class MostrarCompletarCapturaDialogMensaje : ITinyMessage
    {
        public object Sender { get; set; }
    }

    public class CFDIMensaje : ITinyMessage 
    {
        public string UUID { get; set; }
        public DateTime? Fecha { get; set; }
        public object Sender { get; set; }
    }
}
