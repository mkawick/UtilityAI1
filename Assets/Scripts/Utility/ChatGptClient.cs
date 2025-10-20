using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System; // You can install this via NuGet or Unity Package Manager

public class ChatGPTClient : MonoBehaviour
{
    private static readonly string apiUrl = "https://api.openai.com/v1/chat/completions";

    public TMPro.TMP_Text textInput;
    public TMPro.TMP_Text textOutput;
    [SerializeField] private string apiKey;

    private void Awake()
    {
        ReadString();
    }

    public void ReadString()
    {
        
        string path = Application.dataPath + "/Data/ChatKey.bmp";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        apiKey = reader.ReadToEnd();
        apiKey = apiKey.Replace("BMkey:", "");
        apiKey = Reverse(apiKey);
        reader.Close();
        Debug.Log(apiKey);
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public void Send()
    {
        if(textInput != null && textOutput.text.Length > 0)
        {
            string message = textInput.text;
            //var result = await SendChatMessage(message);
            AsyncPassThru(message);
        }
    }

    private async void AsyncPassThru(string message)
    {
        var result = await SendChatMessage(message);
        if (textOutput != null)
        {
            textOutput.SetText(result);
        }
    }

    // ?? DO NOT hardcode your key in production!
    // Use environment variables, secure storage, or Unity's encrypted player prefs.

    public async Task<string> SendChatMessage(string message)
    {
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var requestData = new
            {
                model = "gpt-4o-mini", // or "gpt-4o", "gpt-3.5-turbo"
                messages = new[]
                {
                    new { role = "user", content = message }
                }
            };

            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiUrl, content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Debug.LogError($"Error: {response.StatusCode}\n{responseString}");
                return null;
            }

            // Parse the response JSON
            var result = JsonConvert.DeserializeObject<ChatGPTResponse>(responseString);
            return result.choices[0].message.content;
        }
    }
}

// Data models for JSON parsing
[System.Serializable]
public class ChatGPTResponse
{
    public List<Choice> choices;
}

[System.Serializable]
public class Choice
{
    public Message message;
}

[System.Serializable]
public class Message
{
    public string role;
    public string content;
}
