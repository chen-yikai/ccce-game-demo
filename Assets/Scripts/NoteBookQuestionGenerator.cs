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

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
    void OnEnable()
    {
        if (string.IsNullOrEmpty(GameData.answer))
            StartCoroutine(GetQuestion());
    }

    string endPoint = "https://ccce-game-backend.eliaschen.dev/generate/question";
    IEnumerator GetQuestion()
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
                GameData.answer = answer;
            }
        }
    }
}
