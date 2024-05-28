using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{

    public int cheeseCounter = 0;

    // Boolean variable to determine if the cheese can be picked up
    public bool canPickupCheese = true;

    // Method to handle collision with other objects
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object can destroy the cheese
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            // Destroy the cheese GameObject
            Destroy(gameObject);
        }
    }
}
