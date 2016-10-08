// Copyright(C) 2015 by Pavel Osadchuk <xakz.pc@gmail.com>

//  This file is part of Xakpc.TelegramBot.Client.

//  Xakpc.TelegramBot.Client is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  Xakpc.TelegramBot.Client is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with Xakpc.TelegramBot.Client. If not, see <http://www.gnu.org/licenses/>.

using System.Runtime.Serialization;

namespace Xakpc.TelegramBot.Model
{
    /// <summary>
    /// This object represents an incoming update.
    /// </summary>
    [DataContract]
    public class Update
    {
        /// <summary>
        /// The update‘s unique identifier. Update identifiers start from a certain positive number and increase sequentially. This ID becomes especially 
        /// handy if you’re using Webhooks, since it allows you to ignore repeated updates or to restore the correct update sequence, should they get out of order.
        /// </summary>
        [DataMember(Name = "update_id")]
        public int UpdateId { get; set; }

        /// <summary>
        /// Optional. New incoming message of any kind — text, photo, sticker, etc.
        /// </summary>
        [DataMember(Name = "message")]
        public Message Message { get; set; }

        /// <summary>
        /// Optional. New version of a message that is known to the bot and was edited
        /// </summary>
        [DataMember(Name = "edited_message")]
        public Message EditedMessage { get; set; }

        /// <summary>
        /// Optional. New incoming inline query
        /// </summary>
        [DataMember(Name = "inline_query")]
        public InlineQuery InlineQuery { get; set; }

        /// <summary>
        /// Optional. The result of an inline query that was chosen by a user and sent to their chat partner.
        /// </summary>
        [DataMember(Name = "chosen_inline_result")]
        public ChosenInlineResult ChosenInlineResult { get; set; }

        /// <summary>
        /// Optional. New incoming callback query
        /// </summary>
        [DataMember(Name = "callback_query")]
        public CallbackQuery CallbackQuery { get; set; }
    }
}