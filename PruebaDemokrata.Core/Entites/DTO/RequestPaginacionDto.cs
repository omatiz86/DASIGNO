namespace PruebaDemokrata.Core.Entites.DTO
{
    public class RequestPaginacionDto
    {

        public object Filtro { get; set; } = "{\r\n  \"usuario1\": \"usuario1\",\r\n  \"primerNombre\": \"\",\r\n  \"primerApellido\": \"\",\r\n  \"tipoDocumento\": \"\",\r\n  \"segundoNombre\": \"\",\r\n  \"segundoApellido\": \"\",\r\n  \"numeroDocumento\": \"\"\r\n}";

        public PaginacionDto Paginacion { get; set; }


    }
}
