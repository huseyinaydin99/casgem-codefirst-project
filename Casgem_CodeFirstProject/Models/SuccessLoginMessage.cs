using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casgem_CodeFirstProject.Models
{
    public class SuccessLoginMessage : IMessage
    {
        public string _message { get; }
        public SuccessLoginMessage(string message)
        {
            _message = message;
        }
    }
}