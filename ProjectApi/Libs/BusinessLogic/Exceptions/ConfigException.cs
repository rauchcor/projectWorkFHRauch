using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions
{
    public class ConfigException : Exception
    {
        public ConfigException(string setting, string message) : base($"setting: {setting}, error: {message}")
        {
            
        }
    }
}
