namespace FreeTeam.Logging
{
    [System.Flags]
    public enum LogTypes
    {
        Default = 1,
        Info = 2,
        Message = 4,
        Warning = 8,
        Error = 16,
    }
}
