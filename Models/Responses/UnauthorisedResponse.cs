namespace APIPractice.Models.Responses
{
    public class UnauthorisedResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }

        public T? ErrorDetails { get; set; }

        public UnauthorisedResponse(int status, string message, T? details = default)
        {
            Status = status;
            Message = message;
            ErrorDetails = details;
        }

        public static UnauthorisedResponse<T> Execute(T details)
        {
            return new UnauthorisedResponse<T>(StatusCodes.Status401Unauthorized, "Error occured", details);
        }
    }
}
