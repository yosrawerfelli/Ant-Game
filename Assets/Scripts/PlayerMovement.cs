using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    public Rigidbody2D body;
    public float horizontal;
    private bool isFacingRight = true;
    private Animator anim;
    public Dialogue dialogue;

    //the awake method is called whenever the code is loaded 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    //the update method is called each and every frame
    private void Update()
    {
        if(!dialogue.Interact)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }

        Flip();
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
        if (horizontal !=0)
        {
            anim.SetBool ("isWalking", true);

        }
         else {
         anim.SetBool ("isWalking", false);
         }
        
    }
       private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = gameObject.transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
