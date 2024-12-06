using Microsoft.EntityFrameworkCore;
using PaymentAPI.Database;
using PaymentAPI.Dtos;
using PaymentAPI.Entities;
using PaymentAPI.Interfaces;

namespace PaymentAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentDbContext _context;
        public PaymentService(PaymentDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(PaymentDetailsDto details)
        {
            if (details == null)
            {
                throw new ArgumentNullException();
            }
            var payment = new PaymentDetails
            {
                CardOwnerName = details.CardOwnerName,
                ExpirationDate = details.ExpirationDate,
                CardOwnerNumber = details.CardOwnerNumber,
                SecurityCode = details.SecurityCode,
            };
            _context.PaymentDetails.Add(payment);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task Delete(int id)
        {
            var payment = await _context.PaymentDetails.FirstOrDefaultAsync(p=>p.Id == id);
            if(payment == null)
            {
                throw new KeyNotFoundException();
            }
            _context.PaymentDetails.Remove(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<PaymentDetails>> GetAll()
        {
            var payment = await _context.PaymentDetails.ToListAsync();
            return payment;
        }

        public async Task<PaymentDetails> GetById(int id)
        {
            var payment = await _context.PaymentDetails.FirstOrDefaultAsync(p => p.Id == id);
            if (payment == null)
            {
                throw new KeyNotFoundException();
            }
            return payment;
        }

        public async Task<bool> Update(PaymentDetailsDto details)
        {
            var oldPayment = await _context.PaymentDetails.FirstOrDefaultAsync(p => p.Id == details.Id);
            if (oldPayment == null)
            {
                throw new KeyNotFoundException();
            }
            oldPayment.SecurityCode = details.SecurityCode;
            oldPayment.CardOwnerNumber = details.CardOwnerNumber;
            oldPayment.ExpirationDate = details.ExpirationDate;
            oldPayment.CardOwnerName = details.CardOwnerName;
            _context.PaymentDetails.Update(oldPayment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
