namespace Domain.Models
{
    public class LogBattleModel
    {
        public string CharacterFirst { get; set; }
        public string CharacterSecond { get; set; }
        public List<string> Log { get; set; } = new List<string>();
    }
}
