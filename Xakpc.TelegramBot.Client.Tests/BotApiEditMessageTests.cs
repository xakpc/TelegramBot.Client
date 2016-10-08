using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using NUnit.Framework;
using Xakpc.TelegramBot.Model;

namespace Xakpc.TelegramBot.Client.Tests
{
    [TestFixture]
    public class BotApiEditMessageTests : BotApiTests
    {
        [Test]
        public async Task EditMessageTextAsync_Called_SuccessfullyEditedMessageText()
        {
            var apiClient = ConstructClient();
            const string messageText = "SendMessageAsync_Called_SuccesfullySentMessage";

            var message = await apiClient.SendMessageAsync(TestChatId, messageText, null, null, null);

            Assert.That(message.Text, Is.EqualTo(messageText));

            const string newMessageText = "EditMessageTextAsync_Called_SuccessfullyEditedMessageText";
            message = await apiClient.EditMessageTextAsync(TestChatId, message.MessageId, newMessageText);

            Assert.That(message.Text, Is.EqualTo(newMessageText));
        }

        [Test]
        public async Task EditMessageTextAsync_WithInlineKeyboardMarkup_SuccessfullyEditedMessage()
        {
            var apiClient = ConstructClient();
            const string messageText = "SendMessageAsync_WithInlineKeyboardMarkup_SuccessfullySentMessage";
            var tempKeyboard = new InlineKeyboardMarkup
            {
                InlineKeyboard = new List<List<InlineKeyboardButton>>
                {
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton { Text = "A", Url = "https://telegram.org/" },
                        new InlineKeyboardButton { Text = "B", Url = "https://telegram.org/" }
                    },
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton { Text = "C", CallbackData = "callback1" },
                        new InlineKeyboardButton { Text = "D", CallbackData = "callback2" }
                    }
                }
            };

            var message = await apiClient.SendMessageAsync(TestChatId, messageText, null, null, tempKeyboard);

            Assert.That(message.Text, Is.EqualTo(messageText));

            const string newMessageText = "EditMessageTextAsync_WithInlineKeyboardMarkup_SuccessfullyEditedMessage";
            tempKeyboard = new InlineKeyboardMarkup
            {
                InlineKeyboard = new List<List<InlineKeyboardButton>>
                {
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton { Text = "E", Url = "https://telegram.org/" },
                        new InlineKeyboardButton { Text = "F", Url = "https://telegram.org/" }
                    },
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton { Text = "G", CallbackData = "callback1" },
                        new InlineKeyboardButton { Text = "H", CallbackData = "callback2" }
                    }
                }
            };

            message = await apiClient.EditMessageTextAsync(TestChatId, message.MessageId, newMessageText, replyMarkup: tempKeyboard);

            Assert.That(message.Text, Is.EqualTo(newMessageText));
        }

        [Test]
        public async Task EditMessageCaptionAsync_Called_SuccessfullyEditedMessageCaption()
        {
            var apiClient = ConstructClient();

            const string caption = "caption";
            var message = await apiClient.SendPhotoAsync(TestChatId, new InputFile(ImageToByte(Resources.photo), "photo.png"), caption, null, null);

            Assert.That(message.Caption, Is.EqualTo(caption));

            const string newCaption = "new caption";
            message = await apiClient.EditMessageCaptionAsync(TestChatId, message.MessageId, newCaption);

            Assert.That(message.Caption, Is.EqualTo(newCaption));
        }

        [Test]
        public async Task EditMessageReplyMarkupAsync_WithoutReplyMarkup_SuccessfullyEditedMessage()
        {
            var apiClient = ConstructClient();
            const string messageText = "EditMessageReplyMarkupAsync_Called_SuccessfullyEditedMessage";
            var tempKeyboard = new InlineKeyboardMarkup
            {
                InlineKeyboard = new List<List<InlineKeyboardButton>>
                {
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton { Text = "A", Url = "https://telegram.org/" },
                        new InlineKeyboardButton { Text = "B", Url = "https://telegram.org/" }
                    },
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton { Text = "C", CallbackData = "callback1" },
                        new InlineKeyboardButton { Text = "D", CallbackData = "callback2" }
                    }
                }
            };

            var message = await apiClient.SendMessageAsync(TestChatId, messageText, null, null, tempKeyboard);

            Assert.That(message.Text, Is.EqualTo(messageText));

            message = await apiClient.EditMessageReplyMarkupAsync(TestChatId, message.MessageId);

            Assert.That(message.Text, Is.EqualTo(messageText));
        }

        [Test]
        public async Task EditMessageReplyMarkupAsync_WithNewReplyMarkup_SuccessfullyEditedMessage()
        {
            var apiClient = ConstructClient();
            const string messageText = "EditMessageReplyMarkupAsync_Called_SuccessfullyEditedMessage";
            var tempKeyboard = new InlineKeyboardMarkup
            {
                InlineKeyboard = new List<List<InlineKeyboardButton>>
                {
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton { Text = "A", Url = "https://telegram.org/" },
                        new InlineKeyboardButton { Text = "B", Url = "https://telegram.org/" }
                    },
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton { Text = "C", CallbackData = "callback1" },
                        new InlineKeyboardButton { Text = "D", CallbackData = "callback2" }
                    }
                }
            };

            var message = await apiClient.SendMessageAsync(TestChatId, messageText, null, null, tempKeyboard);

            Assert.That(message.Text, Is.EqualTo(messageText));

            tempKeyboard = new InlineKeyboardMarkup
            {
                InlineKeyboard = new List<List<InlineKeyboardButton>>
                {
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton { Text = "E", Url = "https://telegram.org/" },
                        new InlineKeyboardButton { Text = "F", Url = "https://telegram.org/" }
                    },
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton { Text = "G", CallbackData = "callback1" },
                        new InlineKeyboardButton { Text = "H", CallbackData = "callback2" }
                    }
                }
            };

            message = await apiClient.EditMessageReplyMarkupAsync(TestChatId, message.MessageId, tempKeyboard);

            Assert.That(message.Text, Is.EqualTo(messageText));
        }

        private static byte[] ImageToByte(Image img)
        {
            var converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
