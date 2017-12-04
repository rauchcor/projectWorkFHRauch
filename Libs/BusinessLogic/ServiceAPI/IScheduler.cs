using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ServiceAPI
{
    public interface IScheduler
    {
        void Start(double interval);
        void Stop();
        Action Action { get; set; }
    }
}
