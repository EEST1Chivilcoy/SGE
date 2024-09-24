﻿using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.ViewModels
{
    public class ComputadoraVM
    {
        public int ID { get; set; }
        public ComputerStatus Estado { get; set; }
        public string? NombreOCodigoDispositivo { get; set; }
        public string? SistemaOperativo { get; set; }
        public string? Procesador { get; set; }
        public int? RAM { get; set; }
        public int? Almacenamiento { get; set; }
        public string? Ubicacion { get; set; }
        public TypeStorage tipoAlmacenamiento { get; set; }
        public string Logo_PC = "Imagenes/PC_Escritorio.png";
    }
}
