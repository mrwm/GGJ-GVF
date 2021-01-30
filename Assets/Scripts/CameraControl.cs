using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour{

  public GameObject player;
  private Vector3 playerPos;

  private GameObject flagRight;
  private float flagRightPos;

  private GameObject flagLeft;
  private float flagLeftPos;

  private float offset;
  private float offsetSmooth;
  private float offsetChange;

  private Camera camera;
  float halfHeight;
  float halfWidth;
  float horizontalMin;
  float horizontalMax;

  private int levelInd;
  private GameManager gm;

  // Start is called before the first frame update
  void Start(){
    gm = GameManager.getManager();
    levelInd = gm.getLevel();

    // locate flag according to level index. This will set camera limits
    string leftF = "left-"+levelInd;
    string rightF = "right-"+levelInd;
    //flagLeft = GameObject.Find("Flag");
    //flagRight = GameObject.Find(/LevelFlags/rightF);
    Debug.Log("LEFT: "+leftF);





    // Get camera dimensions
    camera = Camera.main;
    halfHeight = camera.orthographicSize;
    halfWidth = camera.aspect * halfHeight;

    // Get the min and max of camera dimensions
    horizontalMin = -halfWidth;
    horizontalMax =  halfWidth;

    // Makes the player not in the center of the camera
    offset = horizontalMax/2 - (player.transform.localScale.x*2);
    offsetSmooth = offset; // + player.GetComponent<PlayerControler>().speed;
  }

  // Update is called once per frame
  void Update(){
    // Get the player's X-position
    playerPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

    //flagLeftPos = flagLeft.transform.position.x - player.transform.position.x;
    //flagRightPos = flagRight.transform.position.x - player.transform.position.x;

    // Update the location of the camera according to the player's X-position 
    if(player.transform.localScale.x > 0f)
      playerPos = new Vector3(playerPos.x + offset, transform.position.y, transform.position.z);
    else
      playerPos = new Vector3(playerPos.x - offset, transform.position.y, transform.position.z);

    // Stop the camera from panning more to the right if player passed the flag
    //if(flagLeftPos < horizontalMin)
      transform.position = Vector3.Lerp(transform.position, playerPos, offsetSmooth * Time.deltaTime);
    //if(flagRightPos > horizontalMax)
    //  transform.position = Vector3.Lerp(transform.position, playerPos, offsetSmooth * Time.deltaTime);
  }

  void levelCamera(){
    //
  }

}
