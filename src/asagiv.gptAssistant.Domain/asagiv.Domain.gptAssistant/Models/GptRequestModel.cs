using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Domain.gptAssistant.Models;

internal record GptRequestModel(string RequestString,
        string RequestProcessorName) 
    : IGptRequestModel;
