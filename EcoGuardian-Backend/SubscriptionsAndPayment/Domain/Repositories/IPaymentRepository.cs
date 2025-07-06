using EcoGuardian_Backend.Shared.Domain.Repositories;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Payment>
{
    Task<IEnumerable<Payment>> GetAllPaymentsAsync();
    Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId);
    Task<Payment?> FindByPaymentIntentIdAsync(string paymentIntentId);
    Task<IEnumerable<Payment>> GetPaymentsBySubscriptionType(string subscriptionType);
    Task<Payment?> GetPaymentByIdAsync(int paymentId);
}