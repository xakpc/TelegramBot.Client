using System.Runtime.Serialization;

namespace Xakpc.TelegramBot.Model
{
    /// <summary>
    /// This object represents an incoming inline query
    /// </summary>
    [DataContract]
    public class InlineQuery
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
        /// Optional. Sender location, only for bots that request user location
        /// </summary>
        [DataMember(Name = "location")]
        public Location Location { get; set; }

        /// <summary>
        /// Text of the query (up to 512 characters)
        /// </summary>
        [DataMember(Name = "query")]
        public string Query { get; set; }

        /// <summary>
        /// Offset of the results to be returned, can be controlled by the bot
        /// </summary>
        [DataMember(Name = "offset")]
        public string Offset { get; set; }
    }
}
