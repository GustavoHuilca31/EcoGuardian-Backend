using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;
using UpdatePaymentStatusCommand = EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Resources.UpdatePaymentStatusCommand;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Services;

public interface IPaymentCommandService
{
    public Task<Payment> Handle(CreatePaymentCommand command);
    public Task<string> Handle(CreatePaymentIntentCommand command);
    public Task<string> Handle(ConfirmPaymentIntentCommand command);
    
    public Task Handle(UpdatePaymentCommand command);
}