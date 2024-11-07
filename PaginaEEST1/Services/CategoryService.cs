using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Categories;

namespace PaginaEEST1.Services
{
    public interface ICategoryService
    {
        Task<List<string>> GetListCategories(TypeCategory typeCategory);
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
    }
}
