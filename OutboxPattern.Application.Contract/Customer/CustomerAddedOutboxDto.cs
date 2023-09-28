using OutboxPattern.Constants.Enums.Event;

namespace OutboxPattern.Application.Contract.Customer
{
    public class CustomerAddedOutboxDto
    {
        public Guid EventId { get; set; }

        /// <summary>
        /// OrderCreated
        /// </summary>
        public string EventType { get; set; }
        public string Payload { get; set; }
        public DateTime TimeStamp { get; private set; }
        public EventStatus EventStatus { get; set; }
        public string ExchangeName { get; set; }

        public CustomerAddedOutboxDto()
        {
            this.EventId = Guid.NewGuid();
            this.TimeStamp = DateTime.Now;
        }

    }
}
