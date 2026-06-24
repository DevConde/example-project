namespace Example.Contracts.Base
{
    public class ResponseBase
    {
        public IEnumerable<Error> Errors { get; set; }
        public IEnumerable<Warning> Warnings { get; set; }
    }

    public class Error
    {

    }

    public class Warning
    {

    }
}
