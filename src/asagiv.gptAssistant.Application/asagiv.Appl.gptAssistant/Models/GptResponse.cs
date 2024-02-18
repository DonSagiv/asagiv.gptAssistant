using asagiv.Domain.gptAssistant.Interfaces;
using System.Linq;

namespace asagiv.Appl.gptAssistant.Models
{
    public class GptResponse
    {
        #region Properties
        public string Id { get; set; }
        public string ObjectType { get; set; }
        public long Created { get; set; }
        public string Model { get; set; }
        public string SystemFingerprint { get; set; }
        public IGptResponseChoice[] Choices { get; set; }
        public IGptUsage Usage { get; set; }
        #endregion

        #region Methods
        public string[] GetMessageLines()
        {
            return Choices
                .Select(x => x.Payload.Content)
                .ToArray();
        }
        #endregion
    }
}
