using Backend.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backend.Models.Invoice
{
    public class InvoiceCollection : IInvoiceCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Invoice> Collection;

        public InvoiceCollection()
        {
            Collection = _repository.db.GetCollection<Invoice>("Invoices");
        }
        public async Task DeleteInvoice(string id)
        {            
            await Collection.DeleteOneAsync(x => x.Code == id);
        }
        public async Task<List<Invoice>> GetInvoices()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }
        public async Task<Invoice> GetInvoice(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.
                FirstAsync();
        }
        public async Task InsertInvoice(Invoice invoice)
        {
            await Collection.InsertOneAsync(invoice);
        }
        public async Task UpdateInvoice(string id, Invoice invoice)
        {
            await Collection.ReplaceOneAsync(x => x.Code == id, invoice);
        }

    }
}
