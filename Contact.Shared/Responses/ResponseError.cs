namespace Contact.Shared.Responses
{
    public class ResponseError : Exception
    {
        public int StatusCode { get; set; }
        public string Messages { get; set; }
    }
}
