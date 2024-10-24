using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum TypeArea
    {
        [Display(Name = "Área de Uso Común")] // Nombre de visualización para uso común
        Common, // Área de uso común, por ejemplo, cafetería, biblioteca
        [Display(Name = "Área Privada")] // Nombre de visualización para área privada
        Private // Área privada o restringida, por ejemplo, oficina del profesor, sala de profesores
    }
}
