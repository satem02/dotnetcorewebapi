using System;
using Common.Enumerations;

namespace Common.Bases
{
    [Serializable]
    public abstract class TransferBase
    {

        #region Class Member Declarations
        public int Id { get; set; }
        public TransactionResult TransactionResult { get; set; }
        public string Message { get; set; }
        public string MessageCode { get; set; }
        public object DefaultValue { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.String CreateUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public System.String UpdateUser { get; set; }
        #endregion Class Member Declarations

    }
}