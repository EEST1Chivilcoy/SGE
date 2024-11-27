using PaginaEEST1.Data.Models.PhysicalObjects;
using PaginaEEST1.Data;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using PaginaEEST1.Data.Enums;
using System.Reflection;
using PaginaEEST1.Data.Models.Images;
using PaginaEEST1.Data.Models.Categories;
using PaginaEEST1.Data.Models.SchoolArea;
using Microsoft.AspNetCore.Components.Forms;
using PaginaEEST1.Data.Models.Personal;

namespace PaginaEEST1.Services
{
    public interface IImageService
    {
        Task<bool> SaveImage(AbstractImage image);
    }

    public class ImageService : IImageService
    {
        private readonly PaginaDbContext _context;
        public ImageService(PaginaDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveImage(AbstractImage image)
        {
            try
            {
                // Manejar las relaciones según el tipo de imagen
                switch (image)
                {
                    case AreaImage_Area areaImage:
                        var area = await _context.Areas.FindAsync(areaImage.AreaId);
                        if (area != null)
                        {
                            areaImage.Area = area;
                            area.ImageArea = areaImage;
                        }
                        break;

                    case ItemImage_Item itemImage:
                        var item = await _context.Items.FindAsync(itemImage.ItemId);
                        if (item != null)
                        {
                            itemImage.Item = item;
                            item.ItemImage = itemImage;
                        }
                        break;

                    case ProfileImage_Person profileImage:
                        var person = await _context.People.FindAsync(profileImage.PersonId);
                        if (person != null)
                        {
                            profileImage.Person = person;
                            person.ProfileImage = profileImage;
                        }
                        break;
                }

                // Agregar y guardar la imagen
                _context.Images.Add(image);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException("Error inesperado al guardar una Imagen.");
            }
        }
    }
}
