using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour{
  private GameManager gm;
  private float player_health;
  private float slime_health;

  public float leftBoundLimit;
  public float rightBoundLimit;
  public bool moving;
  public bool jumping;
  public float jumpDelay = 3f;
  public float jumpForce = 3f;
  private float speed = 1f;

  private bool isGrounded = true;
  private Rigidbody2D rigidBody;

  // Start is called before the first frame update
  void Start(){
    gm = GameManager.getManager();
    slime_health = 5f;

    rigidBody = GetComponent<Rigidbody2D>();

    InvokeRepeating("animateSlime", 2f, 1f);
  }

  // Update is called once per frame
  void Update(){
    if (slime_health < 0)
      Destroy(gameObject);
    if (moving)
      moveHorizontal();
    if (jumping){
      if(isGrounded){
        jumpTime();
        isGrounded = false;
        StartCoroutine(onTheGround());
      }
    }
  }

  void OnTriggerEnter2D(Collider2D other){
    if (other.tag == "Player"){
      player_health = gm.getHealth();
      player_health -= 1;
      gm.setHealth(player_health);
    }
    else if (other.tag == "Weapon"){
      slime_health -= 2.5f;
    }
  }

  private Vector2 slime_scale;
  private int scaleDirection = 1;
  void animateSlime(){
    slime_scale = new Vector2(transform.localScale.x, transform.localScale.y + (0.035f * scaleDirection));
    scaleDirection = -scaleDirection;

    //transform.localScale = Vector3.Lerp(transform.localScale, slime_scale, 10f * Time.deltaTime);;
    transform.localScale = slime_scale;
  }

  void moveHorizontal(){
    Vector3 pos = transform.position;
    pos.x += speed * Time.deltaTime;
    transform.position = pos;
    // Changing Direction
    if ( pos.x < leftBoundLimit ){
      speed = Mathf.Abs(speed); // Move right
      transform.localScale = new Vector2(transform.localScale.x,transform.localScale.y);
    }
    else if ( pos.x > rightBoundLimit ){
      speed = -Mathf.Abs(speed); // Move left
      transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
      Debug.Log(leftBoundLimit);
    }
  }

  void jumpTime(){
    rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
  }

  public IEnumerator onTheGround(){
    yield return new WaitForSeconds(jumpDelay);
    isGrounded = true;
  }
}
