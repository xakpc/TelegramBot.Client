using System.Runtime.Serialization;

namespace Xakpc.TelegramBot.Model
{
    [DataContract]
    public class File
    {
        [DataMember(Name = "file_id")]
        public string FileId { get; set; }

        [DataMember(Name = "file_path", IsRequired = false, EmitDefaultValue = true)]
        public int FileSize { get; set; }

        [DataMember(Name = "title", IsRequired = false, EmitDefaultValue = true)]
        public string FilePath { get; set; }
    }
}