using PaginaEEST1.Data.Models.PhysicalObjects;
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
        Task<Computer?> GetComputer(int ID);
        Task<bool> SaveComputer(Computer computer);
        Task<Computer?> EditComputer(Computer NewPC);
        Task DelComputer(int ID);
        Task<List<ComputerViewModel>> GetListComputerDevices(TypeComputer? computerType = null);
    }

    public class ComputerService : IComputerService
    {
        private readonly PaginaDbContext _context;

        public ComputerService(PaginaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveComputer(Computer save)
        {
            try
            {
                if (save is Desktop desktop && desktop.LocationId != 0)
                {
                    desktop.Location = await _context.Areas.FindAsync(desktop.LocationId);
                }
                _context.Computers.Add(save);
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
            Computer? computer = await _context.Computers.FindAsync(ID);
            if (computer == null)
                throw new InvalidOperationException("No se encontró la Computadora.");

            _context.Computers.Remove(computer);
            await _context.SaveChangesAsync();
        }

        public async Task<Computer?> GetComputer(int ID)
        {
            Computer? computer = await _context.Computers.FindAsync(ID);

            if (computer is Desktop)
            {
                return _context.Computers
                    .OfType<Desktop>()
                    .Include(c => c.Location)
                    .Where(c => c == computer)
                    .SingleOrDefault();
            }

            return computer;
        }

        public async Task<Computer?> EditComputer(Computer newpc)
        {
            Computer? computer = await _context.Computers.FindAsync(newpc.Id);
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
                computer.typeStorage = newpc.typeStorage;
                if (computer is Desktop desktop && newpc is Desktop newdesktop)
                { 
                    desktop.LocationId = newdesktop.LocationId;
                    desktop.Location = await _context.Areas.FindAsync(newdesktop.LocationId);
                }
                if (computer is Netbook netbook && newpc is Netbook newnetbook)
                {
                    netbook.Model = newnetbook.Model;
                    netbook.IsAvailable = newnetbook.IsAvailable;
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

        public async Task<List<ComputerViewModel>> GetListComputerDevices(TypeComputer? computerType = null)
        {
            List<Computer> computers = await _context.Computers.Where(c => c != null).ToListAsync();

            switch(computerType)
            {
                case(TypeComputer.Netbook):
                    return computers.Where(computer => computer is Netbook).Select(computer => GetComputerVM(computer)).ToList();
                case(TypeComputer.Computer):
                    return computers.Where(computer => computer is Computer).Select(computer => GetComputerVM(computer)).ToList();
                default:
                    return computers.Select(computer => GetComputerVM(computer)).ToList();    
            }
        }
        private ComputerViewModel GetComputerVM(Computer computer){

            ComputerViewModel computerVM = new ComputerViewModel
            {
                ID = computer.Id,
                Type = computer.Type,
                Status = computer.Status,
                DeviceName = computer.DeviceName,
                OperatingSystem = computer.OperatingSystem,
                Logo = computer.Type == TypeComputer.Computer ? "Images/Logo_Desktop.png" : "Images/Logo_Netbook.png"
            };
            return computerVM;
        }
    }
}
