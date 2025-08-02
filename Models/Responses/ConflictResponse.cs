namespace APIPractice.Models.Responses
{
    public class ConflictResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }

        public T? ErrorDetails { get; set; }

        public ConflictResponse(int status, string message, T? details = default)
        {
            Status = status;
            Message = message;
            ErrorDetails = details;
        }

        public static ConflictResponse<T> Execute(T details)
        {
            return new ConflictResponse<T>(StatusCodes.Status409Conflict, "Error occured", details);
        }
    }
}
