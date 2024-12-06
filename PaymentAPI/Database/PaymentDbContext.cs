using Microsoft.EntityFrameworkCore;
using PaymentAPI.Entities;

namespace PaymentAPI.Database
{
    public class PaymentDbContext :DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
            
        }
        public DbSet<PaymentDetails> PaymentDetails {  get; set; }
    }
}
