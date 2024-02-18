namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptRequestSerializer
    {
        string Serialize(IGptRequest request);
    }
}
