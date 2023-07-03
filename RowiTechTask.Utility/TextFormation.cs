namespace RowiTechTask.Utility
{
    public static class TextFormation
    {
        public static string TextToFormat(string text)
        {
            return text[0..133] + "...";
        }
    }
}
