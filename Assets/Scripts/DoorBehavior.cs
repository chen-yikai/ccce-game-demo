using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehavior : MonoBehaviour
{
    public GameObject allowToLeave;
    public GameObject disallowToLeave;
    public bool isOpen = false;
    bool playerContact = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") playerContact = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") playerContact = false;
    }
    void Update()
    {
        if (playerContact)
        {
            if (!isOpen)
            {
                if (GameData.LevelRequiredTools.Count == GameData.levelRequiredToolsCount[GameData.currentLevel - 1])
                {
                    allowToLeave.SetActive(true);
                    disallowToLeave.SetActive(false);
                }
                else
                {
                    allowToLeave.SetActive(false);
                    disallowToLeave.SetActive(true);
                }
            }
            else
            {
                allowToLeave.SetActive(true);
                disallowToLeave.SetActive(false);
            }
        }
        else
        {
            allowToLeave.SetActive(false);
            disallowToLeave.SetActive(false);
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("GameScene"); // TODO: load last scene
            }
        }
    }
}
