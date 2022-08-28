using HMSCore.Models.Vouchers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMSCore.Services
{
    public interface IVouchersService
    {
        Task AddVoucherAsync(AddVoucherFormModel voucher);

        IEnumerable<ListAllVouchersViewModel> GetAllVouchers();

        EditVoucherFormModel GetVoucher(string id);

        Task UpdateVoucher(EditVoucherFormModel voucher);

        Task Delete(string id);
    }
}