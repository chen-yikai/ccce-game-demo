using UnityEngine;

public class NoteBookBehaviorV2 : MonoBehaviour
{
    public GameObject hintToast;
    public GameObject noteBookDialog;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hintToast.SetActive(true);
            GameData.currentNoteBook = this.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hintToast.SetActive(false);
            GameData.currentNoteBook = null;
        }
    }

    void Update()
    {
        if (hintToast.activeSelf && Input.GetKeyDown(KeyCode.F) && GameData.currentNoteBook == gameObject)
        {
            hintToast.SetActive(false);
            noteBookDialog.SetActive(true);
        } else {

        }
    }
}
