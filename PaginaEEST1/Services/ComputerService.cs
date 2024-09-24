using PaginaEEST1.Data.Models.Objetos_Fisicos;
using PaginaEEST1.Data;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using QRCoder;
using PaginaEEST1.Data.Enums;
using AntDesign;
using System.Reflection;

namespace PaginaEEST1.Services
{
    public interface IComputerService
    {
        Task<ComputerViewModel?> GetComputer(int ID);
        Task<bool> SaveComputer(ComputerViewModel computer);
        Task<Computer?> EditComputer(ComputerViewModel NewPC);
        Task DelComputer(int ID);
        Task<List<ComputerViewModel?>> GetListComputerDevices();
    }

    public class ComputerService : IComputerService
    {
        private readonly PaginaDbContext _context;
        public ComputerService(PaginaDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveComputer(ComputerViewModel computer)
        {
            try
            {
                if (computer.Type == TypeComputer.Computadora)
                {
                    Desktop Save = new Desktop()
                    {
                        Status = computer.Status,
                        DeviceName = computer.DeviceName,
                        OperatingSystem = computer.OperatingSystem,
                        Processor = computer.Processor,
                        RAM = computer.RAM,
                        Storage = computer.Storage,
                        Location = computer.Location
                    };
                    _context.Computers.Add(Save);
                }
                else
                {
                    Netbook Save = new Netbook()
                    {
                        Status = computer.Status,
                        DeviceName = computer.DeviceName,
                        OperatingSystem = computer.OperatingSystem,
                        Processor = computer.Processor,
                        RAM = computer.RAM,
                        Storage = computer.Storage,
                        Model = computer.Model,
                        IsAvailable = computer.IsAvailable
                    };
                    _context.Computers.Add(Save);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task DelComputer(int ID)
        {
            Computer? Delete = await _context.Computers.Where(v => v.Id == ID).SingleOrDefaultAsync();
            if (Delete != null)
            {
                _context.Computers.Remove(Delete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("No se encontró la Computadora.");
            }
        }
        public async Task<ComputerViewModel?> GetComputer(int ID)
        {
            Computer? computer = await _context.Computers.Where(i => i.Id == ID).SingleOrDefaultAsync();

            if (computer == null)
            {
                throw new InvalidOperationException("No se encontró la Computadora.");
            }

            ComputerViewModel computerVM = new()
            {
                ID = computer.Id,
                Type = computer.Type,
                Status = computer.Status,
                DeviceName = computer.DeviceName,
                OperatingSystem = computer.OperatingSystem,
                Processor = computer.Processor,
                RAM = computer.RAM,
                Storage = computer.Storage,
                StorageType = computer.typeStorage,
                Logo = computer.Type == TypeComputer.Computadora ? "Images/Logo_Desktop.png" : "Images/Logo_Netbook.png"
            };

            if (computer.Type == TypeComputer.Computadora)
            {
                computerVM.Location = (computer as Desktop).Location;
            }
            else
            {
                computerVM.Model = (computer as Netbook).Model;
                computerVM.IsAvailable = (computer as Netbook).IsAvailable;
            }

            return computerVM;
        }
        public async Task<Computer?> EditComputer(ComputerViewModel newpc){
            Computer? edit = await _context.Computers.Where(v => v.Id == newpc.ID).SingleOrDefaultAsync();
            try{
                foreach(var i in newpc.GetType().GetProperties()){
                    var propNombre = i.Name;
                    var propValor = i.GetValue(newpc);
                    var editarProp = edit.GetType().GetProperty(propNombre);
                    if (editarProp != null && editarProp.CanWrite && propValor != null)
                    {
                        editarProp.SetValue(edit, propValor);
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch{
                throw new InvalidOperationException("Error inesperado al editar el Ordenador.");
            }
            return edit;
        }
        public async Task<List<ComputerViewModel?>> GetListComputerDevices()
        {
            List<ComputerViewModel?> devices = new();

            foreach (Computer i in await _context.Computers.ToListAsync())
            {
                devices.Add(await GetComputer(i.Id));
            }
            return devices;
        }
    }
}
