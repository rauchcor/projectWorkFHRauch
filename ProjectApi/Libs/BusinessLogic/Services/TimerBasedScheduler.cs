using BusinessLogic.ServiceAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace BusinessLogic.Services
{
    public class TimerBasedScheduler : IScheduler
    {
        private Timer timer;

        public Action Action { get; set; }

        /// <summary>
        /// Starts the timer and executes the given action every interval.
        /// The timer is stopped during execution of the action.
        /// </summary>
        /// <param name="interval">interval to call the action in miliseconds</param>
        public void Start(double interval)
        {
            if (interval < 1 || interval > int.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(interval), "Should be between 1 and int.Max");

            timer = new Timer(interval);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(Action != null)
            {
                timer.Enabled = false;
                Action();
                timer.Enabled = true;
            }
        }

        /// <summary>
        /// Stops the timer
        /// </summary>
        public void Stop()
        {
            if (timer == null)
                throw new InvalidOperationException("Call Scheduler.Start before Stop!");

            timer?.Stop();
            timer?.Close();
        }
    }
}
