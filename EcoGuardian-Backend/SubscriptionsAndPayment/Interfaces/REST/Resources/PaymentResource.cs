using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.ValueObjects;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Resources;

public record PaymentResource(
    int Id,
    decimal Amount,
    string Currency,
    string PaymentIntentId,
    string PaymentMethodId,
    string PaymentStatus,
    int UserId,
    int ReferenceId,
    string ReferenceType,
    DateTime CreatedAt,
    DateTime UpdatedAt
);