using Backend.Models;
using Backend.Models.Invoice;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class InvoicesController : Controller
    {
        private Email email = new Email();
        private IInvoiceCollection db = new InvoiceCollection();
        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            return Ok(await db.GetInvoices());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoice(string id)
        {
            return Ok(await db.GetInvoice(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
        {
            await db.InsertInvoice(invoice);
            return Created("Factura creada", invoice);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice([FromBody] Invoice invoice, string id)
        {
            invoice.Code = id;
            email.GmailReceptor = invoice.email;
            await db.UpdateInvoice(id, invoice);            
            if (invoice.ChangeStatus == "Inicial" && invoice.Status == "Primerrecordatorio")
            {
                email.SendMessage= "El estado ha cambiado a primer recordatorio ";
                await email.sendEmail();
            }
            if (invoice.ChangeStatus == "Primerrecordatorio" && invoice.Status == "Segundorecordatorio")
            {
                email.SendMessage = "El estado ha cambiado a segundo recordatorio ";                
                await email.sendEmail();
            }
            if (invoice.ChangeStatus == "Segundorecordatorio" && invoice.Status == "Desactivado")
            {
                email.SendMessage = "El estado ha cambiado a desactivado";
                await email.sendEmail();
            }
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(string id)
        {
            await db.DeleteInvoice(id);
            return NoContent();
        }







    }
}
