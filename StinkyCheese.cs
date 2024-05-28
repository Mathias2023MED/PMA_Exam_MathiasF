using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StinkyCheese : Cheese
{
    // Variables for stinky cheese behavior
    public static PickupCheese Instance = null;
    private float acclAmount;
    [SerializeField] float shakeAmount = 0.3f;
    [SerializeField] float fallSpeed = 0f;

    private bool isStinkyCheese = true;


    CheeseMeter _cheeseMeter;


    private void Update()
    {
        acclAmount = Mathf.Abs(Input.acceleration.y);
        if (isStinkyCheese)
        {
            if (acclAmount > shakeAmount)
            {
                Debug.Log("Stinky cheese accelerometer");
                isStinkyCheese = false;
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                this.gameObject.GetComponent<PlayerMovement>().enabled = true;
            }
        }
    }

    private void StopMovement()
    {
        if (isStinkyCheese)
        {
            if (PlayerVFX.Instance.IsPlayerDead() != true)
            {
                AudioManager.instance.playOneShot(FmodEvents.instance.badCheese, this.transform.position);
            }
            Debug.Log("Stinky cheese running");
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.gameObject.GetComponent<PlayerMovement>().enabled = false;
            fallSpeed = -2f;
            transform.position = new Vector3(transform.position.x, transform.position.y + fallSpeed * Time.deltaTime, transform.position.z);
            Physics.IgnoreLayerCollision(0, 1);
            Debug.Log("Stinky Accl: " + Input.acceleration.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopMovement();
        }
    }
}



