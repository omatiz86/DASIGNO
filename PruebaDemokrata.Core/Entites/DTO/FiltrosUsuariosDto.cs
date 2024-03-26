namespace PruebaDemokrata.Core.Entites.DTO
{
    public class FiltrosUsuariosDto
    {
        
        public int? Id { get; set; } = 0;
        public string? PrimerNombre { get; set; } = String.Empty;
        public string? SegundoNombre { get; set; } = String.Empty;
        public string? PrimerApellido { get; set; } = String.Empty;
        public string? SegundoApellido { get; set; } = String.Empty;
        public DateTime? FechaNacimiento { get; set; } = null;
        public decimal? Sueldo { get; set; } = 0;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;

    }
}
