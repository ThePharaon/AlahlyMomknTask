namespace AlahlyMomknTask.Server.Statics
{
    public static class JWTConfigrations
    {
        public static string Key { get; private set; } = string.Empty;
        public static void SetJWTKeyString(string key)
        {
            Key = key;
        }
    }
}
