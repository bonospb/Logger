using System;

namespace FreeTeam.Logging
{
    public interface ILog
    {
        DateTime Date { get; }
        LogTypes Type { get; }
        string Text { get; }
        ChannelTypes Channel { get; }

        string Prefix { get; }
    }
}
