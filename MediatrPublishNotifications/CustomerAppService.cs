using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatrPublishNotifications.Commands;

namespace MediatrPublishNotifications
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler Bus;

        public CustomerAppService(
            IMapper mapper,
            IMediatorHandler bus
           )
        {
            _mapper = mapper;
             Bus = bus;
           
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return new List<CustomerViewModel>();
        }

        public CustomerViewModel GetById(Guid id)
        {
            return null;
        }

        public void Register(CustomerViewModel customerViewModel)
        {

            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            Bus.SendCommand(removeCommand);
        }

        

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
