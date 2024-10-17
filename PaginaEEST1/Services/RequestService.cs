using PaginaEEST1.Data.Models.Objetos_Fisicos;
using PaginaEEST1.Data;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using QRCoder;
using PaginaEEST1.Data.Enums;
using AntDesign;
using System.Reflection;
using Azure.Core;
using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request;
using PaginaEEST1.Components.Pages.SGE.EMATP;

namespace PaginaEEST1.Services
{
    public interface IRequestService
    {
        //GetAllRequest, SaveRequestVM, GetRequest
        Task<bool> SaveRequest(RequestEMATP request);
        Task<bool> UpdateStatus(int Id, RequestStatus status);
        Task<bool> UpdateDate(int Id, DateTime estimated);
        Task<RequestEMATP?> GetRequest(int Id);
        Task DelRequest(int Id);
        Task<List<RequestViewModel?>> GetListRequests();
    }

    public class RequestService : IRequestService
    {
        private readonly PaginaDbContext _context;
        public RequestService(PaginaDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveRequest(RequestEMATP request)
        {
            if (request != null)
            {
                try
                {
                    if (request is FailureRequest failure)
                    {
                        failure.Computer = await _context.Computers.FindAsync(failure.ComputerId);
                        _context.ComputerRequests.Add(failure);
                    }
                    if (request is InstallationRequest installation)
                    {
                        installation.Computer = await _context.Computers.FindAsync(installation.ComputerId);
                        _context.ComputerRequests.Add(installation);
                    }
                    else
                    {
                        _context.ComputerRequests.Add(request);
                    }
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public async Task<RequestEMATP?> GetRequest(int Id)
        {
            return await _context.ComputerRequests.FindAsync(Id);
        }
        public async Task DelRequest(int Id)
        {
            try
            {
                RequestEMATP request = await _context.ComputerRequests.FindAsync(Id);
                _context.ComputerRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new InvalidOperationException("No se pudo eliminar la solicitud.");
            }
        }
        public async Task<bool> UpdateStatus(int Id, RequestStatus status)
        {
            try
            {
                RequestEMATP request = await _context.ComputerRequests.FindAsync(Id);
                request.Status = status;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> UpdateDate(int Id, DateTime estimated)
        {
            try
            {
                RequestEMATP request = await _context.ComputerRequests.FindAsync(Id);
                request.RequestStartDate = DateTime.Now;
                request.EstimatedCompletionDate = estimated;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<RequestViewModel?>> GetListRequests()
        {
            List<RequestViewModel?> requests = new();

            foreach (RequestEMATP i in await _context.ComputerRequests.ToListAsync())
            {
                RequestViewModel add = new()
                {
                    ID = i.Id,
                    ShortDescription = i.ShortDescription,
                    RequestDate = i.RequestDate,
                    Type = i.Type
                };
                requests.Add(add);
            }
            return requests;
        }
    }
}
