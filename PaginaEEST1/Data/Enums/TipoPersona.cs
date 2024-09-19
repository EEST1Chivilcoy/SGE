using PaginaEEST1.Data.Models.Personal;
using System.ComponentModel;

namespace PaginaEEST1.Data.Enums
{
    public enum TipoPersona
    {
        [Description("Directivo")]
        Directivo = 1,
        [Description("EMATP")]
        EMATP = 2,
        [Description("Pañol")]
        Paniol = 3,
        [Description("Profesor")]
        Profesor = 4,
        [Description("Alumno")]
        Alumno = 5
    }
}
