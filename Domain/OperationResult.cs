namespace Domain
{
    public class OperationResult<T>
    {
        public string? Message { get; set; }
        public T? Data { get; set; }
        public bool Succes { get; set; }

        public OperationResult()
        {
            this.Succes = true;
        }
    }
}
