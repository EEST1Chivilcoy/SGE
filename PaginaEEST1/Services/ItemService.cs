using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Categories;
using PaginaEEST1.Data.Models.PhysicalObjects;
using PaginaEEST1.Data.ViewModels;
using System.Text;

namespace PaginaEEST1.Services
{
    public interface IItemService
    {
        Task<List<ItemViewModel?>> GetListItems(EducationalGuidance Owner);
        Task<Item?> SaveItem(Item Item);
        Task<ItemViewModel?> GetItemViewModel(int Id);
        Task DeleteItem(int ID);
        Task<string> GenerateUniqueCodeAsync();
    }

    public class ItemService : IItemService
    {
        private readonly PaginaDbContext _context;

        public ItemService(PaginaDbContext context)
        {
            _context = context;
        }

        public async Task DeleteItem(int ID)
        {
            var Item = await _context.Items.FindAsync(ID);
            if (Item == null)
                throw new InvalidOperationException("No se encontró el Objeto.");

            _context.Items.Remove(Item);
            await _context.SaveChangesAsync();
        }

        public async Task<ItemViewModel?> GetItemViewModel(int ID)
        {
            // Obtener el item desde la base de datos con la categoría incluida.
            Item? SelItem = await _context.Items
                .Where(i => i.Id == ID)
                .Include(i => i.Category)
                .Include(i => i.ItemImage)
                .SingleOrDefaultAsync();

            // Verificar si el item existe
            if (SelItem == null)
                throw new InvalidOperationException("No se encontró el Objeto.");

            // Mapear el objeto Item a ItemViewModel
            return new ItemViewModel
            {
                ID = SelItem.Id,
                Type = SelItem.Type,
                Name = SelItem.Name,
                Description = SelItem.Description,
                Category = SelItem.Category?.Name ?? "Sin Categoría",  // Usar la propiedad Category cargada con Include
                Code = SelItem.Code,
                IdImageItem = SelItem.ItemImage?.Id
            };
        }

        public async Task<List<ItemViewModel?>> GetListItems(EducationalGuidance Owner)
        {
            // Obtener todos los items de la base de datos
            List<Item> items = await _context.Items.Include(item => item.ItemImage).ToListAsync();

            // Filtrar los elementos basándose en el valor del enum y el propietario
            var filteredItems = items
                .Where(item => item.Owner == Owner && Owner != EducationalGuidance.None);

            // Mapear los elementos filtrados a ItemViewModel
            return filteredItems.Select(item => new ItemViewModel
            {
                ID = item.Id,
                Type = item.Type,
                Name = item.Name,
                Description = item.Description,
                Category = _context.Categories.AsNoTracking()
                .OfType<ItemCategory>()
                .Where(c => c.Items.Any(a => a.Id == item.Id)).SingleOrDefault()?.Name ?? "Sin Categoría",
                Code = item.Code,
                IdImageItem = item.ItemImage?.Id
            }).ToList();
        }

        public async Task<Item?> SaveItem(Item save)
        {
            try
            {
                _context.Items.Add(save);
                await _context.SaveChangesAsync();

                return _context.Items.Where(a => a == save).SingleOrDefault();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<string> GenerateUniqueCodeAsync()
        {
            string code;
            bool isUnique;

            do
            {
                code = GenerateRandomCode();
                isUnique = !await _context.Items.AnyAsync(e => e.Code == code);
            }
            while (!isUnique);

            return code;
        }

        private string GenerateRandomCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var code = new StringBuilder(4);

            for (int i = 0; i < 4; i++)
            {
                code.Append(chars[random.Next(chars.Length)]);
            }

            return code.ToString();
        }
    }
}
