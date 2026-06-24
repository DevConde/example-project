namespace Example.Contracts.Base.Create
{
    public record CreateRequestBase<T>
    {
        public required T Item { get; set; }
    }
}
