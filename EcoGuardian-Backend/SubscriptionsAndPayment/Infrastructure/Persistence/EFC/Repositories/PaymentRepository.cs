using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Infrastructure.Persistence.EFC.Repositories;

public class PaymentRepository(AppDbContext context) : BaseRepository<Payment>(context), IPaymentRepository
{
    public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
    {
        return await context.Set<Payment>()
            .ToListAsync();
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId)
    {
        return await context.Set<Payment>()
            .Where(payment => payment.UserId == userId)
            .ToListAsync();
    }

    public Task<Payment?> FindByPaymentIntentIdAsync(string paymentIntentId)
    {
        return context.Set<Payment>()
            .FirstOrDefaultAsync(payment => payment.PaymentIntentId == paymentIntentId);
    }

    public async Task<IEnumerable<Payment>> GetPaymentsBySubscriptionType(string subscriptionType)
    {
        return await context.Set<Payment>()
            .Where(payment => payment.ReferenceType.ToString() == subscriptionType)
            .ToListAsync();
    }

    public Task<Payment?> GetPaymentByIdAsync(int paymentId)
    {
        return context.Set<Payment>()
            .FirstOrDefaultAsync(payment => payment.Id == paymentId);
    }
}