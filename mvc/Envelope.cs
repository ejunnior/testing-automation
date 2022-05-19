namespace FrontEnd
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Envelope<T>
    {
        //protected internal Envelope(T result, string errorMessage)
        //{
        //    Result = result;
        //    ErrorMessage = errorMessage;
        //    TimeGenerated = DateTime.UtcNow;
        //}

        public object ErrorMessage { get; set; }
        public T Result { get; set; }
        public DateTime TimeGenerated { get; set; }
    }

    //public sealed class Envelope : Envelope<string>
    //{
    //    private Envelope(string errorMessage)
    //        : base(null, errorMessage)
    //    {
    //    }

    //    public static Envelope Error(string errorMessage)
    //    {
    //        return new Envelope(errorMessage);
    //    }

    //    public static Envelope<T> Ok<T>(T result)
    //    {
    //        return new Envelope<T>(result, null);
    //    }

    //    public static Envelope Ok()
    //    {
    //        return new Envelope(null);
    //    }
    //}
}