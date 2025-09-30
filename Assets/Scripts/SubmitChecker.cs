using System.Collections;
using TMPro;
using UnityEngine;

public class SubmitChecker : MonoBehaviour
{
    public TMP_InputField answerInputField;
    public GameObject toastCorrect;
    public GameObject toastIncorrect;
    public GameObject noteBook = GameData.currentNoteBook;
    public GameObject dialog;
    void Start()
    {
        answerInputField.ActivateInputField();
    }
    public void SubmitAnswer()
    {
        string answer = GameData.Answer;
        if (answerInputField.text.Trim() == answer)
        {
            toastIncorrect.SetActive(false);
            Debug.Log("Correct Answer!");
            toastIncorrect.SetActive(false);
            toastCorrect.SetActive(true);
            // StartCoroutine(NextChapter());
            GameData.Tools.Add(ToolType.NoteBook);
            GameData.LevelRequiredTools.Add(ToolType.NoteBook);
            noteBook.SetActive(false);
            dialog.SetActive(false);
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
