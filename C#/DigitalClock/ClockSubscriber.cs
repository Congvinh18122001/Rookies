namespace DigitalClock
{
    public class ClockSubscriber
    {
        public void Subscriber(ClockPublisher publisher){
           publisher.SecondChange += new ClockPublisher.SecondChangeHandle(TimehasChange);
        }
        private void TimehasChange(ClockPublisher publisher,Clock time){
           System.Console.WriteLine($"The current time is {time.Hour}:{time.Minute}:{time.Second}");
        }
    }
}