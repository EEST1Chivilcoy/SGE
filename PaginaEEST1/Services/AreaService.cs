﻿using PaginaEEST1.Data.Models.SchoolArea;
using PaginaEEST1.Data.Models.Categories;
using PaginaEEST1.Data;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using PaginaEEST1.Data.Enums;
using Microsoft.Identity.Client.Extensions.Msal;
using System.Runtime.Intrinsics.Arm;

namespace PaginaEEST1.Services
{
    public interface IAreaService
    {
        Task<Area?> GetArea(int ID);
        Task<Area?> SaveArea(Area area);
        Task DelArea(int ID);
        Task<List<AreaViewModel?>> GetListAreas();

        // Funcion GetListCategories implementada temporalmente
        // Posiblemente se deba implementar dentro de un posible futuro servicio especifico para categorias
        Task<List<AreaCategory?>> GetListCategories();
    }

    public class AreaService : IAreaService
    {
        private readonly PaginaDbContext _context;

        public AreaService(PaginaDbContext context)
        {
            _context = context;
        }

        public async Task<Area?> SaveArea(Area save)
        {
            try
            {
                if (save.Category != null){
                    save.Category = await _context.Categories
                        .OfType<AreaCategory>()
                        .FirstOrDefaultAsync(v => v.Id == save.Category.Id);
                }
                _context.Areas.Add(save);
                await _context.SaveChangesAsync();

                return _context.Areas.Where(a => a == save).SingleOrDefault();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task DelArea(int ID)
        {
            Area? area = await _context.Areas.FindAsync(ID);
            if (area == null)
                throw new InvalidOperationException("No se encontró el salón.");

            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
        }

        public async Task<Area?> GetArea(int ID)
        {
            Area? area = await _context.Areas.FindAsync(ID);
            
            if (area == null)
                throw new InvalidOperationException("No se encontró el salón.");

            return area;
        }
        public async Task<List<AreaViewModel?>> GetListAreas()
        {
            List<Area> areas = await _context.Areas.ToListAsync();

            return areas.Select(area => new AreaViewModel
            {
                Id = area.Id,
                Name = area.Name,
                CategoryId = area.Category?.Id ?? 0,
                CategoryName = area.Category?.Name ?? "",
                ImageId = area.ImageArea?.Id ?? 0
            }).ToList();
        }
        public async Task<List<AreaCategory?>> GetListCategories()
        {
            // Funcion implementada temporalmente hasta que se agregue posiblemente el servicio propio de categorías
            List<AreaCategory> areas = await _context.Categories
                .OfType<AreaCategory>()
                .ToListAsync();

            return areas;
        }
    }
}
