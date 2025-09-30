using System.Collections;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class NoteBookQuestionGenerator : MonoBehaviour
{
    public TMP_Text questionText;
    void OnEnable()
    {
        if (string.IsNullOrEmpty(GameData.Answer))
            StartCoroutine(PostRequest());
    }

    string endPoint = "https://ccce-game-backend.eliaschen.dev/generate/question";
    IEnumerator PostRequest()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(endPoint))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                string rawJson = request.downloadHandler.text;
                JObject questionObj = JObject.Parse(rawJson);
                string question = (string)questionObj["question"];
                string answer = (string)questionObj["answer"];
                Debug.Log("Response: " + question + ", " + answer);
                questionText.text = question;
                GameData.Answer = answer;
            }
        }
    }
}
