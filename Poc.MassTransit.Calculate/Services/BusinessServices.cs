using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.MassTransit.Calculate.Services
{
    class BusinessServices : IServices
    {
        IBusinessSaga _saga;

        public BusinessServices(IBusinessSaga saga)
        {
            _saga = saga;
        }
        public int MultiplyBy2(int number)
        {
            return number * 2;
        }
    }
}
