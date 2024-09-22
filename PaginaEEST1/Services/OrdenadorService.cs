using PaginaEEST1.Data.Models.Objetos_Fisicos;
using PaginaEEST1.Data;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using PaginaEEST1.Data.Enums;
using AntDesign;

namespace PaginaEEST1.Services
{
    public interface IOrdenadorService
    {
        Task<ComputadoraVM?> GetDesktop(int ID);
        Task<Ordenador> SaveComputer<T>(T ordenador) where T : Ordenador;
    }

    public class OrdenadorService : IOrdenadorService
    {
        private readonly PaginaDbContext _context;
        public OrdenadorService(PaginaDbContext context)
        {
            _context = context;
        }
        public async Task<Ordenador> SaveComputer<T>(T ordenador) where T : Ordenador
        {
            try
            {
                _context.Ordenadores.Add(ordenador);
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
            var ordenador = await _context.Ordenadores.Where(i => i.OrdenadorId == ID).SingleOrDefaultAsync();

            if (ordenador == null)
            {
                throw new InvalidOperationException("No se encontro la Computadora.");
            }

            if (ordenador is Computadora computadora)
            {
                ComputadoraVM computadora_VM = new ComputadoraVM()
                {
                    Estado = computadora.Estado,
                    Nombre = computadora.Nombre,
                    Sistema_Operativo = computadora.Sistema_Operativo,
                    Procesador = computadora.Procesador,
                    RAM = computadora.RAM,
                    Almacenamiento = computadora.Almacenamiento,
                    Ubicacion = computadora.Ubicacion
                };
                return computadora_VM;
            }
            return null;
        }
    }
}
