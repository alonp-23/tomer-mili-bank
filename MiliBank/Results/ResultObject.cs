namespace MiliBank.Results
{
    public class ResultObject
    {
        public ResultStatus Status { get; set; }

        public ResultObject(ResultStatus status)
        {
            Status = status;
        }
    }
}