using PaginaEEST1.Data.Models.PhysicalObjects;
using PaginaEEST1.Data;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using QRCoder;
using PaginaEEST1.Data.Enums;
using AntDesign;
using System.Reflection;

namespace PaginaEEST1.Services
{
    public interface IQRService
    {
        Task<string> LoadQR(string link);
        string GetQRCodeUrl(string link);
    }

    public class QRService : IQRService
    {
        private readonly PaginaDbContext _context;
        public QRService(PaginaDbContext context)
        {
            _context = context;
        }

        public async Task<string> LoadQR(string link)
        {
            return await Task.Run(() =>
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(link, QRCodeGenerator.ECCLevel.Q);
                PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);
                return $"data:image/png;base64,{Convert.ToBase64String(qrCodeAsPngByteArr)}";
            });
        }

        public string GetQRCodeUrl(string link)
        {
            // Reemplazar el espacio en blanco y otros caracteres especiales por su equivalente en URL
            var encodedLink = Uri.EscapeDataString(link);

            // Usamos la API de GoQR.me para obtener la URL del QR
            var qrApiUrl = $"https://api.qrserver.com/v1/create-qr-code/?data={encodedLink}&size=200x200";

            return qrApiUrl;
        }
    }
}
