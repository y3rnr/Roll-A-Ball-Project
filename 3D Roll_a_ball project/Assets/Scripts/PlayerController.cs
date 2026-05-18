using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private int count;
    private float movementX;
    private float movementZ;
    // Jumping variables
    public float jumpForce = 6f;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementZ = movementVector.y;
    }

    void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isGrounded = false;
        }
    }

    void FixedUpdate() // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementZ); // create a movement vector based on the input
        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision collision) // OnCollisionEnter is called when the Player collides with other ogject
    {
        if (collision.gameObject.CompareTag("Enemy")) // check if the other object has the tag "Enemy"
        {
            Destroy(gameObject); // destroy the player object when it collides with an enemy
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
        if (collision.gameObject.CompareTag("Ground")) // check if the other object has the tag "Ground"
        {
            isGrounded = true; // set isGrounded to true when the player collides with the ground
        }
    }

    void OnTriggerEnter(Collider other) // OnTriggerEnter is called when the Player collides with other ogject
    {
        if (other.gameObject.CompareTag("Pickup")) // check if the other object has the tag "Pickup"
        {
            other.gameObject.SetActive(false); // deactivate the pickup object when the player collides with it
            count = count + 1; // increment the count variable by 1
            SetCountText(); // update the count text on the UI
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!";
            Destroy(GameObject.Find("Enemy")); // destroy the enemy object when the player collects all pickups
        }
    }

}
