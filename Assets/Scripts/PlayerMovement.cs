using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float VerticalX;
    public float VerticalY;
    bool touchLeft = false;
    bool touchRight = false;
    bool touchTop = false;
    bool touchBottom = false;
    bool touchNoteBook = false;
    bool touchDoor = false;
    public GameObject noteBookToastObject;
    public GameObject noteBookDialogObject;
    public GameObject ExitToast;
    public GameObject CantExitToast;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "FloorEdgeLeft":
                touchLeft = true;
                break;
            case "FloorEdgeRight":
                touchRight = true;
                break;
            case "FloorEdgeTop":
                touchTop = true;
                break;
            case "FloorEdgeBottom":
                touchBottom = true;
                break;
            case "Door":
                touchDoor = true;
                break;
            case "NoteBookObject":
                touchNoteBook = true;
                break;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "FloorEdgeLeft":
                touchLeft = false;
                break;
            case "FloorEdgeRight":
                touchRight = false;
                break;
            case "FloorEdgeTop":
                touchTop = false;
                break;
            case "FloorEdgeBottom":
                touchBottom = false;
                break;
            case "Door":
                touchDoor = false;
                break;
            case "NoteBookObject":
                touchNoteBook = false;
                break;
        }
    }


    void FixedUpdate()
    {
        // Door interaction
        if (touchDoor)
        {
            if (GameData.LevelRequiredTools.Count == GameData.levelRequiredToolsCount[GameData.currentLevel - 1])
            {
                ExitToast.SetActive(true);
                CantExitToast.SetActive(false);
            }
            else
            {
                CantExitToast.SetActive(true);
                ExitToast.SetActive(false);
            }
        }
        else
        {
            ExitToast.SetActive(false);
            CantExitToast.SetActive(false);
        }
        // NoteBook interaction
        if (touchNoteBook && !noteBookDialogObject.activeSelf)
        {
            noteBookToastObject.SetActive(true);
        }
        else
        {
            noteBookToastObject.SetActive(false);
        }
        if (touchDoor)
        {

        }
        // Player Movement
        if (noteBookDialogObject.activeSelf) return;
        if (touchLeft || touchRight || touchTop || touchBottom)
        {
            rb.linearVelocity = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (touchLeft) return;
            rb.linearVelocityX = -5;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (touchRight) return;
            rb.linearVelocityX = 5;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (touchTop || touchRight) return;
            rb.linearVelocityX = VerticalX;
            rb.linearVelocityY = VerticalY;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (touchBottom) return;
            rb.linearVelocityX = -VerticalX;
            rb.linearVelocityY = -VerticalY;
        }
        else
        {
            rb.linearVelocity = new Vector2(0, 0);
        }
    }
}
