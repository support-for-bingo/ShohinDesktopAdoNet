using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShohinDesktopAdoNet.Models.DomainObjects
{
    public class DomainObjectException : ArgumentException
    {
        public DomainObjectException(string message) : base(message)
        {

        }

        public DomainObjectException(string message, ArgumentException innerException) : base(message, innerException)
        {

        }
    }
}