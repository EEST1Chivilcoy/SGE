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
        Task<ComputadoraVM?> GetDesktop(int ID);
        Task<Computer> SaveComputer<T>(T ordenador) where T : Computer;
        Task<Desktop> SaveDesktop(ComputadoraVM computadora);

        Task<string> GenerarQR(int ID); // Posiblemente esta funcion no deberia pertenecer al Service
        Task<List<ComputadoraVM?>> GetListDesktopDevices();
    }

    public class OrdenadorService : IOrdenadorService
    {
        private readonly PaginaDbContext _context;
        public OrdenadorService(PaginaDbContext context)
        {
            _context = context;
        }
        public async Task<Desktop> SaveDesktop(ComputadoraVM computadora){
            
            Desktop Guardar = new Desktop(){
                Status = computadora.Estado,
                DeviceName = computadora.NombreOCodigoDispositivo,
                OperatingSystem = computadora.SistemaOperativo,
                Processor = computadora.Procesador,
                RAM = computadora.RAM,
                Storage = computadora.Almacenamiento,
                Location = computadora.Ubicacion
            };

            await SaveComputer(Guardar);
            return Guardar;
        }
        public async Task<string> GenerarQR(int ID)
        {
            return await Task.Run(() => {
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
        public async Task<ComputadoraVM?> GetDesktop(int ID)
        {
            var ordenador = await _context.Computers.Where(i => i.Id == ID).SingleOrDefaultAsync();

            if (ordenador == null)
            {
                throw new InvalidOperationException("No se encontro la Computadora.");
            }

            if (ordenador is Desktop computadora)
            {
                ComputadoraVM computadora_VM = new ComputadoraVM()
                {
                    Estado = computadora.Status,
                    NombreOCodigoDispositivo = computadora.DeviceName,
                    SistemaOperativo = computadora.OperatingSystem,
                    Procesador = computadora.Processor,
                    RAM = computadora.RAM,
                    Almacenamiento = computadora.Storage,
                    tipoAlmacenamiento = computadora.typeStorage,
                    Ubicacion = computadora.Location
                };
                return computadora_VM;
            }
            return null;
        }
        public async Task<List<ComputadoraVM?>> GetListDesktopDevices(){
            List<ComputadoraVM?> computadoras = new();

            foreach(Desktop i in await _context.Computers.ToListAsync())
            {
                if (i is Desktop)
                {
                    computadoras.Add(await GetDesktop(i.Id));
                }
            }
            return computadoras;
        }
    }
}
