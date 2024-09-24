using PaginaEEST1.Data.Models.Objetos_Fisicos;
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
    }
}
