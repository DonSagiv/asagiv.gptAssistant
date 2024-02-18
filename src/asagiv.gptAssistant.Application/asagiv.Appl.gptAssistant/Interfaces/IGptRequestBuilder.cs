using asagiv.Appl.gptAssistant.Models;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptRequestBuilder
    {
        IGptRequestBuilder WithModel(string model);
        IGptRequestBuilder WithSystemMessage(string systemContent);
        IGptRequestBuilder WithUserMessage(string userContent);
        IGptRequestBuilder UseStream();
        GptRequest Build();
    }
}
