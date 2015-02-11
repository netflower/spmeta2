using System;
using System.Diagnostics;

namespace System
{
    [Serializable]
    [DebuggerDisplay("Count = {InnerExceptions.Count}")]
    public class AggregateException : Exception
    {

    }
}
