using PaginaEEST1.Data.Models.PhysicalObjects;
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
                        Computer? computer = await _context.Computers.FindAsync(failure.ComputerId);
                        if (computer != null){
                            failure.Computer = computer;
                            computer.Status = ComputerStatus.Fallas;
                        }
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
            RequestEMATP? request = await _context.ComputerRequests
                .Where(r => r.Id == Id)
                .SingleOrDefaultAsync();

            if (request == null)
                throw new InvalidOperationException("No se encontró el reporte.");

            if (request is RequestComputer computerRequest)
            {
                await _context.Entry(computerRequest)
                    .Reference(cr => cr.Computer)
                    .LoadAsync();

                return computerRequest;
            }

            return request;
        }

        public async Task DelRequest(int Id)
        {
            try
            {
                RequestEMATP? request = await _context.ComputerRequests.FindAsync(Id);
                if (request != null) { 
                    request.Status = RequestStatus.Archivada;
                    await _context.SaveChangesAsync();
                }
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
                RequestEMATP? request = await _context.ComputerRequests.FindAsync(Id);
                request.Status = status;
                if (status == RequestStatus.Completada)
                    request.EstimatedCompletionDate = DateTime.Now;
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

            foreach (RequestEMATP i in await _context.ComputerRequests
                .Where(e => e.Status != RequestStatus.Archivada)
                .ToListAsync())
            {
                RequestViewModel add = new()
                {
                    ID = i.Id,
                    ShortDescription = i.ShortDescription,
                    RequestDate = i.RequestDate,
                    Type = i.Type,
                    Status = i.Status
                };
                requests.Add(add);
            }
            return requests;
        }
    }
}
