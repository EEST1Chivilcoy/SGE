using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Personal;
using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PaginaEEST1.Services
{
    public class RequestsHostedService : IHostedService, IDisposable
    {
        private Timer? _timer;
        private readonly IServiceProvider _serviceProvider;

        public RequestsHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Configurar el temporizador para ejecutar ArchiveOldRequests cada 24 horas
            _timer = new Timer(ArchiveOldRequests, null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private void ArchiveOldRequests(object? state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                try { 
                    var dbContext = scope.ServiceProvider.GetRequiredService<PaginaDbContext>();

                    var archiveDate = DateTime.UtcNow.AddDays(-14);
                    var toArchive = dbContext.ComputerRequests
                        .Where(e => e.EstimatedCompletionDate < archiveDate && e.Status == RequestStatus.Completada)
                        .ToList();

                    if (toArchive.Any())
                    {
                        foreach(RequestEMATP request in toArchive)
                            request.Status = RequestStatus.Archivada;
                        dbContext.SaveChanges();
                    }
                }
                catch
                {
                    throw new InvalidOperationException("No se pudo archivar las solicitudes.");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
