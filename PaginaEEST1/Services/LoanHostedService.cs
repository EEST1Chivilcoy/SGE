using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PaginaEEST1.Services
{
    public class LoanHostedService : IHostedService, IDisposable
    {
        private Timer? _timer;
        private readonly IServiceProvider _serviceProvider;

        public LoanHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Configurar el temporizador para ejecutar CheckLoans cada 24 horas
            _timer = new Timer(CheckLoans, null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private void CheckLoans(object? state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<PaginaDbContext>();

                    // Obtener la fecha actual
                    var currentDate = DateOnly.FromDateTime(DateTime.Now);
                    var twoWeeksAgo = currentDate.AddDays(-14);

                    // Actualizar préstamos cuyo RequiredDate sea igual a la fecha actual
                    var loansToUpdate = dbContext.Loans
                        .Where(l => l.RequiredDate == currentDate)
                        .ToList();

                    foreach (var loan in loansToUpdate)
                    {
                        loan.Status = LoanStatus.Busy;

                        // Actualizar disponibilidad de activos asociados (si aplica)
                        if (loan is NetbookLoan netbookLoan)
                        {
                            NetbookLoan includeLoan = dbContext.Loans.OfType<NetbookLoan>()
                                .Include(l => l.Netbooks)
                                .Where(l => l == netbookLoan)
                                .SingleOrDefault() ??
                                throw new InvalidOperationException("Error inesperado al actualizar la disponibilidad.");
                            includeLoan.Netbooks.ForEach(n => n.IsAvailable = false);
                        }
                    }

                    // Eliminar préstamos con RequestDate hace más de 2 semanas
                    var loansToDelete = dbContext.Loans
                        .Where(l => l.RequiredDate < twoWeeksAgo)
                        .ToList();

                    dbContext.Loans.RemoveRange(loansToDelete);

                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error al procesar préstamos.", ex);
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
