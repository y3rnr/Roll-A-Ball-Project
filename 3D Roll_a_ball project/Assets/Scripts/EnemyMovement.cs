using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // reference to the player's transform, which we will set in the Unity editor

    public float speed = 1f; // the speed at which the enemy moves towards the player

    void Update() // Update is called once per frame
    {
        Vector3 direction = player.position - transform.position; // creates a vector pointing: enemy -> player

        direction.y = 0f; // we don't want the enemy to move up or down, so we set the y component to 0

        direction.Normalize(); // makes the vector have a length of 1, so it only represents the direction, not the distance

        transform.position += direction * speed * Time.deltaTime; // moves the enemy towards the player at the specified speed, multiplied by Time.deltaTime to move enemy smoothly every frame
    }
}