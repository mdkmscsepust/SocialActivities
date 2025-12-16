namespace Backend.API.Services.Eventervice
{
    public class EventService
    {
        public event Action<string>? OnMessage;
        public void SendMessage(string message)
        {
            OnMessage?.Invoke(message);
        }
    }
}