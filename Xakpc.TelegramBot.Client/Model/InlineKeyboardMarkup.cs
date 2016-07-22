using System.Collections.Generic;
using System.Runtime.Serialization;
using Xakpc.TelegramBot.Model.Base;

namespace Xakpc.TelegramBot.Model
{
    /// <summary>
    /// This object represents an inline keyboard that appears right next to the message it belongs to.
    /// </summary>
    [DataContract]
    public class InlineKeyboardMarkup : ReplyMarkup
    {
        /// <summary>
        /// Array of button rows, each represented by an Array of InlineKeyboardButton objects
        /// </summary>
        [DataMember(Name = "inline_keyboard")]
        public IEnumerable<IEnumerable<InlineKeyboardButton>> InlineKeyboard { get; set; }
    }
}
