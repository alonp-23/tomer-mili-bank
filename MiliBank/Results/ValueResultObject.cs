namespace MiliBank.Results
{
    public class ValueResultObject<T> : ResultObject
    {
        public T Value { get; set; }

        public ValueResultObject(ResultStatus status, T value) : base(status)
        {
            Value = value;  
        }
    }
}