using PaginaEEST1.Data.Models.Objetos_Fisicos;
using PaginaEEST1.Data;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using QRCoder;
using PaginaEEST1.Data.Enums;
using AntDesign;

namespace PaginaEEST1.Services
{
    public interface IOrdenadorService
    {
        Task<DesktopViewModel?> GetDesktop(int ID);
        Task<Computer> SaveComputer<T>(T ordenador) where T : Computer;
        Task<Desktop> SaveDesktop(DesktopViewModel computadora);

        Task<string> GenerarQR(int ID); // Posiblemente esta funcion no deberia pertenecer al Service
        Task<List<DesktopViewModel?>> GetListDesktopDevices();
    }

    public class OrdenadorService : IOrdenadorService
    {
        private readonly PaginaDbContext _context;
        public OrdenadorService(PaginaDbContext context)
        {
            _context = context;
        }
        public async Task<Desktop> SaveDesktop(DesktopViewModel computadora)
        {

            Desktop Guardar = new Desktop()
            {
                Status = computadora.Status,
                DeviceName = computadora.DeviceName,
                OperatingSystem = computadora.OperatingSystem,
                Processor = computadora.Processor,
                RAM = computadora.RAM,
                Storage = computadora.Storage,
                Location = computadora.Location
            };

            await SaveComputer(Guardar);
            return Guardar;
        }
        public async Task<string> GenerarQR(int ID)
        {
            return await Task.Run(() =>
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                // Tal vez haya que referirse a la pagina de otra forma en vez de poner la url completa:
                QRCodeData qrCodeData = qrGenerator.CreateQrCode($"https://paginaeest1.azurewebsites.net/Computadora_VistaQR_{ID}", QRCodeGenerator.ECCLevel.Q);
                PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);
                return $"data:image/png;base64,{Convert.ToBase64String(qrCodeAsPngByteArr)}";
            });
        }
        // Cree la funcion GuardarComputadora ya que utilizo el ViewModel de Computadora
        public async Task<Computer> SaveComputer<T>(T ordenador) where T : Computer
        {
            try
            {
                _context.Computers.Add(ordenador);
                await _context.SaveChangesAsync();
                return ordenador;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"ERROR: Error al cargar el Ordenador. {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: Ocurrió un error inesperado. {ex.Message}");
                throw;
            }
        }
        public async Task<DesktopViewModel?> GetDesktop(int ID)
        {
            var desktopVM = await _context.Computers
                .OfType<Desktop>()
                .Where(i => i.Id == ID)
                .Select(computadora => new DesktopViewModel
                {
                    ID = computadora.Id,
                    Status = computadora.Status,
                    DeviceName = computadora.DeviceName,
                    OperatingSystem = computadora.OperatingSystem,
                    Processor = computadora.Processor,
                    RAM = computadora.RAM,
                    Storage = computadora.Storage,
                    StorageType = computadora.typeStorage,
                    Location = computadora.Location
                })
                .SingleOrDefaultAsync();

            if (desktopVM == null)
            {
                throw new InvalidOperationException("No se encontró la Computadora.");
            }

            return desktopVM;
        }

        public async Task<List<DesktopViewModel?>> GetListDesktopDevices()
        {
            List<DesktopViewModel?> Desktops = new();

            foreach (Desktop i in await _context.Computers.ToListAsync())
            {
                if (i is Desktop)
                {
                    Desktops.Add(await GetDesktop(i.Id));
                }
            }
            return Desktops;
        }
    }
}
