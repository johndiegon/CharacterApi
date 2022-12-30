using Domain.Enums;

namespace Domain.Models.Command
{
    public class CommandResponse<T>
    {
        public T Data { get; set; }
        public StatusRequest Status { get; set; }
        public string Message { get; set; }
        public List<Notification> Notification { get; set; }
    }
}
