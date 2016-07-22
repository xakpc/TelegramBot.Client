using System.Runtime.Serialization;

namespace Xakpc.TelegramBot.Model
{
    /// <summary>
    /// This object represents an incoming callback query from a callback button in an inline keyboard.
    /// If the button that originated the query was attached to a message sent by the bot,  the field message will be presented.
    /// If the button was attached to a message sent via the bot (in inline mode), the field inline_message_id will be presented
    /// </summary>
    [DataContract]
    public class CallbackQuery
    {
        /// <summary>
        /// Unique identifier for this query
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        [DataMember(Name = "from")]
        public User From { get; set; }

        /// <summary>
        /// Optional. Message with the callback button that originated the query. Note that message content and message date will not be available if the message is too old
        /// </summary>
        [DataMember(Name = "message")]
        public Message Message { get; set; }

        /// <summary>
        /// Optional. Identifier of the message sent via the bot in inline mode, that originated the query
        /// </summary>
        [DataMember(Name = "inline_message_id")]
        public string InlineMessageId { get; set; }

        /// <summary>
        /// Data associated with the callback button. Be aware that a bad client can send arbitrary data in this field
        /// </summary>
        [DataMember(Name = "data")]
        public string Data { get; set; }
    }
}
