namespace Backend.Models.Invoice
{
    public interface IInvoiceCollection
    {
        Task InsertInvoice(Invoice invoice);//task para que todo sea asyncrono
        Task UpdateInvoice(string id, Invoice invoice);

        Task DeleteInvoice(string id);

        Task<List<Invoice>> GetInvoices();

        Task<Invoice> GetInvoice(string id);

    }
}
