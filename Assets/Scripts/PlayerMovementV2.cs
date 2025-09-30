using UnityEngine;

public class PlayerMovementV2 : MonoBehaviour
{

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.linearVelocityY = 5;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.linearVelocityY = -5;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocityX = -5;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocityX = 5;
        }
        else
        {
            rb.linearVelocity = new Vector2(0, 0);
        }
    }
}
