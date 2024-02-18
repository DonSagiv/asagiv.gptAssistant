namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptRequestBuilder
    {
        IGptRequestBuilder WithModel(string model);
        IGptRequestBuilder WithSystemMessage(string systemContent);
        IGptRequestBuilder WithUserMessage(string userContent);
        IGptRequestBuilder UseStream();
        IGptRequest Build();
    }
}
