namespace Example.Contracts.Base.Get
{
    public class GetResponseBase<T> : ResponseBase where T : BaseDto
    {
        public IEnumerable<T> Items { get; set; }
    }
}
