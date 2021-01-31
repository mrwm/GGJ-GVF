using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour{

  public GameObject player;
  private Vector3 playerPos;

  public GameObject flagRight1;
  public GameObject flagRight2;
  public GameObject flagRight3;
  public GameObject flagRight4;
  private float flagRightPos;

  public GameObject flagLeft1;
  public GameObject flagLeft2;
  public GameObject flagLeft3;
  public GameObject flagLeft4;
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


    // Update the location of the camera according to the player's X-position 
    if(player.transform.localScale.x > 0f)
      playerPos = new Vector3(playerPos.x + offset, transform.position.y, transform.position.z);
    else
      playerPos = new Vector3(playerPos.x - offset, transform.position.y, transform.position.z);

    levelInd = 2;
    switch (levelInd){
      case 1:
        flagLeftPos = player.transform.position.x - flagLeft1.transform.position.x;
        flagRightPos = flagRight1.transform.position.x - player.transform.position.x;
        break;
      case 2:
        flagLeftPos = player.transform.position.x - flagLeft2.transform.position.x;
        flagRightPos = flagRight2.transform.position.x - player.transform.position.x;
        break;
      case 3:
        flagLeftPos = flagLeft3.transform.position.x - player.transform.position.x;
        flagRightPos = flagRight3.transform.position.x - player.transform.position.x;
        break;
      case 4:
        flagLeftPos = player.transform.position.x - flagLeft4.transform.position.x;
        flagRightPos = flagRight4.transform.position.x - player.transform.position.x;
        break;
      default:
        flagLeftPos = player.transform.position.x - flagLeft1.transform.position.x;
        flagRightPos = flagRight1.transform.position.x - player.transform.position.x;
        break;
    }



    // Stop the camera from panning more to the right if player passed the flag
    if(flagLeftPos < horizontalMin)
      transform.position = Vector3.Lerp(transform.position, playerPos, offsetSmooth * Time.deltaTime);
    if(flagRightPos > horizontalMax)
      transform.position = Vector3.Lerp(transform.position, playerPos, offsetSmooth * Time.deltaTime);
  }

  void levelCamera(){
    //
  }

}
