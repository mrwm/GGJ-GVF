using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour{

  public GameObject player;
  private Vector3 playerPos;

  public GameObject flag;
  private float flagPos;

  private float offset;
  private float offsetSmooth;
  private float offsetChange;

  private Camera camera;
  float halfHeight;
  float halfWidth;
  //float horizontalMin;
  float horizontalMax;

  // Start is called before the first frame update
  void Start(){

    // Get camera dimensions
    camera = Camera.main;
    halfHeight = camera.orthographicSize;
    halfWidth = camera.aspect * halfHeight;

    // Get the min and max of camera dimensions
    //horizontalMin = -halfWidth;
    horizontalMax =  halfWidth;

    // Makes the player not in the center of the camera
    offset = horizontalMax/2 - (player.transform.localScale.x*2);
    offsetSmooth = offset;
  }

  // Update is called once per frame
  void Update(){
    // Get the player's X-position
    playerPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

    // Get the flag position relative to the player:
    // this is assuming that the flag is always on the right.
    flagPos = flag.transform.position.x - player.transform.position.x;

    // Update the location of the camera according to the player's X-position 
    if(player.transform.localScale.x > 0f)
      playerPos = new Vector3(playerPos.x + offset, transform.position.y, transform.position.z);
    else
      playerPos = new Vector3(playerPos.x - offset, transform.position.y, transform.position.z);

    // Stop the camera from panning more to the right if player passed the flag
    if(flagPos > horizontalMax)
      transform.position = Vector3.Lerp(transform.position, playerPos, offsetSmooth * Time.deltaTime);
  }

  void levelCamera(){
    //
  }

}
