﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.Models.Personal
{
    public class Persona
    {
        public int PersonaId { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public TipoSexo Sexo { get; set; }
        [Required, StringLength(255)]
        public string? Nombre { get; set; }
        [Required, StringLength(255)]
        public string? Apellido { get; set; }
        [StringLength(255)]
        public string? Direccion { get; set; }
        [StringLength(255)]
        public string? Documento { get; set; }
        [StringLength(255)]
        public string? Titulo { get; set; }
        [StringLength(255)]
        public NivelDeEstudio NivelEstudios { get; set; }
    }
}