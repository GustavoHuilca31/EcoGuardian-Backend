using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;
using EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Transform;

public class UpdatePaymentCommandFromResourceAssembler
{
    public static UpdatePaymentCommand ToCommandFromResource(int id, UpdatePaymentResource resource)
    {
        return new UpdatePaymentCommand(
            id,
            resource.Amount,
            resource.Currency,
            resource.PaymentIntentId,
            resource.PaymentMethodId,
            resource.PaymentStatus,
            resource.UserId,
            resource.ReferenceId,
            resource.ReferenceType
        );
    }
}