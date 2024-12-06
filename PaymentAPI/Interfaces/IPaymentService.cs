using PaymentAPI.Dtos;
using PaymentAPI.Entities;

namespace PaymentAPI.Interfaces
{
    public interface IPaymentService
    {
        Task<ICollection<PaymentDetails>> GetAll();
        Task<PaymentDetails> GetById(int id);
        Task<bool> Create(PaymentDetailsDto details);
        Task<bool> Update(PaymentDetailsDto details);
        Task Delete(int id);

    }
}
