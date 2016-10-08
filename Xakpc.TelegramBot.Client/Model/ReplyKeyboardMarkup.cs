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

using System.Collections.Generic;
using System.Runtime.Serialization;
using Xakpc.TelegramBot.Model.Base;

namespace Xakpc.TelegramBot.Model
{   
    [DataContract]
    public class ReplyKeyboardMarkup : ReplyMarkup
    {
        [DataMember(Name = "keyboard")]
        public IEnumerable<IEnumerable<string>> Keyboard { get; set; }

        [DataMember(Name = "resize_keyboard", IsRequired = false, EmitDefaultValue = false)]
        public bool? ResizeKeyboard { get; set; }

        [DataMember(Name = "one_time_keyboard", IsRequired = false, EmitDefaultValue = false)]
        public bool? OneTimeKeyboard { get; set; }

        /// <summary>
        /// Optional. Use this parameter if you want to force reply from specific users only. Targets: 
        /// 1) users that are @mentioned in the text of the Message object; 
        /// 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.
        /// </summary>
        [DataMember(Name = "selective", IsRequired = false, EmitDefaultValue = false)]
        public bool? Selective { get; set; }
    }
}