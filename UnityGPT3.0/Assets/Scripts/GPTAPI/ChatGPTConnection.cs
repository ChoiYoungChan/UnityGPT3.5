using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;
using System.Linq;
using Cysharp.Threading.Tasks;

namespace openAI
{
    public class ChatGPTConnection : SingletonClass<ChatGPTConnection>
    {
        const string GPT_API_KEY = "input Key";
        const string API_END_POINT = "https://api.openai.com/v1/completions";

        string answerText = "";
        /// <summary>
        /// send question text data and wait response, return answer json data
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public async UniTask GetAPIResponse(string prompt)
        {
            APIRequestData _requestData = new()
            {
                Prompt = prompt,
                MaxTokens = 300
            };

            string _requestJson = JsonConvert.SerializeObject(_requestData, Formatting.Indented);
            Debug.Log("### " + _requestJson);

            // text data for post
            byte[] _data = System.Text.Encoding.UTF8.GetBytes(_requestJson);


            string _jsonString = null;
            using (UnityWebRequest _request = UnityWebRequest.Post(API_END_POINT, "Post"))
            {
                _request.uploadHandler = new UploadHandlerRaw(_data);
                _request.downloadHandler = new DownloadHandlerBuffer();
                _request.SetRequestHeader("Content-Type", "application/json");
                _request.SetRequestHeader("Authorization", "Bearer " + GPT_API_KEY);
                await _request.SendWebRequest();

                switch(_request.result)
                {
                    case UnityWebRequest.Result.InProgress :
                        Debug.Log("### Processing");
                        break;
                    case UnityWebRequest.Result.Success:
                        Debug.Log("### Success");
                        _jsonString = _request.downloadHandler.text;
                        Debug.Log("### "+ _jsonString);
                        break;
                    case UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.DataProcessingError :
                        Debug.LogError("### Error");
                        throw new Exception();
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            APIResponseData _json = JsonConvert.DeserializeObject<APIResponseData>(_jsonString);
            answerText = _json.Choices[0].Text;
        }

        public string GetAnswerData()
        {
            return answerText;
        }
    }
}
