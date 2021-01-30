using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eCatMove : MonoBehaviour {

  public float speed = 3f;
  public float scale = 0.5f;
  public float leftBoundLimit;
  public float rightBoundLimit;
  public float jumpForce = 3f;
  public float jumpDelay = 5f;
  public bool jumping;

  private Rigidbody2D rigidBody;
  private bool isGrounded = true;

  // Use this for initialization
  void Start () {
    rigidBody = GetComponent<Rigidbody2D>();
  }
  
  // Update is called once per frame
  void Update () {
    if(!jumping){
      Vector3 pos = transform.position;
      pos.x += speed * Time.deltaTime;
      transform.position = pos;
      // Changing Direction
      if ( pos.x < leftBoundLimit ){
        speed = Mathf.Abs(speed); // Move right
        transform.localScale = new Vector2(scale,scale);
      }
      else if ( pos.x > rightBoundLimit ){
        speed = -Mathf.Abs(speed); // Move left
        transform.localScale = new Vector2(-scale,scale);
      }
    }
    else{
      if(isGrounded){
        jumpTime();
        isGrounded = false;
        StartCoroutine(onTheGround());
      }
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
