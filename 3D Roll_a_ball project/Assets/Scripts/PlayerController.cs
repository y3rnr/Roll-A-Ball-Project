using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementZ;
    Vector3 startPosition; // variable to store the starting position of the player


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
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

    void FixedUpdate() // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementZ); // create a movement vector based on the input
        rb.AddForce(movement * speed);
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
        }
    }

}
