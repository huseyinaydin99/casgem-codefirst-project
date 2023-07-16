using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casgem_CodeFirstProject.Models
{
    public class ErrorLoginMessage : IMessage
    {
        public string _message { get; }
        public ErrorLoginMessage(string message)
        {
            _message = message;
        }
    }
}