using PaginaEEST1.Data.Models.PhysicalObjects;
using PaginaEEST1.Data;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using PaginaEEST1.Data.Enums;
using AntDesign;
using System.Reflection;

namespace PaginaEEST1.Services
{
    public interface IQRService
    {
        string GenerateQRWithExternalAPI(string link, int size = 200);
    }

    public class QRService : IQRService
    {
        public string GenerateQRWithExternalAPI(string link, int size = 200)
        {
            // Reemplazar el espacio en blanco y otros caracteres especiales por su equivalente en URL
            var encodedLink = Uri.EscapeDataString(link);

            // Se utiliza la API de GoQR.me para obtener la URL del QR
            var qrApiUrl = $"https://api.qrserver.com/v1/create-qr-code/?data={encodedLink}&size={size}x{size}";

            return qrApiUrl;
        }
    }
}
