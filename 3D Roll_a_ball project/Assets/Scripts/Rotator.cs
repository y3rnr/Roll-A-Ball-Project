using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update() // Update is called once per frame, and is where we put code that needs to run continuously, such as checking for input or moving objects.
    {
        transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
    }
}