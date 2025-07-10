using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class QuestionHandler : MonoBehaviour
{
    public Button askButton;
    public InputField questionInputField;
    public Text answerText;

    void Start()
    {
        askButton.onClick.AddListener(OnAskButtonClicked);
    }

    void OnAskButtonClicked()
    {
        string userQuestion = questionInputField.text;
        StartCoroutine(PostRequest(userQuestion));
    }

    IEnumerator PostRequest(string query)
    {
        string url = "http://127.0.0.1:5000/generate_answer";
        string json = "{\"query\":\"" + query + "\"}";

        using (UnityWebRequest www = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();

            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                var responseJson = JsonUtility.FromJson<ResponseData>(responseText);
                DisplayAnswer(responseJson.answer);
            }
        }
    }

    void DisplayAnswer(string answer)
    {
        answerText.text = "Answer: " + answer;
    }

    [System.Serializable]
    public class ResponseData
    {
        public string answer;
    }
}
