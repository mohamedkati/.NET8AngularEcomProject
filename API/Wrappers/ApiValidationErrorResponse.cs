namespace API.Wrappers
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }
        public ApiValidationErrorResponse(IEnumerable<string> errors) : base(400)
        {
            Errors = errors;
        }
        public IEnumerable<string> Errors { get; set; }
    }
}
