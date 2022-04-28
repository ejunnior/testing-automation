namespace Finance.Tests.Infrastructure.Api
{
    using System;

    public class Envelope<T>
    {
        public object ErrorMessage { get; set; }

        public T Result { get; set; }

        public DateTime TimeGenerated { get; set; }
    }
}