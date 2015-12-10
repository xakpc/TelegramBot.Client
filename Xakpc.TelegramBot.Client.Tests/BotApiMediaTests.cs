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

using System;
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
            var apiClient = ConstructClient();

            var message = await apiClient.SendPhotoAsync(TestChatId, new InputFile(ImageToByte(Resources.photo), "photo.png"), null, null, null);

            Assert.IsNotNull(message.Photo);
        }

        [Test]
        public async Task SendPhotoAsync_CalledWithFileId_SuccesfullyResent()
        {
            // arrange
            var apiClient = ConstructClient();

            var message = await apiClient.SendPhotoAsync(TestChatId, new InputFile(ImageToByte(Resources.photo), "photo.png"), "send photo", null, null);

            Assert.IsNotNull(message.Photo);

            // act 
            message = await apiClient.SendPhotoAsync(TestChatId, message.Photo.Last().FileId, "resend photo", null, null);

            // assert
            Assert.IsNotNull(message.Photo);
        }

        [Test]
        public async Task SendAudioAsync_Called_SuccesfullySent()
        {
            var apiClient = ConstructClient();

            var message = await apiClient.SendAudioAsync(TestChatId, new InputFile(Resources.audio, "audio.mp3"), 100, "Markus Haist", "Free Software Song", null, null);

            Assert.IsNotNull(message.Audio);
        }

        [Test]
        public async Task SendVoiceAsync_Called_SuccesfullySent()
        {
            var apiClient = ConstructClient();

            var message = await apiClient.SendVoiceAsync(TestChatId, new InputFile(Resources.voice, "voice.ogg"), 100, null, null);

            Assert.IsNotNull(message.Voice);
        }

        [Test]
        public async Task SendVideoAsync_Called_SuccesfullySent()
        {
            var apiClient = ConstructClient();

            var message = await apiClient.SendVideoAsync(TestChatId, new InputFile(Resources.video, "video.mp4"), 572, "Linus Torvalds says GPL v3 violates everything that GPLv2 stood for", null, null);

            Assert.IsNotNull(message.Video);
        }

        [Test]
        public async Task SendAudioAsync_CalledWithFileId_SuccesfullyResent()
        {
            // arrange
            var apiClient = ConstructClient();

            var message = await apiClient.SendAudioAsync(TestChatId, new InputFile(Resources.audio, "audio.mp3"), 100, "Markus Haist", "Free Software Song", null, null);

            Assert.IsNotNull(message.Audio);

            // act
            message = await apiClient.SendAudioAsync(TestChatId, message.Audio.FileId, 100, "Markus Haist", "Free Software Song", null, null);

            Assert.IsNotNull(message.Audio);
        }

        [Test]
        public async Task SendLocationAsync_Called_SuccesfullySent()
        {
            var apiClient = ConstructClient();           

            var message = await apiClient.SendLocationAsync(TestChatId, -14.407778f, -71.3f, null, null);

            Assert.IsNotNull(message.Location);
        }

        [Test]
        public async Task SendAndDownloadPhoto_ReturnsSamePhoto()
        {
            var apiClient = ConstructClient();

            var message = await apiClient.SendPhotoAsync(TestChatId, new InputFile(ImageToByte(Resources.photo), "photo.png"), null, null, null);

            var file = await apiClient.GetFileAsync(message.Photo.Last().FileId);

            Assert.IsNotNullOrEmpty(file.FilePath);

            var actual = await apiClient.DownloadFileAsync(file);

            Assert.AreEqual(file.FileSize, actual.Length);
        }

        private static byte[] ImageToByte(Image img)
        {
            var converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}