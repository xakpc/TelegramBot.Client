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

    }
}