using System;
using System.Collections.Generic;
using System.Messaging;

namespace SqlInterface
{
    public interface IMSMQRepository
    { 
        long MessageCount(string machineName, string queueName);
    }
}