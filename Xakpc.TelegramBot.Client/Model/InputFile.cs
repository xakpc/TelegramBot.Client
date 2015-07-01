namespace Xakpc.TelegramBot.Model
{
    public class InputFile
    {
        public string FileName { get; }

        public InputFile(byte[] file, string fileName)
        {
            Data = file;
            FileName = fileName;
        }

        public byte[] Data { get; set; }
    }
}