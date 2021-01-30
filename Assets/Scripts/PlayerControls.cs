using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour {

  // Variables

  // Character variables
  public float speed = 5f;
  public float jumpSpeed = 3f;
  private float movementX = 0f;
  private float movementY = 0f;
  private Rigidbody2D rigidBody;
  private float knockback = 75f;
  private bool hasKey = false;

  private GameObject redBox; // used for the "where am i" thingy

  // These variables check if the player is on the ground
  public Transform groundCheckPoint;
  public float groundCheckRadius;
  public LayerMask groundLayer;
  private bool isTouchingGround;
  private bool isHurt;
  private float hurtTime = 1f;

  // Changes how the player looks
  private Animator playerAnimation;

  // Moves the player according to what they touch
  public Vector3 teleportTo;
  private float teleportDelta = 1;

  // These variables control how to camera moves
  private Camera cam;
  public float cameraSmoothing = 1f;
  public float transitionDelay = 0f;

  private float deltaX = 0;
  private float deltaY = 0;
  private float screenHeight; // = Camera.main.orthographicSize * 2.0f;
  private float screenWidth; // = screenHeight * Screen.width / Screen.height;

  private float screenDrift = 1f;

  // Mention the level manager script
  public LevelManager gameLevelManager;

  // Prepare the popup messages
  public GameObject endPanel;
  public GameObject deadEndPanel;
  public GameObject hpHit;

  // Use this for initialization
  void Start () {
    // Find screen dimensions
    screenHeight = Camera.main.orthographicSize * 2.0f;
    screenWidth = screenHeight * Screen.width / Screen.height;

    // Make the player physics available in code
    rigidBody = GetComponent<Rigidbody2D>();

    // Setup the animator
    playerAnimation = GetComponent<Animator>();

    // Prep the camera
    cam = Camera.main;
    //Debug.Log("W: "+screenWidth+" H: "+screenHeight);

    // Load the level manager and hide popups
    gameLevelManager = FindObjectOfType<LevelManager>();

    // hide end panels
    endPanel.SetActive (false);
    deadEndPanel.SetActive (false);

    // hide damage popup
    hpHit.SetActive (false);

    // starting off not hurting
    isHurt = false;

  }

  // Update is called once per frame
  void Update () {
    // Ground check
    isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position,groundCheckRadius,groundLayer);

    // Grab keyboard codes at Edit > Proj.Settings > Input > Axis @ side bar
    movementX = Input.GetAxis("Horizontal");
    if(movementX > 0f){
      rigidBody.velocity = new Vector2(movementX * speed, rigidBody.velocity.y);
      transform.localScale = new Vector2(1f,1f);
    }
    else if (movementX < 0f) {
      rigidBody.velocity = new Vector2(movementX * speed, rigidBody.velocity.y);
      transform.localScale = new Vector2(-1f,1f);
    }
    else {
      rigidBody.velocity = new Vector2(0,rigidBody.velocity.y);
    }
    // Y-Axis
    movementY = Input.GetAxis("Vertical");
    if(movementY > 0f){
      rigidBody.velocity = new Vector2(rigidBody.velocity.x, movementY * speed);
    }
    // helicopter-like properties
    //else if (movementY < 0f) {
    //  rigidBody.velocity = new Vector2(rigidBody.velocity.x, movementY * speed);
    //}
    //else {
    //  rigidBody.velocity = new Vector2(rigidBody.velocity.x,0);
    //}

    // Fly upon jumping
    if(Input.GetButtonDown("Jump")){
      gameLevelManager.dropDaFood();
      //rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed); // space to flap
    }

    // Change the animation based on conditions
    playerAnimation.SetFloat("Speed",Mathf.Abs(rigidBody.velocity.x));
    playerAnimation.SetBool("onGround",isTouchingGround);
    playerAnimation.SetBool("isHurt",isHurt);
  }

