using System;
using MediatR;

namespace MediatrPublishNotifications.Commands
{
    public class CustomerCommandHandler : CommandHandler,
        INotificationHandler<RegisterNewCustomerCommand>,
        INotificationHandler<UpdateCustomerCommand>,
        INotificationHandler<RemoveCustomerCommand>
    {
     
        private readonly IMediatorHandler Bus;

        public CustomerCommandHandler(
                                     
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base( bus, notifications)
        {
           
            Bus = bus;
        }

        public void Handle(RegisterNewCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var customer = new Customer(Guid.NewGuid(), message.Name, message.Email, message.BirthDate);


            Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
            return;





            //Bus.RaiseEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));

        }

        public void Handle(UpdateCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var customer = new Customer(message.Id, message.Name, message.Email, message.BirthDate);
            var existingCustomer = customer;

            if (existingCustomer != null && existingCustomer.Id != customer.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
                    return;
                }
            }

           

            
                Bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            
        }

        public void Handle(RemoveCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

        

       
                Bus.RaiseEvent(new CustomerRemovedEvent(message.Id));
      
        }

        public void Dispose()
        {
            
        }
    }
}
