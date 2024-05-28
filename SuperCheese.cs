using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCheese : Cheese
{
    private static int cheeseCounter = 0;

    // Method to handle picking up the super cheese
    public void Pickup()
    {
        cheeseCounter += 2;
        AudioManager.instance.playOneShot(FmodEvents.instance.cheesePickupSFX, this.transform.position);
        Debug.Log("Cheese Counter: " + cheeseCounter);
        if (cheeseCounter >= 9)
        {
            GameFlow.Instance.GameWin();
        }
    }
}

