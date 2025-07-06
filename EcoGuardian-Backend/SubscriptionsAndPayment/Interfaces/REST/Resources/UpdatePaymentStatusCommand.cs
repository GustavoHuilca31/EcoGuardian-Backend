namespace EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Resources;

public record UpdatePaymentStatusCommand(int id, string PaymentStatus);