using MediatR;

namespace Domain.Models.Command
{
    public class Notification : INotification
    {
        public string Exception { get; set; }
        public string Message { get; set; }
    }
}
