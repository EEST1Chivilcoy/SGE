using PaginaEEST1.Data.Models.SchoolArea;
using PaginaEEST1.Data.Models.Categories;
using PaginaEEST1.Data;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using PaginaEEST1.Data.Enums;
using Microsoft.Identity.Client.Extensions.Msal;
using System.Runtime.Intrinsics.Arm;
using PaginaEEST1.Data.Models.Images;
using PaginaEEST1.Data.Models.PhysicalObjects;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace PaginaEEST1.Services
{
    public interface IAreaService
    {
        Task<Area?> GetArea(int ID);
        Task<Area?> SaveArea(Area area);
        Task<Area?> EditArea(Area newArea);
        Task DelArea(int ID);
        Task<List<AreaViewModel>> GetListAreas();
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
                    AreaCategory? category = await _context.Categories
                        .OfType<AreaCategory>()
                        .FirstOrDefaultAsync(v => v.Id == save.Category.Id);

                    if (category.Areas == null)
                        category.Areas = new();

                    category.Areas.Add(save);
                    save.Category = category;
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
        public async Task<Area?> EditArea(Area newArea)
        {
            Area? area = await _context.Areas.FindAsync(newArea.Id);
            if (area == null)
                throw new InvalidOperationException("No se encontró el Area.");
            try
            {
                area.Name = newArea.Name;
                area.Location = newArea.Location;
                area.AreaType = newArea.AreaType;
                area.AreaGuidance = newArea.AreaGuidance;

                if (newArea.Category != null){
                    AreaCategory? category = await _context.Categories
                        .OfType<AreaCategory>()
                        .FirstOrDefaultAsync(v => v.Id == newArea.Category.Id);

                    if (category.Areas == null)
                        category.Areas = new();

                    category.Areas.Add(area);
                    area.Category = category;
                }

                await _context.SaveChangesAsync();
                return area;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException("Error inesperado al editar el Area.");
            }
        }
        public async Task<Area?> GetArea(int ID)
        {
            Area? area = await _context.Areas.FindAsync(ID);
            
            if (area == null)
                throw new InvalidOperationException("No se encontró el salón.");

            return area;
        }
        public async Task<List<AreaViewModel>> GetListAreas()
        {
            List<Area> areas = await _context.Areas.Where(a => a != null).ToListAsync();
            return areas.Select(area => new AreaViewModel
            {
                Id = area.Id,
                Name = area.Name,
                CategoryId = area.Category != null ? area.Category.Id : 0,
                CategoryName = area.Category?.Name ?? "",
                ImageId = _context.Images.OfType<AreaImage_Area>()
                    .Where(i => i.AreaId == area.Id)
                    .SingleOrDefault()?.Id
            }).ToList();
        }
    }
}
