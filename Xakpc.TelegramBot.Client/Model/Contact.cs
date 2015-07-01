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
    [DataContract(Name = "Contact")]
    public class Contact
    {
        [DataMember(Name = "phone_number")]
        public string PhoneNumber { get; set; }

        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "last_name", IsRequired = false, EmitDefaultValue = true)]
        public string LastName { get; set; }

        [DataMember(Name = "user_id", IsRequired = false, EmitDefaultValue = true)]
        public string UserId { get; set; }
    }
}