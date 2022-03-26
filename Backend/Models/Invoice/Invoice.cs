using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models.Invoice
{
    public class Invoice
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Code { get; set; }
        public string Client { get; set; }
        public string City { get; set; }
        public int Nit { get; set; }
        public int Total { get; set; }
        public int SubTotal { get; set; }
        public int Iva { get; set; }
        public int Retention { get; set; }
        public string CreationDate { get; set; }
        public string Status { get; set; }
        public string ChangeStatus { get; set; }
        public string email { get; set; }
        public string Paid { get; set; }
        public string PaymentDate { get; set; }
    }
}
