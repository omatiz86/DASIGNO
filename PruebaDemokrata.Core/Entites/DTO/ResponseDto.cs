namespace PruebaDemokrata.Core.Entites.DTO
{
    public class ResponseDto
    {
        public bool Estado { get; set; }

        public int Codigo { get; set; }

        public string? mensaje { get; set; }

        public object? data { get; set; }

        public PaginacionDto? paginacion { get; set; }

    }
}
