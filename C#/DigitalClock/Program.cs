using System;

namespace DigitalClock
{
    class Program
    {
        static void Main(string[] args)
        {
            ClockPublisher clockPublisher = new ClockPublisher();
            ClockSubscriber clockSubscriber = new ClockSubscriber();
            clockSubscriber.Subscriber(clockPublisher);
            clockPublisher.Run();
        }
    }
}
