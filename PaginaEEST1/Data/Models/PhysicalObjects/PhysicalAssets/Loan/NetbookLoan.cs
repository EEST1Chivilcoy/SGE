using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PaginaEEST1.Data.Models.Personal;
using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes
{
    public class NetbookLoan : Loan
    {

        /// <summary>
        /// Relacion Con Netbooks (Obligatoria)
        /// </summary>
        public List<Netbook> Netbooks { get; set; } = null!;
    }
}
