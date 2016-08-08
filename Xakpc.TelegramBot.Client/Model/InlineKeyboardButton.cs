using System.Runtime.Serialization;

namespace Xakpc.TelegramBot.Model
{
    /// <summary>
    /// This object represents one button of an inline keyboard. You must use exactly one of the optional fields.
    /// </summary>
    [DataContract]
    public class InlineKeyboardButton
    {
        /// <summary>
        /// Label text on the button
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Optional. HTTP url to be opened when button is pressed
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// Optional. Data to be sent in a callback query to the bot when button is pressed, 1-64 bytes
        /// </summary>
        [DataMember(Name = "callback_data", EmitDefaultValue = false)]
        public string CallbackData { get; set; }

        /// <summary>
        /// Optional. If set, pressing the button will prompt the user to select one of their chats,
        /// open that chat and insert the bot‘s username and the specified inline query in the input field.
        /// Can be empty, in which case just the bot’s username will be inserted.
        /// </summary>
        [DataMember(Name = "switch_inline_query", EmitDefaultValue = false)]
        public string SwitchInlineQuery { get; set; }
    }
}
