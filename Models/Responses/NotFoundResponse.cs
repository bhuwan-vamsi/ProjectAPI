namespace APIPractice.Models.Responses
{
    public class NotFoundResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }

        public T? ErrorDetails { get; set; }

        public NotFoundResponse(int status, string message, T? details = default)
        {
            Status = status;
            Message = message;
            ErrorDetails = details;
        }

        public static NotFoundResponse<T> Execute(T details)
        {
            return new NotFoundResponse<T>(StatusCodes.Status404NotFound, "Error occured", details);
        }
    }
}
