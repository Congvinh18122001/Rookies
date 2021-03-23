using System.Threading;
using System;
namespace DigitalClock
{

    public class ClockPublisher
    {
        
        public delegate void SecondChangeHandle(ClockPublisher clockPublisher , Clock time); 

        public event SecondChangeHandle SecondChange;

        public void OnSecondChange (ClockPublisher clockPublisher , Clock time){
            SecondChange(clockPublisher,time);
        }
        public void Run (){
            while (true)
            {
                Thread.Sleep(1000);
                var dateTime  = DateTime.Now;
                Clock time = new Clock(dateTime.Hour,dateTime.Minute,dateTime.Second);
                OnSecondChange(this,time);
            }
        }
    }
}