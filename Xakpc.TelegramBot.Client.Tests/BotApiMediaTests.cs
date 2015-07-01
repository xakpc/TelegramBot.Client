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

using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Xakpc.TelegramBot.Model;

namespace Xakpc.TelegramBot.Client.Tests
{
    public class BotApiMediaTests : BotApiTests
    {
        [Test]
        public async Task SendPhotoAsync_Called_SuccesfullySent()
        {
            ITelegramBotApiClient apiClient = ConstructClient();

            var incoming = await apiClient.GetUpdatesAsync(timeout: 60); // need some mesage to determine chat
            Assert.That(incoming, Has.Count.AtLeast(1), "need some incoming mesage to determine chat");
            var lastMessage = incoming.Last();

            var message =
                await
                    apiClient.SendPhotoAsync(lastMessage.Message.Chat.Id, new InputFile(ImageToByte(Resources.photo), "photo.png"), null, null, null);

            Assert.IsNotNull(message.Photo);
        }

        [Test]
        public async Task SendPhotoAsync_CalledWithFileId_SuccesfullyResent()
        {
            // arrange
            ITelegramBotApiClient apiClient = ConstructClient();

            var incoming = await apiClient.GetUpdatesAsync(timeout: 60); // need some mesage to determine chat
            Assert.That(incoming, Has.Count.AtLeast(1), "need some incoming mesage to determine chat");
            var lastMessage = incoming.Last();

            var message =
                await
                    apiClient.SendPhotoAsync(lastMessage.Message.Chat.Id, new InputFile(ImageToByte(Resources.photo), "photo.png"), null, null, null);

            Assert.IsNotNull(message.Photo);

            // act
            message =
                await
                    apiClient.SendPhotoAsync(lastMessage.Message.Chat.Id, message.Photo.Last().FileId, "resend photo", null, null);

            // assert
            Assert.IsNotNull(message.Photo);
        }

        [Test]
        public async Task SendAudioAsync_Called_SuccesfullySent()
        {
            ITelegramBotApiClient apiClient = ConstructClient();

            var incoming = await apiClient.GetUpdatesAsync(timeout: 60); // need some mesage to determine chat
            Assert.That(incoming, Has.Count.AtLeast(1), "need some incoming mesage to determine chat");
            var lastMessage = incoming.Last();

            var message =
                await
                    apiClient.SendAudioAsync(lastMessage.Message.Chat.Id, new InputFile(Resources.audio, "audio.ogg"), null, null);

            Assert.IsNotNull(message.Audio);
        }

        [Test]
        public async Task SendAudioAsync_CalledWithFileId_SuccesfullyResent()
        {
            // arrange
            ITelegramBotApiClient apiClient = ConstructClient();

            var incoming = await apiClient.GetUpdatesAsync(timeout: 60); // need some mesage to determine chat
            Assert.That(incoming, Has.Count.AtLeast(1), "need some incoming mesage to determine chat");
            var lastMessage = incoming.Last();

            var message = await apiClient.SendAudioAsync(lastMessage.Message.Chat.Id, new InputFile(Resources.audio, "audio.ogg"), null, null);

            Assert.IsNotNull(message.Audio);

            // act
            message = await apiClient.SendAudioAsync(lastMessage.Message.Chat.Id, message.Audio.FileId, null, null);

            Assert.IsNotNull(message.Audio);
        }

        [Test]
        public async Task SendLocationAsync_Called_SuccesfullySent()
        {
            ITelegramBotApiClient apiClient = ConstructClient();

            var incoming = await apiClient.GetUpdatesAsync(timeout: 60); // need some mesage to determine chat
            Assert.That(incoming, Has.Count.AtLeast(1), "need some incoming mesage to determine chat");
            var lastMessage = incoming.Last();

            var message = await apiClient.SendLocationAsync(lastMessage.Message.Chat.Id, -14.407778f, -71.3f, null, null);

            Assert.IsNotNull(message.Location);
        }

        private static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}