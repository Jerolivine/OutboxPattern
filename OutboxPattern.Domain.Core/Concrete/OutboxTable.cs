using OutboxPattern.Constants.Enums.Event;

namespace OutboxPattern.Domain.Core.Concrete
{
    public class OutboxTable
    {
        public Guid EventId { get; set; }

        /// <summary>
        /// OrderCreated
        /// </summary>
        public string EventType { get; set; }
        public string Payload { get; set; }
        public DateTime TimeStamp { get; private set; }
        public EventStatus EventStatus { get; set; }

        //public int RetryCount { get; private set; }
        //public DateTime LastRetryTimeStamp { get; set; }

        public string ExchangeName { get; set; }

        public OutboxTable()
        {
            this.EventId = Guid.NewGuid();
            this.TimeStamp = DateTime.Now;
        }

        //public void IncreaseRetryCount()
        //{
        //    this.RetryCount++;
        //    this.LastRetryTimeStamp = DateTime.Now;
        //}
    }
}
