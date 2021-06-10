using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.Helpers
{
    public class OnLoginAttemptMessage
    {
        public string Username { get; set; }
        public bool IsLoginSuccessful { get; set; }
    }
}
