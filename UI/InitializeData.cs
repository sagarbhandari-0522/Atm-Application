using Atm_Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace Atm_Application.UI
{
    public static class InitializeData
    {
        public static void Initialize()
        {
            new UserAccount("Sagar Bhandari", 12321, 12345.67m, 123123, 123, 0);
            new UserAccount("Sandhya Bhandari", 12321, 12345.67m, 123123, 123, 0);
            new UserAccount("Sandhya Pandey", 12321, 12345.67m, 123123, 123, 0);

        }

    }
}
