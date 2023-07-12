using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casgem_CodeFirstProject.DAL.Entities
{
    public class Admin : IEntity
    {
        public int AdminID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}