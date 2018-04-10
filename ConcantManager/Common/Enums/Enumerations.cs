using System;

namespace Common.Enumerations
{
    public enum TransactionResult
    {
        Success,
        Fail,
        Warn
    }

    public enum EntityState
    {
        Initial,
        Updated,
        Inserted,
        Deleted
    }
}