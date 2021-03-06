﻿using DataTransfer.Requests.Registrations;
using DataTransfer.Responses.Registrations;

namespace Business.Interfaces.Registrations
{
    public interface IWaiterAppService : ICrudAppService<WaiterRequest, WaiterResponse>
    {
    }
}
