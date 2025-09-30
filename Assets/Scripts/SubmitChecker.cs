using System.Collections;
using TMPro;
using UnityEngine;

public class SubmitChecker : MonoBehaviour
{
    public TMP_InputField answerInputField;
    public GameObject toastCorrect;
    public GameObject toastIncorrect;
    public GameObject noteBook;
    public GameObject dialog;
    public TMP_Text questionText;
    public bool isV2 = false;
    void Start()
    {
        answerInputField.ActivateInputField();
    }
    public void SubmitAnswer()
    {
        string answer = GameData.answer;
        if (answerInputField.text.Trim() == answer)
        {
            toastIncorrect.SetActive(false);
            Debug.Log("Correct Answer!");
            toastIncorrect.SetActive(false);
            toastCorrect.SetActive(true);
            // StartCoroutine(NextChapter());
            GameData.Tools.Add(ToolType.NoteBook);
            GameData.LevelRequiredTools.Add(ToolType.NoteBook);

            if (isV2 && noteBook == null)
            {
                GameData.currentNoteBook.SetActive(false);
            }
            else
            {
                noteBook.SetActive(false);
            }
            dialog.SetActive(false);

            GameData.answer = "";
            answerInputField.text = "";
            questionText.text = "載入中...";
        }
        else
        {
            Debug.Log("Incorrect Answer. Try again!");
            toastCorrect.SetActive(false);
            toastIncorrect.SetActive(true);
            answerInputField.text = "";
            answerInputField.ActivateInputField();
        }
    }

    IEnumerator NextChapter()
    {
        yield return new WaitForSeconds(3f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("NextChScene");
    }
}
