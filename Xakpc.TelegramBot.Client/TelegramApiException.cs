using System;

namespace Xakpc.TelegramBot.Client
{
    public class TelegramApiException : Exception
    {
        public TelegramApiException(int errorCode, string description) : base($"{errorCode}: {description}")
        {
        }
    }
}