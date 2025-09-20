namespace Notas.Api.Erros
{
    public class ApiException
    {

        public ApiException(string statusCode, string message, string datails)
        {
            StatusCode = statusCode;
            Message = message;
            Details = datails;
        }
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string? Details { get; set; }
    }
}
