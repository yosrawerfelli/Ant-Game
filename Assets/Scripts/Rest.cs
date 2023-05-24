using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : MonoBehaviour
{
    [SerializeField] private GameObject player;
    AntEnergy energy;
    //PlayerMovement movement;
    private float initialSpeed;
    public GameObject text;

    
    void Start()
    {
        energy = player.GetComponent<AntEnergy>();
        //initialSpeed = movement.speed;
    }

    /*private void Update() 
    {
        if (energy.t >=1)
        {
            movement.speed = initialSpeed;
        }
    }*/


     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //movement.speed = 0;
            text.SetActive(true);
        }
    }
       void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            energy.t += (0.3f * Time.deltaTime);
            /*if (energy.t >=1)
            {
                movement.speed = initialSpeed;
            }*/
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
        }
    }

}
