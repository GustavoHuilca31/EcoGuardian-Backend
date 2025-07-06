using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Queries;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Services;

public interface IPaymentQueryService
{
    Task<IEnumerable<Payment>> Handle(GetAllPayments query);
    Task<IEnumerable<Payment>> Handle(GetPaymentsByUserId query);
    Task<IEnumerable<Payment>> Handle(GetPaymentsBySubscriptionType query);
    
    Task<Payment?> Handle(GetPaymentByPaymentIntentId query);
    Task<Payment?> Handle(GetPaymentById query);
}