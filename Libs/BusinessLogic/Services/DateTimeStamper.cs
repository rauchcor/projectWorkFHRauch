using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.ServiceAPI;

namespace BusinessLogic.Services
{
    public class DateTimeStamper : ITimeStamper
    {
        public DateTime GetTimeStamp()
        {
            return DateTime.Now;
        }
    }
}
