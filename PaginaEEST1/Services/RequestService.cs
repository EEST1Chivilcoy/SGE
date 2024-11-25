using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request;
using Microsoft.AspNetCore.Components.Authorization;
using PaginaEEST1.Data.Models.PhysicalObjects;
using PaginaEEST1.Data.Models.Personal;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using PaginaEEST1.Data.Enums;
using System.Security.Claims;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan;
using Azure.Core;

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
        Task<List<RequestViewModel?>> GetListRequests(bool? forManagement = false);
    }

    public class RequestService : IRequestService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly PaginaDbContext _context;
        public RequestService(PaginaDbContext context, AuthenticationStateProvider authenticationStateProvider)
        {
            _context = context;
            _authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<bool> SaveRequest(RequestEMATP request)
        {
            if (request != null)
            {
                try
                {
                    if (request is FailureRequest failure)
                    {
                        failure.Professor = _context.People.OfType<Professor>().Where(p => p.PersonId == failure.ProfessorId).SingleOrDefault();
                        failure.Computer = await _context.Computers.FindAsync(failure.ComputerId);
                        _context.ComputerRequests.Add(failure);
                    }
                    if (request is InstallationRequest installation)
                    {
                        installation.Professor = _context.People.OfType<Professor>().Where(p => p.PersonId == installation.ProfessorId).SingleOrDefault();
                        installation.Computer = await _context.Computers.FindAsync(installation.ComputerId);
                        _context.ComputerRequests.Add(installation);
                    }
                    else
                    {
                        _context.ComputerRequests.Add(request);
                    }

                    if (request is RequestComputer requestComputer)
                        await UpdateComputerStatus(requestComputer.ComputerId);

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
                if (request != null)
                {
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

                if (request is RequestComputer computerRequest)
                    await UpdateComputerStatus(computerRequest.ComputerId);

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
        public async Task<List<RequestViewModel?>> GetListRequests(bool? forManagement = false)
        {
            // Autenticación 
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var personIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = user.FindFirst(ClaimTypes.Role)?.Value;

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
                    Status = i.Status,
                    ProfessorId = i is RequestComputer computerRequest
                          ? computerRequest.ProfessorId
                          : null
                };
                requests.Add(add);
            }

            if (forManagement == false)
                requests = requests.Where(l => l.ProfessorId == personIdClaim).ToList();

            return requests;
        }
        private async Task UpdateComputerStatus(int computerId)
        {
            List<RequestEMATP>? allRequests = await _context.ComputerRequests.ToListAsync();

            List<RequestComputer>? computerRequests = allRequests.OfType<RequestComputer>().Where(r => r.ComputerId == computerId).ToList();
            if (computerRequests == null || !computerRequests.Any())
            {
                (await _context.Computers.FindAsync(computerId)).Status = ComputerStatus.Fallas;
                return;
            }
            // Verificar el estado de las solicitudes
            if (computerRequests.Any(r => r.Status == RequestStatus.Pendiente))
            {
                var computer = await _context.Computers.FindAsync(computerId);
                if (computer != null) computer.Status = ComputerStatus.Fallas;
            }
            else if (computerRequests.Any(r => r.Status == RequestStatus.EnProceso))
            {
                var computer = await _context.Computers.FindAsync(computerId);
                if (computer != null) computer.Status = ComputerStatus.Mantenimiento;
            }
            else
            {
                var computer = await _context.Computers.FindAsync(computerId);
                if (computer != null) computer.Status = ComputerStatus.Operativo;
            }
        }

    }
}
