using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCinema.Application.Exceptions
{
    public class BussinesException : Exception
    {
        public BussinesException() : base()
        {
            
        }  public BussinesException(string message) : base(message)
        {
            
        }
    }
}
