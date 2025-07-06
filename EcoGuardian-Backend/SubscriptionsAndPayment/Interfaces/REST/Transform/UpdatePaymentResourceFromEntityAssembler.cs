using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;
using EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Transform;

public class UpdatePaymentResourceFromEntityAssembler
{
    public static UpdatePaymentResource ToResourceFromEntity(Payment entity)
    {
        return new UpdatePaymentResource(
            entity.Amount,
            entity.Currency,
            entity.PaymentIntentId,
            entity.PaymentMethodId,
            entity.PaymentStatus,
            entity.UserId,
            entity.ReferenceId,
            entity.ReferenceType
        );
    }
}