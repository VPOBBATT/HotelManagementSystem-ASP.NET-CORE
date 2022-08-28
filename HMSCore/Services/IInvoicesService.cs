using HMSCore.Models.Invoices;

namespace HMSCore.Services
{
    public interface IInvoicesService
    {
        AllInvoicesQueryModel All(AllInvoicesQueryModel query);

        void Pay(string id);

        DetailsInvoiceViewModel Details(string id);

        void Delete(string id);
    }
}