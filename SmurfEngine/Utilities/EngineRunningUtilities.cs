namespace SmurfEngine.Utilities
{
    public static class EngineRunningUtilities
    {

        public static int GetFirstNumber(int number)
        {
            while (number >= 10)
                number /= 10;

            return number;
        }
    }
}
