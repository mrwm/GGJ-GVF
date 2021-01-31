using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour{

  public float speed = 5f;
  public float jumpSpeed = 5f;
  private float movement = 0f;
  private Rigidbody2D rigidBody;
  public Transform groundCheckPoint;
  public float groundCheckRadius;
  public LayerMask groundLayer;
  private bool isTouchGround;
  private Animator playerAnimation;
  private AudioSource audioSrc;
  public AudioClip footsteps;
  public AudioClip jump;
  private Vector2 spriteScale;
  private bool doubleJump;

  // Start is called before the first frame update
  void Start(){
    rigidBody = GetComponent<Rigidbody2D>();
    spriteScale = transform.localScale;
    doubleJump = true;
    playerAnimation = GetComponent<Animator>();
    audioSrc = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update(){
    isTouchGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

    movement = Input.GetAxis("Horizontal");
    // Player movement Logic
    if (movement != 0f){
      if(!audioSrc.isPlaying){
        audioSrc.PlayOneShot(footsteps);
      }
      rigidBody.velocity = new Vector2(movement*speed, rigidBody.velocity.y);
        if (movement > 0f)
          transform.localScale = new Vector2(spriteScale.x,spriteScale.y);
        else
          transform.localScale = new Vector2(-spriteScale.x,spriteScale.y);
    }

    if(Input.GetButtonDown("Jump")){
      audioSrc.PlayOneShot(jump);
      if (doubleJump && !isTouchGround){
        rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed);
        doubleJump = false;
      }
      else if (isTouchGround){
        rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed);
        doubleJump = true;
      }
    }

    playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
    playerAnimation.SetBool("OnGround", isTouchGround);
  }
}
