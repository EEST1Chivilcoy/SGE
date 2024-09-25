using PaginaEEST1.Data.Models.Objetos_Fisicos;
using PaginaEEST1.Data;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using QRCoder;
using PaginaEEST1.Data.Enums;
using AntDesign;
using System.Reflection;
using PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes;

namespace PaginaEEST1.Services
{
    public interface IRequestService
    {
        //GetAllRequest, SaveRequestVM, GetRequest
        Task<bool> SaveRequest(RequestViewModel request);
    }

    public class RequestService : IRequestService
    {
        private readonly PaginaDbContext _context;
        public RequestService(PaginaDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveRequest(RequestViewModel request)
        {
            try
            {
                if (request.Type == TypeRequest.ReporteFallo)
                {
                    FailureRequest save = new()
                    {
                        Type = request.Type,
                        ComputerId = request.ComputerId,
                        ShortDescription = request.ShortDescription,
                        RequestDate = request.RequestDate,
                        FailureDescription = request.FailureDescription,
                        Preority = request.Preority
                    };
                    save.Computer = await _context.Computers.Where(v => v.Id == save.ComputerId).SingleOrDefaultAsync();
                    _context.ComputerRequests.Add(save);
                }
                else
                {
                    InstallationRequest save = new()
                    {
                        Type = request.Type,
                        ComputerId = request.ComputerId,
                        ShortDescription = request.ShortDescription,
                        RequestDate = request.RequestDate,
                        NameProgram = request.NameProgram,
                        VersionProgram = request.VersionProgram
                    };
                    save.Computer = await _context.Computers.Where(v => v.Id == save.ComputerId).SingleOrDefaultAsync();
                    _context.ComputerRequests.Add(save);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
