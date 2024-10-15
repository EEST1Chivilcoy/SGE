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
        Task<bool> SaveRequest(RequestViewModel request);
        Task<bool> UpdateStatus(int Id, RequestStatus status);
        Task<bool> UpdateDate(int Id, DateTime estimated);
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
        public async Task DelRequest(int Id){
            try{
                RequestEMATP request = await _context.ComputerRequests.FindAsync(Id);
                _context.ComputerRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
            catch{
                throw new InvalidOperationException("No se pudo eliminar la solicitud.");
            }
        }
        public async Task<bool> UpdateStatus(int Id, RequestStatus status){
            try{
                RequestEMATP request = await _context.ComputerRequests.FindAsync(Id);
                request.Status = status;
                await _context.SaveChangesAsync();
                return true;
            }
            catch{
                return false;
            }
        }
        public async Task<bool> UpdateDate(int Id, DateTime estimated){
            try{
                RequestEMATP request = await _context.ComputerRequests.FindAsync(Id);
                request.RequestStartDate = DateTime.Now;
                request.EstimatedCompletionDate = estimated;
                await _context.SaveChangesAsync();
                return true;
            }
            catch{
                return false;
            }
        }
        public async Task<List<RequestViewModel?>> GetListRequests()
        {
            List<RequestViewModel?> requests = new();

            foreach (RequestEMATP i in await _context.ComputerRequests.ToListAsync())
            {
                requests.Add(GetRequestVM(i));
            }
            return requests;
        }
        private RequestViewModel GetRequestVM(RequestEMATP com){
            RequestViewModel vm = new(){
                    ID = com.Id,
                    Type = com.Type,
                    ShortDescription = com.ShortDescription,
                    RequestDate = com.RequestDate,
                    RequestStartDate = com.RequestStartDate,
                    EstimatedCompletionDate = com.EstimatedCompletionDate,
                    Status = com.Status
            };
            if (com is FailureRequest failurerequest){
                vm.ComputerId = failurerequest.ComputerId;
                vm.FailureDescription = failurerequest.FailureDescription;
                vm.Preority = failurerequest.Preority;
            }
            if(com is InstallationRequest installationrequest){
                vm.ComputerId = installationrequest.ComputerId;
                vm.NameProgram = installationrequest.NameProgram;
                vm.VersionProgram = installationrequest.VersionProgram;
            }
            if(com is StudentAccountRequest accountrequest){

            }
            return vm;
        }
    }
}
