using PaginaEEST1.Data.Models.PhysicalObjects;
using PaginaEEST1.Data;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using QRCoder;
using PaginaEEST1.Data.Enums;
using System.Reflection;
using PaginaEEST1.Data.Models.Images;
using PaginaEEST1.Data.Models.Categories;
using PaginaEEST1.Data.Models.SchoolArea;
using Microsoft.AspNetCore.Components.Forms;
using PaginaEEST1.Helpers;
using PaginaEEST1.Data.Models.Personal;

namespace PaginaEEST1.Services
{
    public interface IImageService
    {
        Task<bool> SaveImage(AbstractImage image, InputFileChangeEventArgs file);
        Task<AbstractImage> GetImageById(int ID);
        Task<AbstractImage?> GetImageByType(TypeImage type, string ReferenceId);
    }

    public class ImageService : IImageService
    {
        private readonly PaginaDbContext _context;
        public ImageService(PaginaDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveImage(AbstractImage image, InputFileChangeEventArgs file)
        {
            try
            {
                if (image is AreaImage_Area AreaImage)
                {
                    Area? area = await _context.Areas.FindAsync(AreaImage.AreaId);
                    if (area != null){
                        AreaImage.Area = area;
                        area.ImageArea = AreaImage;
                    }
                }
                else if (image is ItemImage_Item ItemImage)
                {
                    Item? item = await _context.Items.FindAsync(ItemImage.ItemId);
                    if (item != null){
                        ItemImage.Item = item;
                        item.ItemImage = ItemImage;
                    }
                }
                else if (image is ProfileImage_Person ProfileImage)
                {
                    Person? person = await _context.People.FindAsync(ProfileImage.PersonId);
                    if (person != null){
                        ProfileImage.Person = person;
                        person.ProfileImage = ProfileImage;
                    }
                }
                image.Base64Image = await ImageUploadHelper.StreamToBase64(file) ?? "";
                _context.Images.Add(image);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<AbstractImage> GetImageById(int ID)
        {
            AbstractImage? image = await _context.Images.FindAsync(ID);
            if (image == null)
                throw new InvalidOperationException("No se encontró la Computadora.");

            return image;
        }
        public async Task<AbstractImage?> GetImageByType(TypeImage type, string ReferenceId)
        {
            try
            {
                switch (type)
                {
                    case (TypeImage.AreaImage):
                        AreaImage_Area? imageArea = await _context.Images.OfType<AreaImage_Area>()
                        .Where(i => i.AreaId == Convert.ToInt32(ReferenceId))
                        .SingleOrDefaultAsync();

                        return imageArea;

                    case (TypeImage.ItemImage):
                        ItemImage_Item? imageItem = await _context.Images.OfType<ItemImage_Item>()
                        .Where(i => i.ItemId == Convert.ToInt32(ReferenceId))
                        .SingleOrDefaultAsync();

                        return imageItem;

                    case (TypeImage.ProfileImage):
                        return null;

                    default:
                        return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
