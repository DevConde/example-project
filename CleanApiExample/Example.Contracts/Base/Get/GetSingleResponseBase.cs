namespace Example.Contracts.Base.Get
{
    public record GetSingleResponseBase<T> where T : BaseDto
    {
        public required T Item { get; set; }
    }
}
