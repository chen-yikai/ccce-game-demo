using UnityEngine;

public class NoteBookBehavior : MonoBehaviour
{
    public GameObject noteBookDialog;
    public GameObject noteBookToast;
    public GameObject player;
    void Start()
    {
        noteBookDialog.SetActive(false);
    }

    void Update()
    {
        if (noteBookToast.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            noteBookDialog.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape)){
            noteBookDialog.SetActive(false);
        }
    }
}
