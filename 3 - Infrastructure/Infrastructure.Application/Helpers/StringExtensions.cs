namespace Infrastructure.Application.Helpers
{
    public static class StringExtensions
    {
        public static bool IsValidName(this string name)
        {
            if(string.IsNullOrEmpty(name))
                return false;

            if (string.IsNullOrWhiteSpace(name))
                return false;

            if (name.Length > 15)
                return false;

            if (name.Count(char.IsNumber) > 0)
                return false;

            if (name.Replace("_", "").Count(char.IsLetter) + name.Replace("_", "").Count(char.IsNumber) != name.Replace("_", "").Length)
                return false;

            if (name.Count(char.IsWhiteSpace) > 0)
                return false;

            return true;
        }
    }
}
