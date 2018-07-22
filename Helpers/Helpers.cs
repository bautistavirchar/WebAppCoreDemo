namespace WebAppCoreDemo.Helpers
{
    internal static class Helpers
    {
        public static int ConvertToNumber(this string value)
        {
            int result = 0;
            int.TryParse(value, out result);
            return result;
        }
    }
}