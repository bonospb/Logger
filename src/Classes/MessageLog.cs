using System;
using UnityEngine;

namespace FreeTeam.Logging
{
    public sealed class MessageLog : ILog
    {
        #region Constants
        private const string RUNTIME_PREFIX = "[Message]";
        private const string EDITOR_PREFIX = "<color=#99BB33><b>[Message]</b></color>";
        #endregion

        #region Public
        public DateTime Date { get; private set; } = DateTime.Now;
        public LogTypes Type => LogTypes.Message;
        public string Text { get; private set; }
        public ChannelTypes Channel { get; private set; }

        public string Prefix => (Application.isEditor) ? EDITOR_PREFIX : RUNTIME_PREFIX;
        #endregion

        public MessageLog(string text, ChannelTypes channel = ChannelTypes.Default)
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
