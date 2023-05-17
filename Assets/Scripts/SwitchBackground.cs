using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBackground : MonoBehaviour
{
    public GameObject background;
    private bool inZone = false;
    public PlayerMovement movement;

    private void OnTriggerEnter2D(Collider2D other) 
    {
         if (other.CompareTag("Player"))
        {
            //Debug.Log("enter");
            inZone = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
          if (other.CompareTag("Player"))
        {
            //Debug.Log("exist");
            inZone = false; 
        }
    }

   

    private void Update() {
        if (inZone && movement.horizontal > 0f)
        {
            background.SetActive(false);
        }
        if (inZone && movement.horizontal < 0f)
        {
            background.SetActive(true);
        }
    }
}
