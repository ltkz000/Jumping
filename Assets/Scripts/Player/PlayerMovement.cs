using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Animator anim;
    private float dirX = 0f;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 11f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private AudioSource jumpSoundEffect;

    private enum movementState {idle, run, jump, fall}

    // Update is called once per frame
    private void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal"); 
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded()){
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        movementState state;

        if(dirX > 0f){
            state = movementState.run;
            sprite.flipX = false;
        }else if(dirX < 0f){
            state = movementState.run;
            sprite.flipX = true;
        }else{
            state = movementState.idle;
        }

        if(rb.velocity.y > .1f){
            state = movementState.jump ;
        }else if(rb.velocity.y < -.1f){
            state = movementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
