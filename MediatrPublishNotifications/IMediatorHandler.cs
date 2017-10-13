using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatrPublishNotifications.Commands;

namespace MediatrPublishNotifications
{

    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
