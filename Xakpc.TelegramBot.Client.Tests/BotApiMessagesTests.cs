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

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Xakpc.TelegramBot.Model;

namespace Xakpc.TelegramBot.Client.Tests
{
    [TestFixture]
    public class BotApiMessagesTests : BotApiTests
    {
        [Test]
        public async Task SendMessageAsync_Called_SuccesfullySentMessage()
        {
            ITelegramBotApiClient apiClient = ConstructClient();

            var incoming = await apiClient.GetUpdatesAsync(timeout: 60); // need some incoming mesage to determine chat

            Assert.That(incoming, Has.Count.AtLeast(1), "need some incoming mesage to determine chat");

            var lastMessage = incoming.Last();

            var message =
                await
                    apiClient.SendMessageAsync(lastMessage.Message.Chat.Id, lastMessage.Message.Text, null, null, null);

            Assert.That(message.Text, Is.EqualTo(lastMessage.Message.Text));
        }

        [Test]
        public async Task SendMessageAsync_WithKeyboardHide_SuccesfullyHideKeyboard()
        {
            ITelegramBotApiClient apiClient = ConstructClient();

            var incoming = await apiClient.GetUpdatesAsync(timeout: 60); // need some mesage to determine chat

            Assert.That(incoming, Has.Count.AtLeast(1), "need some incoming mesage to determine chat");

            var lastMessage = incoming.Last();

            var tempKeyboard = new ReplyKeyboardHide() { HideKeyboard = true };

            var message =
                await
                    apiClient.SendMessageAsync(lastMessage.Message.Chat.Id, lastMessage.Message.Text, null, null,
                        tempKeyboard);

            Assert.That(message.Text, Is.EqualTo(lastMessage.Message.Text));
        }

        [Test]
        public async Task SendMessageAsync_WithKeyboardMarkup_SuccesfullySentMessage()
        {
            ITelegramBotApiClient apiClient = ConstructClient();

            var incoming = await apiClient.GetUpdatesAsync(timeout: 60); // need some mesage to determine chat

            Assert.That(incoming, Has.Count.AtLeast(1), "need some incoming mesage to determine chat");

            var lastMessage = incoming.Last();

            var tempKeyboard = new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<string>>
                {
                    new List<string> {"A", "B"},
                    new List<string> {"C", "D"}
                },

                Selective = true
            };

            var message =
                await
                    apiClient.SendMessageAsync(lastMessage.Message.Chat.Id, lastMessage.Message.Text, null, null,
                        tempKeyboard);

            Assert.That(message.Text, Is.EqualTo(lastMessage.Message.Text));
        }

        [Test]
        public async Task ForwardMessageAsync_Called_SuccesfullyForwarded()
        {
            ITelegramBotApiClient apiClient = ConstructClient();

            var incoming = await apiClient.GetUpdatesAsync(timeout: 60); // need some mesage to determine chat

            Assert.That(incoming, Has.Count.AtLeast(1), "need some incoming mesage to determine chat");

            var lastMessage = incoming.Last();

            var message =
                await
                    apiClient.ForwardMessageAsync(lastMessage.Message.Chat.Id, lastMessage.Message.Chat.Id,
                        lastMessage.Message.MessageId);

            Assert.That(message.Text, Is.EqualTo(lastMessage.Message.Text));
        }

    }
}