//  void OnGUI(){
//    //GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "This is a box");
//    Texture2D texture = new Texture2D(1, 1);
//    texture.SetPixel(0,0,Color.red);
//    texture.Apply();
//    GUI.skin.box.normal.background = texture;
//    GUI.Box(new Rect(0, 0, Screen.width, Screen.height), GUIContent.none);
//  }

  public IEnumerator hurtAnimate(){
    hpHit.SetActive(true);
    isHurt = true;
    yield return new WaitForSeconds(hurtTime);
    hpHit.SetActive(false);
    isHurt = false;
  }

  // Scene change after delay
  public IEnumerator sceneChange(float time){
    // Move the player out of the way
    transform.position = teleportTo;

    // Pause
    yield return new WaitForSeconds(time);

    // Setup the new camera position
    Vector3 camPosition = new Vector3(deltaX,deltaY,cam.transform.position.z);
    camPosition = new Vector3(cam.transform.position.x + camPosition.x,cam.transform.position.y + camPosition.y,cam.transform.position.z);

    // Move the camera to the new position
    float t = 0;
    while (t < cameraSmoothing){
      cam.transform.position = Vector3.Lerp(cam.transform.position,camPosition,(t*cameraSmoothing));
      t += Time.deltaTime;
      yield return new WaitForEndOfFrame();
      //yield return null;
    }
    gameLevelManager.showTheFood();
  }

  void OnTriggerEnter2D(Collider2D other){

    if(other.name == "Bottom"){
      deadEndPanel.SetActive(true);
      StartCoroutine(gameLevelManager.endSCREEN());
    }
    /*****************************************************
      The section below take care of the camera movement
    ******************************************************/
    Vector3 curPos = transform.position;
    if(other.tag == "EdgeTop"){ // screen:🡅
      deltaX = 0;
      deltaY = screenHeight;
      teleportTo = new Vector3(curPos.x,curPos.y + teleportDelta,curPos.z);
      StartCoroutine(sceneChange(transitionDelay));
    }
    else if(other.tag == "EdgeBottom"){ // screen:🡇
      deltaX = 0;
      deltaY = -screenHeight;
      teleportTo = new Vector3(curPos.x,curPos.y - teleportDelta,curPos.z);
      StartCoroutine(sceneChange(transitionDelay));
    }
    else if(other.tag == "EdgeRight"){ // screen:🡆
      screenDrift += 0.05f;
      deltaX = screenWidth + 0.1f * screenDrift;
      deltaY = 0;
      teleportTo = new Vector3(curPos.x + teleportDelta,curPos.y,curPos.z);
      StartCoroutine(sceneChange(transitionDelay));
    }
    else if(other.tag == "EdgeLeft"){ // screen:🡄
      screenDrift -= 0.09f;
      deltaX = -screenWidth - 0.1f * screenDrift;
      deltaY = 0;
      teleportTo = new Vector3(curPos.x - teleportDelta,curPos.y,curPos.z);
      StartCoroutine(sceneChange(transitionDelay));
    }
    /**********************
     End of messy section
    ***********************/
  }

  void OnCollisionEnter2D(Collision2D collisionInfo){

    // Get collider info
    Collider2D collided = collisionInfo.collider;
    Vector3 contactPoint = collisionInfo.contacts[0].point;
    Vector3 center = collided.bounds.center;

    bool right = contactPoint.x > center.x;
    //bool top = contactPoint.y > center.y;
    if((collisionInfo.gameObject.tag == "Key") && !hasKey ){
      hasKey = true;
      Destroy(collisionInfo.gameObject);
    }
    if((collisionInfo.gameObject.tag == "Door") && hasKey ){
      Destroy(collisionInfo.gameObject);
      hasKey = false;
    }

    if(collisionInfo.gameObject.tag == "Enemy"){
      gameLevelManager.hit();
      if (right){
        rigidBody.AddForce(transform.right * knockback);
      }
      else if (!right){
        rigidBody.AddForce(transform.right * -knockback);
      }
      /* Code used for virtical feedback
      else if (top){
        Debug.Log("UP");
        rigidBody.AddForce(transform.up * knockback);
      }
      else if (!top){
        Debug.Log("DOWN");
        rigidBody.AddForce(transform.up * -knockback);
      }
      */

      // Change the animation to the blinking one
      StartCoroutine(hurtAnimate());
    }
  }
}
