using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PaginaEEST1.Services
{
    public class NetbookLoanHostedService : IHostedService, IDisposable
    {
        private Timer? _timer;
        private readonly IServiceProvider _serviceProvider;

        public NetbookLoanHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Configurar el temporizador para ejecutar CheckNetbookLoans cada 24 horas
            _timer = new Timer(CheckNetbookLoans, null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private void CheckNetbookLoans(object? state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<PaginaDbContext>();

                    // Obtener la fecha actual
                    var currentDate = DateOnly.FromDateTime(DateTime.Now);

                    // Buscar los préstamos que han alcanzado su fecha requerida
                    var loansToUpdate = dbContext.Loans
                        .OfType<NetbookLoan>()
                        .Include(nl => nl.Netbooks)
                        .Where(nl => nl.RequiredDate == currentDate)
                        .ToList();

                    if (loansToUpdate != null && loansToUpdate.Any())
                    {
                        foreach (var loan in loansToUpdate)
                        {
                            // Actualizar el estado de disponibilidad de todas las netbooks
                            foreach (var netbook in loan.Netbooks)
                            {
                                netbook.IsAvailable = false;
                            }
                        }

                        dbContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("No se pudo actualizar el estado de las netbooks.", ex);
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