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
                switch (request.Type)
                {
                    case TypeRequest.ReporteFallo:
                        FailureRequest failure = new()
                        {
                            Type = request.Type,
                            ComputerId = request.ComputerId,
                            ShortDescription = request.ShortDescription ?? "Sin descripción",
                            RequestDate = request.RequestDate,
                            FailureDescription = request.FailureDescription ?? "Sin descripción del fallo",
                            Preority = request.Preority
                        };
                        failure.Computer = await _context.Computers.Where(v => v.Id == failure.ComputerId).SingleOrDefaultAsync();
                        _context.ComputerRequests.Add(failure);
                        break;
                    case TypeRequest.Instalacion:
                        InstallationRequest installation = new()
                        {
                            Type = request.Type,
                            ComputerId = request.ComputerId,
                            ShortDescription = request.ShortDescription ?? "Sin descripción",
                            RequestDate = request.RequestDate,
                            NameProgram = request.NameProgram ?? "No se especifico el programa",
                            VersionProgram = request.VersionProgram
                        };
                        installation.Computer = await _context.Computers.Where(v => v.Id == installation.ComputerId).SingleOrDefaultAsync();
                        _context.ComputerRequests.Add(installation);
                        break;
                    case TypeRequest.SolicitudCuenta:
                        StudentAccountRequest account = new()
                        {
                            Type = request.Type,
                            ShortDescription = request.ShortDescription ?? "Sin descripción",
                            RequestDate = request.RequestDate,
                            StudentName = request.StudentName,
                            StudentSurname = request.StudentSurname,
                            StudentEmail = request.StudentEmail,
                            StudentCellPhoneNumber = request.StudentCellPhoneNumber,
                            SchoolYear = request.SchoolYear,
                            SchoolDivision = request.SchoolDivision
                        };
                        _context.ComputerRequests.Add(account);
                        break;
                    default:
                        return false;
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
                vm.StudentName = accountrequest.StudentName;
                vm.StudentSurname = accountrequest.StudentSurname;
                vm.StudentEmail = accountrequest.StudentEmail;
                vm.StudentCellPhoneNumber = accountrequest.StudentCellPhoneNumber;
                vm.SchoolYear = accountrequest.SchoolYear;
                vm.SchoolDivision = accountrequest.SchoolDivision;
            }
            return vm;
        }
    }
}
