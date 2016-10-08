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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xakpc.TelegramBot.Model;
using Xakpc.TelegramBot.Model.Base;

namespace Xakpc.TelegramBot.Client
{
    /// <summary>
    /// Client for HTTP-based interface created for developers keen on building bots for Telegram.
    /// </summary>
    public interface ITelegramBotApiClient
    {
        /// <summary>
        /// A simple method for testing your bot's auth token. Requires no parameters. 
        /// </summary>
        /// <returns>Returns basic information about the bot in form of a User object.</returns>
        Task<User> GetMeAsync();

        /// <summary>
        /// Use this method to receive incoming updates using long polling.
        /// </summary>
        /// <param name="offset">Identifier of the first update to be returned. Must be greater by one than the highest among the identifiers of previously received updates. 
        /// By default, updates starting with the earliest unconfirmed update are returned. 
        /// An update is considered confirmed as soon as getUpdates is called with an offset higher than its update_id.</param>
        /// <param name="limit">Limits the number of updates to be retrieved. Values between 1—100 are accepted. Defaults to 100</param>
        /// <param name="timeout">Timeout in seconds for long polling. Defaults to 0, i.e. usual short polling</param>
        /// <returns>An Array of Update objects is returned.</returns>
        Task<List<Update>> GetUpdatesAsync(int offset = 0, int limit = 100, int timeout = 0);

        /// <summary>
        /// Use this method to get basic info about a file and prepare it for downloading. For the moment, 
        /// bots can download files of up to 20MB in size. On success, a File object is returned. 
        /// The file can then be downloaded via the link https://api.telegram.org/file/bot/<token/>//<file_path/>, 
        /// where /<file_path/> is taken from the response. It is guaranteed that the link will be valid for at least 1 hour. 
        /// When the link expires, a new one can be requested by calling getFile again.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task<File> GetFileAsync(string fileId);

        /// <summary>
        /// Build file download uri to download file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        string GetFileDownloadUri(File file);

        /// <summary>
        /// Download file as byte array
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<byte[]> DownloadFileAsync(File file);

        /// <summary>
        /// Use this method to specify a url and receive incoming updates via an outgoing webhook
        /// </summary>
        /// <param name="url">Optional. HTTPS url to send updates to.</param>
        Task SetWebhookAsync(Uri url);

        /// <summary>
        /// Use this method to specify a url and receive incoming updates via an outgoing webhook
        /// </summary>
        /// <param name="url">Optional. HTTPS url to send updates to.</param>
        /// <param name="certificate">Optional. Upload your public key certificate so that the root certificate in use can be checked</param>
        Task SetWebhookAsync(Uri url, InputFile certificate);

        /// <summary>
        /// Use this method to send empty string to remove webhook integration
        /// </summary>
        Task RemoveWebhookAsync();

        /// <summary>
        /// Use this method to send text messages.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="text">Text of the message to be sent</param>
        /// <returns>On success, the sent Message is returned.</returns>
        Task<Message> SendMessageAsync(int chatId, string text);

        /// <summary>
        /// Use this method to send text messages.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="text">Text of the message to be sent</param>
        /// <param name="disableWebPagePreview">Optional. Disables link previews for links in this message</param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional.	Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        Task<Message> SendMessageAsync(int chatId, string text, bool? disableWebPagePreview, int? replyToMessageId, ReplyMarkup replyMarkup);

        /// <summary>
        /// Use this method to send text messages.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="text">Text of the message to be sent</param>
        /// <param name="parseMode">Send "Markdown", if you want Telegram apps to show bold, italic and inline URLs in your bot's message. For the moment, only Telegram for Android supports this.</param>
        /// <param name="disableWebPagePreview">Optional. Disables link previews for links in this message</param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional.	Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        Task<Message> SendMessageAsync(int chatId, string text, string parseMode, bool? disableWebPagePreview, int? replyToMessageId, ReplyMarkup replyMarkup);

        /// <summary>
        /// Use this method to forward messages of any kind.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="fromChatId">Unique identifier for the chat where the original message was sent — User or GroupChat id</param>
        /// <param name="messageId">Unique message identifier</param>
        /// <returns>On success, the sent Message is returned.</returns>
        Task<Message> ForwardMessageAsync(int chatId, int fromChatId, int messageId);

        /// <summary>
        /// Use this method to send photos.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="photo">Photo to send.</param>
        /// <param name="caption">Photo caption (may also be used when resending photos by file_id).</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        Task<Message> SendPhotoAsync(int chatId, InputFile photo, string caption, int? replyToMessageId,
            ReplyMarkup replyMarkup);

