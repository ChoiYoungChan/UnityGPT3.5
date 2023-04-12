using Newtonsoft.Json;

namespace openAI
{
    [JsonObject]
    public class APIRequestData
    {
        public string Model { get; set; }
        public string Prompt { get; set; }
        public int Temperature { get; set; }
        public int MaxTokens { get; set; }
    }


    [JsonObject]
    public class APIResponseData
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public string Model { get; set; }
        public int Created { get; set; }
        public ChoiceData[] Choices { get; set; }
        public UsageData Usage { get; set; }
    }

    [JsonObject]
    public class ChoiceData
    {
        public string Message { get; set; }
        public int Index { get; set; }
        public string MessageLog { get; set; }
        public string FinishReason { get; set; }
    }

    [JsonObject]
    public class UsageData
    {
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
        public int TotalTokens { get; set; }
    }
}