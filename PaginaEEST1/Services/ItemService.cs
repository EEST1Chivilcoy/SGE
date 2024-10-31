﻿using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.PhysicalObjects;
using PaginaEEST1.Data.ViewModels;
using System.Text;

namespace PaginaEEST1.Services
{
    public interface IItemService
    {
        Task<List<ItemViewModel?>> GetListItems(EducationalGuidance Owner);
        Task<bool> SaveItem(Item Item);
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
                throw new InvalidOperationException("No se encontró la Computadora.");

            _context.Items.Remove(Item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ItemViewModel?>> GetListItems(EducationalGuidance Owner)
        {
            // Obtener todos los items de la base de datos
            List<Item> items = await _context.Items.ToListAsync();

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
                Category = item.Category?.Name ?? "Sin categoría", // Manejo de categoría nula
                Code = item.Code
            }).ToList();
        }

        public async Task<bool> SaveItem(Item save)
        {
            try
            {
                _context.Items.Add(save);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
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
