using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class GoodCheese : Cheese
{

    // Method to handle picking up the good cheese
    void Pickup()
    {
        cheeseCounter++;
        AudioManager.instance.playOneShot(FmodEvents.instance.cheesePickupSFX, this.transform.position);
        Debug.Log("Cheese Counter: " + cheeseCounter);
        if (cheeseCounter >= 9)
        {
            GameFlow.Instance.GameWin();
        }
    }
}





