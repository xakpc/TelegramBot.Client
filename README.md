#TelegramBot Client
C# client library to consume Telegram Bots api https://core.telegram.org/bots/api

##Usage
Most of usage can be peeked in tests. To make tests work set your bot token in `BotApiTests.cs`
```C#
protected static ITelegramBotApiClient ConstructClient()
{
  return new TelegramBotApiClient("bot-token");
}
```
Usage of API is pretty straightforward
```C#
{
  var apiClient = new TelegramBotApiClient("bot-token");
  var meUser = await apiClient.GetMeAsync();
}
```

##Remarks
This client is one-to-one wrapper around Telegram bot API. It does not provide functional to control update's offset or recieve webhooked updates. 

##License
[![GPLv3](https://www.gnu.org/graphics/gplv3-127x51.png)](https://www.gnu.org/licenses/gpl-3.0.en.html)
