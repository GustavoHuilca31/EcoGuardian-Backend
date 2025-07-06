using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;
using EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Transform;

public class PaymentResourceFromEntityAssembler
{
    public static PaymentResource ToResourceFromEntity(Payment entity)
    {
        return new PaymentResource(
            entity.Id,
            entity.Amount,
            entity.Currency,
            entity.PaymentIntentId,
            entity.PaymentMethodId,
            entity.PaymentStatus,
            entity.UserId,
            entity.ReferenceId,
            entity.ReferenceType.ToString(),
            entity.CreatedAt,
            entity.UpdatedAt ?? DateTime.UtcNow
        );
    }
}