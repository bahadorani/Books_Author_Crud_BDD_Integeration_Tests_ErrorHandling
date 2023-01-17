namespace Book.ClientSdk
{
    public class ErrorBase<TEnum>
        where TEnum : Enum
    {
        public ErrorBase(TEnum code, int values)
        {
            Code = code;
            Values = values;
        }

        public TEnum Code { get; init; }
        public int Values { get; init; }
    }
}
