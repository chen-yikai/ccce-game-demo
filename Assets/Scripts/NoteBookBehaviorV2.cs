using System.Collections;
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
            GameData.currentNoteBook = gameObject;
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
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F) && gameObject.activeSelf && hintToast.activeSelf)
        {
            hintToast.SetActive(false);
            noteBookDialog.SetActive(true);
        }
    }
}
