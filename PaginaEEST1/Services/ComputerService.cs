using PaginaEEST1.Data.Models.Objetos_Fisicos;
using PaginaEEST1.Data;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using PaginaEEST1.Data.Enums;
using Microsoft.Identity.Client.Extensions.Msal;
using System.Runtime.Intrinsics.Arm;

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
                        typeStorage = computer.StorageType,
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
                        typeStorage = computer.StorageType,
                        Model = computer.Model,
                        IsAvailable = computer.IsAvailable
                    };
                    _context.Computers.Add(Save);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task DelComputer(int ID)
        {
            Computer computer = await _context.Computers.FindAsync(ID);
            if (computer == null)
                throw new InvalidOperationException("No se encontró la Computadora.");

            _context.Computers.Remove(computer);
            await _context.SaveChangesAsync();
        }

        public async Task<ComputerViewModel?> GetComputer(int ID)
        {
            Computer computer = await _context.Computers.FindAsync(ID);
            
            if (computer == null)
                throw new InvalidOperationException("No se encontró la Computadora.");

            return GetComputerVM(computer);
        }

        public async Task<Computer?> EditComputer(ComputerViewModel newpc)
        {
            Computer computer = await _context.Computers.FindAsync(newpc.ID);
            if (computer == null)
                throw new InvalidOperationException("No se encontró la Computadora.");

            try
            {
                computer.Status = newpc.Status;
                computer.DeviceName = newpc.DeviceName;
                computer.OperatingSystem = newpc.OperatingSystem;
                computer.Processor = newpc.Processor;
                computer.RAM = newpc.RAM;
                computer.Storage = newpc.Storage;
                computer.typeStorage = newpc.StorageType;
                if (computer is Desktop desktop)
                    desktop.Location = newpc.Location;
                if (computer is Netbook netbook)
                {
                    netbook.Model = newpc.Model;
                    netbook.IsAvailable = newpc.IsAvailable;
                }
                await _context.SaveChangesAsync();
                return computer;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException("Error inesperado al editar el Ordenador.");
            }
        }

        public async Task<List<ComputerViewModel?>> GetListComputerDevices()
        {
            List<Computer> computers = await _context.Computers.ToListAsync();

            return computers.Select(computer => new ComputerViewModel
            {
                ID = computer.Id,
                Type = computer.Type,
                Status = computer.Status,
                DeviceName = computer.DeviceName,
                OperatingSystem = computer.OperatingSystem,
                Logo = computer.Type == TypeComputer.Computadora ? "Images/Logo_Desktop.png" : "Images/Logo_Netbook.png"
            }).ToList();
        }
        private ComputerViewModel GetComputerVM(Computer computer){

            ComputerViewModel computerVM = new ComputerViewModel
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
            if (computer is Desktop desktop)
                computerVM.Location = desktop.Location;

            if (computer is Netbook netbook)
            {
                computerVM.Model = netbook.Model;
                computerVM.IsAvailable = netbook.IsAvailable;
            }

            return computerVM;
        }
    }
}
