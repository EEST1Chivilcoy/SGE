using PaginaEEST1.Data.Models.Objetos_Fisicos;
using PaginaEEST1.Data;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Services
{
    public interface IOrdenadorService
    {
        Task<ComputadoraVM> GetComputadora(int ID);
    }
    public class OrdenadorService : IOrdenadorService
    {
        private readonly PaginaDbContext _context;
        public OrdenadorService(PaginaDbContext context)
        {
            _context = context;
        }
        public async Task<ComputadoraVM> GetComputadora(int ID)
        {
            Computadora? computadora = await _context.Computadoras.Where(i => i.OrdenadorId == ID).SingleOrDefaultAsync();
            if (computadora == null)
            {
                throw new InvalidOperationException("No se encontro la Computadora.");
            }

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
    }
}
