using UnityEngine;
using UnityEngine.SceneManagement;

public class NextChMovement : MonoBehaviour
{
    public GameObject player;
    void Start()
    {

    }
    void Update()
    {
        if (player.transform.position.x < 15f)
        {
            player.transform.position += Vector3.right * Time.deltaTime * 5f;
        }
        else
        {
            GameData.answer = "";
            SceneManager.LoadScene("HomeScene");
        }
    }
}
