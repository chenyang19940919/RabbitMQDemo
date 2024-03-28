namespace RabbitMQDemo.API.Producer
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
