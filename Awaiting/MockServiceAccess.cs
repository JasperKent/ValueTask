using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awaiting
{
    public class MockServiceAccess : IServiceAccess
    {
        public ValueTask<string> GetDataAsync()
        {
            return new ValueTask<string>("Dummy data");
        }
    }
}
