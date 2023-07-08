namespace RowiTechTask.Utility
{
    public static class TextFormation
    {
        public static string TextToFormat(string text)
        {
            if (text.IndexOf('>') != -1)
            {
                return text[(text.IndexOf('>') + 1)..130] + "...";
            }
            return text[0..133] + "...";
        }
        public static string SolutionHeader(string firstName, string lastName)
        {
            return firstName + " " + lastName + "'s";
        }
    }
}
