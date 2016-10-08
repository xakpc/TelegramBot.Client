using System.Threading.Tasks;
using NUnit.Framework;

namespace Xakpc.TelegramBot.Client.Tests
{
    [TestFixture]
    public class BotApiExceptionsTests : BotApiTests
    {
        [Test]
        public void SendMessageAsync_WithMalformedUrl_SuccesfullyRaiseException()
        {
            var apiClient = ConstructClient();
            const string messageText = "[[u'Personal']]";

            Assert.Throws<TelegramApiException>(
                async () => await apiClient.SendMessageAsync(TestChatId, $"{messageText}", "Markdown", null, null, null));
        }

        [Test]
        public void SendMessageAsync_MalformedFormat_SuccesfullyRaiseException()
        {
            var apiClient = ConstructClient();
            const string messageText = "*Personal";

            Assert.Throws<TelegramApiException>(
               async () => await apiClient.SendMessageAsync(TestChatId, $"{messageText}", "Markdown", null, null, null));
        }
    }
}