using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dependencies
{
    public class ResolutionFailedException : Exception
    {
        public ResolutionFailedException(Exception innerException, string message = "Could not resolve Type") 
            : base(message, innerException)
        {
            
        }
    }
}
