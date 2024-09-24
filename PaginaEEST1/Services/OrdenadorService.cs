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
        Task<DispositivoComputacional> SaveComputer<T>(T ordenador) where T : DispositivoComputacional;
        Task<ComputadoraDeEscritorio> GuardarComputadora(ComputadoraVM computadora);

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
        public async Task<ComputadoraDeEscritorio> GuardarComputadora(ComputadoraVM computadora){
            
            ComputadoraDeEscritorio Guardar = new ComputadoraDeEscritorio(){
                Estado = computadora.Estado,
                NombreOCodigoDispositivo = computadora.NombreOCodigoDispositivo,
                SistemaOperativo = computadora.SistemaOperativo,
                Procesador = computadora.Procesador,
                RAM = computadora.RAM,
                Almacenamiento = computadora.Almacenamiento,
                Ubicacion = computadora.Ubicacion
            };
            _context.DispositivosComputacionales.Add(Guardar as DispositivoComputacional);
            await _context.SaveChangesAsync();
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
        public async Task<DispositivoComputacional> SaveComputer<T>(T ordenador) where T : DispositivoComputacional
        {
            try
            {
                _context.DispositivosComputacionales.Add(ordenador);
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
            var ordenador = await _context.DispositivosComputacionales.Where(i => i.Id == ID).SingleOrDefaultAsync();

            if (ordenador == null)
            {
                throw new InvalidOperationException("No se encontro la Computadora.");
            }

            if (ordenador is ComputadoraDeEscritorio computadora)
            {
                ComputadoraVM computadora_VM = new ComputadoraVM()
                {
                    ID = computadora.Id,
                    Estado = computadora.Estado,
                    NombreOCodigoDispositivo = computadora.NombreOCodigoDispositivo,
                    SistemaOperativo = computadora.SistemaOperativo,
                    Procesador = computadora.Procesador,
                    RAM = computadora.RAM,
                    Almacenamiento = computadora.Almacenamiento,
                    tipoAlmacenamiento = computadora.tipoAlmacenamiento,
                    Ubicacion = computadora.Ubicacion
                };
                return computadora_VM;
            }
            return null;
        }
        public async Task<List<ComputadoraVM?>> GetListDesktopDevices(){
            List<ComputadoraVM?> computadoras = new();

            foreach(ComputadoraDeEscritorio i in await _context.DispositivosComputacionales.ToListAsync())
            {
                if (i is ComputadoraDeEscritorio)
                {
                    computadoras.Add(await GetDesktop(i.Id));
                }
            }
            return computadoras;
        }
    }
}
