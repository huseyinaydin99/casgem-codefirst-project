using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casgem_CodeFirstProject.Models
{
    public class LoginMessage : IMessage
    {
        public string _message { get; }
        public LoginMessage(string message)
        {
            _message = message;
        }
    }
}