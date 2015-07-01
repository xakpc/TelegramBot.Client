// Copyright(C) 2015 by Pavel Osadchuk <xakz.pc@gmail.com>

//  This file is part of Xakpc.TelegramBot.Client.Tests.

//  Xakpc.TelegramBot.Client.Tests is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  Xakpc.TelegramBot.Client.Tests is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with Xakpc.TelegramBot.Client.Tests. If not, see <http://www.gnu.org/licenses/>.

namespace Xakpc.TelegramBot.Client.Tests
{
    public class BotApiTests
    {
        protected static ITelegramBotApiClient ConstructClient()
        {
            return new TelegramBotApiClient("bot-token");
        }
    }
}