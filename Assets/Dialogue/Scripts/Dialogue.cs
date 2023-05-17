using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject _Canvas;
    public GameObject Holder;
    public GameObject Option1, Option2;
    public GameObject _HelpText;
    public GameObject AntHelpText;
    
    public GameObject Player;
    public PlayerMovement movement;
    private float initialSpeed;
    [HideInInspector] public bool Interact;
  

    void Start()
    {
        movement = Player.gameObject.GetComponent<PlayerMovement>();
        initialSpeed = movement.speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            _Canvas.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                _Canvas.SetActive(false);
                Holder.SetActive(true);
                AntHelpText.SetActive(true);

                movement.horizontal = 0;
                Interact = true;
                movement.body.velocity = new Vector2(0, 0);
                movement.speed = 0;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _Canvas.SetActive(false);
            Holder.SetActive(false);
            _HelpText.SetActive(false);
            Option1.SetActive(true);
            Option2.SetActive(true);
        }
    }

    public void Action1()
    {
        Debug.Log("it works");
        Option1.SetActive(false);
        Option2.SetActive(false);
        AntHelpText.SetActive(false);
        _HelpText.SetActive(true);
        movement.speed = initialSpeed;
        Interact = false;
    }

    public void Action2()
    {
        Option1.SetActive(false);
        Option2.SetActive(false);
        AntHelpText.SetActive(false);
        movement.speed = initialSpeed;
        Interact = false;
    }
}
