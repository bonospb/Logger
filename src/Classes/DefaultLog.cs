using System;
using UnityEngine;

namespace FreeTeam.Logging
{
    public sealed class DefaultLog : ILog
    {
        #region Constants
        private const string RUNTIME_PREFIX = "[Log]";
        private const string EDITOR_PREFIX = "<color=#eeeeee><b>[Log]</b></color>";
        #endregion

        #region Public
        public DateTime Date { get; private set; } = DateTime.Now;
        public LogTypes Type => LogTypes.Default;
        public string Text { get; private set; }
        public ChannelTypes Channel { get; private set; }

        public string Prefix => (Application.isEditor) ? EDITOR_PREFIX : RUNTIME_PREFIX;
        #endregion

        public DefaultLog(string text, ChannelTypes channel = ChannelTypes.Default)
        {
            Text = text;
            Channel = channel;
        }

        #region Public methods
        public override string ToString() =>
            $"{Prefix} {Text}";
        #endregion
    }
}
