namespace API.Helpers
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }
        public ApiValidationErrorResponse(IEnumerable<string> errors) : base(400)
        {
            this.Errors = errors;
        }
        public IEnumerable<string> Errors { get; set; }
    }
}