        /// <summary>
        /// Use this method to send photos.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="photo">file_id as string to resend a photo that is already on the Telegram servers</param>
        /// <param name="caption">Optional. Photo caption (may also be used when resending photos by file_id)</param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        Task<Message> SendPhotoAsync(int chatId, string photo, string caption, int? replyToMessageId,
            ReplyMarkup replyMarkup);

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display them in the music player. Your audio must be in the .mp3 format. 
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="audio">Audio file to send. You can either pass a file_id as String to resend an audio that is already on the Telegram servers, or upload a new audio file using multipart/form-data.</param>
        /// <param name="duration">Optional. Duration of the audio in seconds</param>
        /// <param name="performer">Optional. Performer</param>
        /// <param name="title">Optional. Track name</param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        /// <remarks>Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.</remarks>
        Task<Message> SendAudioAsync(int chatId, InputFile audio, int? duration, string performer, string title, int? replyToMessageId, ReplyMarkup replyMarkup);

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display them in the music player. Your audio must be in the .mp3 format. 
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="audio">Audio file to send. You can either pass a file_id as String to resend an audio that is already on the Telegram servers, or upload a new audio file using multipart/form-data.</param>
        /// <param name="duration">Optional. Duration of the audio in seconds</param>
        /// <param name="performer">Optional. Performer</param>
        /// <param name="title">Optional. Track name</param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        /// <remarks>Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.</remarks>
        Task<Message> SendAudioAsync(int chatId, string audio, int? duration, string performer, string title, int? replyToMessageId, ReplyMarkup replyMarkup);

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. 
        /// For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document).  
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="voice">Audio file to send. You can either pass a file_id as String to resend an audio that is already on the Telegram servers, or upload a new audio file using multipart/form-data.</param>
        /// <param name="duration"></param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        /// <remarks>Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.</remarks>
        Task<Message> SendVoiceAsync(int chatId, InputFile voice, int? duration, int? replyToMessageId, ReplyMarkup replyMarkup);

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. 
        /// For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document).  
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="voice">Audio file to send. You can either pass a file_id as String to resend an audio that is already on the Telegram servers, or upload a new audio file using multipart/form-data.</param>
        /// <param name="duration"></param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        /// <remarks>Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.</remarks>
        Task<Message> SendVoiceAsync(int chatId, string voice, int? duration, int? replyToMessageId, ReplyMarkup replyMarkup);

        /// <summary>
        /// Use this method to send general files. 
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="document">File to send. You can either pass a file_id as String to resend a file that is already on the Telegram servers, or upload a new file using multipart/form-data.</param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned. </returns>
        /// <remarks>Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.</remarks>
        Task<Message> SendDocumentAsync(int chatId, InputFile document, int? replyToMessageId, ReplyMarkup replyMarkup);

        /// <summary>
        /// Use this method to send general files. 
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="document">File to send. You can either pass a file_id as String to resend a file that is already on the Telegram servers, or upload a new file using multipart/form-data.</param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned. </returns>
        /// <remarks>Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.</remarks>
        Task<Message> SendDocumentAsync(int chatId, string document, int? replyToMessageId, ReplyMarkup replyMarkup);

        /// <summary>
        /// Use this method to send .webp stickers.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="sticker">Sticker to send. You can either pass a file_id as String to resend a sticker that is already on the Telegram servers, or upload a new sticker using multipart/form-data.</param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        Task<Message> SendStickerAsync(int chatId, InputFile sticker, int? replyToMessageId, ReplyMarkup replyMarkup);
        
        /// <summary>
        /// Use this method to send .webp stickers.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="sticker">Sticker to send. You can either pass a file_id as String to resend a sticker that is already on the Telegram servers, or upload a new sticker using multipart/form-data.</param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        Task<Message> SendStickerAsync(int chatId, string sticker, int? replyToMessageId, ReplyMarkup replyMarkup);

        /// <summary>
        /// Use this method to send video files, Telegram clients support mp4 videos (other formats may be sent as Document). 
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="video">Video to send. You can either pass a file_id as String to resend a video that is already on the Telegram servers, or upload a new video file using multipart/form-data.</param>
        /// <param name="duration"></param>
        /// <param name="caption"></param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        /// <remarks>Bots can currently send video files of up to 50 MB in size, this limit may be changed in the future.</remarks>
        Task<Message> SendVideoAsync(int chatId, InputFile video, int? duration, string caption, int? replyToMessageId, ReplyMarkup replyMarkup);

        /// <summary>
        /// Use this method to send video files, Telegram clients support mp4 videos (other formats may be sent as Document). 
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="video">Video to send. You can either pass a file_id as String to resend a video that is already on the Telegram servers, or upload a new video file using multipart/form-data.</param>
        /// <param name="duration"></param>
        /// <param name="caption"></param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        /// <remarks>Bots can currently send video files of up to 50 MB in size, this limit may be changed in the future.</remarks>
        Task<Message> SendVideoAsync(int chatId, string video, int? duration, string caption, int? replyToMessageId, ReplyMarkup replyMarkup);

        /// <summary>
        /// Use this method to send point on the map.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="latitude">Latitude of location</param>
        /// <param name="longitude">Longitude of location</param>
        /// <param name="replyToMessageId">Optional. If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        Task<Message> SendLocationAsync(int chatId, float latitude, float longitude, int? replyToMessageId, ReplyMarkup replyMarkup);

        /// <summary>
        /// Use this method when you need to tell the user that something is happening on the bot's side. 
        /// The status is set for 5 seconds or less (when a message arrives from your bot, Telegram clients clear its typing status).
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="action">Type of action to broadcast. Choose one, depending on what the user is about to receive: typing for text messages, 
        ///     upload_photo for photos, record_video or upload_video for videos, 
        ///     record_audio or upload_audio for audio files, upload_document for general files, 
        ///     find_location for location data.</param>
        /// <returns></returns>
        /// <remarks>We only recommend using this method when a response from the bot will take a noticeable amount of time to arrive.</remarks>
        Task<bool> SendChatAction(int chatId, string action);

        /// <summary>
        /// Use this method to get a list of profile pictures for a user.
        /// </summary>
        /// <param name="userId">Unique identifier of the target user</param>
        /// <param name="offset">Optional. Sequential number of the first photo to be returned. By default, all photos are returned.</param>
        /// <param name="limit">Optional. Limits the number of photos to be retrieved. Values between 1—100 are accepted. Defaults to 100.</param>
        /// <returns>Returns a UserProfilePhotos object.</returns>
        Task<UserProfilePhotos> GetUserProfilePhotos(int userId, int? offset, int? limit);

        /// <summary>
        /// Use this method to edit text messages sent by the bot or via the bot (for inline bots)
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="messageId">Unique identifier of the sent message. Required if inline_message_id is not specified</param>
        /// <param name="text">New text of the message</param>
        /// <param name="parseMode">Send "Markdown", if you want Telegram apps to show bold, italic and inline URLs in your bot's message. For the moment, only Telegram for Android supports this.</param>
        /// <param name="disableWebPagePreview">Optional. Disables link previews for links in this message</param>
        /// <param name="replyMarkup">Optional. A JSON-serialized object for an inline keyboard</param>
        /// <returns>On success, if edited message is sent by the bot, the edited Message is returned</returns>
        Task<Message> EditMessageTextAsync(int chatId, int messageId, string text, string parseMode = null, bool? disableWebPagePreview = null, InlineKeyboardMarkup replyMarkup = null);

        /// <summary>
        /// Use this method to edit text messages sent by the bot or via the bot (for inline bots)
        /// </summary>
        /// <param name="inlineMessageId">Identifier of the inline message</param>
        /// <param name="text">New text of the message</param>
        /// <param name="parseMode">Send "Markdown", if you want Telegram apps to show bold, italic and inline URLs in your bot's message. For the moment, only Telegram for Android supports this.</param>
        /// <param name="disableWebPagePreview">Optional. Disables link previews for links in this message</param>
        /// <param name="replyMarkup">Optional. A JSON-serialized object for an inline keyboard</param>
        /// <returns>On success, if edited message is sent by the bot, the edited Message is returned</returns>
        Task<Message> EditMessageTextAsync(string inlineMessageId, string text, string parseMode = null, bool? disableWebPagePreview = null, InlineKeyboardMarkup replyMarkup = null);

        /// <summary>
        /// Use this method to edit captions of messages sent by the bot or via the bot (for inline bots)
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="messageId">Unique identifier of the sent message. Required if inline_message_id is not specified</param>
        /// <param name="caption">New caption of the message</param>
        /// <param name="replyMarkup">Optional. A JSON-serialized object for an inline keyboard</param>
        /// <returns>On success, if edited message is sent by the bot, the edited Message is returned</returns>
        Task<Message> EditMessageCaptionAsync(int chatId, int messageId, string caption, InlineKeyboardMarkup replyMarkup = null);

        /// <summary>
        /// Use this method to edit captions of messages sent by the bot or via the bot (for inline bots)
        /// </summary>
        /// <param name="inlineMessageId">Identifier of the inline message</param>
        /// <param name="caption">New caption of the message</param>
        /// <param name="replyMarkup">Optional. A JSON-serialized object for an inline keyboard</param>
        /// <returns>On success, if edited message is sent by the bot, the edited Message is returned</returns>
        Task<Message> EditMessageCaptionAsync(string inlineMessageId, string caption, InlineKeyboardMarkup replyMarkup = null);

        /// <summary>
        /// Use this method to edit only the reply markup of messages sent by the bot or via the bot (for inline bots)
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="messageId">Unique identifier of the sent message. Required if inline_message_id is not specified</param>
        /// <param name="replyMarkup">Optional. A JSON-serialized object for an inline keyboard</param>
        /// <returns>On success, if edited message is sent by the bot, the edited Message is returned</returns>
        Task<Message> EditMessageReplyMarkupAsync(int chatId, int messageId, InlineKeyboardMarkup replyMarkup = null);

        /// <summary>
        /// Use this method to edit only the reply markup of messages sent by the bot or via the bot (for inline bots)
        /// </summary>
        /// <param name="inlineMessageId">Identifier of the inline message</param>
        /// <param name="replyMarkup">Optional. A JSON-serialized object for an inline keyboard</param>
        /// <returns>On success, if edited message is sent by the bot, the edited Message is returned</returns>
        Task<Message> EditMessageReplyMarkupAsync(string inlineMessageId, InlineKeyboardMarkup replyMarkup = null);
    }   
}
