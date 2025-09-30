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
        Debug.Log("Player entered area" + collision.tag);
        if (collision.tag == "Player") playerContact = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") playerContact = false;

        if (allowToLeave != null)
        {
            allowToLeave.SetActive(false);
            disallowToLeave.SetActive(false);
        }
    }
    void FixedUpdate()
    {
        if (playerContact)
        {
            if (!isOpen)
            {
                if (GameData.LevelRequiredTools.Count == GameData.levelRequiredToolsCount[GameData.currentLevel - 1])
                {
                    if (allowToLeave != null)
                    {
                        allowToLeave.SetActive(true);
                        disallowToLeave.SetActive(false);
                    }
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        SceneManager.LoadScene("NextChScene");
                    }
                }
                else
                {
                    if (allowToLeave != null)
                    {
                        allowToLeave.SetActive(false);
                        disallowToLeave.SetActive(true);
                    }
                }
            }
            else
            {
                if (allowToLeave != null)
                {
                    allowToLeave.SetActive(true);
                    disallowToLeave.SetActive(false);
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    SceneManager.LoadScene("GameScene"); // TODO: load last scene
                }
            }
        }
    }

}
