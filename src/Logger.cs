using System.Collections.Generic;
using UnityEngine;

namespace FreeTeam.Logging
{
    public static class Logger
    {
        #region Public static
        public delegate void OnConsoleLogHandler(ILog log);
        public static event OnConsoleLogHandler OnConsoleLog = null;
        #endregion

        #region Private static
        private static readonly List<ILog> _logs = new List<ILog>();
        #endregion

        #region Public static methods
        public static void AddToLog(ILog log)
        {
            if (_logs.Count > 200)
                _logs.RemoveAt(0);

            _logs.Add(log);
        }

        public static void Clear() =>
            _logs.Clear();

        public static void Log(string message, ChannelTypes channel = ChannelTypes.Default) =>
            ToConsole(new DefaultLog(message, channel));

        public static void Info(string message, ChannelTypes channel = ChannelTypes.Default) =>
            ToConsole(new InfoLog(message, channel));

        public static void Message(string message, ChannelTypes channel = ChannelTypes.Default) =>
            ToConsole(new MessageLog(message, channel));

        public static void Warning(string message, ChannelTypes channel = ChannelTypes.Default) =>
            ToConsole(new WarningLog(message, channel));

        public static void Error(string message, ChannelTypes channel = ChannelTypes.Default) =>
            ToConsole(new ErrorLog(message, channel));

        public static void ToConsole(ILog log)
        {
            AddToLog(log);

            Debug.Log($"{log}");

            OnConsoleLog?.Invoke(log);
        }
        #endregion
    }
}