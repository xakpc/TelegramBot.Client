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

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xakpc.TelegramBot.Model
{
    /// <summary>
    /// This object represents a message.
    /// </summary>
    [DataContract]
    public class Message
    {
        [DataMember(Name = "message_id")]
        public int MessageId { get; set; }

        [DataMember(Name = "from")]
        public User From { get; set; }

        /// <summary>
        /// Date the message was sent in Unix time
        /// </summary>
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "chat")]
        public GroupChat Chat { get; set; }

        [DataMember(Name = "forward_from", IsRequired = false, EmitDefaultValue = true)]
        public User ForwardFrom { get; set; }

        [DataMember(Name = "forward_date", IsRequired = false, EmitDefaultValue = true)]
        public DateTime? ForwardDate { get; set; }

        [DataMember(Name = "reply_to_message", IsRequired = false, EmitDefaultValue = true)]
        public Message ReplyToMessage { get; set; }

        [DataMember(Name = "text", IsRequired = false, EmitDefaultValue = true)]
        public string Text { get; set; }

        [DataMember(Name = "audio", IsRequired = false, EmitDefaultValue = true)]
        public Audio Audio { get; set; }

        [DataMember(Name = "document", IsRequired = false, EmitDefaultValue = true)]
        public Document Document { get; set; }

        [DataMember(Name = "photo", IsRequired = false, EmitDefaultValue = true)]
        public List<PhotoSize> Photo { get; set; }

        [DataMember(Name = "sticker", IsRequired = false, EmitDefaultValue = true)]
        public Sticker Sticker { get; set; }

        [DataMember(Name = "video", IsRequired = false, EmitDefaultValue = true)]
        public Video Video { get; set; }

        [DataMember(Name = "contact", IsRequired = false, EmitDefaultValue = true)]
        public Contact Contact { get; set; }

        [DataMember(Name = "location", IsRequired = false, EmitDefaultValue = true)]
        public Location Location { get; set; }

        [DataMember(Name = "new_chat_participant", IsRequired = false, EmitDefaultValue = true)]
        public User NewChatParticipant { get; set; }

        [DataMember(Name = "left_chat_participant", IsRequired = false, EmitDefaultValue = true)]
        public User LeftChatParticipant { get; set; }

        [DataMember(Name = "new_chat_title", IsRequired = false, EmitDefaultValue = true)]
        public string NewChatTitle { get; set; }

        [DataMember(Name = "new_chat_photo", IsRequired = false, EmitDefaultValue = true)]
        public List<PhotoSize> NewChatPhoto { get; set; }

        [DataMember(Name = "delete_chat_photo", IsRequired = false, EmitDefaultValue = true)]
        public bool? DeleteChatPhoto { get; set; }

        [DataMember(Name = "group_chat_created", IsRequired = false, EmitDefaultValue = true)]
        public bool? GroupChatCreated { get; set; }
    }
}