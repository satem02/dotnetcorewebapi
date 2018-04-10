using System;

namespace Models
{
    [Serializable]
    public class Concant
    {
        public int ConcantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}