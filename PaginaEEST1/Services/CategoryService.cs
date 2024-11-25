using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Categories;

namespace PaginaEEST1.Services
{
    public interface ICategoryService
    {
        Task<List<string>> GetListCategories(TypeCategory typeCategory);
        Task<Category?> SaveCategory(TypeCategory typeCategory, string name);
    }

    public class CategoryService : ICategoryService
    {
        private readonly PaginaDbContext _context;

        public CategoryService(PaginaDbContext context)
        {
            _context = context;
        }
        public async Task<List<string>> GetListCategories(TypeCategory typeCategory)
        {

            if (typeCategory == TypeCategory.AreaCategory)
                return await _context.Categories.AsNoTracking().OfType<AreaCategory>().Where(c => c.Name != null).Select(c => c.Name).Distinct().ToListAsync();

            if(typeCategory == TypeCategory.ItemCategory)
                return await _context.Categories.AsNoTracking().OfType<ItemCategory>().Where(c => c.Name != null).Select(c => c.Name).Distinct().ToListAsync();

            return null;
        }
        public async Task<Category?> SaveCategory(TypeCategory typeCategory, string name)
        {
            // Eliminar espacios al inicio y al final
            name = name.Trim();
        
            // Validar que el nombre no sea vacío o solo contenga espacios
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                return null;
        
            // Validar que no contenga caracteres especiales (solo letras, números y espacios)
            if (!System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z0-9\s]+$"))
                return null;
        
            // Buscar si ya existe una categoría con el mismo nombre (ignorar espacios y mayúsculas/minúsculas)
            Category? exists = _context.Categories
                .Where(c => c.Name.Replace(" ", "").ToLower() == name.Replace(" ", "").ToLower())
                .SingleOrDefault();
            if (exists != null || string.IsNullOrEmpty(name))
                return exists;
            
            Category? category = null;
            if (typeCategory == TypeCategory.AreaCategory){
                AreaCategory save = new(){
                    Type = TypeCategory.AreaCategory,
                    Name = name
                };
                category = save;
                _context.Categories.Add(save);
            }
            if (typeCategory == TypeCategory.ItemCategory){
                ItemCategory save = new(){
                    Type = TypeCategory.ItemCategory,
                    Name = name
                };
                category = save;
                _context.Categories.Add(save);
            }
            await _context.SaveChangesAsync();
            return _context.Categories.Where(c => c == category).SingleOrDefault();
        }
    }
}
